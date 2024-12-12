# Crazy Musicians Web API

This ASP.NET Core Web API manages "Crazy Musicians" data, supporting basic CRUD operations with validation and search functionality.

Features

CRUD Operations: Create, Read, Update, and Delete musicians.

*Search: Search musicians by name, genre, or instrument using query parameters.

*Validation: Ensures input data is valid before processing.

*Routing: Clean API routes for interacting with musician data.

Endpoints

*GET /api/musicians: Get all musicians.

*GET /api/musicians/{id}: Get a musician by ID.

*GET /api/musicians/search: Search musicians by name, genre, or instrument.

*POST /api/musicians: Create a new musician.

*PUT /api/musicians/{id}: Update a musician by ID.

*PATCH /api/musicians/{id}: Partially update a musician by ID.

*DELETE /api/musicians/{id}: Delete a musician by ID.

Validation

Validates input data (e.g., name, genre, instrument) for correct format and required fields.

Technologies

*ASP.NET Core 6+

*Entity Framework Core (in-memory database)
