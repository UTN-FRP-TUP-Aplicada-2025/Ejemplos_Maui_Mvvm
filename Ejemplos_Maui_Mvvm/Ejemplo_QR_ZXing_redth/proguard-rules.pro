# Configuración de R8 para resolver conflictos de androidx.tracing

# Mantener todas las clases de tracing intactas
-keep class androidx.tracing.** { *; }
-keep interface androidx.tracing.** { *; }

# Mantener clases de Kotlin
-keep class kotlin.** { *; }
-keep interface kotlin.** { *; }

# Mantener clases de serialización de Kotlin
-keep class kotlinx.serialization.** { *; }
-keep interface kotlinx.serialization.** { *; }

# No optimizar o encriptar Kotlin synthetic
-keepclassmembers class ** {
    *** get*();
    void set*(***);
}
