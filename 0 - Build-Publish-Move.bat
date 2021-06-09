@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.CSharpProject\bin\Release\Panosen.CodeDom.CSharpProject.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.CSharpProject.Engine\bin\Release\Panosen.CodeDom.CSharpProject.Engine.*.nupkg D:\LocalSavoryNuget\

pause