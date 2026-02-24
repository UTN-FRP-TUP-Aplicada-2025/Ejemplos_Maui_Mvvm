

El Opacity y el BackgroundColor con alpha se pisan entre sí, estás aplicando 
transparencia dos veces. Tenés que elegir uno solo:

Solo con el alpha del color (recomendada)

```
<Grid IsVisible="{Binding IsBusy}" 
      BackgroundColor="#80FFFFFF"
      ZIndex="999">
```

El #80 es el canal alpha en hex. #80 = 128/255 ≈ 50% de opacidad. Si querés más o menos transparencia cambiás ese valor:

#33FFFFFF → ~20% (casi transparente)
#80FFFFFF → ~50%
#B3FFFFFF → ~70%
#FFFFFFFF → 100% opaco (equivalente a blanco sólido)