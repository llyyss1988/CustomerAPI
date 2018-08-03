#!/bin/bash
dotnet publish -v d -o ".//bin//Debug//netcoreapp2.1//linux-x64" --framework netcoreapp2.1 --runtime linux-x64 customerAPI.csproj 
