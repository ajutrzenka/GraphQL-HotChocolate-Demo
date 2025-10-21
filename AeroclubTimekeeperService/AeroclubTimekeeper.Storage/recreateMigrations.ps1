Write-Host "Removing the content of Migrations folder..."
$migrationsPath = "Migrations"

Get-ChildItem -Path $migrationsPath -File | Remove-Item

if (-not $?) {
    throw "Could not remove the content of Migrations folder."
}

Write-Host "Generating initial migration..."
& "./addNewMigration.ps1" -migrationName "InitialCreate"

if ($LASTEXITCODE -ne 0) {
    throw "Could not generate initial migration."
}

Write-Host "Generating empty fill database migration..."
& "./addNewMigration.ps1" -migrationName "FillDatabase"

if ($LASTEXITCODE -ne 0) {
    throw "Could not generate migration."
}

Write-Host "Insert handling sql script into last migration..."

$migrationFilePath = Get-ChildItem -Path $migrationsPath -Recurse | `
    Where-Object { $_.Name -match ".*FillDatabase.cs" } | `
    Select-Object -ExpandProperty FullName

Write-Host "Attempting to modify following file:`n" $migrationFilePath

$migrationFileContent = Get-Content -Path $migrationFilePath -Raw

$regexPattern = "(?ms)Up\(MigrationBuilder migrationBuilder\)\s*?{\s*?}"
#$matches = [regex]::Matches($migrationFileContent, $regexPattern)
#Write-Host $matches

$updatedContent = $migrationFileContent -replace $regexPattern, `
"Up(MigrationBuilder migrationBuilder)
        {
            var sql = Utils.EmbeddedFileReader.ReadContent(`"SQL/FillDatabase.sql`");
            migrationBuilder.Sql(sql);
        }"

Set-Content -Path $migrationFilePath -Value $updatedContent -Force

Write-Host "Removing existing SQLite database if exists..."
$dbFilePath = "aeroclub.db" 
if (Test-Path $dbFilePath) {
    Remove-Item $dbFilePath -Force
}