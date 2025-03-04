
# Student Management API

## Overview
The Student Management API is a RESTful web service built with ASP.NET Core 8.0, designed to manage student data and their associated subjects. This API supports CRUD operations for students, including registration, retrieval, updates, and subject management, following RESTful conventions and best practices. It is intended for educational institutions to track student information and course enrollment.

## Features
- **Student Management**: Create, read, update, and retrieve student records using their identification number (e.g., ID card or cedula).
- **Subject Management**: Add and retrieve subjects associated with a student based on their unique code.
- **Logging**: Track changes and actions with detailed log entries for auditing purposes.
- **Swagger Integration**: Interactive API documentation and testing via Swagger UI.
- **Unit Tests**: Comprehensive unit tests using xUnit to ensure reliability and maintainability.
- **Docker Support**: Containerized deployment with Docker Compose for easy setup and scalability.

## Prerequisites
Before running the project, ensure you have the following installed:
- **.NET SDK 8.0** or higher (available at [dotnet.microsoft.com](https://dotnet.microsoft.com/download))
- **Docker** and **Docker Compose** (available at [docker.com](https://www.docker.com/get-started))
- **SQL Server 2022** (or use the Docker containerized version provided in this setup)
- **Optional**: Visual Studio 2022 or higher for development and debugging

## Installation

### 1. Clone the Repository
Clone this repository to your local machine:
```bash
git clone https://github.com/EdgarC97/20250304EdgarCardona
cd StudentManagementApi\StudentManagementApi
```

### 2. Restore Dependencies
Restore the .NET dependencies:
```bash
dotnet restore
```

### 3. Configure Environment
Copy the sample environment file and configure it for your environment:
- For development, rename `.env.local.example` to `.env.local` and adjust the `DB_CONNECTION` to point to your local SQL Server (e.g., `Server=localhost;Database=Student_DB;User Id=sa;Password=YourPassword;MultipleActiveResultSets=true;TrustServerCertificate=true`).
- For production, ensure `.env.production` is configured with the Docker SQL Server settings (e.g., `Server=sqlserver;Database=ERP_DB;User Id=sa;Password=Riwi2025**;MultipleActiveResultSets=true;TrustServerCertificate=true`).

### 4. Apply Migrations and Seed Data
Run the following command to apply database migrations and seed initial data:
```bash
dotnet ef database update --context StudentDbContext
```
Alternatively, use Docker (see below) to handle migrations automatically.

## Running the Application

### Local Development
1. Ensure SQL Server is running locally or use the Docker setup below.
2. Run the application:
   ```bash
   dotnet run
   ```
3. Access the API at `http://localhost:8080` or use Swagger at `http://localhost:8080/swagger` for interactive documentation and testing.

### Docker Deployment
1. Ensure Docker and Docker Compose are installed and running.
2. Navigate to the project directory and build/run the containers:
   ```bash
   StudentManagementApi\StudentManagementApi
   docker-compose up --build -d
   ```
3. The API will be available at `http://localhost:8080`, and SQL Server will run in a containerized environment.

## API Endpoints
### Students
- **POST `/api/student/{id}`**: Register or update a student by their identification number (cedula). Requires a JSON body with student details (excluding ID, which is in the URL).
  - Example: `POST /api/student/110480525` with body `{ "code": "STU007", "names": "María", "lastnames": "López", ... }`.
- **GET `/api/student/{id}`**: Retrieve a student by their identification number.
  - Example: `GET /api/student/110480525`.
- **GET `/api/student`**: Retrieve all students.

### Subjects
- **GET `/api/subject/byStudentCode/{studentCode}`**: Retrieve all subjects for a student by their code.
  - Example: `GET /api/subject/byStudentCode/STU001`.
- **POST `/api/subject/add/{studentId}`**: Add a new subject for a specific student by their identification number.
  - Example: `POST /api/subject/add/123456789` with body `{ "code": "MAT001", "name": "Mathematics", ... }`.

## Configuration
- **Database**: The API uses SQL Server with Entity Framework Core. Configure the connection string in `.env.local` or `.env.production`.
- **Environment Variables**: Use `.env.local` for development and `.env.production` for production. Example variables:
  ```env
  DB_CONNECTION=Server=sqlserver;Database=ERP_DB;User Id=sa;Password=Riwi2025**;MultipleActiveResultSets=true;TrustServerCertificate=true
  ASPNETCORE_ENVIRONMENT=Production
  ```

## Running Tests
Run unit tests to verify the API functionality:
```bash
cd StudentManagementApi\StudentManagementApi.Tests
dotnet test
```
