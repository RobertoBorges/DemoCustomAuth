# Individual Authentication demo With Custom Attributes manager

This is a demo of how to use the Individual Authentication on AspNet Core with Razor Pages and Identity.

## How to use

Alternatively, you can apply pending migrations from a command prompt at your project directory:

> PM> dotnet ef database update

With Visual Studio 2022, open the solution and run the project.

It should create a local database "aspnet-DemoCustomAuth-53bc9b9d-9d6a-45d4-8429-2a2761773502" and open a browser with the demo page.

For a good test create two users and add some roles on the database.

For my tests I used the following users:

| User | Roles |
| ---- | ----- |
user1@test.com | Admin
user2@test.com | User

## How it works

The demo is based on the default Individual Authentication template with Razor Pages and Identity.

