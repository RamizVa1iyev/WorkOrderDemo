# Work Order Demo
This project follows a Domain-Driven Design (DDD) approach and adheres to clean code patterns. It leverages Aggregate Roots, Unit of Work, CQRS, and Mediator on the backend, while the frontend is developed using Blazor Web Assembly.

## Description

This repository contains the source code for WorkOrderDemo. The application is built using .Net7, EntityFramework Core, MediatR, AutoMapper, Polly and organized following DDD principles and clean code patterns.

## GettingStarted
Prerequisites
.Net 7 runtime
Installation
Clone the repository.
Navigate to the appsettings.json file in the Web API directory.
Modify the connectionString in the appsettings.json file to match your database settings.
Proceed to the WorkOrderDbContextDesignFactory file located in Infrastructure => Persistence => Context.
Update the connectionString to correspond with your database configuration in the WorkOrderDbContextDesignFactory file.
Save the changes.
Select WebApp and WebApi as multiple startup projects
Running the Application

## Backend
The backend of this application is built on:

Framework: .Net 7 class library and web api
Architecture: Domain-Driven Design (DDD)
Patterns: Aggregate Roots, Unit of Work, CQRS, Mediator
Technologies: MediatR, EntityFramework Code, Polly, OpenApi, AutoMapper

## Frontend
The frontend of this application is developed using:

Framework: Blazor Web Assembly
Technologies: BlazorBootstrap, NewtonsoftJson 
