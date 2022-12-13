REM MySql
cd ../Oip.Dal.MySql
dotnet ef migrations add Update28 -- "Server=localhost;Port=3306;Database=Oip;User=root;Password=password;" "8.0.22"

REM PostgreSql
cd ../Oip.Dal.PostgreSql
dotnet ef migrations add Update28 -- "Server=localhost;Port=3306;Database=Oip;User=root;Password=password;" "8.0.22"

REM Sqlite
cd ../Oip.Dal.Sqlite
dotnet ef migrations add Update28

REM SqlServer
cd ../Oip.Dal.SqlServer
dotnet ef migrations add Update28 -- "{connection string}"

REM Oracle
cd ../Oip.Dal.Oracle
dotnet ef migrations add Update28 -- "{connection string}"