using Ejemplo_WebAPI_Encuestas.DTOs;

namespace Ejemplo_WebAPI_Encuestas.GraphQL.Types;

public class EstadisticaType : ObjectType<EstadisticaDTO>
{
    protected override void Configure(IObjectTypeDescriptor<EstadisticaDTO> descriptor)
    {
        descriptor.Name("Estadistica");

        descriptor.Field(p => p.Encuestados).Type<NonNullType<IntType>>();

        descriptor.Field(p => p.EdadPromedio).Type<NonNullType<FloatType>>();

        descriptor.Field(p => p.Fecha).Type<NonNullType<DateTimeType>>();
    }
}