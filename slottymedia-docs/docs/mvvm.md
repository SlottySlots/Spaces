# Project Structure Based on the MVVM Principle

In our project, we implement the MVVM principle to enable unit tests for all methods and ensure the functionality of our site. This structure provides good abstraction, allowing us to easily change components in the Model or ViewModel without impacting other parts of the project.

## Model (M)
The Model manages the data in the database (Insert, Update, Delete, Get). This area is divided into two parts:

- **Models Folder**: This is where all database DTOs (Data Transfer Objects) are stored, representing the tables in the database.
- **Services Folder**: This part implements actions for individual models. CRUD actions (Create, Read, Update, Delete) are performed here by directly accessing the database.

## ViewModel (VM)
The ViewModel prepares data from the Model for the View and makes it available to the View. It does not fetch or update data from the database. The ViewModel ensures that actions in the Model are initiated and that data from the View is available to the Model. A separate ViewModel is created for each View and is stored in the **ViewModel Folder**.

## View (V)
The View is the user interface that the users see. It is solely responsible for displaying data, capturing input, and passing it to the ViewModel. The View does not process data or write to the database. The Views are stored in the **Pages Folder**.

## Integration
To use a Model and a ViewModel in a View, they must be registered in the `Program.cs` file.

### Example
```csharp
// Register ViewModels
builder.Services.AddScoped<TestUserVm>();
```