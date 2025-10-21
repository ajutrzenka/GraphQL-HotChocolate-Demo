A simple demo with example usage of HotChocolate GraphQL server .NET framework.

It demonstrates API similar to those used in Polish aeroclubs to keep tracking flights and progress of pilots and students (Timekeeping = Polish "chronometraż").

Keep in mind, it is only API demo, it does not contain any complex business logic nor data valiation.

Startup project uses AspNetCore.WebApi Visual Studio template. 
Example data is stored locally in SQLite database (chosen as being very simple and lightweight solution), which is handled by EntityFramework Core.
