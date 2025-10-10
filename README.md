# Todo app example

This is a simple Todo app example demonstrating .NET minimal API and the Result pattern.


## How to run

Run docker container:

```bash
docker run -dit -e POSTGRES_USER=dev -e POSTGRES_PASSWORD=dev -e POSTGRES_DB=shoulddo -p 127.0.0.1:5432:5432 --name db postgres:18
```

The app will create the database schema on startup.

Run the app:

```bash
dotnet run --project src/ShouldDo.Api/ShouldDo.Api.csproj --launch-profile https
```