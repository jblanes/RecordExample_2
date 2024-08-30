Este es un proyecto de ejemplo!<br/>
Varios módulos importantes existentes en un proyecto de producción (testing, logging, monitoring, APIs, etc) han sido eliminados para poder presentar más claramente las ideas principales.<br/>

Este ejemplo es una evolución de los conceptos presentados en el ejemplo anterior [Uso de Records](https://github.com/jblanes/recordexample), más parecido a lo usado en producción.

Los conceptos son similares, pero una diferencia importante respecto al ejemplo anterior es que el commando no se procesará nunca mientras esté en un estado inválido. De esta forma se evita la entrada de valores incorrectos al Sistema.

Por otro lado, el código de los commandos, ejecución y validaciones es "custom made" para evitar el uso de librerías externas, aunque para producción se recomienda el uso de librerías establecidas para esas tareas.

Por ultimo, el ejemplo también presenta el uso del Localizer de Microsoft para traducciones de mensajes y descripciones en pantalla. Los botones English/Español se pueden usar para el cambio de lenguaje.

Para comenzar el análisis, favor comenzar viendo los comentarios en la pantalla principal /Pages/Index
en el proyecto BC.RecordUseExample.UI.Razor
