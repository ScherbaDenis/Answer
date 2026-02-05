# Answer API

A .NET Clean Architecture Answer API project with gRPC and REST support.

## Architecture

This project follows Microsoft Clean Architecture principles with the following layers:

- **Domain Layer** (`Answer.Domain`): Contains domain entities and business logic
- **Application Layer** (`Answer.Application`): Contains application interfaces and DTOs
- **Infrastructure Layer** (`Answer.Infrastructure`): Contains data persistence implementation
- **API Layer** (`Answer.Api`): Contains gRPC services with REST support via JSON transcoding

## Entities

### User
- `Guid Id`: Unique identifier
- `string Name`: User name

### Question
- `Guid Id`: Unique identifier
- `string Title`: Question title

### Template
- `Guid Id`: Unique identifier
- `string Title`: Template title

### Answer
- `Guid Id`: Unique identifier
- `Guid UserId`: Reference to User
- `Guid QuestionId`: Reference to Question
- `Guid TemplateId`: Reference to Template
- `AnswerType`: Type of answer (SingleLineString, MultiLineText, PositiveInteger, Checkbox, Boolean)
- `string AnswerValue`: The answer value stored as string

## Technologies

- .NET 9.0
- gRPC with ASP.NET Core
- gRPC-JSON Transcoding for REST support
- In-memory data storage (for demonstration)

## Building and Running

### Prerequisites
- .NET 9.0 SDK or later

### Build
```bash
dotnet build
```

### Run
```bash
cd src/Answer.Api
dotnet run
```

The API will be available at `http://localhost:5136`

## API Endpoints

### Users
- `POST /api/users` - Create a user
- `GET /api/users` - List all users
- `GET /api/users/{id}` - Get a user by ID
- `PUT /api/users/{id}` - Update a user
- `DELETE /api/users/{id}` - Delete a user

### Questions
- `POST /api/questions` - Create a question
- `GET /api/questions` - List all questions
- `GET /api/questions/{id}` - Get a question by ID
- `PUT /api/questions/{id}` - Update a question
- `DELETE /api/questions/{id}` - Delete a question

### Templates
- `POST /api/templates` - Create a template
- `GET /api/templates` - List all templates
- `GET /api/templates/{id}` - Get a template by ID
- `PUT /api/templates/{id}` - Update a template
- `DELETE /api/templates/{id}` - Delete a template

### Answers
- `POST /api/answers` - Create an answer
- `GET /api/answers` - List all answers
- `GET /api/answers/{id}` - Get an answer by ID
- `PUT /api/answers/{id}` - Update an answer
- `DELETE /api/answers/{id}` - Delete an answer

## Example Usage

### Create a User
```bash
curl -X POST http://localhost:5136/api/users \
  -H "Content-Type: application/json" \
  -d '{"name":"John Doe"}'
```

### Create a Question
```bash
curl -X POST http://localhost:5136/api/questions \
  -H "Content-Type: application/json" \
  -d '{"title":"What is Clean Architecture?"}'
```

### Create a Template
```bash
curl -X POST http://localhost:5136/api/templates \
  -H "Content-Type: application/json" \
  -d '{"title":"Survey Template"}'
```

### Create an Answer
```bash
curl -X POST http://localhost:5136/api/answers \
  -H "Content-Type: application/json" \
  -d '{
    "user_id": "<user-guid>",
    "question_id": "<question-guid>",
    "template_id": "<template-guid>",
    "answer_type": "SINGLE_LINE_STRING",
    "answer_value": "Clean Architecture is a software design pattern"
  }'
```

### List Users
```bash
curl http://localhost:5136/api/users
```

## gRPC Support

The API supports native gRPC calls. You can use any gRPC client (such as grpcurl, Postman, or BloomRPC) to interact with the services.

In development mode, gRPC reflection is enabled for service discovery.

## Answer Types

The Answer entity supports the following types:
- `SINGLE_LINE_STRING` - Single-line text
- `MULTI_LINE_TEXT` - Multi-line text
- `POSITIVE_INTEGER` - Positive integer numbers
- `CHECKBOX` - Checkbox value (true/false as string)
- `BOOLEAN` - Boolean value (true/false as string)