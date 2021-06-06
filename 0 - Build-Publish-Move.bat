@echo off

dotnet restore

dotnet build --no-restore -c Release

dotnet nuget push Panosen.CodeDom.CSharpProject\bin\Release\Panosen.CodeDom.CSharpProject.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate
dotnet nuget push Panosen.CodeDom.CSharpProject.Engine\bin\Release\Panosen.CodeDom.CSharpProject.Engine.*.nupkg -s https://package.savory.cn/v3/index.json --skip-duplicate

move /Y Panosen.CodeDom.CSharpProject\bin\Release\Panosen.CodeDom.CSharpProject.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.CSharpProject.Engine\bin\Release\Panosen.CodeDom.CSharpProject.Engine.*.nupkg D:\LocalSavoryNuget\

pause