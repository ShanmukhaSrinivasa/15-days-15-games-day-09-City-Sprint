# 15-Days-15-Games-Day-10-City-Sprint

This is the tenth game from my "15 Days 15 Games" challenge. It is a polished 3D side-scrolling endless runner, with a focus on integrating animations, particle effects (VFX), and sound effects (SFX) to enhance the player experience.

## 🚀 About the Game

The player controls a character who runs automatically from left to right. A seamless, repeating background gives the illusion of infinite travel. The player must press a key to jump over procedurally spawned obstacles.
The score increases based on survival time. Colliding with an obstacle ends the game.

## 💡 Technical Highlights

* **Engine:** Unity (3D)
* **Animation Integration:** The `PlayerController` directly interfaces with the `Animator` component. It uses `playerAnimator.SetTrigger()` for single-play animations like jumping and `playerAnimator.SetBool()` / `playerAnimator.SetInteger()` to transition the character into different death animation states upon collision.
* **VFX and SFX Implementation:** The project demonstrates robust use of audio and visual feedback. The `PlayerController` script programmatically controls `ParticleSystem.Play()` and `ParticleSystem.Stop()` for effects like a running dust trail and a collision explosion. It also uses `AudioSource.PlayOneShot()` to play distinct sound clips for jumping and crashing.
* **Seamless Background Loop:** The `RepeatBackground.cs` script creates an infinite scrolling effect. It caches the background's starting position and uses half of its `BoxCollider`'s width as a reset point, providing a robust and asset-agnostic solution for looping backgrounds.
* **Game State Management:** The project uses a `GameManager` singleton to manage the overall game state (start, playing, game over), UI canvases, and time-based scoring, while a separate `SpawnManager` handles the instantiation of obstacles.

## ▶️ Play the Game!

You can play the game in your browser on its itch.io page:
**https://shanmukha.itch.io/city-sprint**
