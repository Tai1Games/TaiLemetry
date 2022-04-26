[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# Tailemetry

Paquete de telemetria desarrollado para los juegos de tai1games

- [Instalación](#instalación)
- [Configuración](#configuración)
- [Instrucciones de uso](#instrucciones-de-uso)

# Instalación

## Con URL de Git

### Manualmente

Abre `Packages/manifest.json` con cualquier editor de texto. Añade este fragmento de texto en la parte de dependencias:

```json
{
  "dependencies": {
    "com.tai1games.TaiLemetry": "https://github.com/tai1games/TaiLemetry.git"
  }
}
```

### Desde el Package Manager

Abrir el Package Manager de Unity (Window > PackageManager) y pulsar el boton de arriba a la izquiera > Add package from git Url. Escribir la Url del servidor de git ( https://github.com/Tai1Games/TaiLemetry ) en la caja que aparezca.

## Descargandose el paquete en local

Despues de decargarse el zip del paquete del [github de tailemetry](https://github.com/Tai1Games/TaiLemetry), abrir el Package Manager de Unity (Window > PackageManager) y añadirlo pulsando el boton de arriba a la izquiera > Add package from disk.

---
# Instrucciones de uso

Para poder trackear eventos hay que crear un tracker e inicializarlo:

```C#
tracker = new Tracker();
tracker.Init();
```

Después se puede usar este tracker para registrar trazas:

```C#
TrackerEv ev = new TrackerEv();
ev.EventType = "SessionStarted";
tracker.TrackEvent(ev);
```

El eventType es un string que se usa para identificar el tipo de evento. Todos los eventos tienen un _EventType_, un _TimeStamp_ y un _SessionId_.

Para guardar más información se usan los _progressionEvent_, que aparte de los campos ya mencionados tambien aceptan un diccionario<string, object> en el que guarda la informacion necesaria. Por ejemplo:

```C#
ProgressionEv ev = new ProgressionEv();
ev.EventType = "TwitterScrolled";
ev.ProgressionDict.Add("TotalVerticalScroll",
  Math.Abs(initScrollPos -
  scrollRect.VerticalNormalizedPosition));
GameManager.instance.GetTracker().TrackEvent(ev);
```

Otro ejemplo:

```C#
ProgressionEv ev = new ProgressionEv();
ev.EventType = "DayEnded";
ev.ProgressionDict.Add("MoneyMade", salesDelta-costDelta);
tracker.TrackEvent(ev);
```

Los eventos se pueden grabar manualmente a disco con

```C#
tracker.Save();
```

---

# Configuración

Una vez instalado el paquete, se puede configurar la ruta en la que se guardan las trazas abriendo la ventana de configuración de tailemetry: Window > TaiLemetry. Una vez cambiada la ruta, pulsar _Apply configuration_ para confirmar.

# License

MIT License

Copyright © 2022 Tai1Games (Pero la mitad)
