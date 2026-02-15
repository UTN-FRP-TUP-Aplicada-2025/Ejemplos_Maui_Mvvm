
## Descripción

comandos para verificar los frameworks y workloads instalados, 
las cargas de trabajo disponibles, instalar un workload específico,
limpiar los manifiestos corruptos, reparar las cargas de trabajo instaladas 
y definir los sdks instalados.

## Ver frameworks y workloads usados 
```
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_QR_BarcodeScanner> dotnet --info
SDK DE .NET:
 Version:           10.0.100
 Commit:            b0f34d51fc
 Workload version:  10.0.100.1
 MSBuild version:   18.0.2+b0f34d51f

Entorno de tiempo de ejecución:
 OS Name:     Windows
 OS Version:  10.0.20348
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\10.0.100\

Cargas de trabajo de .NET instaladas:
 [android]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    36.1.2/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.android\36.1.2\WorkloadManifest.json
   Tipo de instalación:              Msi

 [ios]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    26.1.10494/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.ios\26.1.10494\WorkloadManifest.json
   Tipo de instalación:              Msi

 [maccatalyst]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    26.1.10494/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.maccatalyst\26.1.10494\WorkloadManifest.json
   Tipo de instalación:              Msi

 [maui-windows]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    10.0.0/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.maui\10.0.0\WorkloadManifest.json
   Tipo de instalación:              Msi

Configurado para usar workload sets al instalar nuevos manifiestos.

Host:
  Version:      10.0.0
  Architecture: x64
  Commit:       b0f34d51fc

.NET SDKs installed:
  8.0.406 [C:\Program Files\dotnet\sdk]
  9.0.308 [C:\Program Files\dotnet\sdk]
  10.0.100 [C:\Program Files\dotnet\sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 8.0.13 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 8.0.22 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 9.0.11 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 10.0.0 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 8.0.13 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 8.0.22 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 9.0.11 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 10.0.0 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.WindowsDesktop.App 8.0.13 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 8.0.22 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 9.0.11 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 10.0.0 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]

Other architectures found:
  x86   [C:\Program Files (x86)\dotnet]
    registered at [HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\x86\InstallLocation]

Environment variables:
  DOTNET_CLI_UI_LANGUAGE                   [es-ES]
  DOTNET_GCHeapCount                       [2]
  DOTNET_GCNoAffinitize                    [1]
  DOTNET_MULTILEVEL_LOOKUP                 [0]
  DOTNET_TC_CallCountThreshold             [1000]
  DOTNET_ThreadPool_UnfairSemaphoreSpinLimit [0]
  DOTNET_gcConcurrent                      [0]
  Detected COMPlus_* environment variable(s). Consider transitioning to DOTNET_* equivalent.

global.json file:
  Not found

Learn more:
  https://aka.ms/dotnet/info

Download .NET:
  https://aka.ms/dotnet/download
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_QR_BarcodeScanner>

```

## Ver las cargas de trabajo instaladas

```bash
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm> dotnet workload list

Versión de carga de trabajo: 10.0.100-manifests.5fb86115

Id. de carga de trabajo instalada      Versión del manifiesto      Origen de la instalación
-----------------------------------------------------------------------------------------------------------------------
android                                36.1.2/10.0.100             VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
ios                                    26.1.10494/10.0.100         VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
maccatalyst                            26.1.10494/10.0.100         VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
maui-windows                           10.0.0/10.0.100             VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8

Use "dotnet workload search" para buscar cargas de trabajo adicionales para instalar.
```


## Ver las cargas disponibles

