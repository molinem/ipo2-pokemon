# Pokemon  UWP 👾 
Se trata de un proyecto desarrollado mediante el software `Visual Studio` usando el lenguaje de programación C#, en el cual simulamos tener un pokemon con diversas características.
El objetivo del "juego" es tratar que nuestro pokemon no "muera" para ello hay que mantener siempre los valores de <b>Vida</b>, <b>Energía</b> y <b>Maná</b>. Cuando un valor llegue a 0 perderemos y el juego finalizará mostrando una animación y un cuadro de diálogo con la puntuación final alcanzada.

Para realizar la simulación se utiliza un `DispatcherTimer`, que irá bajando los valores de las progressBar. Siempre que hagamos uso de una poción hasta que la animación no termine los botones no estarán disponibles, esto es controlado mediante el evento Completed en las distintas storyBoards que conforman el software.</br> </br>
El `diseño principal` es un <b>Page WPF</b> que contiene un <b>grid</b> que a su vez contiene un Control de usuario, esto es así debido a que lo que se busca es la reutilización del control de usuario en otra aplicación.

***
# 📸 TimeLapse diseño del pokemon en Windows blend
<p align="center">
  <a href="https://www.youtube.com/watch?v=utnEfus11KE">
    <img src="https://img.youtube.com/vi/utnEfus11KE/0.jpg" alt="Alt text">
  </a>
</p>

***
# ⚡️ Animaciones
🔸 `Animación Salud` --> Cruzes de color verde giran y cambian de color. </br>
🔸 `Animación ProgressBar Salud` --> Alteración en los colores.

🔸 `Animación Energía` --> Charmander cierra y abre los ojos, estrellas salen girando alrededor del mismo. </br>
🔸 `Animación ProgressBar Energía` --> Alteración en los colores.

🔸 `Animación Maná` --> Charmander cambia su color por completo en todos sus path. </br>

🔸 `Animación Nivel` --> La palabra nivel se hace más grande - pequeña al subir de nivel. </br>
🔸 `Animación MasterBall` --> Sale una masterball mostrando un mensaje. </br>
🔸 `Animación Fuego Cola` ---> Animación permanente donde la cola está ardiendo constantemente.

# 🧩 Autor

🔹 Luis Molina Muñoz-Torrero.&nbsp;&nbsp; <a title="Luis Molina Muñoz-Torrero" href="https://www.linkedin.com/in/luis-molina-mu%C3%B1oz-torrero-45829014a">
  <img align="center" src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white">      
 </a> 
