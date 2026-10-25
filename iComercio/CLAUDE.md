# iComercio — Claude Agent Instructions

## Descripción del proyecto
Aplicación de escritorio comercial construida sobre **.NET Framework + WinForms**.
Tiene su **propia base de datos SQL Server**, independiente de los otros proyectos.

## Stack
- **UI**: WinForms (.NET Framework)
- **Backend**: C# .NET Framework
- **Base de datos**: SQL Server propia (ver `_claude/schema/`)

## Contexto del proyecto
El schema y arquitectura específicos de este proyecto están en `_claude/`.

Antes de cualquier tarea leer según corresponda:
- `_claude/schema/tables.sql` → estructura de tablas
- `_claude/schema/relationships.md` → relaciones y claves foráneas
- `_claude/schema/stored_procs.sql` → stored procedures existentes
- `_claude/context/project.md` → dominio y reglas de negocio
- `_claude/context/architecture.md` → arquitectura del proyecto

## Estructura del proyecto
```
iComercio/
├── Forms/              ← Formularios WinForms (.cs + .Designer.cs)
├── Controls/           ← UserControls reutilizables
├── DAL/		← Acceso a datos (repositorios, DAL) 
├── Models/             ← Clases de dominio y entidades
├── Services/           ← Lógica de negocio
├── Data/               
├── Utils/              ← Helpers y utilidades
├── Rest/               ← Cliente rest y restmodels utilizados para peticiones rest
├── ViewModels/         ← Clases utilizadas para mostrar datos de forma especifica
├── _claude/            ← Contexto para el agente (no es código)
│   ├── context/
│   ├── schema/
│   └── skills/
└── App.config          ← Configuración y connection string
```

## Convenciones específicas de este proyecto

### WinForms
- No modificar archivos `.Designer.cs` manualmente — es generado por el diseñador
- Lógica de negocio fuera del code-behind del Form; delegar a Services
- Nombrar controles con prefijo según tipo: `btn`, `txt`, `lbl`, `dgv`, `cmb`, `chk`
  - Ejemplo: `btnGuardar`, `txtNombre`, `dgvArticulos`
- Operaciones largas en background para no bloquear la UI

### C# / .NET Framework
- Respetar la arquitectura de acceso a datos existente (ADO.NET, repositorio, etc.)
- Manejo de excepciones con mensajes amigables al usuario (`MessageBox`)
- Conexión a BD desde `App.config` — nunca hardcodear connection strings
- Validación en el formulario antes de llamar al servicio

### SQL Server
- Ver siempre `_claude/schema/` antes de escribir queries
- Usar stored procedures existentes cuando ya cubran la necesidad
- Para queries destructivas: incluir SELECT de verificación antes del UPDATE/DELETE
- Nunca `SELECT *` — listar columnas explícitamente

## Comportamiento del agente

### Al modificar formularios existentes
- Leer el `.cs` del Form antes de proponer cambios
- No tocar el `.Designer.cs`
- Respetar el flujo de navegación entre formularios ya establecido

### Al crear formularios nuevos
- Seguir el patrón de un Form existente similar
- Separar lógica en Service, no en el code-behind
- Nombrar el archivo según la función: `FormArticulos.cs`, `FormVentas.cs`

## Lo que el agente NO debe hacer
- No modificar archivos `.Designer.cs` directamente
- No agregar referencias/NuGet sin mencionarlo explícitamente
- No cambiar `App.config` sin avisar
- No asumir que las tablas son iguales a los otros proyectos — esta base es independiente
- No migrar a WPF o .NET Core sin que se pida explícitamente
