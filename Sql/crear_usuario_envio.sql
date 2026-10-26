/*
  Crea (o actualiza) el usuario 'envio' en iWeb para el iFinan anterior.
  Es la cuenta con la que iComercio hace TODOS los envios (altas, cobranzas, control diario, archivos, etc.).

  - La clave NO figura aqui: solo su hash en el formato legacy (Base64(SHA512(UTF8(clave + salt)))),
    el mismo que valida UsuarioService.ValidarUsuario. Se puede ejecutar mas de una vez (es idempotente).
  - El usuario queda con el perfil 'Envio' y el permiso 'Envio'. El iFinan anterior protege los controladores
    de envio solo con [Authorize] (usuario valido), sin chequear roles, asi que el permiso es descriptivo:
    deja el usuario identificado y listo por si algun dia se agregan restricciones por rol.
  - IMPORTANTE: no iniciar sesion con 'envio' en iFinan.Web ni en el API nuevo. Ese login migraria la clave a BCrypt
    y el iFinan anterior dejaria de validarla.

  Ejecutar en el servidor del iFinan anterior (base iWeb) con un usuario con permiso de escritura.
*/
USE iWeb;
GO

SET NOCOUNT ON;

DECLARE @usuario  nvarchar(20)  = N'envio';
DECLARE @cont     nvarchar(255) = N'x5mruhfLVdsCJeufxWbHQVeR3ljVllwgRAidebFtyERYIWv3g2POSD3prh+3RpGtTHw9dL4gEkmz5fRjtAbvjA==';
DECLARE @salt     nvarchar(20)  = N'aaBAjMaG';
DECLARE @emp_id   smallint      = 1;     -- debe existir en dbo.empresas (el iFinan anterior lo resuelve al autenticar)
DECLARE @comercio smallint      = 0;

IF NOT EXISTS (SELECT 1 FROM dbo.empresas WHERE emp_id = @emp_id)
BEGIN
    PRINT 'ERROR: la empresa ' + CONVERT(varchar(10), @emp_id) + ' no existe en dbo.empresas. Ajustar @emp_id y volver a ejecutar.';
    RETURN;
END

BEGIN TRY
    BEGIN TRAN;

    -- 1) Permiso 'Envio'
    IF NOT EXISTS (SELECT 1 FROM dbo.permisos WHERE perm_nombre = N'Envio')
        INSERT INTO dbo.permisos (perm_nombre, perm_descripcion) VALUES (N'Envio', N'Envio de informacion desde iComercio');
    DECLARE @perm_id int = (SELECT TOP 1 perm_id FROM dbo.permisos WHERE perm_nombre = N'Envio');

    -- 2) Perfil 'Envio' con ese permiso
    IF NOT EXISTS (SELECT 1 FROM dbo.perfiles WHERE per_nombre = N'Envio')
        INSERT INTO dbo.perfiles (per_nombre, per_descripcion) VALUES (N'Envio', N'Usuario de envio de iComercio');
    DECLARE @per_id int = (SELECT TOP 1 per_id FROM dbo.perfiles WHERE per_nombre = N'Envio');

    IF NOT EXISTS (SELECT 1 FROM dbo.perfiles_permisos WHERE per_id = @per_id AND perm_id = @perm_id AND perperm_comercio = @comercio)
        INSERT INTO dbo.perfiles_permisos (per_id, perm_id, perperm_comercio) VALUES (@per_id, @perm_id, @comercio);

    -- 3) Usuario 'envio' (alta o actualizacion de la clave)
    IF EXISTS (SELECT 1 FROM dbo.usuarios WHERE usu_usuario = @usuario)
        UPDATE dbo.usuarios
        SET usu_cont = @cont, usu_salteado = @salt, usu_habilitado = 1, emp_id = @emp_id
        WHERE usu_usuario = @usuario;
    ELSE
        INSERT INTO dbo.usuarios (usu_comercio, usu_usuario, usu_cont, per_id, usu_habilitado, usu_fecha_creacion, usu_usuario_creacion, emp_id, usu_salteado)
        VALUES (@comercio, @usuario, @cont, NULL, 1, GETDATE(), NULL, @emp_id, @salt);

    DECLARE @usu_id int = (SELECT TOP 1 usu_id FROM dbo.usuarios WHERE usu_usuario = @usuario);

    -- 4) Vincular usuario y perfil
    IF NOT EXISTS (SELECT 1 FROM dbo.usuarios_perfiles WHERE usu_id = @usu_id AND per_id = @per_id)
        INSERT INTO dbo.usuarios_perfiles (usu_id, per_id) VALUES (@usu_id, @per_id);

    COMMIT TRAN;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRAN;
    PRINT 'ERROR: ' + ERROR_MESSAGE();
    RETURN;
END CATCH

-- Verificacion
SELECT u.usu_id, u.usu_usuario, LEFT(u.usu_cont, 6) AS inicio_hash, LEN(u.usu_cont) AS largo_hash, u.usu_habilitado, u.emp_id,
       p.per_nombre AS perfil, pe.perm_nombre AS permiso
FROM dbo.usuarios u
LEFT JOIN dbo.usuarios_perfiles up ON up.usu_id = u.usu_id
LEFT JOIN dbo.perfiles p ON p.per_id = up.per_id
LEFT JOIN dbo.perfiles_permisos pp ON pp.per_id = p.per_id
LEFT JOIN dbo.permisos pe ON pe.perm_id = pp.perm_id
WHERE u.usu_usuario = @usuario;
PRINT 'Usuario envio listo. largo_hash esperado: 88 y inicio_hash NO debe comenzar con $2.';
