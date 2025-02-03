Memory Matching Game

Overview

Memory Matching Game is a fun and engaging card-matching game developed in Unity 3D (URP) using C#. Players flip two cards at a time, attempting to find matching pairs. The game tracks the player's score and number of attempts, and a victory condition is reached when 80 points are achieved.

Features

Grid-Based Matching Game: Cards are arranged in a customizable grid.

Image-Based Matching: Cards match based on identical images.

Score System: Earn 10 points per correct match.

Attempt Tracking: Keeps count of the number of attempts made.

Win Condition: The game ends and displays a victory message when 80 points are reached.

Restart Functionality: Players can restart the game anytime.

Smooth Flip Animation: Cards flip to reveal or hide images.

User-Friendly UI: Displays score, attempts, and a restart button upon winning.

How to Play

Click on a card to reveal its image.

Click on a second card to try and find its match.

If the images match, both cards disappear, and you earn 10 points.

If the images do not match, both cards flip back after 1 second.

The game continues until you reach 80 points.

Once you win, a "You Win!" message appears along with a restart button.

Controls

Mouse Click: Selects and flips a card.

Restart Button: Resets the game when clicked.

Setup & Installation

Open Unity (tested with Unity 2021+).

Create a new 2D/3D URP project.

Import the provided scripts, sprites, and UI elements.

Assign Card Prefab, Grid Layout, Sprites, and UI Elements in the Inspector.

Press Play in Unity Editor to start the game.

Scripts Overview

1. GameManager.cs

Manages game logic, score, attempts, and win conditions.

Handles card interactions and resets the game.

2. Card.cs

Controls individual card behavior, flipping, and clicking.

Stores front and back images for matching logic.

Future Improvements

Add Timer Mode for extra challenge.

Implement Different Difficulty Levels.

Introduce Sound Effects and Animations.

Support Multiplayer Mode.

Credits

Developer: [Your Name]

Engine: Unity 3D (URP)

Language: C#

Assets: Custom/Free-to-use sprites

License

This project is free for personal and educational use. For commercial use, please contact the developer.

Enjoy the game and have fun testing your memory skills! 