```bash
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm> dotnet workload search

Id. de carga de trabajo         Descripción
----------------------------------------------------------------------------------------
android                         .NET SDK Workload for building Android applications.
ios                             .NET SDK Workload for building iOS applications.
maccatalyst                     .NET SDK Workload for building MacCatalyst applications.
macos                           .NET SDK Workload for building macOS applications.
maui                            .NET MAUI SDK for all platforms
maui-android                    .NET MAUI SDK for Android
maui-desktop                    .NET MAUI SDK for Desktop
maui-ios                        .NET MAUI SDK for iOS
maui-maccatalyst                .NET MAUI SDK for Mac Catalyst
maui-mobile                     .NET MAUI SDK for Mobile
maui-tizen                      .NET MAUI SDK for Tizen
maui-windows                    .NET MAUI SDK for Windows
mobile-librarybuilder           workloads/mobile-librarybuilder/description
mobile-librarybuilder-net9      workloads/mobile-librarybuilder-net9/description
tvos                            .NET SDK Workload for building tvOS applications.
wasi-experimental               workloads/wasi-experimental/description
wasi-experimental-net8          workloads/wasi-experimental-net8/description
wasi-experimental-net9          workloads/wasi-experimental-net9/description
wasm-experimental               Herramientas experimentales .NET WebAssembly
wasm-experimental-net7          workloads/wasm-experimental-net7/description
wasm-experimental-net8          workloads/wasm-experimental-net8/description
wasm-experimental-net9          Herramientas experimentales .NET 9.0 WebAssembly
wasm-tools                      Herramientas de compilación de WebAssembly de .NET
wasm-tools-net6                 Herramientas de compilación de WebAssembly de .NET
wasm-tools-net7                 Herramientas de compilación de WebAssembly de .NET
wasm-tools-net8                 Herramientas de compilación de WebAssembly de .NET 8.0
wasm-tools-net9                 Herramientas de compilación de WebAssembly de .NET 9.0
```

## instalar un workload espcifico
```bash
dotnet workload install maui
```

## limpia los manifiestos corruptos
```bash
dotnet workload clean
```

## reparar las cargas de trabajo instaladas

```bash
dotnet workload list --verbosity detailed
dotnet workload clean
dotnet workload repair
dotnet workload update
```


## define los sdks instalados

```bash
PS E:\repos\tup\aplicada\2025\utn\Ejemplos_Maui_Mvvm\Ejemplos_Maui_Mvvm\Ejemplo_HolaMundo> dotnet --info
SDK DE .NET:
 Version:           10.0.100
 Commit:            b0f34d51fc
 Workload version:  10.0.100.1
 MSBuild version:   18.0.2+b0f34d51f

Entorno de tiempo de ejecución:
 OS Name:     Windows
 OS Version:  10.0.20348
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\10.0.100\

Cargas de trabajo de .NET instaladas:
 [android]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    36.1.2/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.android\36.1.2\WorkloadManifest.json
   Tipo de instalación:              Msi

 [ios]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    26.1.10494/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.ios\26.1.10494\WorkloadManifest.json
   Tipo de instalación:              Msi

 [maccatalyst]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    26.1.10494/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.maccatalyst\26.1.10494\WorkloadManifest.json
   Tipo de instalación:              Msi

 [maui-windows]
   Origen de la instalación: SDK 10.0.100, VS 18.0.11222.15, VS 18.3.11222.16, VS 17.14.36717.8
   Versión del manifiesto:    10.0.0/10.0.100
   Ruta de acceso del manifiesto:       C:\Program Files\dotnet\sdk-manifests\10.0.100\microsoft.net.sdk.maui\10.0.0\WorkloadManifest.json
   Tipo de instalación:              Msi

Configurado para usar workload sets al instalar nuevos manifiestos.

Host:
  Version:      10.0.0
  Architecture: x64
  Commit:       b0f34d51fc

.NET SDKs installed:
  8.0.406 [C:\Program Files\dotnet\sdk]
  9.0.308 [C:\Program Files\dotnet\sdk]
  10.0.100 [C:\Program Files\dotnet\sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 8.0.13 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 8.0.22 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 9.0.11 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.AspNetCore.App 10.0.0 [C:\Program Files\dotnet\shared\Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 8.0.13 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 8.0.22 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 9.0.11 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.NETCore.App 10.0.0 [C:\Program Files\dotnet\shared\Microsoft.NETCore.App]
  Microsoft.WindowsDesktop.App 8.0.13 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 8.0.22 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 9.0.11 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]
  Microsoft.WindowsDesktop.App 10.0.0 [C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App]

Other architectures found:
  x86   [C:\Program Files (x86)\dotnet]
    registered at [HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\x86\InstallLocation]

Environment variables:
  DOTNET_CLI_UI_LANGUAGE                   [es-ES]
  DOTNET_GCHeapCount                       [2]
  DOTNET_GCNoAffinitize                    [1]
  DOTNET_MULTILEVEL_LOOKUP                 [0]
  DOTNET_TC_CallCountThreshold             [1000]
  DOTNET_ThreadPool_UnfairSemaphoreSpinLimit [0]
  DOTNET_gcConcurrent                      [0]
  Detected COMPlus_* environment variable(s). Consider transitioning to DOTNET_* equivalent.

global.json file:
  Not found

Learn more:
  https://aka.ms/dotnet/info

Download .NET:
  https://aka.ms/dotnet/download
```