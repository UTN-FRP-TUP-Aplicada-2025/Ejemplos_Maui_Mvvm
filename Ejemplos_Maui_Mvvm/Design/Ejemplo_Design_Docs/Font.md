

## Fuente Material Icons Outlined

Fuente Material Icons Outlined se puede cargar directamente desde Google Fonts CDN, no necesitás descargarla manualmente.

[Visualizar iconos](https://fonts.google.com/icons?selected=Material+Icons+Outlined:home:&icon.size=24&icon.color=%231f1f1f)

##  CDN. Para incluir en el header html

```html
<head>
	<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons+Outlined">
</head>
```

##  Local. Para incluir en el header html

Para trabajarlo localmente hay que descargar el archivo desde [Google Fonts GitHub](https://github.com/google/material-design-icons/tree/master/font) ,
ahí se descarga el fichero MaterialIconsOutlined-Regular.otf, y se lo ubica luego en wwwroot/fonts/, 
y en el archivo ya dejé el bloque @font-face comentado listo para activar.

```css
@font-face {
    font-family: 'Material Icons Outlined';
    font-style: normal;
    font-weight: 400;
    src: url('fonts/MaterialIconsOutlined-Regular.otf') format('opentype');
}

.material-icons-outlined {
    font-family: 'Material Icons Outlined';
    font-weight: normal;
    font-style: normal;
    font-size: 24px;
    line-height: 1;
    letter-spacing: normal;
    text-transform: none;
    display: inline-block;
    white-space: nowrap;
    word-wrap: normal;
    direction: ltr;
    -webkit-font-smoothing: antialiased;
}
```