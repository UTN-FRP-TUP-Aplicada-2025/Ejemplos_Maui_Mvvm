using Ejemplo_WebAPI_Encuestas.GraphQL.Mutations;
using Ejemplo_WebAPI_Encuestas.GraphQL.Queries;
using Ejemplo_WebAPI_Encuestas.GraphQL.Types;
using HotChocolate.Execution.Configuration;

namespace Ejemplo_WebAPI_Encuestas.GraphQL;

static public class SchemaConfig
{
    public static IRequestExecutorBuilder AddGraphQLSchema(this IServiceCollection services)
    {
        return services
            //
            .AddScoped<EncuestasQuery>() //Registra el servicio en el contenedor DI
            .AddScoped<EncuestasMutation>() //Registra el servicio en el contenedor DI
                                           //.AddScoped<PersonasSubscription>() //Registra el servicio en el contenedor DI

            //                                       
            .AddGraphQLServer()

            //queries
            .AddQueryType<Query>() //
                .AddType<EncuestasQuery>() // Expone los métodos de PersonasQuery como campos GraphQL

            //mutations
            .AddMutationType<Mutation>()//(d => d.Name("Mutation"))

            //subscriptions
            //.AddSubscriptionType<PersonasSubscription>()
            //    .AddSubscriptionType<Subscription>() // (d => d.Name("Subscription"))

            .AddSubscriptionType<Subscription>()

            //.AddSubscriptionType<Subscription>() // Registra la raíz
            //   .AddTypeExtension<PersonasSubscription>() // Extiende el tipo, no lo añade como objeto simple
            //    .AddType<PersonasSubscription>()

            .AddInMemorySubscriptions() //y canal de eventos

            //types
            .AddType<PersonaType>();
    }
}
