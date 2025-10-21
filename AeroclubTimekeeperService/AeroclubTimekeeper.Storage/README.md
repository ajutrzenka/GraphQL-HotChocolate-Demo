To (re)create SQLite database, please run following powershell scripts:
	- `recreateDatabase.ps1`
	- `updateDatabase.ps1`

It will appear in the current project root directory as `aeroclub.db` file.

Keep in mind, that main startup project `AeroclubTimekeeperApi` links this db file 
and copies it to its own binary execution folder.