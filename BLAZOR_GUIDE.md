# RefConnect - Blazor Integration

## What is Blazor?

Blazor is a modern web UI framework from Microsoft that allows you to build interactive web applications using C# instead of JavaScript. It's similar to React, Vue, or Angular, but uses C# and .NET instead of JavaScript.

## Features Implemented

### ✅ Interactive Sidebar Component
- **Location**: `/Components/Layout/Sidebar.razor`
- **Features**:
  - Collapsible sidebar (expands on hover)
  - Smooth animations
  - Responsive design (mobile-friendly)
  - Dark mode support
  - Navigation links for all your models

### ✅ Dashboard Page
- **Location**: `/Components/Pages/Home.razor`
- **Features**:
  - Welcome screen with statistics cards
  - Recent activity feed
  - Responsive grid layout

### ✅ Championships Page (Example CRUD)
- **Location**: `/Components/Pages/Championships.razor`
- **Features**:
  - List championships
  - Add new championship (with form)
  - Edit championship
  - Delete championship
  - Demonstrates Blazor forms and data binding

## Project Structure

```
RefConnect/
├── Components/
│   ├── App.razor                    # Root Blazor app component
│   ├── Routes.razor                 # Routing configuration
│   ├── _Imports.razor              # Global using statements
│   ├── Layout/
│   │   ├── MainLayout.razor        # Main layout with sidebar
│   │   ├── MainLayout.razor.css    # Layout styles
│   │   ├── Sidebar.razor           # Interactive sidebar component
│   │   └── Sidebar.razor.css       # Sidebar styles
│   └── Pages/
│       ├── Home.razor              # Dashboard/home page
│       ├── Home.razor.css
│       ├── Championships.razor     # Championships CRUD page
│       └── Championships.razor.css
├── Controllers/                     # Your existing MVC controllers
├── Models/                         # Your database models
└── Views/                          # Your existing Razor views
```

## How to Run

1. **Build the project**:
   ```bash
   dotnet build
   ```

2. **Run the application**:
   ```bash
   cd RefConnect
   dotnet run
   ```

3. **Access the application**:
   - Open your browser and navigate to: `https://localhost:5001` (or the port shown in terminal)

## Key Differences: Blazor vs React

| Feature | React | Blazor |
|---------|-------|--------|
| Language | JavaScript/TypeScript | C# |
| State Management | useState, useContext | Private fields, @code blocks |
| Rendering | JSX | Razor syntax (@if, @foreach) |
| Events | onClick={handler} | @onclick="Handler" |
| Two-way binding | Controlled components | @bind-Value |
| Styling | CSS-in-JS, Tailwind | Scoped CSS files (.razor.css) |
| Dependencies | npm packages | NuGet packages |

## Blazor Syntax Examples

### 1. Component with State
```razor
@code {
    private bool isOpen = false;
    
    private void Toggle()
    {
        isOpen = !isOpen;
    }
}
```

### 2. Conditional Rendering
```razor
@if (isOpen)
{
    <div>Content is visible</div>
}
```

### 3. Loops
```razor
@foreach (var item in items)
{
    <div>@item.Name</div>
}
```

### 4. Event Handlers
```razor
<button @onclick="Toggle">Toggle</button>
```

### 5. Two-way Data Binding
```razor
<input @bind="userName" />
<p>Hello, @userName!</p>
```

## Creating New Pages

To create a new Blazor page:

1. Create a new `.razor` file in `/Components/Pages/`
2. Add the `@page` directive with the route
3. Add `@rendermode InteractiveServer` for interactivity
4. Write your component code

Example:
```razor
@page "/mypage"
@rendermode InteractiveServer

<h1>My Page</h1>
<p>Counter: @count</p>
<button @onclick="Increment">Click me</button>

@code {
    private int count = 0;
    
    private void Increment()
    {
        count++;
    }
}
```

## Integrating with Your Database

To use your existing models with Blazor:

1. **Inject DbContext** in your component:
   ```razor
   @inject AppDbContext DbContext
   ```

2. **Load data** in `OnInitializedAsync`:
   ```razor
   @code {
       private List<Championship> championships = new();
       
       protected override async Task OnInitializedAsync()
       {
           championships = await DbContext.Championships.ToListAsync();
       }
   }
   ```

3. **Display the data**:
   ```razor
   @foreach (var championship in championships)
   {
       <div>@championship.numeChampionat</div>
   }
   ```

## Next Steps

1. **Create Blazor pages for your other models**:
   - Matches.razor
   - Teams.razor
   - Posts.razor
   - Comments.razor
   - GroupChats.razor
   - Referees.razor

2. **Integrate with your database**:
   - Inject `AppDbContext` into your components
   - Replace sample data with actual database queries

3. **Add authentication**:
   - Implement user login/logout
   - Protect routes with `[Authorize]` attribute

4. **Enhance the UI**:
   - Add more interactive components
   - Implement real-time updates with SignalR
   - Add charts and visualizations

## Resources

- [Blazor Documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
- [Blazor Tutorial](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro)
- [Blazor Components](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/)
- [Blazor Forms](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/)

## Benefits of Using Blazor

✅ **Single Language**: Use C# for both frontend and backend  
✅ **Type Safety**: Compile-time checking for your UI code  
✅ **Code Sharing**: Share models and logic between client and server  
✅ **Performance**: Runs on WebAssembly or Server-side with SignalR  
✅ **Tooling**: Full Visual Studio/Rider support with IntelliSense  
✅ **Integration**: Seamless integration with existing ASP.NET Core apps

Enjoy building with Blazor! 🚀

