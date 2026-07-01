# AGENTS.md - Backend Torneos

## Proyecto
API REST en ASP.NET Core 8 (Web API) para gestión de torneos deportivos: equipos, jugadores y partidos.

## Stack
- **Framework:** .NET 8
- **ORM:** Entity Framework Core 9
- **BD:** PostgreSQL (Npgsql)
- **Pruebas:** xUnit + FluentAssertions + InMemoryDatabase
- **Swagger:** Swashbuckle

## Estructura
```
parcial_backend/
├── Controllers/          # API endpoints (Equipo, Jugador, Partido)
├── Data/                 # ApplicationDbContext (Fluent API, tablas: teams, players, matches)
├── Database/
│   └── StoredProcedures/ # Procedimientos almacenados PostgreSQL
├── Models/               # Teams, Players, Matches (DataAnnotations para validación)
├── Migrations/           # Migraciones EF Core
└── Program.cs            # Configuración CORS, DbContext, Swagger
Test_Parcial/             # Pruebas unitarias con xUnit + InMemory
```

## Modelos
- **Teams**: Id, Nombre, Ciudad, Estadio, Fundacion
- **Players**: Id, Nombre, Posicion, Edad, EquipoId (FK → Teams)
- **Matches**: Id, Fecha, EquipoLocalId, EquipoVisitanteId (FK → Teams), GolesLocal, GolesVisitante

## Convenciones
- Controladores con ruta `api/[controller]`, decorados con `[ApiController]`
- Rutas nombradas en español (`crearEquipo`, `ListaEquipos`, `EditarJugador`, etc.)
- Atributos `[Required]`, `[MaxLength]`, `[Range]` para validación en modelos
- `[JsonIgnore]` en propiedades de navegación
- CORS permite origen `http://localhost:4200`
- BD: `Host=localhost;Port=5432;Database=TorneoDb`

## Comandos
```powershell
# Restaurar paquetes
dotnet restore

# Compilar
dotnet build

# Migraciones (Package Manager Console en VS)
Add-Migration NombreMigracion
Update-Database

# Ejecutar API
dotnet run --project parcial_backend

# Ejecutar pruebas
dotnet test Test_Parcial
```

## Pruebas
- Usan `UseInMemoryDatabase` con GUID único por test
- `TestBase` provee `SeedTestDatabse()` y helpers de validación
- Cada controlador tiene su clase de test (`EquipoControllerTest`, `JugadorControllerTest`, `PartidoControllerTest`)
- Tests: crear, listar (2 endpoints: SP y directo), ver por id, editar, eliminar

## Endpoints
- `POST api/Equipo/crearEquipo`
- `GET api/Equipo/ListaEquipos` (via SP), `GET api/Equipo/ListaEquipos2` (EF directo)
- `GET api/Equipo/verEquipos?id=N`, `GET api/Equipo/jugadoresEquipo/{equipoId}`
- `PUT api/Equipo/EditarEquipo?id=N`, `DELETE api/Equipo/EliminarEquipo?id=N`
- Ídem para `api/Jugador` y `api/Partido`
