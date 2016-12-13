# LudumDare37Agoraphobic
Ludum Dare 37 Unity Project
http://ludumdare.com/compo/ludum-dare-37/?action=preview&uid=124517

Outside wants to kill you. Now the outside is coming inside...

Don't let the outside win!

WASD or Arrow Keys move, aim/shoot with the mouse

Wave based, defense shooter. The 3 characters have different waves. Each wave has a little message that will display when it starts, completes, and if you die on that wave.

Certain waves will have a red box around one of the static objects; if enemies enter the box, they will die but do damage to the hot zone. 



On the windows build it looks best at 800*600. The build on itch.io has some GUI graphics that got stretched, but it's still playable.

Programming/Content Design:
Tyler Rasmussen
Art/Music Design:
Alan Molina


Major TODOs

Visual/Sound feedback on hit

Brief period of Invulnerabilty after getting hit

Fix GUI layouts, especially for WEBGL build

Spawn system refactor:

Changes spawn points to be game objects anchored to the floor instead of just vector2s

Abstract the wavedata class to allow random waves

Abstract the spawn event class to allow multiple spawns at the same time

Overall make it easier to create new waves
