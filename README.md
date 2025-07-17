# 2D Platformer "Schwarzennegern't" - Proyecto de Videojuego en Unity


## Descripción General

Este repositorio contiene el código fuente y los assets de un juego de plataformas 2D completo Schwarzennegern't, desarrollado como proyecto para la Semana 7 y evaluación recuperativa del módulo "Taller de Desarrollo de Videojuegos" de AIEP. 
El juego está inspirado en los plataformas clásicos como Metal Slug y tiene como objetivo demostrar la implementación de las mecánicas básicas de un videojuego 2D desarrollado en Unity Hub con scripting en C#.

El jugador controla al "Soldado", un personaje que debe navegar por un nivel ambientado en una jungla con el objetivo final de llegar a unas cajas de municiones como meta.

---

## Características Principales

El proyecto incluye las siguientes funcionalidades:

*   **Movimiento de Personaje:**
    *   Control responsivo de desplazamiento horizontal (izquierda/derecha).
    *   Salto con detección de suelo para evitar saltos infinitos en el aire.
    *   Sistema de animaciones básicas para los sprites del jugador y enemigos.

*   **Combate:**
    *   El jugador puede disparar proyectiles para eliminar enemigos.
    *   Enemigos (Grunts) con una IA simple que detectan al jugador a corta distancia y disparan.

*   **Sistema de Vidas y Salud:**
    *   El personaje tiene un número limitado de vidas (3).
    *   Recibir daño de los enemigos reduce la salud del jugador. Al llegar a cero, se pierde una vida.

*   **Checkpoints y Respawn:**
    *   Presencia de un Checkpoint a mitad del nivel que actualizan el lugar de reaparición del jugador.
    *   Al perder una vida, el jugador reaparece en el último checkpoint activado.

*   **Flujo de Juego Completo:**
    *   **Menú Principal:** Una escena de título con opciones para iniciar el juego o salir.
    *   **Pantalla de Victoria:** Al completar el nivel, se muestra una pantalla de "Mission Completed" con la opción de volver a jugar.
    *   **Pantalla de Game Over:** Si el jugador pierde todas sus vidas, se presenta una pantalla de "Game Over" con la opción de reiniciar el nivel presionando la barra de espacio.
    *   **UI (Interfaz de Usuario):** Un Canvas funcional que muestra el contador de vidas.

*   **Sonido:**
    *   Efectos de sonido básicos para disparos y música de fondo.

---

## Tecnologías Utilizadas

*   **Motor de Juego:** Unity 6000.1.10f1 *(Reemplaza con tu versión de Unity)*
*   **Lenguaje de Programación:** C#
*   **Editor de Código:** Visual Studio Code
*   **Assets:** Gráficos y sonidos de (https://didigameboy.itch.io/jambo-jungle-free-sprites-asset-pack).

---


## Estructura del Proyecto

*   **/Assets/Animations:** Contiene los `Animation Clips` y `Animator Controllers` para el jugador, enemigos y otros elementos.
*   **/Assets/Prefabs:** Almacena los GameObjects prefabricados, como el jugador, enemigos y balas.
*   **/Assets/Scenes:** Contiene las escenas del juego (`TitleScene`, `SampleScene`).
*   **/Assets/Scripts:** Aquí se encuentra todo el código C# que da vida al juego.
*   **/Assets/Sounds:** Efectos de sonido utilizados en el proyecto.
*   **/Assets/Spritesheets:** Todos los assets gráficos 2D.

---

## Autor

*   **[Johann Mora Mira]** - [johann.mora@correoaiep.cl]
