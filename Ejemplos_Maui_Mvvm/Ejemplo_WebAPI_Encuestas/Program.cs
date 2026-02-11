
using Ejemplo_WebAPI_Encuestas.GraphQL;
using Ejemplo_WebAPI_Encuestas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<EncuestasService>()
    .AddGraphQLSchema();

var app = builder.Build();

app.UseWebSockets();

//app.MapGraphQL(); //caso sencillo


#region paginas estaticas
app.UseDefaultFiles();
app.UseStaticFiles();
#endregion

app.UseWebSockets();   // para los subscriptions
app.UseRouting();

app.MapGet("/", () => Results.Redirect("/graphql"));


app.MapGraphQL("/graphql");

await app.RunAsync();