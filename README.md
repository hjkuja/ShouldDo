# Todo app example

This is a simple todo app example demonstrating .NET minimal APIs and the Result pattern.


## Database

The demo uses PostgreSQL as the database. The app will create the database schema on startup.

You can run the db using Docker and the provided `docker-compose.yml` file:

```bash
docker compose up -d
```

Alternatively, the command below will start a default PostgreSQL instance:

```bash
docker run -dit -e POSTGRES_USER=dev -e POSTGRES_PASSWORD=dev -e POSTGRES_DB=shoulddo -p 127.0.0.1:5432:5432 --name db --rm postgres:18
```

## Testing the app

The app uses [Scalar](https://github.com/scalar/scalar) for the API documentation.

Start the app and navigate to `https://localhost:5555/scalar/v1` to see the API documentation and test the endpoints.
