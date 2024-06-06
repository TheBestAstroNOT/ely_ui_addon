# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/femc.addon.ely.art/*" -Force -Recurse
dotnet publish "./femc.addon.ely.art.csproj" -c Release -o "$env:RELOADEDIIMODS/femc.addon.ely.art" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location