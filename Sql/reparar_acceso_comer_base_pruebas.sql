/*
  Repara el acceso del login 'comer' a la base de pruebas de iComercio.
  Sintoma: Cannot open database "ComercioPru" requested by the login. Login failed for user 'comer'. (error 4060)

  Ejecutar en el servidor SQL de la base de pruebas (ej. 192.168.1.251) con un usuario sysadmin, por ejemplo desde SSMS.
  El script no cambia contrasenas ni borra datos. Cada paso informa lo que hizo con PRINT.
*/

SET NOCOUNT ON;

DECLARE @Base  sysname = N'ComercioPru';   -- nombre de la base (el que figura en Initial Catalog del exe.config)
DECLARE @Login sysname = N'comer';
DECLARE @sql   nvarchar(max);

-- 1) Diagnostico ------------------------------------------------------------
PRINT '--- 1) Diagnostico';

IF DB_ID(@Base) IS NULL
BEGIN
    PRINT 'ERROR: la base [' + @Base + '] no existe en este servidor. Restaurarla o corregir Initial Catalog en el exe.config.';
    RETURN;
END

SELECT name AS base, state_desc AS estado, user_access_desc AS acceso
FROM sys.databases WHERE name = @Base;

IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @Login AND type = 'S')
BEGIN
    PRINT 'ERROR: el login [' + @Login + '] no existe en el servidor. Crearlo con: CREATE LOGIN [' + @Login + '] WITH PASSWORD = ''<clave>'', CHECK_POLICY = OFF;  y volver a ejecutar este script.';
    RETURN;
END

SELECT name AS login, is_disabled AS deshabilitado, default_database_name AS base_por_defecto
FROM sys.sql_logins WHERE name = @Login;

-- 2) Login habilitado -------------------------------------------------------
PRINT '--- 2) Login';
IF EXISTS (SELECT 1 FROM sys.server_principals WHERE name = @Login AND is_disabled = 1)
BEGIN
    SET @sql = N'ALTER LOGIN ' + QUOTENAME(@Login) + N' ENABLE;';
    EXEC (@sql);
    PRINT 'Login [' + @Login + '] habilitado.';
END
ELSE PRINT 'Login [' + @Login + '] ya estaba habilitado.';

-- 3) Base en linea ----------------------------------------------------------
PRINT '--- 3) Estado de la base';
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = @Base AND state_desc <> 'ONLINE')
BEGIN
    SET @sql = N'ALTER DATABASE ' + QUOTENAME(@Base) + N' SET ONLINE;';
    EXEC (@sql);
    PRINT 'Base [' + @Base + '] puesta ONLINE.';
END
ELSE PRINT 'Base [' + @Base + '] ya estaba ONLINE.';

-- 4) Usuario dentro de la base (corrige usuario huerfano tras un restore) ----
PRINT '--- 4) Usuario en la base';
SET @sql = N'
USE ' + QUOTENAME(@Base) + N';

DECLARE @loginSid varbinary(85) = SUSER_SID(N''' + @Login + N''');
DECLARE @userSid  varbinary(85) = (SELECT sid FROM sys.database_principals WHERE name = N''' + @Login + N''' AND type = ''S'');

IF @userSid IS NULL
BEGIN
    CREATE USER ' + QUOTENAME(@Login) + N' FOR LOGIN ' + QUOTENAME(@Login) + N';
    PRINT ''Usuario creado en la base.'';
END
ELSE IF @userSid <> @loginSid
BEGIN
    ALTER USER ' + QUOTENAME(@Login) + N' WITH LOGIN = ' + QUOTENAME(@Login) + N';
    PRINT ''Usuario huerfano reasociado al login.'';
END
ELSE PRINT ''El usuario ya estaba asociado correctamente.'';

IF IS_ROLEMEMBER(''db_owner'', N''' + @Login + N''') <> 1
BEGIN
    EXEC sp_addrolemember N''db_owner'', N''' + @Login + N''';
    PRINT ''Agregado a db_owner (iComercio aplica migraciones de EF y necesita permisos de esquema).'';
END
ELSE PRINT ''Ya es miembro de db_owner.'';
';
EXEC (@sql);

-- 5) Verificacion: entrar como el login y leer la tabla de migraciones ------
PRINT '--- 5) Verificacion';
SET @sql = N'
USE ' + QUOTENAME(@Base) + N';
EXECUTE AS LOGIN = N''' + @Login + N''';
SELECT SUSER_NAME() AS entrando_como, DB_NAME() AS base;
IF OBJECT_ID(N''dbo.__MigrationHistory'') IS NOT NULL
    SELECT TOP 1 MigrationId AS ultima_migracion FROM dbo.__MigrationHistory ORDER BY MigrationId DESC;
ELSE
    PRINT ''La base no tiene dbo.__MigrationHistory: iComercio la creara y migrara al abrirla por primera vez.'';
REVERT;
';
EXEC (@sql);

PRINT 'Esperado en ultima_migracion: 202110151917079_29';
