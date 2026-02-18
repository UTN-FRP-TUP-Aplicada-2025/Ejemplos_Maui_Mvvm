using Ejemplo_WebAPI_Encuestas.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Types;

public class EncuestaType : ObjectType<EncuestaModel>
{
    protected override void Configure(IObjectTypeDescriptor<EncuestaModel> descriptor)
    {
        descriptor.Name("Encuesta");

        descriptor.Field(p => p.Nombre).Type<NonNullType<StringType>>();

        descriptor.Field(p => p.FechaNacimiento).Type<NonNullType<DateTimeType>>();
    }
}