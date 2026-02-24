 
 
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

```
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