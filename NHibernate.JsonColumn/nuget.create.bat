IF EXIST "%VS140COMNTOOLS%\vsvars32.bat" CALL "%VS140COMNTOOLS%\vsvars32.bat"
IF EXIST "%VS120COMNTOOLS%\vsvars32.bat" CALL "%VS120COMNTOOLS%\vsvars32.bat"
IF EXIST "%VS110COMNTOOLS%\vsvars32.bat" CALL "%VS110COMNTOOLS%\vsvars32.bat"
msbuild ..\NHibernate.JsonColumn.sln /p:Configuration=Release /p:Platform="Any CPU"
nuget pack NHibernate.JsonColumn.csproj -Prop Configuration=Release -Prop Platform=AnyCPU
nuget pack NHibernate.JsonColumn.csproj -Prop Configuration=Release -Prop Platform=AnyCPU -Symbols
