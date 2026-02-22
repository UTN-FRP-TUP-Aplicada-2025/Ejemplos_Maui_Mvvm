
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using Ejemplo_WebAPI_Encuestas.GraphQL;
using Ejemplo_WebAPI_Encuestas.Identity;
using Ejemplo_WebAPI_Encuestas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

#region identity server
builder.Services.AddSingleton<IUserService, InMemoryUserService>();

builder.Services
    .AddIdentityServer()
    .AddInMemoryApiScopes(new[]
    {
        new ApiScope("api1", "offline_access")
    })
    .AddInMemoryClients(new[]
    {
        new Client
        {
            ClientId = "client_id",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("secret".Sha256()) },
            AllowedScopes = { "api1", "offline_access" },
            AllowOfflineAccess = true, //habilita, refresh tokens

            //adicionales para refresh tokens
            AccessTokenLifetime = 3600,
            RefreshTokenUsage = TokenUsage.ReUse,
            RefreshTokenExpiration = TokenExpiration.Sliding,
            SlidingRefreshTokenLifetime = 2592000 // 30 días
        }
    })
    .AddDeveloperSigningCredential();

builder.Services.AddTransient<IResourceOwnerPasswordValidator, CustomProfileService>();
builder.Services.AddTransient<IProfileService, CustomProfileService>();
#endregion

#region restapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
#endregion

#region graphql
builder.Services
    .AddSingleton<EncuestasService>()
    .AddGraphQLSchema()
    .AddAuthorization();
#endregion

#region JWT validation (misma app)
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        //options.Authority = "https://localhost:7041"; // esta misma app
        options.Authority = "https://geometriafernando.somee.com"; // esta misma app
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters.ValidateAudience = false;
    });

//builder.Services
//.AddAuthentication("Bearer")
//.AddJwtBearer("Bearer", options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters.ValidateAudience = false;

//    options.Events = new JwtBearerEvents
//    {
//        OnMessageReceived = context =>
//        {
//            var request = context.HttpContext.Request;
//            var issuer = $"{request.Scheme}://{request.Host}";
//            context.Options.Authority = issuer;
//            return Task.CompletedTask;
//        }
//    };
//});

//builder.Services
//    .AddAuthentication("Bearer")
//    .AddJwtBearer("Bearer", options =>
//    {
//        options.RequireHttpsMetadata = false;

//        options.TokenValidationParameters = new()
//        {
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = false
//        };
//    });

builder.Services.AddAuthorization();
#endregion

var app = builder.Build();
app.UseHttpsRedirection();

//app.MapGraphQL(); //caso sencillo

#region recursos estáticos
app.UseDefaultFiles();

app.Use(async (ctx, next) =>
{
    var path = ctx.Request.Path.Value;

    if (!string.IsNullOrEmpty(path) &&
        path.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
    {
        var env = ctx.RequestServices.GetRequiredService<IWebHostEnvironment>();
        var filePath = System.IO.Path.Combine(env.WebRootPath, path.TrimStart('/'));

        if (File.Exists(filePath))
        {
            ctx.Response.ContentType = "text/html; charset=utf-8";

            // 🔥 lectura manual → evita sendfile / kernel cache / líos HTTP2
            var bytes = await File.ReadAllBytesAsync(filePath);
            await ctx.Response.Body.WriteAsync(bytes);

            return; // 🚨 IMPORTANTÍSIMO
        }
    }

    await next();
});

app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.DoNotCompress,
    ContentTypeProvider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider
    {
        Mappings =
        {
            [".json"] = "application/json; charset=utf-8"
        }
    }
});

/*
//app.UseStaticFiles();

//app.UseStaticFiles(new StaticFileOptions
//{
//    ServeUnknownFileTypes = true,
//    HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.DoNotCompress,
//    ContentTypeProvider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider
//    {
//        Mappings =
//        {
//            [".html"] = "text/html; charset=utf-8",
//            [".json"] = "application/json; charset=utf-8"
//        }
//    },
//    DefaultContentType = "application/octet-stream",
//    FileProvider = app.Environment.WebRootFileProvider,
//    OnPrepareResponse = ctx =>
//    {
//        if (ctx.File.Name.EndsWith(".html"))
//        {
//            ctx.Context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
//        }
//        else if (ctx.File.Name.EndsWith(".json"))
//        {
//            ctx.Context.Response.Headers["Content-Type"] = "application/json; charset=utf-8";
//        }
//    }

//});

//app.UseStaticFiles(new StaticFileOptions
//{
//    OnPrepareResponse = ctx =>
//    {
//        if (ctx.File.Name.EndsWith(".html"))
//        {
//            ctx.Context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
//        }
//    }
//});
*/
#endregion

app.UseWebSockets();   // para los subscriptions
app.UseRouting();

//IdentityServer (emite tokens)
app.UseIdentityServer();     // EMITE TOKENS

// AuthN / AuthZ (orden IMPORTANTE)
//app.UseAuthorization();
app.UseAuthentication(); // VALIDA TOKENS
app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/graphql"));

// OpenAPI / Scalar (podés condicionar por env si querés)
//haceder con url/scalar
//if (app.Environment.IsDevelopment()) 
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// GraphQL
app.MapGraphQL("/graphql");

// Controllers
app.MapControllers();

/*
//app.MapGet("/proxy", async (string url) =>
//{
//    if (string.IsNullOrWhiteSpace(url))
//        return Results.BadRequest("url requerida");

//    try
//    {
//        var handler = new HttpClientHandler
//        {
//            AutomaticDecompression =
//                System.Net.DecompressionMethods.GZip |
//                System.Net.DecompressionMethods.Deflate
//        };

//        using var http = new HttpClient(handler);

//        var response = await http.GetAsync(url);
//        var content = await response.Content.ReadAsStringAsync();

//        return Results.Content(content, "text/html; charset=utf-8");
//    }
//    catch (Exception ex)
//    {
//        return Results.Problem(ex.Message);
//    }
//});

//app.MapGet("/ver-estadistica-help.html", async (HttpContext ctx, IWebHostEnvironment env) =>
//{
//    var file = System.IO.Path.Combine(env.WebRootPath, "ver-estadistica-help_.html");

//    ctx.Response.ContentType = "text/html; charset=utf-8";

//    var bytes = await File.ReadAllBytesAsync(file);
//    await ctx.Response.Body.WriteAsync(bytes);
//});

//app.MapGet("/privacy-policy.html", async (HttpContext ctx, IWebHostEnvironment env) =>
//{
//    var file = System.IO.Path.Combine(env.WebRootPath, "privacy-policy_.html");

//    ctx.Response.ContentType = "text/html; charset=utf-8";

//    var bytes = await File.ReadAllBytesAsync(file);
//    await ctx.Response.Body.WriteAsync(bytes);
//});
*/

await app.RunAsync();