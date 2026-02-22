
## Ejemplos

```xml
<Shell.TitleView>
        <Grid ColumnDefinitions="*, *,Auto" VerticalOptions="Center" Padding="0,0,10,0">
           
            <ImageButton Grid.Column="2" BackgroundColor="Transparent" WidthRequest="24" HeightRequest="24" VerticalOptions="Center"  Command="{Binding HelpCommand}" CommandParameter="https://geometriafernando.somee.com/ver-encuesta-help.html">
                <ImageButton.Source>
                    <FontImageSource Glyph="help" FontFamily="MaterialIconsOutlined" Color="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
                </ImageButton.Source>
            </ImageButton>
            
        </Grid>
    </Shell.TitleView>
```

```
 <Shell.TitleView>
        <Grid ColumnDefinitions="*, *,Auto" VerticalOptions="Center" Padding="0,0,10,0">
            <!-- Columna vacía para empujar el ícono a la derecha -->
            <!--<BoxView Grid.Column="0" Color="Transparent"/>-->

            <!-- Ícono de ayuda a la derecha -->
            <!--<ImageButton Grid.Column="1"
                     WidthRequest="38"
                     HeightRequest="38"
                     CornerRadius="19"
                     BackgroundColor="{StaticResource Primary}"
                     Command="{Binding AyudaCommand}">
                <ImageButton.Source>
                    <FontImageSource Glyph="help" 
                                 FontFamily="MaterialIconsOutlined" 
                                 Color="White" 
                                 Size="22"/>
                </ImageButton.Source>
            </ImageButton>-->

            <ImageButton Grid.Column="2" BackgroundColor="Transparent" WidthRequest="24" HeightRequest="24" VerticalOptions="Center" Command="{Binding HelpCommand}" CommandParameter="https://geometriafernando.somee.com/ver-encuesta-help.html">
                <ImageButton.Source>
                    <FontImageSource Glyph="help" FontFamily="MaterialIconsOutlined" Color="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
                </ImageButton.Source>
            </ImageButton>
        </Grid>
    </Shell.TitleView>

```


alternativa provisoria
```xml
<Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto" Padding="16,10" HeightRequest="60">

            --><!--<ImageButton Grid.Column="0" BackgroundColor="Transparent" WidthRequest="24" HeightRequest="24" VerticalOptions="Center" 
                         Command="Back">
                <ImageButton.Source>
                    <FontImageSource Glyph="arrow_back" FontFamily="MaterialIconsOutlined" Color="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
                </ImageButton.Source>
            </ImageButton>--><!--

            <ImageButton Grid.Column="2" BackgroundColor="Transparent" WidthRequest="24" HeightRequest="24" VerticalOptions="Center" 
                         Command="{Binding HelpCommand}" CommandParameter="https://geometriafernando.somee.com/ver-estadistica-help.html">
                <ImageButton.Source>
                    <FontImageSource Glyph="help" FontFamily="MaterialIconsOutlined" Color="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
                </ImageButton.Source>
            </ImageButton>
        </Grid>
```

```xml
<Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto" Padding="16,10" HeightRequest="60">

            <ImageButton Grid.Column="0" BackgroundColor="Transparent" WidthRequest="24" HeightRequest="24" VerticalOptions="Center" Command="{Binding GoBackCommand}">
                <ImageButton.Source>
                    <FontImageSource Glyph="chevron_left" FontFamily="MaterialIconsOutlined" Color="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
                </ImageButton.Source>
            </ImageButton>

            <ImageButton Grid.Column="2" BackgroundColor="Transparent" WidthRequest="24" HeightRequest="24" VerticalOptions="Center" Command="{Binding HelpCommand}" CommandParameter="https://geometriafernando.somee.com/ver-encuesta-help.html">
                <ImageButton.Source>
                    <FontImageSource Glyph="help" FontFamily="MaterialIconsOutlined" Color="{AppThemeBinding Light={StaticResource Primary}, Dark={StaticResource PrimaryDark}}" />
                </ImageButton.Source>
            </ImageButton>
            
        </Grid>
        ```