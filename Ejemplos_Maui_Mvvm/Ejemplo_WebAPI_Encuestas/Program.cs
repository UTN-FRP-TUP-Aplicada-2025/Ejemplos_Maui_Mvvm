
using Ejemplo_WebAPI_Encuestas.GraphQL;
using Ejemplo_WebAPI_Encuestas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<EncuestasService>()
    .AddGraphQLSchema();

var app = builder.Build();

app.UseWebSockets();

//app.MapGraphQL(); //caso sencillo

app.UseRouting();
app.UseWebSockets();   // para los subscriptions

app.MapGet("/", () => Results.Redirect("/graphql"));

app.MapGraphQL("/graphql");

await app.RunAsync();