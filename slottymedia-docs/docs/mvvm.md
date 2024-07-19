## Project Structure Based on the MVVM Principle

We fundamentally want to implement the MVVM principle in our project to enable unit testing for all methods, ensuring the functionality of our site. 

### Model (M)
The Model is responsible for managing the data in the database (Insert, Update, Delete, Get). In our project, this area is fundamentally divided into two parts:
- The **Model** folder, where all database DTOs are stored. These DTO Classes represent the tables in the database.
- The **Services** part, which is responsible for implementing actions for the individual models. CRUD actions are performed by directly accessing the database here. 

### ViewModel (VM)
The ViewModel serves to prepare data from the Model for the View and make it available to the View. It is not responsible for fetching or updating data from the database. Additionally, it ensures that actions in the Model are initiated and that data from the View is available to the Model. A separate ViewModel is created for each individual View, which is stored in the **ViewModel** folder.

### View (V)
The View is what the users ultimately see. It is solely for displaying data, capturing it, and passing it to the ViewModel. It is not intended to process data or write to the database. The Views are stored in the **Pages** folder.

### Integration
To use a Model and a ViewModel in a View, it is mandatory to register them in the `Program.cs` class.

#### Example
```csharp
    //Register ViewModels
    builder.Services.AddScoped<TestUserVm>();
```

