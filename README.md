# ASP.Net WebApi Project Seed
Asp.Net WebAPI Seed Project. This project is created from the base ASP.NET 4.5.2 Web Application Template.
+ Repositories
+ API Controllers

## Getting Started
+ Clone the project
+ Refactor project namespace `WebApiSeed` with your prefered project name.
+ Run update packages `Update-Package`
+ Ensure migrations are correctly configured
+ Run `Update-Database`

## Project Structure
+ App_Data
+ App_Start
  * BundleConfig.cs
  * FilterConfig.cs
  * IdentityConfig.cs
  * RouteConfig.cs
  * Startup.Auth.cs
  * WebApiConfig.cs
+ Assets
  *Audio
  	* General.wav
  	* OrderIn.wav
  	* OrderReady.wav
  * Images
    * loading.gif
+ AxHelpher
  * DateHelpers.cs
  * ImageHelpers.cs
  * MessageHelpers.cs
  * NotificationHelpers.cs
  * StringHelpers.cs
  * WebHelpers.cs

+ Controllers
  * AccountController.cs
  * BasiApi.cs
  * HomeController.cs
+ DataAccess
  * Filters
    * BasiFilter.cs
    * UserFilter.cs
  * Repositories
    * BaseRepository.cs
    * ProfileRepository.cs
    * UserRepository.cs
+ Extensions
  * IdentityExtensions.cs
+ Migrations
  * Configuration.cs
+ Models
  * AccountBindingModels.cs
  * AccountViewModels.cs
  * AppDbContext.cs
  * EntitySet.cs
  * Keys.cs
+ Services
  * MessageProcessor.cs
  * ServicesScheduler.cs
+ Views
  * Home
    * Index.Html
  * Web.config
+ favicon.ico
+ Global.asax
+ Startup.cs
+ Web.config

This is a fork of https://github.com/adjeteyadjei/aspnet4-webapi-seed