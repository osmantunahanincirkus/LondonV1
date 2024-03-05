# LondonV1 API

LondonV1 API is a .NET RESTful API designed to allow users to manage the books they have read.

## Features

- **Authentication**: JWT authentication is implemented for user authentication.
- **Database**: MySQL is used as the database for storing user and book data.
- **Endpoints**:
  1) **POST: /users/login**: Allows users to log in to the system.
     - Request body: username, password
     - Response: user object (id, username, name, surname)
     - Response header: JWT authentication token

  2) **POST: /users/sign-up**: Allows users to sign up for the system.
     - Request body: username, password, name, surname
     - Response: user object (id, username, name, surname)
     - Response header: JWT authentication token

  3) **POST: /books**: Allows users to add a book.
     - Request body: book name, author name
     - Request header: JWT authentication token
     - Response: book object (id, book name, author name)
     - Response header: JWT authentication token

  4) **POST: /books**: Allows users to add a book they have read.
     - Request body: book name, author name
     - Request header: JWT authentication token
     - Response: book object (id, book name, author name)
     - Response header: JWT authentication token

  5) **GET: /books**: Retrieves the books read by the user.
     - Request body: None
     - Request header: JWT authentication token
     - Response: Array of book objects (id, book name, author name)
     - Response header: JWT authentication token

- **Testing**: Unit tests for Login and Sign-up operations, integration tests for UserController are available.
- **Design Principles**:
  - SOLID, DRY, and KISS principles are followed.
  - Dependency Injection is used.
  - Object-Oriented Programming principles are adhered to.
- **Asynchronous Operations**: The API is designed to perform operations asynchronously.
- **Design Patterns**: Various design patterns are implemented for better code organization and maintenance.
- **Object-Relational Mapping**: EF Core is used for object-relational mapping.
- **Request Model Validation**: Fluent Validation is integrated for validating request models.
- **Global Exception Handling**: NET8's global exception handling feature is utilized.
- **Extension Methods and Constants**: Extension methods and constants are used throughout the project for improved code readability and maintainability.

## Installation

To install and run the API locally, follow these steps:

1. Clone the repository: git clone https://github.com/osmantunahanincirkus/LondonV1.git
   
2. Navigate to the project directory and build the solution.

3. Update the connection string in the `appsettings.json` file to point to your MySQL database.

4. Run the application. 

## Usage

Once the API is running, you can interact with it using tools like Postman or by integrating it into your applications.

## Contributing

Contributions are welcome! If you have any suggestions or want to report a bug, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
