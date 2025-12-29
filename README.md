# Game Overview
**Flop-a-Bird** - A Unity recreation of the classic mobile game "Flappy Bird" with enhanced mechanics.

Fly the bird through an endless series of pipes by clicking the space bar to flap and stay in the air. Avoid collisions with pipes and try to achieve the highest score possible!

## Core Mechanics

- Gravity & Physics: The bird constantly falls due to gravity and must be kept 'alive' through player input
- Collision Detection: Contact with pipes results in game over
- Procedural Generation: Pipes spawn continuously with randomized gap positions
- Score System: Points are awarded for successfully passing through pipe gaps + star collectibles which double your score

### Game Modes

1. Classic Mode
The traditional endless Flappy Bird experience where you aim to pass through as many pipes as possible. The game continues until you collide with a pipe.

2. Time Attack Mode
A race against the clock! You have 30 seconds to collect 10 points. This mode adds an exciting time pressure element that changes the strategy completely.

3. Scenes
  - MainMenu - Mode selection screen
  - FlappyClassic - Traditional endless mode
  - FlappyTimeAttack - Timed challenge mode

#### Most Notable Features

 1. Sound System with Singleton Pattern
- Complete audio management system with background music and sound effects
- Implements the Singleton pattern with `DontDestroyOnLoad` for persistence across scenes
- Dynamic sound effects for:
  - Win condition - Victory sound when completing Time Attack
  - Lose condition - Defeat sound on collision
  - Star collection - Special audio feedback when doubling score
- Implemented via the `SoundManager.cs`

 2. Dynamic High Score Color Change
- The bird changes color from white to yellow in real-time when you beat your personal best score
- Provides instant visual feedback for achievement
- Implemented via the `HighScoreColorChanger.cs`

 3. Star Collectibles with Score Doubling
- Stars spawn randomly (50% chance) near pipes
- Collecting a star instantly doubles your current score
- Stars move with pipes (parented to pipe objects) for synchronized movement
- Stars appear in varying positions within the pipe gap for added challenge

 4. Camera Shake on Collision
- Smooth camera shake effect triggers when the bird crashes
- Adds satisfying tactile feedback to collisions

 5. Dual-Mode Architecture
- Same core mechanics, two completely different gameplay experiences
- Time Attack mode introduces win/lose conditions beyond simple survival
- Modular design allows easy addition of more modes

##### Controls

- Space Bar - fly upwards

###### Project Structure
1. Core Scripts
- `BirdScript.cs` - Player physics, input handling, and collision detection
- `LogicScript.cs` - Score management, high score tracking, and game state
- `TimeAttackManager.cs` - Time limit and target score logic for Time Attack mode

2. Environment Scripts
- `PipeSpawnScript.cs` - Procedural pipe and star spawning
- `PipeMoveScript.cs` - Scrolling pipe movement
- `PipeMiddleScript.cs` - Score zone detection

3. Polish & Effects
- `CameraShake.cs` - Impact feedback system
- `HighScoreColorChanger.cs` - Visual achievement indicator
- `StarCollectible.cs` - Bonus collectible logic
- `SoundManager.cs` - Audio management with singleton pattern

4. UI
- `MenuManager.cs` - Scene transitions and menu navigation

# How to Run

1. Open the project with the 6000.3.2f1 version or later
2. Load the `MainMenu` scene from
3. Press Play in the Unity Editor
4. Choose your game mode and start playing

