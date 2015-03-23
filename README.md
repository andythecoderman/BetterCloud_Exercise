### Assignment Description

*   Please write an ASP.NET MVC application that allows a user to perform CRUD operations on Customer information on a web page.
*   The application should save the data to a database of your choice.
*   Take the Address Information from the Customer Information and save the Longitude and Latitude using Google's Geocoding API.
*   Use proper architectural layering / patterns.
*   Write the unit / integration tests for each layer.
*   NUGET packages are acceptable but please do not use any frameworks/utilities that you have previously written (unless you can re-write them within the timeframe).
*   Write a little excerpt as to what architectural / layering decisions you made, why you made the decisions, and alternatives you rejected and why.

* * *

### Architectural Description

    The Application is broken into a few major components: The MVC Web Application, Business Logic, Data Access, and the Database.
    Each layer is decoupled by use of dependency injection via Ninject so that each component can be substutided to make maintence easier
    and to support mocking for unit and integration testing.
    Each component shares a refrence to a common assembly/project which contians the interfance definitions, shared POCO data objects, and access to the singleton dependency injection kernel.

#### Assemblies

*   BetterCloud.CustomerAdmin.Common

        *   DataObjects - Simple .net objects that contains the data structures passed between layers
    *   Interfaces - Contians the component-level interfaces consumable by the system.
    *   Kernel - Singleton Dependency Injection provider.

                *   Allows components to retreive a configurable concerte object for one of the component interfaces
        *   Abstracts underlying Ninject DI provider
        *   Ninject is full-featured but not as performant as other DI frameworks. Abstracting allows for futher reasearch
                        and potential replacement without affecting dependant code.
    *   BetterCloud.CustomerAdmin.Common.Test - Unit Test project for Common component
*   BetterCloud.CustomerAdmin.Business

        *   Provides implementation of the Common.Business.ICustomerBusiness interface
    *   Contains all business rules and facalitates all operations on Customer data
    *   BetterCloud.CustomerAdmin.Busines.Tests

                *   Provides unit testing for CustomerBusiness
        *   Uses special Kernel configuration to Mock external components to reduce testing to Business functionality only
*   BetterCloud.CustomerAdmin.DataAccess.MSSQL

        *   Provides data storage for Customer data using a Microsoft SQL Server Database
    *   Other database providers can by substutided by replacing this assembly with another that implements Common.DataAccess.ICustomerData
    *   BetterCloud.CustomerAdmin.DataAccess.MSSQL.Tests - Provides Unit Tests for componment
*   BetterCloud.CustomerAdmin.Database

        *   MSSQL Datbase project for managing the database schema and stored procedures
    *   Generates publish scripts to create the Db from Scratch or produce and Update script for changes
*   BetterCloud.CustomerAdmin.Web

        *   .NET MVC Web Application
    *   Uses MVVM Pattern. The controllers respond to route defintions and bind the Views and as in a traditonal MVC archectecture,
                but uses the Common DataObjects as ViewModles to simplify binding data to Views while the Model handles the transfer of data via the Business Component
    *   Built from standard Visual Studio 2013 MVC Application template to save time on UX/UI Creation
    *   Assignment functionality build using new Customer contoller, Views, and Model
    *   BetterCloud.CustomerAdmin.Web.Tests - Provides Unit Testing for Web project

#### Technologies Used

*   IDE: Visual Studio 2013 Community Edition
*   Unit Testing Provided by MSTest

        *   Standard Platform with good integration support for Visual Studio
    *   Nunit also an option but prefer MSTest for the ease of use
*   Logging provided by log4net

        *   Industry standard for logging in .net applications
    *   Highly customizeable for using diffrent logging methods such a console, file, and other pluggins for logging to databases and other systems
*   Dependency Injection by Ninject

        *   Popular Opensorce framework
    *   Easy to configure and supports many scenarios
    *   Not as performant as other IoC's such as AutoFac or Funq
*   Gecoding.net

#### Other Notes:

*   Unit Testing - The actual unit tests in this project aren't as complete as I woudl like in a real production application
        I wanted to provide an example of how I go about creating unit tests and mocking the diffrent layers, but focused on other aspects
        of the exercise vs. fleshing out all the diffrent cases. Which would include full mocking of data to support both positive and negative
        results including expected exceptions.
*   Geocoding - I would have liked to have demonstrated a custom implemnation, but chose Geocoding.net for sake of time, and in reality
        I would have used this package vs creating my own and contributed to the existing project if customizations were required.

            My customer version would have made the service call via WebRequest and searlized the JSON data into a POCO object using JSON.net
*   Dependency Injection - I have the basic functionaly wrapped, but currenly only works with empty constructors. Ninject supports more options but
        I didn't feel it nesscary for this example to wrap more featurs such as IParamater to avoid other componetns other than Common being directly dependant on Ninject
