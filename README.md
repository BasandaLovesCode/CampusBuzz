# CampusBuzz

CampusBuzz is a full-stack student project that includes a web frontend built with Angular and a backend API built with ASP.NET Core. The project allows users to manage campus events, including creating, editing, and listing events.

## Tech Stack

* Frontend: Angular
* Backend: ASP.NET Core Web API
* Database: (Specify your database, e.g., SQL Server, SQLite)
* Testing: xUnit (Unit tests for API)
* Version Control: Git + GitHub

## Project Structure

CampusBuzz/         # Angular frontend
CampusBuzz_API/     # ASP.NET Core API + unit tests
.gitignore          # Git ignore file

## Features

* Create, edit, delete, and view campus events
* API endpoints for managing events
* Unit tests for backend functionality
* Clean separation of frontend and backend

## How to Run

### Backend (API)

1. Open **PowerShell** or **Command Prompt**.
2. Navigate to the API folder:

```
cd "C:\3rd Year\INF354\Homework Assignment\CampusBuzz_API"
```

3. Run the API:

```
dotnet run
```

4. The API should start at `https://localhost:5001` (check `launchSettings.json` if different).

### Frontend (Angular)

1. Open **PowerShell** or **Command Prompt**.
2. Navigate to the Angular folder:

```
cd "C:\3rd Year\INF354\Homework Assignment\CampusBuzz"
```

3. Install dependencies:

```
npm install
```

4. Start the Angular development server:

```
ng serve
```

5. Open your web browser and go to:

```
http://localhost:4200
```

> **Important:** Make sure the API is running before opening the Angular frontend. The Angular app communicates with the backend API to display and manage events.

## Running Tests

To run backend API unit tests:

1. Navigate to the API folder:

```
cd "C:\3rd Year\INF354\Homework Assignment\CampusBuzz_API"
```

2. Run the tests:

```
dotnet test
```

## Notes

* The `.gitignore` file excludes `node_modules/`, `bin/`, `obj/`, and `.vs/` folders.
* Always start the backend API first, then the Angular frontend.
* If you are on Windows, you may see line ending warnings (LF → CRLF); these do not affect functionality.

## Author

**Basanda Shabalala**
[GitHub Profile](https://github.com/BasandaLovesCode)
