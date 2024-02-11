# APITest01

## Description

APITest01 is a .NET project designed to showcase API development with a focus on user management. The project is structured around a layered architecture, separating concerns into web API, processing logic, database services, and models. This approach ensures a clean separation of duties and makes the codebase more maintainable and scalable.

## Features

- **User Registration and Management**: Provides APIs for user registration, data validation, and retrieval.
- **Validation**: Implements custom validation logic for user input.
- **Error Handling and Logging**: Utilizes structured logging and error handling for debugging and monitoring.

## Getting Started

### Prerequisites

- .NET 5.0 SDK or later
- Visual Studio 2019 or Visual Studio Code
- SQL Server (for database operations)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/mic-pie/APITest01.git
   ```
2. Open the solution in Visual Studio or Visual Studio Code.
3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
4. Update the database connection string in `appsettings.json` according to your SQL Server instance.
5. Run the application:
   ```bash
   dotnet run --project WebApi/WebApi.csproj
   ```

## Usage

The project exposes a set of APIs for managing users. Here are some examples of how to interact with these APIs:

- **Create a User**: POST `/api/user` with user information in the request body.
- **Retrieve a User by ID**: GET `/api/user/{userId}`.

Refer to the API documentation (Swagger/OpenAPI) for detailed information on all available endpoints and their usage.

## Contributing

Contributions are welcome! For major changes, please open an issue first to discuss what you would like to change.

Please ensure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
