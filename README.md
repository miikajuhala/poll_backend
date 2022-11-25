
### my First .NET C# backend


### 1. `Create empty Microsoft SQL database`
### 2. `Connect to server and created empty database in Visual Code`
### 3. `Get datagbases connection string from database -> properties -> connection string`
### 4. `Add connection string to appsettings.json and remember to add Trust Server Certificate=true to the end.`
`"ConnectionStrings": {
        "PollConnStr": "Data Source=DESKTOP-VNB4G1U\\MSSQLSERVER01;Initial Catalog=database2;Integrated Security=True;Trust Server Certificate=true"
    }`
### 5. `run in Package managment console: "update-database -migration MigrationV3"` or `run in Package managment console: "add-migration MigrationV4" and then update-database -migration MigrationV4`

### 6. `now db is created WITH dummy data and backend id ready to use`
	