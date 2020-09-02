# BDSA2020

Analysis, Design and Software Architecture (Autumn 2020)

## Updating packages

```powershell
# List outdated packages
dotnet list package --outdated

# Add code coverage tool
dotnet add package coverlet.msbuild
```

## Running tests

Install extension: Coverage Gutters

```powershell
# Watch for changes and run tests
dotnet watch --project .\Lecture02.Tests test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./obj/lcov.info
```
