# My_Defender

This project is a Tower Defense game inspired by the mobile game INFINITODE 2.

Game made with Marton Szuts in 5 weeks.

Here you can find the video of the end result of this project :

[![](http://img.youtube.com/vi/_oOO-t6krrw/0.jpg)](https://www.youtube.com/watch?v=_oOO-t6krrw&t "Defender")

## Usage

./my_defender [-h]
  
  
  
## Game description

The Goal is to survive all the waves.  
The waves are composed of 3 types of enemies, circles, squares, and triangles.  
(The arrows moving at the begining of the level aren't enemies, there are showing you the way ennemies will come).  
  
Your goal is to protect the base from enemies.  
If an ennemy hits the base you lose 2 hitpoints. (You only have 20)  
To stop enemy waves you'll need to place turrets in a smart way.  
  
In this game there are four types of turrets :  
  
-> The Basic (48 gold)  
1v1 type turret with medium rate of fire, medium damage and medium range.  
  
-> The Big Bertha (60 gold)  
Area of effect type turret with high damage, low rate of fire and short range.  
  
-> The Sniper (80 gold)  
1v1 type turret with high damage, very low rate of fire and very high range.  
  
-> The Frozen (80 gold)  
Area of effect type turret with the ability to slow down enemies around.  
  
You'll face the same X waves on all maps.  
Some maps are really hard to complete.  
  
## Features

### Menus and interfaces
  
- A menu with sliding buttons on the right side.  
- An oportunity to continue the current game after getting back to the menu.  
- A map selector screen with all your custom maps loaded to.  
  
- A settings menu with the ability to stop sounds, music.  
- Able or disable shaders and the secret "Eric mode".  
- Chose between 30, 60 or 120 fps.  
- A custom map editor where you'll have a graphical interface to build your own maps.  
- A statistics menu.  
  
### Custom map editor
  
To build a map you'll need to respect these 2 rules:  
  
- Place at least 1 spawner and one castle.  
- Do only one possible path.  
  
To place a tile first clic on a square and then chose the type of tile you want to place.  
The four type of tiles you can place are displayed on the right side.  
Thanks to the editor you'll be able to undo, reset and save your maps.  

### In game
  
- The ability to clic and select all the map tiles to get information.  

- A slider menu that you can deploy with the button on the bottom right.  
(This button is only visible if you clic on a tile).  
The slider's interface depends on witch tile you are clicking on.  
  
- The ability to place turrets by double clicking them in the side menu.  
Before and after placing a turret you can chose witch type of enemy you want to attack.  
You can chose between the first in range, the last in range, the weakest, the strongest and the closest.  
A turret will only change his target if the enemy is out of range or dead.  
You can upgrade your turrets (3 times max) with money (This type of upgrade only depends on money).  
Your turret will gain xp by killing enemies (if you sell the turret you'll lose it's xp).  
If a turret reaches level 3 you'll be able to chose a special ability for you turret in the slider menu.  
  
- The ability to pause the game.  
- You will see the statistics of your turret by clicking on it and openning the slider.  
- You can launch waves with the wave button on the bottom left.  
- Your current wave, your money, and lives are displayed on the HUD on top.  
  
## Controls

ESCAPE To pause the game.  
MOUSE LEFT CLIC To everything else.  
  
  
  
# Infos

- **Binary name:** my_defender
- **Language:** C
- **Group Size:** 2
- **Compilation:** via Makefile, including re, clean and fclean rules

## Table of content
<!-- TOC depthFrom:1 depthTo:6 withLinks:1 updateOnSave:1 orderedList:0 -->

- [Subject](#subject)
	- [Requirements](#requirements)
		- [Mandatory](#mandatory)
		- [Must](#must)
		- [Should](#should)
		- [Could](#could)
	- [Authorized functions](#authorized-functions)

<!-- /TOC -->

## Subject

Your main challenge for this game will be to create nice and
smooth user interface and menus.

Your game must follow the following rules:
- The player is a builder who must defend his castle,
- Enemy waves will regularly appear from one side of the playground,
- The player must buy and place buildings on the playground grid to block/kill enemies,
- Buildings can be offensive (towers attacking) or defensive (basic walls),
- When the castle is reached by an enemy, it takes damages,
- If the castle reaches 0 hit points the player loose.

Having a pleasant user interface is one of the details that makes a good quality game, this project is the
occasion for you to try your best on that topic.

## Requirements

### Mandatory

The following features are mandatory (if your project is missing one of them it will not be evaluated further):

- the window can be closed using events,
- the game manages the input from the mouse click and keyboard,
- the game contains animated sprites rendered thanks to sprite sheets,
- animations in your program are frame rate independent,
- animations and movements in your program are timed by clocks.

### Must

The game must have:

- a starting menu with at least two buttons, one to launch a game, and one to quit the game,
- an escape key to pause the game when launched,
- a menu when the game is paused with at least three buttons, one to resume the game, one to go to the starting menu and the one to leave the game,
- at least 4 different types of buildings (e.g. walls, slowing towers, damaging towers, etc. . .),
- a building menu showing the different available buildings and their price,
- at least 2 different sound effects, and one looping background music.


> :exclamation: The starting menu and the game must be two different scenes


### Should

The game should have:

- a windows that sticks between 800x600 pixels and 1920x1080 pixels.
- a “How To play” menu, explaining how to play your game.
- a stored scoreboard.
- a scoreboard displayed at the end of a game, or thanks to a scoreboard button in the starting menu.
- buttons with at least three visual states: idle, hover, and clicked.
- a way to skip eventual cut scenes or an animated intro.
- different types of enemies with different speed and hit points.

### Could

The game could:

- let the user upgrade its buildings,
- load buildings from files,
- take buildings files as command line argument,
- take buildings files from a menu inside the game,
- have a skill tree, unlock different types of buildings,
- have a “settings” menu that contains sound options and/or screen size options

> :exclamation: The size of your repository (including the assets) must be as small as possible. Think about the format and the encoding of your resource files (sounds, musics, images, etc.).
> An average maximal size might be 15MB, all included. Any repository exceeding this limit might not evaluated at all.

## Authorized functions

All the functions from the CSFML and the math library are allowed.
From the libc, here is the full list of authorized functions:

- malloc
- free
- memset
- (s)rand
- getline
- (f)open
- (f)read
- (f)close
- (f)write
- opendir
- readdir
- closedir

> :exclamation: Any unspecified functions are de facto banned.
