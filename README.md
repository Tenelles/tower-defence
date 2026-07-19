# Tower Defense

A small single-player Tower Defense game made with Unity.

The player must defend their base from incoming enemy waves by building and upgrading defensive towers.

![Gameplay GIF](./Screenshots/gameplay.gif)

---

# Features

* Wave-based tower defense gameplay.
* 4 unique tower types.
* 5 enemy types.
* Tower upgrade system.
* Tower selling system.
* Multiple handcrafted levels.
* Configurable enemy and tower data.
* Save system.
* Settings menu.
* Sound effects and background music.

---

# Gameplay

The core gameplay loop:

1. Start an enemy wave.
2. Defend the base using defensive towers.
3. Earn gold by defeating enemies.
4. Build and upgrade towers.
5. Survive all waves to complete the level.

The game focuses on strategic tower placement and choosing the right combination of defenses.

---

# Towers

## Archer Tower

A fast single-target damage tower.

* High attack speed.
* Can target ground and flying enemies.
* Effective against regular enemies.

---

## Cannon Tower

A heavy area damage tower.

* Slow attacks.
* High damage.
* Effective against groups of enemies.

---

## Magic Tower

A magical damage tower.

* Reliable damage output.
* Can target ground and flying enemies.
* Effective against durable enemies.

---

## Support Tower

A non-damaging tower.

* Buffs nearby towers.
* Improves damage and attack speed.
* Rewards strategic placement.

---

# Enemies

## Basic Enemy

Standard enemy unit.

* Balanced health and speed.
* Appears throughout the game.

---

## Fast Enemy

A fast-moving enemy.

* Low health.
* Requires quick damage output.

---

## Heavy Enemy

A durable enemy.

* High health.
* Slow movement speed.
* Requires focused damage.

---

## Flying Enemy

An aerial enemy.

* Requires towers capable of attacking flying targets.

---

## Boss Enemy

A powerful enemy appearing during boss waves.

* Extremely high health.
* Requires optimized defenses.

---

# Levels

## Level 1 - Training Grounds

The first level introduces the core mechanics.

Features:

* 10 waves.
* Basic enemy progression.
* Introduction of all enemy types.
* First boss encounter.

---

## Level 2 - Advanced Defense

A more challenging level with:

* 15 waves.
* More complex enemy combinations.
* Increased strategic requirements.

---

# Architecture

The project uses:

* Component-based gameplay architecture.
* ScriptableObjects for configurable data.
* Event-based communication.
* Object pooling for frequently created objects.

---

# Project Structure

```
Assets
|
├── Scripts
│   ├── Core
│   ├── Towers
│   ├── Enemies
│   ├── Systems
│   ├── UI
│   └── Data
│
├── Prefabs
│   ├── Towers
│   ├── Enemies
│   ├── Projectiles
│   └── UI
│
├── ScriptableObjects
│   ├── Towers
│   ├── Enemies
│   └── Waves
│
├── Audio
│
├── Scenes
│
└── Art
```

---

# Development Status

## Current Version

`v1.0.0`

## Status

✅ Completed

The game is fully playable and released.

---

# Development Progress

## Core Systems

* [] Project setup
* [] Game state management
* [] Wave system
* [] Enemy spawning
* [] Enemy navigation
* [] Tower placement
* [] Tower upgrades
* [] Tower selling
* [] Currency system
* [] Save system

---

## Gameplay

* [] Archer Tower

* [] Cannon Tower

* [] Magic Tower

* [] Support Tower

* [] Basic Enemy

* [] Fast Enemy

* [] Heavy Enemy

* [] Flying Enemy

* [] Boss Enemy

---

## UI

* [] Main Menu
* [] HUD
* [] Build Menu
* [] Tower Info Panel
* [] Pause Menu
* [] Settings Menu
* [] Victory Screen
* [] Defeat Screen

---

## Release

* [] Sound Effects
* [] Background Music
* [] Visual Effects
* [] Game Icon
* [] Screenshots
* [] Gameplay GIF
* [] GitHub Release
* [] itch.io Release

---

# Task Tracking

All development tasks are tracked using GitHub Issues.

Each task has a unique identifier:

```
[Task-ID]
```

Commit messages follow this format:

```
[ref #42]: First step of tower targeting
[fix #42]: Implement tower targeting
```

This keeps commits linked to specific development tasks.

---

# Design Document

The full game design document is available here:

[Game Design Document](./GameDesignDocument.md)

---

# Known Limitations

The project intentionally does not include:

* Multiplayer.
* Procedurally generated levels.
* Infinite game mode.
* Complex enemy abilities.
* Online features.
* Large-scale progression systems.

The goal of this project is to create a complete, polished single-player Tower Defense experience.

---

# Screenshots

![Gameplay](./Screenshots/gameplay.png)

![Tower Placement](./Screenshots/tower-placement.png)

![Boss Wave](./Screenshots/boss-wave.png)

---

# Release

Available on:

* GitHub Releases
* itch.io

---

# Technologies

* Unity
* C#
* ScriptableObjects
* Unity UI
* GitHub Issues
* Git

---

# License

This project is licensed under the MIT License.
