
using Ejemplo_WebAPI_Encuestas.GraphQL;
using Ejemplo_WebAPI_Encuestas.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

#region restapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
#endregion

#region graphql
builder.Services
    .AddSingleton<EncuestasService>()
    .AddGraphQLSchema();
#endregion

var app = builder.Build();

app.UseWebSockets();

//app.MapGraphQL(); //caso sencillo

#region recursos estáticos
app.UseDefaultFiles();
app.UseStaticFiles();
#endregion

app.UseWebSockets();   // para los subscriptions
app.UseRouting();

app.MapGet("/", () => Results.Redirect("/graphql"));

//haceder con url/scalar
//if (app.Environment.IsDevelopment()) 
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGraphQL("/graphql");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();