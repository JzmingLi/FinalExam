# Command Pattern
Commands were used to invert the players mouse inputs
When the Unity Input system detects a change in mouse position, the change is passed in a command to move the crosshair
The command has two methods, one is for applying the change normally and the other is for applying the inverted change

# Object Pooling
The object pool keeps 10 ducks in an array, which are instantiated disabled at the start of the game
The game manager and their status as a decoy is randomized when enabled

# Other Pattern
The game manager is a singleton that the ducks and decoys access to let them know when a duck has died or the player needs to be penalized for hitting a decoy

I had an issue getting the mouse inputs to work but the logic is all there

![NVIDIA_Overlay_MgqbBsyeAz](https://github.com/user-attachments/assets/598ee289-b764-4fbf-a085-d5ea67024e17)
