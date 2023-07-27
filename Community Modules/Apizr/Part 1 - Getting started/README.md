
## Getting Started

### Apizr Introduction

Apizr has been created for faciliting the configuration, implementation and usage of "advanced" API client (HttpClient) service/instance, with the best practices, the integration of powerfull and frequently used third parties librairies, new and common patterns in mind (fluent, attributes), and years of experiences (and real implementations) in our customers projects (according to our developers/company choices and point of view, therefore necessarily subjective...)

As mobile applications developpers, we get rid of doing again the same things on each new project, and we create this library to help us to configure quickly and easily all our Api Clients in all our different projects, in the same "standard-way" (or "code-habits"), with the less code/boilerplate as possible, and the more configuration/customization as possible.

In this workshop, we will see the "basics" of Apizr (implementation and uses) but we have lots of extensions and advanced usages around this core library (with separate extension NuGet Packages, to include only what you realy need).

The "advantages" of Apizr will not be obvious in this workshop (because this sample is very to much simple, with just one very simple "GET" endpoint), but in more complex projects with more complex functionnal needs and advanced scenarios, Apizr will better reveal all is potential !

So in this workshop we simply will learn how to add/migrate/use Apizr on an existing project, and extend it step by step to offer some nice and usual basic features.

You can find more updated informations and more complex scenario on the [GitHub repo](https://github.com/Respawnsive/Apizr) or in the documentation :

[![Read - Documentation](https://img.shields.io/badge/read-documentation-blue?style=for-the-badge)](https://apizr.net/ "Go to project documentation")

This project is Open-Source and will have a "minimum viable support" (as our company use it in production on all our customer project).
So feel free to use it, and all your remarks, suggestions and contributions are welcome !

And if you realy like it, please consider to give us a star on GitHub, and/or to support our work on [GitHub Sponsors](https://github.com/sponsors/Respawnsive)


### Open Solution in Visual Studio

1. Open **Part 1 - Getting Started/MonkeyFinder.sln**

This MonkeyFinder contains 1 project:

* MonkeyFinder - The main .NET MAUI project that targets Android, iOS, macOS, and Windows. It includes all scaffolding for the app including Models, Views, ViewModels, and Services.


The **MonkeyFinder** project is the result of the MAUI workshop, and is complete at this point (MauiProgram, Model, Views, ViewModels, and Services) and will be used as a reference for the Hands on Lab.


### Build, run and debug the app

Try to build and run the app on Android, iOS, macOS, and/or Windows.
If all is ok, you are ready for this workshop and can continue with the next step.
Otherwise, please check the original MAUI workshop to fix your environment.

### Add Apizr to the project

TODO

### Run the App

TODO

old markdown stuctured sample :

---

Ensure that you have your machine setup to deploy and debug to the different platforms:

* [Android Emulator Setup](https://docs.microsoft.com/dotnet/maui/)
* [Windows setup for development](https://docs.microsoft.com/dotnet/maui/windows/setup)

1. In Visual Studio, set the Android or Windows app as the startup project by selecting the drop down in the debug menu and changing the `Framework`

2. In Visual Studio, click the "Debug" button or Tools -> Start Debugging
    - If you are having any trouble, see the Setup guides for your runtime platform

Running the app will result in a list of three monkeys:

![App running on Android showing 3 monkeys](../Art/CodedMonkeys.png)

Let's continue and learn about using the MVVM pattern with data binding in [Part 2](../Part%202%20-%20MVVM/README.md)

---

TODO
