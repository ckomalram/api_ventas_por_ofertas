# Comandos

## Ejecución

    dotnet run
    dotnet build
    dotnet clean

## Migraciones

    dotnet ef migrations add InitialCreate
    dotnet ef migrations add MyMigration
    dotnet ef database update

## Installs

    dotnet tool install --global dotnet-ef
    dotnet new webapi -f net6.0 --dry-run
    dotnet new webapi -f net6.0

    dotnet add package Microsoft.EntityFrameworkCore --version 6.0.3
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.3
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.3

# Referencias

    https://www.nuget.org/
    https://learn.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools

# sql server steps

## v0.0.1

    Crear proyecto
    Instalar librerías de EF , efsqlserver, efdesign
    Configurar la db en appsettings
    Crear entidades/Modelos
    Crear contexto hacia la DB
    Crear Servicio relacionado al contexto.
    Inyectar dependencias en program.cs
    Crear Migraciones
    Ejecutar migraciones
    Crear controlador
    Agregar Ilogger  (Opcional)
