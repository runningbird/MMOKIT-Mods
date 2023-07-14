# Enviro Utilities

  ***[Enviro Unity Asset Required](https://assetstore.unity.com/packages/tools/particles-effects/enviro-sky-and-weather-33963)***

## Enviro - DayNightTimeUpdate

> By default if you don't have a DayNightTimeUpdater Object in your GameInstance the day will be only 60 seconds long

- Add this script as a component somewhere either on an empty or the enviro instance .  
- Make sure to set the Enviro Instance Time and Location Controls Progres Time to None.  

## Enviro - EnviroLightToggle
>
>This uses the built in EnviroManager IsNight feature

EnviroLightToggle allows you to automatically enable a light in your scene when Enviro says it's nighttime

- Add this script as a component on your light gameobject

## Enviro - EnviroObjectToggle
>
>This uses the built in EnviroManager IsNight feature

EnviroObjectToggle allows you to automatically enable a gameobjets MeshRender in your scene when Enviro says it's nighttime or Day time.

- Add this script as a component on your gameobject
