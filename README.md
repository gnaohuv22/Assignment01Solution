# eStore Project

## Overview

The eStore project is a web application designed to manage an online store. It includes both client-side and server-side components, utilizing various technologies and frameworks to provide a robust and scalable solution.

## Technologies Used

### Client-Side
- **JavaScript**: For client-side scripting.
- **jQuery Validation Plugin**: For form validation.
- **Razor**: For server-side rendering of HTML views.

### Server-Side
- **C#**: The primary programming language.
- **.NET 8**: The framework used for building the application.
- **Entity Framework Core**: For database operations.
- **AutoMapper**: For object-object mapping.
- **Swagger**: For API documentation.

## Project Structure

### eStoreClient
- **wwwroot/lib/jquery-validation**: Contains the jQuery validation library.
- **wwwroot/js/site.js**: Custom JavaScript code for the client-side.
- **Views/Shared/Error.cshtml**: Razor view for displaying error messages.

### eStoreAPI
- **Program.cs**: The entry point of the application, configuring services and middleware.

### BusinessObject
- **BusinessObject.csproj**: Project file containing package references and build configurations.

## Setup Instructions

1. **Clone the repository**:
```
git clone https://github.com/your-repo/eStore.git
cd eStore
```

2. **Build the solution**:
    Open the solution in Visual Studio and build it to restore all dependencies.

3. **Update the database connection string**:
    Modify the connection string in `appsettings.json` to point to your SQL Server instance.

4. **Run the application**:
    Press `F5` in Visual Studio to run the application. The API will be available at `https://localhost:5001` and the client at `https://localhost:5000`.

## License

This project is licensed under the MIT License. See the [LICENSE](eStoreClient/wwwroot/lib/jquery-validation/LICENSE.md) file for more details.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## Contact

For any questions or issues, please open an issue on GitHub or contact the project maintainers.


    