# Flappy Bird (Unity)

This repository contains a lightweight Flappy Bird-style game implementation for Unity. The project focuses on simple gameplay scripting and clear setup steps so you can drop it into a Unity project quickly.

## What's Included

- Bird controller with tap/spacebar flap, velocity clamping, and tilt.
- Pipe spawner and moving pipe obstacles with scoring trigger.
- Parallax scroller for background layers.
- Game manager to handle score, game over UI, and restart.

## Quick Start (Unity Editor)

1. Create a **2D** Unity project (Unity 2021+ recommended).
2. Copy the `Assets` folder from this repo into your Unity project's `Assets` folder.
3. Create a new scene named `FlappyBird` and save it under `Assets/Scenes`.
4. Build the scene using the setup guide below, then add it to **Build Settings**.

## Scene Setup Guide

### 1) Player (Bird)
- Create a new GameObject named **Bird**.
- Add a **SpriteRenderer** with your bird sprite.
- Add **Rigidbody2D**:
  - Gravity Scale: 2.5
  - Freeze Rotation (Z) unchecked so tilt works.
- Add **CircleCollider2D**.
- Tag the object as **Player**.
- Attach `BirdController` and tune values as needed.

### 2) Pipes (Prefab)
- Create an empty GameObject named **Pipe**.
- Add two child sprites for top/bottom pipes.
- Add **BoxCollider2D** to each pipe sprite (set to not trigger).
- Add a **BoxCollider2D** to the parent (set `Is Trigger = true`) and size it between pipes for scoring.
- Attach `Pipe` to the parent.
- Create a prefab from the parent and assign it to the `PipeSpawner`.

### 3) Pipe Spawner
- Create an empty GameObject named **PipeSpawner**.
- Position it to the right of the camera view.
- Attach `PipeSpawner` and assign the pipe prefab.
- Tune `Spawn Interval`, `Min Height`, and `Max Height`.

### 4) Background Parallax (Optional)
- Create background sprites as separate GameObjects.
- Attach `ParallaxScroller` to each layer and tweak the speeds.

### 5) UI
- Create a Canvas with:
  - **ScoreText** (TextMeshProUGUI).
  - **GameOverPanel** (set inactive by default) with a restart button calling `GameManager.RestartGame()`.
- Add the `GameManager` component to an empty GameObject and wire references:
  - Player, PipeSpawner, Parallax layers, ScoreText, GameOverPanel.

## Controls
- **Spacebar** or **Left Mouse Button** to flap.

## Notes
- The scripts are intentionally minimal for clarity and quick iteration.
- Add audio, animations, and polish as needed.
