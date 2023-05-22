dotnet test tests/SP.API.UnitTest/SP.API.UnitTest.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=Coverage/ /p:excludebyattribute=*.ExcludeFromCodeCoverage*

C:\Users\iventis.rmoraes\.nuget\packages\reportgenerator\4.3.1\tools\net47\ReportGenerator.exe "-reports:tests/SP.API.UnitTest/Coverage/coverage.opencover.xml" "-targetdir:tests/Coverage"
C:\Users\iventis.cutiyama\.nuget\packages\reportgenerator\4.3.1\tools\net47\ReportGenerator.exe "-reports:tests/SP.API.UnitTest/Coverage/coverage.opencover.xml" "-targetdir:tests/Coverage"
pause