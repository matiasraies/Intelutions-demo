# Intelutions DEMO

_Proyecto de evaluacion tecnica._

## Comenzando 

### Arquitectura

**API Rest**

Construido con .NET Core 3.1

#### Caracteristicas

Patron DDD

Patron Command and Query Responsibility Segregation (CQRS)

Patron Mediador

Patron UnitOfWork + AggregateModel + Repository

#### Modulos

Injeccion de dependencias (Autofac)

IMediator


**WEB MVC** 

Construido con .NET Core 3.1

### Pre-requisitos 

_Visual Studio 2019. SQLServer._

### Migracion

Ejecute los siguientes comandos por consola PM de vs 2019.

Add-Migration InitialCreate -Project Request.Infrastructure

Update-Database InitialCreate -Project Request.Infrastructure

## Autor 

* **Matias Marcelo Raies**
