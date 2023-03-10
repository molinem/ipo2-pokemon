# Pokemon  UWP 馃懢 
Se trata de un proyecto desarrollado mediante el software `Visual Studio` usando el lenguaje de programaci贸n C#, en el cual simulamos tener un pokemon con diversas caracter铆sticas.
El objetivo del "juego" es tratar que nuestro pokemon no "muera" para ello hay que mantener siempre los valores de <b>Vida</b>, <b>Energ铆a</b> y <b>Man谩</b>. Cuando un valor llegue a 0 perderemos y el juego finalizar谩 mostrando una animaci贸n y un cuadro de di谩logo con la puntuaci贸n final alcanzada.

Para realizar la simulaci贸n se utiliza un `DispatcherTimer`, que ir谩 bajando los valores de las progressBar. Siempre que hagamos uso de una poci贸n hasta que la animaci贸n no termine los botones no estar谩n disponibles, esto es controlado mediante el evento Completed en las distintas storyBoards que conforman el software.</br> </br>
El `dise帽o principal` es un <b>Page WPF</b> que contiene un <b>grid</b> que a su vez contiene un Control de usuario, esto es as铆 debido a que lo que se busca es la reutilizaci贸n del control de usuario en otra aplicaci贸n.

***
# 馃摳 TimeLapse dise帽o del pokemon en Windows blend
<p align="center">
  <a href="https://www.youtube.com/watch?v=utnEfus11KE">
    <img src="https://img.youtube.com/vi/utnEfus11KE/0.jpg" alt="Alt text">
  </a>
</p>

***
# 鈿★笍 Animaciones
馃敻 `Animaci贸n Salud` 鉃★笍 Cruces de color verde giran y cambian de color. </br>
馃敻 `Animaci贸n ProgressBar Salud` 鉃★笍 Alteraci贸n en los colores, cambia de negro a rojo.

馃敻 `Animaci贸n Energ铆a` 鉃★笍 Charmander cierra y abre los ojos, estrellas salen girando alrededor del mismo. </br>
馃敻 `Animaci贸n ProgressBar Energ铆a` 鉃★笍 Alteraci贸n en los colores, cambia de negro a blanco.

馃敻 `Animaci贸n Man谩` 鉃★笍 Charmander cambia su color por completo en todos sus path. </br>
馃敻 `Animaci贸n ProgressBar Man谩` 鉃★笍 Alteraci贸n en los colores, cambia de negro a Azul.

馃敻 `Animaci贸n Nivel` 鉃★笍 La palabra nivel se hace m谩s grande - peque帽a al subir de nivel. </br>
馃敻 `Animaci贸n MasterBall` 鉃★笍 Sale una masterball mostrando un mensaje. </br>
馃敻 `Animaci贸n Fuego Cola` 鉃★笍 Animaci贸n permanente donde la cola est谩 ardiendo constantemente.

***
# 馃З Autor

馃敼 Luis Molina Mu帽oz-Torrero.&nbsp;&nbsp; <a title="Luis Molina Mu帽oz-Torrero" href="https://www.linkedin.com/in/luis-molina-mu%C3%B1oz-torrero-45829014a">
  <img align="center" src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white">      
 </a> 
