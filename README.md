# CSE 210 — Programming with Classes (C#)

Repositorio académico con ejercicios y proyectos de programación orientada a objetos en **C# y .NET**. El material está organizado por semanas según el curso CSE 210 de BYU–Idaho.

> Este repositorio reúne **trabajos de formación**. No representa por sí solo aplicaciones comerciales listas para producción.

## Proyectos con implementaciones observables

| Ruta | Tema | Qué demuestra |
| --- | --- | --- |
| `week02/Journal` | Clases y datos | Entradas de diario, archivos de texto y persistencia |
| `week03/ScriptureMemorizer` | Encapsulación | Clases para referencia, texto y palabras |
| `week04/OnlineOrdering` | Diseño de objetos | Producto, cliente, dirección, orden y cálculo de costos |
| `week04/YouTubeVideos` | Composición | Videos y comentarios |
| `week05/Mindfulness` | Herencia | Clase abstracta de actividad y actividades derivadas |
| `week06/EternalQuest` | Polimorfismo | Metas con comportamientos distintos, puntajes y persistencia |

También hay carpetas de ejercicios iniciales y **plantillas parcialmente vacías**, como `week03/Fractions`, `week05/Homework`, `week06/Shapes` y `week07/ExerciseTracking`. No se presentan como ejercicios terminados.

## Ejecución

Los proyectos son aplicaciones de consola independientes y utilizan `.csproj`. Ejemplos:

```bash
dotnet run --project week04/OnlineOrdering/OnlineOrdering.csproj
dotnet run --project week05/Mindfulness/Mindfulness.csproj
dotnet run --project week06/EternalQuest/EternalQuest.csproj
```

Instalá el **SDK .NET 10** para compilar los proyectos que declaran `net10.0`. Verificá el `TargetFramework` del proyecto elegido.

Para compilar uno de los ejemplos:

```bash
dotnet build week06/EternalQuest/EternalQuest.csproj
```

## Principios practicados

- **Encapsulación:** separación de estado y métodos en clases.
- **Composición:** objetos que agrupan otros objetos.
- **Herencia:** reutilización de comportamiento mediante una clase base.
- **Polimorfismo:** implementación de métodos abstractos o virtuales en clases derivadas.
- **Persistencia básica:** lectura y escritura de archivos.

## Alcance y próximos pasos

Son proyectos formativos, no sistemas multiusuario. Algunas rutas tienen código de plantilla, y algunas operaciones de persistencia necesitan validación adicional ante archivos dañados o formatos inesperados. Conviene ejecutar y probar cada proyecto antes de reutilizarlo.

Para proyectos empresariales y experiencia laboral: [Portfolio](https://etorri.com.ar/) · [Perfil GitHub](https://github.com/enzotorricella).

**Autor:** Enzo Torricella.
