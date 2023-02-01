# Shine
Program for running configured command-line jobs.

## Usage
Place/create a config file in the build directory called "shine_config.json"
Run

## Example config
```json
{
	"jobs":[
		{
			"name": "scoop",
			"commands":[
				"scoop update",
				"scoop update *",
				"scoop cleanup *",
				"scoop cache rm *"
			]
		},
		{
			"name": "winget",
			"commands":[
				"winget upgrade --all --accept-source-agreements"
			]
		},
		{
			"name": "temp",
			"commands":[
				"cmd.exe /q/c del /q/f/s %TEMP%/*",
				"cmd.exe /q/c del /q/f/s C:/Windows/Temp/*"
			]
		},
		{
			"name": "memory",
			"commands":[
				"cmd.exe /q/c WinMemoryCleaner.exe /CombinedPageList /ModifiedPageList /ProcessesWorkingSet /StandbyList /SystemWorkingSet"
			]
		}
	]
}
```
