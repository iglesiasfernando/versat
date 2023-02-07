<h1>Proyecto desafío Versat</h1>


*Tecnologías*

La tecnología utilizada es xamarin forms, implementando el proyecto en android. Para el desarrollo se utilizó Visual Studio Community 2022. Para la base de datos me tomé la libertad de utilizar una librería de sqlite para Xamarin.Forms, ya que no encontré documentación suficiente para el uso de Room con Xamarin.Forms.

*Funcionalidades*

En cuanto a las funcionalidades de la App, en el ingreso carga las noticias de esta url : https://www.pagina12.com.ar/rss/secciones/deportes/notas
Las enlista en un listview y tiene un evento en el click de un ítem que hace que lo puedas setear en favorito, o borrar de favoritos.
Las noticias favoritas serán guardadas y luego cargadas primeras en la lista, y sumando las del rss. Así si la noticia favorita deja de llegar en el rss, igualmente quedará visible hasta que se elimine de la base de datos local.

*APK*

La apk para probar la app, está generada y puesta en la raíz del proyecto, para poder fácilmente instalarla. El proyecto se llama VersatDesafio y el logo es el que llega por defecto de Xamarin.




