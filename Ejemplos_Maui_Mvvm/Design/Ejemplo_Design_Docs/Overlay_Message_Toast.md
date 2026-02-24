 
 
## Overlay de carga 

El estado de ocupado se representa con un overlay que bloquea la 
interacción y muestra un indicador de actividad. Esto es especialmente 
útil en formularios o procesos que requieren tiempo, como el registro o 
la carga de datos.


```
[ObservableProperty]
private bool isBusy = false;
```

En la pagina se agrega un Grid que contiene el contenido actual y
un overlay que se muestra cuando `IsBusy` es verdadero. El overlay 
tiene un fondo semitransparente para indicar que la aplicación está
ocupada, y un `ActivityIndicator` centrado para mostrar que se está
procesando algo. Con ZIndex se asegura que el overlay esté por 
encima del contenido.

```xml 
<Grid>
    <!-- Tu contenido actual -->
    <ScrollView>...</ScrollView>

    <!-- Overlay de carga -->
    <Grid IsVisible="{Binding IsBusy}" 
          BackgroundColor="#80FFFFFF"
          ZIndex="999">
        <ActivityIndicator IsRunning="{Binding IsBusy}"
                           Color="{StaticResource Primary}"
                           HorizontalOptions="Center"
                           VerticalOptions="Center"
                           WidthRequest="50"
                           HeightRequest="50"/>
    </Grid>
</Grid>
```

En el ViewModel, el comando que realiza el proceso pesado se encarga de 
establecer `IsBusy` en true al inicio y en false al finalizar, asegurando 
que el overlay    

```
[RelayCommand]
async private Task ProcesoPesado()
{
    if (IsBusy) return; // evita doble tap
    IsBusy = true;

    try
    {
        // ... invocando al procesado pesado!

        //... mensaje de exito!
    }
    catch (Exception ex)
    {
        // ...
    }
    finally
    {
        IsBusy = false; // siempre se limpia, incluso si hubo error
    }
```

## Uso de Opacity y BackgroundColor respecto al ActivityIndicator

### BackgroundColor 

Con el alpha en el BackgroundColor solo el fondo es transparente, 
el ActivityIndicator se mantiene al 100% de opacidad y se ve bien definido.

```xml

<Grid IsVisible="{Binding IsBusy}" 
      BackgroundColor="#80FFFFFF"
      ZIndex="999">
```

El #80 es el canal alpha en hex. #80 = 128/255 ≈ 50% de opacidad. Si querés más o menos transparencia cambiás ese valor:

```
#33FFFFFF → ~20% (casi transparente)
#80FFFFFF → ~50%
#B3FFFFFF → ~70%
#FFFFFFFF → 100% opaco (equivalente a blanco sólido)
```

### Opacity

Opacity afecta a todo el elemento y sus hijos, entonces el ActivityIndicator también se vuelve semitransparente y se ve desvanecido. 

```
<Grid IsVisible="{Binding IsBusy}" 
      BackgroundColor="White"
      Opacity="0.75"
      ZIndex="999">
```

## Feedback de resultado.

Toast / Snackbar: se usa para acciones secundarias o confirmaciones que 
no requieren atención inmediata (ej: "guardado automáticamente")

```csharp
await Toast.Make($"Registrado", ToastDuration.Long).Show();
```

Alert / Dialog: es para cuando el usuario necesita saber el resultado 
antes de continuar, especialmente en formularios con submit. El error 
en particular siempre merece un dialog porque el usuario tiene que tomar
una acción (reintentar, corregir datos, etc.)

```csharp
 await Shell.Current.DisplayAlertAsync("Error", $"No se pudo registrar: {ex.Message}", "OK");
 ```