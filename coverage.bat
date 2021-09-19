rmdir CoverageResults /s /q

dotnet test ^
/p:CollectCoverage=true ^
/p:CoverletOutput="../../CoverageResults/" ^
/p:CoverletOutputFormat=\"cobertura,json,opencover\" ^
/p:Exclude=[xunit*] ^
/p:ExcludeByFile="**/Migrations/*.cs" ^
/p:MergeWith="../../CoverageResults/coverage.json" ^
-m:1

dotnet reportgenerator ^
-reports:"./CoverageResults/coverage.cobertura.xml" ^
-targetdir:"./CoverageResults/Report" ^
-reporttypes:Html;HTMLSummary