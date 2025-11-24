

## Generar una apk universal
Archivo de proyecto (.csproj):
```xml
<AndroidCreatePackagePerAbi>true</AndroidCreatePackagePerAbi>
```




```
dotnet publish -c Release -f net10.0-android
```

## Configuración Android con soporte de Paginas de 16k

Archivo de proyecto (.csproj):
```xml
	<!-- Configuración base para Android con soporte 16KB -->
	<PropertyGroup Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'">
		<AndroidLdFlags>-Wl,-z,max-page-size=16384</AndroidLdFlags>
		<AndroidUseAapt2>true</AndroidUseAapt2>
		<RuntimeIdentifiers>android-arm;android-arm64;android-x86;android-x64</RuntimeIdentifiers>
		<!--<AndroidUseWebKit>true</AndroidUseWebKit>	-->
		<AndroidCreatePackagePerAbi>true</AndroidCreatePackagePerAbi>
		<!-- Desactiva minificación en Debug
		<AndroidUseProguard>false</AndroidUseProguard>
		<AndroidEnableMultiDex>true</AndroidEnableMultiDex>
		 -->
	</PropertyGroup>
```

## Acortar las rutas de salida de compilación

Archivo de proyecto (.csproj):
```xml
<PropertyGroup>
		<TargetFrameworks>net10.0-android;net10.0-ios</TargetFrameworks>
		<BaseOutputPath>E:\bin\$(MSBuildProjectName)\</BaseOutputPath>
		<IntermediateOutputPath>E:\obj\$(MSBuildProjectName)\</IntermediateOutputPath>
		<ApplicationTitle>Ejemplo</ApplicationTitle>
</PropertyGroup>
```

## Acortar las rutas de la caché de NuGet

C:\Users\fernando\AppData\Roaming\NuGet\NuGet.Config:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
    <config>
		<add key="globalPackagesFolder" value="E:\.nuget\packages" />
		<add key="repositoryPath" value="E:\.nuget\NuGetPackages" />
	</config>
</configuration>
```


## versión que está usando


Archivo de proyecto (.csproj):
```xml
<PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
```

```bash
dotnet restore
dotnet build
```

```bash
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_HolaMundo> dotnet workload list

Versión de carga de trabajo: 10.0.100.1

Id. de carga de trabajo instalada      Versión del manifiesto      Origen de la instalación
-------------------------------------------------------------------------------------------------------------------------------------
android                                36.1.2/10.0.100             SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
ios                                    26.1.10494/10.0.100         SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
maccatalyst                            26.1.10494/10.0.100         SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
maui-windows                           10.0.0/10.0.100             SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8

Use "dotnet workload search" para buscar cargas de trabajo adicionales para instalar.
```


```bash
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_HolaMundo> dotnet list package
Restaurar correcto con 3 advertencias en 0,7s
    E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_HolaMundo\Ejemplo_HolaMundo.csproj : warning NU1608: Se detectó una versión del paquete fuera de la restricción de dependencia: CommunityToolkit.Maui 10.0.0 requiere Microsoft.Maui.Controls (>= 9.0.21 && < 10.0.0), pero la versión Microsoft.Maui.Controls 10.0.0 ya se resolvió.
    E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_HolaMundo\Ejemplo_HolaMundo.csproj : warning NU1608: Se detectó una versión del paquete fuera de la restricción de dependencia: CommunityToolkit.Maui.Core 10.0.0 requiere Microsoft.Maui.Core (>= 9.0.21 && < 10.0.0), pero la versión Microsoft.Maui.Core 10.0.0 ya se resolvió.
    E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_HolaMundo\Ejemplo_HolaMundo.csproj : warning NU1608: Se detectó una versión del paquete fuera de la restricción de dependencia: CommunityToolkit.Maui.Core 10.0.0 requiere Microsoft.Maui.Essentials (>= 9.0.21 && < 10.0.0), pero la versión Microsoft.Maui.Essentials 10.0.0 ya se resolvió.

Compilación correcto con 3 advertencias en 0,8s
El proyecto "Ejemplo_HolaMundo" tiene las referencias de paquete siguientes
   [net10.0-android36.0]:
   Paquete de nivel superior                    Solicitado   Resuelto
   > CommunityToolkit.Maui                      10.0.0       10.0.0
   > CommunityToolkit.Mvvm                      8.4.0        8.4.0
   > Microsoft.Extensions.Logging.Debug         10.0.0       10.0.0
   > Microsoft.Maui.Controls                    10.0.0       10.0.0
   > Microsoft.Maui.Core                        10.0.0       10.0.0
   > Microsoft.Maui.Essentials                  10.0.0       10.0.0
   > Microsoft.NET.ILLink.Tasks           (A)   [10.0.0, )   10.0.0

   [net10.0-ios26.1]:
   Paquete de nivel superior                    Solicitado   Resuelto
   > CommunityToolkit.Maui                      10.0.0       10.0.0
   > CommunityToolkit.Mvvm                      8.4.0        8.4.0
   > Microsoft.Extensions.Logging.Debug         10.0.0       10.0.0
   > Microsoft.Maui.Controls                    10.0.0       10.0.0
   > Microsoft.Maui.Core                        10.0.0       10.0.0
   > Microsoft.Maui.Essentials                  10.0.0       10.0.0
   > Microsoft.NET.ILLink.Tasks           (A)   [10.0.0, )   10.0.0

(A): paquete con referencia automática.
```
