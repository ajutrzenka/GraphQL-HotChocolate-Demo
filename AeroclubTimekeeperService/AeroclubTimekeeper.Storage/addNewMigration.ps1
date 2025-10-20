param(
    [string]$migrationName
)

if (-not $PSBoundParameters.ContainsKey('migrationName')) {
    throw "The 'migrationName' parameter is missing."
}

dotnet ef migrations add $migrationName --verbose

# dotnet ef migrations add InitialCreate --verbose
# dotnet ef migrations add FillDatabase --verbose