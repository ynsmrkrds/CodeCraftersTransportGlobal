# Transport Global Application

This project aims to create an e-service application that connects people with transportation needs from all around the world with the companies that provide transportation services, developed using the ASP.NET Core.

## Features

This application provides a platform for users to handle their transportation needs. Users can perform the following functions:

### 1. Creating Transport Requests

Customers can enter requests for transportation services such as home-to-home moving, office relocation, and transporting large and heavy cargo. They can create reservations based on the offers they receive.

### 2. Creating Transport Contracts

Shippers can submit offers to customers' open transport requests. Customers can review and accept these offers.

### 3. Viewing Company Information

Users can access detailed information about the vehicles used in transportation. They can obtain detailed information about the vehicle to be used in their reservation. Additionally, they can view information about the vehicle transportation team and see reviews from other users regarding these companies.

### 4. Communication

After creating transportation requests, customers can communicate with the shippers that submitted offers to customers' transport request through the messaging system within the application, ensuring efficient and smooth communication.

### 5. Evaluation

Upon completion of the transportation process, customers can provide feedback and ratings based on their experience. This helps guide other customers and improves the quality of services provided by companies on the platform.

## Technologies Used

The following technologies and tools were used in this project:

- C# programming language
- ASP.NET Core Web API for backend
- ASP.NET Core MVC for frontend
- MSSQL for database
- DDD for backend architecuture
- Entity Framework Core for ORM
- AutoMapper for mappings
- CQRS pattern to manage data
- RestSharp for HTTP requests
- GitHub for version control
- GitHub Projects to manage tasks
- Visual Studio to develop project
- Google Meet for meetings

## Installation

To run the application in your local development environment, you can follow these steps:

1. Clone this repository: `git clone https://github.com/ynsmrkrds/CodeCraftersTransportGlobal`
2. Open the project in Visual Studio or your preferred .NET IDE.
3. Use NuGet Package Manager to install dependencies.
4. Use Entity Framework Code First Migration to create the database and add data.
5. Start the applications (`TransportGlobal.API` and `TransportGlobalWeb.UI`) and use the local server's address to view it in your browser.

## Contributing

This project is open source, and we welcome contributions. If you find any issues or wish to add new features, please submit a pull request or open an issue.