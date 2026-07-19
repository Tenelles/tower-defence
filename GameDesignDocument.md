# Tower Defense - Game Design Document

## 1. Overview

### Genre

Tower Defense

### Engine

Unity

### Platform

PC

### Game Objective

The player must defend their base from incoming enemy waves by placing and upgrading defensive towers.

The game consists of several handcrafted levels with increasing difficulty.

The player wins by surviving all waves.
The player loses when the base health reaches zero.

---

# 2. Core Gameplay Loop

1. Start a wave.
2. Enemies spawn and move toward the base.
3. Towers automatically attack enemies.
4. Defeated enemies reward the player with gold.
5. Player spends gold on new towers or upgrades.
6. Next wave begins.
7. Repeat until victory or defeat.

---

# 3. Player

The player does not directly control attacks.

The player can:

* Place towers.
* Upgrade towers.
* Sell towers.
* Control camera movement.
* Pause the game.

---

# 4. Base

The base is the player's main objective.

## Base Statistics

| Parameter       | Value |
| --------------- | ----- |
| Maximum Health  | 100   |
| Starting Health | 100   |

## Damage Rules

When an enemy reaches the base:

* Enemy is removed.
* Base loses health.
* No gold reward is given.

## Base Destruction

When:

```
Health <= 0
```

the level ends with defeat.

---

# 5. Economy

The game uses one resource:

## Gold

Gold is used for:

* Building towers.
* Upgrading towers.

---

## Starting Gold

```
500
```

---

## Gold Sources

### Enemy Rewards

Enemies grant gold when defeated.

Example:

| Enemy        | Reward |
| ------------ | -----: |
| Basic Enemy  |     10 |
| Fast Enemy   |     12 |
| Heavy Enemy  |     25 |
| Flying Enemy |     20 |
| Boss Enemy   |    200 |

---

## Tower Refund

Selling a tower returns:

```
60%
```

of the total gold spent on the tower.

Example:

Tower cost:

```
100 gold
```

Refund:

```
60 gold
```

---

# 6. Waves

A level consists of multiple waves.

## Wave Structure

Each wave contains:

* Enemy groups.
* Spawn delays.
* Enemy composition.

---

## Default Wave Settings

| Parameter          |      Value |
| ------------------ | ---------: |
| Initial Wave Count |         10 |
| Time Between Waves | 15 seconds |
| Spawn Interval     |   1 second |

---

## Difficulty Scaling

Each new wave increases difficulty.

Default scaling:

| Parameter    | Increase |
| ------------ | -------: |
| Enemy Count  |     +15% |
| Enemy Health |     +10% |
| Enemy Speed  |      +2% |
| Enemy Reward |      +5% |

---

# 7. Victory Conditions

A level is completed when:

* All waves are finished.
* All spawned enemies are defeated.

---

# 8. Defeat Conditions

The player loses when:

```
Base Health = 0
```

---

# 9. Difficulty Philosophy

Difficulty should increase through:

* More complex enemy combinations.
* Increased pressure on tower placement.
* Different enemy roles.

Difficulty should not rely only on increasing enemy health.
# 10. Tower Catalogue

## Tower System Overview

Towers are the player's main defensive structures.

All towers share common properties:

* Construction cost
* Attack range
* Attack speed
* Upgrade levels
* Target selection rules

Towers can be upgraded up to **3 times**.

Each upgrade increases tower effectiveness and changes its statistics.

---

# 10.1 Archer Tower

## Description

The Archer Tower is the basic single-target damage tower.

It has high attack speed and reliable damage against regular enemies.

## Role

* Single-target damage
* Early game defense
* Cheap and reliable tower

---

## Base Statistics

| Parameter        |           Value |
| ---------------- | --------------: |
| Build Cost       |        100 gold |
| Sell Value       |         60 gold |
| Damage           |              15 |
| Attack Range     |               6 |
| Attack Speed     | 1.5 attacks/sec |
| Target Type      | Ground + Flying |
| Projectile Speed |    15 units/sec |

---

## Upgrade 1

### Sharpened Arrows

| Parameter    |           Value |
| ------------ | --------------: |
| Cost         |         75 gold |
| Damage       |              25 |
| Range        |               6 |
| Attack Speed | 1.6 attacks/sec |

---

## Upgrade 2

### Improved Bow

| Parameter    |           Value |
| ------------ | --------------: |
| Cost         |        125 gold |
| Damage       |              40 |
| Range        |               7 |
| Attack Speed | 1.8 attacks/sec |

---

## Upgrade 3

### Master Archer

| Parameter    |         Value |
| ------------ | ------------: |
| Cost         |      200 gold |
| Damage       |            65 |
| Range        |             8 |
| Attack Speed | 2 attacks/sec |

---

# 10.2 Cannon Tower

## Description

The Cannon Tower deals heavy area damage.

It has slow attacks but can damage multiple enemies at once.

## Role

* Area damage
* Crowd control
* Counter against groups of enemies

---

## Base Statistics

| Parameter        |           Value |
| ---------------- | --------------: |
| Build Cost       |        250 gold |
| Sell Value       |        150 gold |
| Damage           |              50 |
| Attack Range     |               5 |
| Attack Speed     | 0.5 attacks/sec |
| Splash Radius    |               2 |
| Target Type      |          Ground |
| Projectile Speed |     8 units/sec |

---

## Upgrade 1

### Larger Cannon

| Parameter     |    Value |
| ------------- | -------: |
| Cost          | 150 gold |
| Damage        |       80 |
| Splash Radius |      2.5 |
| Range         |        5 |

---

## Upgrade 2

### Explosive Shells

| Parameter     |           Value |
| ------------- | --------------: |
| Cost          |        250 gold |
| Damage        |             120 |
| Splash Radius |               3 |
| Attack Speed  | 0.6 attacks/sec |

---

## Upgrade 3

### Siege Cannon

| Parameter     |    Value |
| ------------- | -------: |
| Cost          | 400 gold |
| Damage        |      200 |
| Splash Radius |        4 |
| Range         |        6 |

---

# 10.3 Magic Tower

## Description

The Magic Tower deals consistent magical damage and is effective against enemies with high physical resistance.

## Role

* Reliable damage
* Anti-heavy enemy tower
* Alternative damage source

---

## Base Statistics

| Parameter        |           Value |
| ---------------- | --------------: |
| Build Cost       |        300 gold |
| Sell Value       |        180 gold |
| Damage           |              35 |
| Attack Range     |               7 |
| Attack Speed     |    1 attack/sec |
| Target Type      | Ground + Flying |
| Projectile Speed |         Instant |

---

## Upgrade 1

### Arcane Focus

| Parameter    |           Value |
| ------------ | --------------: |
| Cost         |        175 gold |
| Damage       |              55 |
| Range        |               8 |
| Attack Speed | 1.1 attacks/sec |

---

## Upgrade 2

### Arcane Power

| Parameter    |           Value |
| ------------ | --------------: |
| Cost         |        300 gold |
| Damage       |              90 |
| Range        |               9 |
| Attack Speed | 1.2 attacks/sec |

---

## Upgrade 3

### Master of Elements

| Parameter    |           Value |
| ------------ | --------------: |
| Cost         |        500 gold |
| Damage       |             150 |
| Range        |              10 |
| Attack Speed | 1.4 attacks/sec |

---

# 10.4 Support Tower

## Description

The Support Tower does not attack enemies.

Instead, it increases the effectiveness of nearby towers.

## Role

* Tower enhancement
* Strategic placement
* Late-game scaling

---

## Base Statistics

| Parameter          |    Value |
| ------------------ | -------: |
| Build Cost         | 350 gold |
| Sell Value         | 210 gold |
| Effect Range       |        5 |
| Damage Bonus       |     +15% |
| Attack Speed Bonus |     +10% |

---

## Upgrade 1

### Improved Support Field

| Parameter          |    Value |
| ------------------ | -------: |
| Cost               | 200 gold |
| Effect Range       |        6 |
| Damage Bonus       |     +25% |
| Attack Speed Bonus |     +15% |

---

## Upgrade 2

### Advanced Support Field

| Parameter          |    Value |
| ------------------ | -------: |
| Cost               | 350 gold |
| Effect Range       |        7 |
| Damage Bonus       |     +35% |
| Attack Speed Bonus |     +20% |

---

## Upgrade 3

### Tactical Command

| Parameter          |    Value |
| ------------------ | -------: |
| Cost               | 600 gold |
| Effect Range       |        8 |
| Damage Bonus       |     +50% |
| Attack Speed Bonus |     +30% |

---

# 11. Tower Balance Goals

## Archer Tower

Should remain useful throughout the game due to:

* Low cost.
* High attack speed.
* Ability to target all enemy types.

---

## Cannon Tower

Should dominate against:

* Large groups.
* Slow enemies.

Should struggle against:

* Fast enemies.
* Flying enemies.

---

## Magic Tower

Should provide:

* Stable damage.
* Reliable late-game scaling.

---

## Support Tower

Should become more valuable when:

* Multiple towers are placed nearby.
* Upgrade levels increase.

# 12. Enemy Catalogue

## Enemy System Overview

Enemies are units that move along predefined paths and attempt to reach the player's base.

All enemies share common properties:

* Health
* Movement speed
* Reward value
* Path navigation
* Damage interaction

Enemies are designed to create different tactical challenges rather than simply having higher statistics.

---

# 12.1 Basic Enemy

## Description

The Basic Enemy is the standard enemy unit.

It represents the baseline threat and appears throughout the entire game.

## Role

* Introduction enemy
* Balanced statistics
* Used to fill waves

---

## Statistics

| Parameter      |       Value |
| -------------- | ----------: |
| Health         |         100 |
| Movement Speed | 2 units/sec |
| Base Damage    |          10 |
| Reward         |     10 gold |
| Size Modifier  |         1.0 |
| Target Type    |      Ground |

---

## Appearance

Available from:

```
Wave 1
```

---

## Behavior

* Moves directly toward the base.
* Has no special abilities.
* Serves as the reference point for other enemies.

---

# 12.2 Fast Enemy

## Description

The Fast Enemy sacrifices durability for increased movement speed.

It creates pressure by reaching the base before slow towers can eliminate it.

## Role

* Speed threat
* Punishes poor tower coverage
* Forces high attack speed usage

---

## Statistics

| Parameter      |       Value |
| -------------- | ----------: |
| Health         |          60 |
| Movement Speed | 4 units/sec |
| Base Damage    |          10 |
| Reward         |     12 gold |
| Size Modifier  |         0.8 |
| Target Type    |      Ground |

---

## Appearance

Available from:

```
Wave 3
```

---

## Behavior

* Uses standard path movement.
* No additional mechanics.
* Relies entirely on speed.

---

# 12.3 Heavy Enemy

## Description

The Heavy Enemy is a slow but durable unit designed to absorb damage.

It requires strong single-target damage or sustained fire.

## Role

* Damage sponge
* Tests player damage output
* Protects weaker enemies behind it

---

## Statistics

| Parameter      |      Value |
| -------------- | ---------: |
| Health         |        500 |
| Movement Speed | 1 unit/sec |
| Base Damage    |         25 |
| Reward         |    25 gold |
| Size Modifier  |        1.4 |
| Target Type    |     Ground |

---

## Appearance

Available from:

```
Wave 5
```

---

## Behavior

* Moves slowly.
* Has no special abilities.
* Requires focused damage.

---

# 12.4 Flying Enemy

## Description

The Flying Enemy ignores ground movement restrictions and attacks tower placement strategies.

It requires towers capable of attacking aerial targets.

## Role

* Forces tower diversity
* Counters ground-only defenses

---

## Statistics

| Parameter      |       Value |
| -------------- | ----------: |
| Health         |         150 |
| Movement Speed | 3 units/sec |
| Base Damage    |          15 |
| Reward         |     20 gold |
| Size Modifier  |         0.9 |
| Target Type    |      Flying |

---

## Appearance

Available from:

```
Wave 7
```

---

## Behavior

* Uses aerial path movement.
* Can only be targeted by towers supporting flying targets.
* Ignores ground-only defenses.

---

# 12.5 Boss Enemy

## Description

The Boss Enemy is a powerful unit appearing in special waves.

It is designed as a major test of the player's defenses.

## Role

* Wave milestone challenge
* Requires preparation
* Creates memorable moments

---

## Statistics

| Parameter      |         Value |
| -------------- | ------------: |
| Health         |          5000 |
| Movement Speed | 0.8 units/sec |
| Base Damage    |           100 |
| Reward         |      200 gold |
| Size Modifier  |           2.5 |
| Target Type    |        Ground |

---

## Appearance

Available from:

```
Wave 10
```

Boss waves:

```
Every 10 waves
```

---

## Behavior

Initial version:

* No special abilities.
* Extremely high health.
* Requires optimized tower placement.

Future mechanics may include:

* Summoning enemies.
* Temporary shields.
* Area attacks.

---

# 13. Enemy Spawn Rules

## Basic Wave Composition

Example:

### Wave 1

```
10 Basic Enemies
```

---

### Wave 5

```
15 Basic Enemies
5 Heavy Enemies
```

---

### Wave 10

```
20 Basic Enemies
5 Fast Enemies
2 Heavy Enemies
1 Boss Enemy
```

---

# 14. Enemy Balance Goals

## Basic Enemy

Purpose:

* Teach the player the game.

Should never become completely irrelevant.

---

## Fast Enemy

Purpose:

* Punish slow reaction.
* Require fast attacking towers.

---

## Heavy Enemy

Purpose:

* Prevent relying only on cheap towers.

---

## Flying Enemy

Purpose:

* Force strategic tower variety.

---

## Boss Enemy

Purpose:

* Test overall strategy.

Bosses should be difficult because of preparation requirements, not because of unavoidable damage.

# 15. Level Design

## Level Overview

The game consists of several handcrafted levels.

Each level defines:

* Enemy paths.
* Build locations.
* Wave configurations.
* Difficulty progression.

Levels should encourage different tower placement strategies.

---

# 15.1 Level 1 - Training Grounds

## Purpose

The first level introduces the player to the core gameplay loop.

The player learns:

* Tower placement.
* Basic enemy behavior.
* Economy management.

---

## Configuration

| Parameter     | Value |
| ------------- | ----: |
| Waves         |    10 |
| Starting Gold |   500 |
| Base Health   |   100 |
| Build Spots   |    12 |

---

## Enemy Progression

### Waves 1-3

Enemies:

* Basic Enemy

Purpose:

* Introduce tower placement.

---

### Waves 4-6

Enemies:

* Basic Enemy
* Fast Enemy

Purpose:

* Introduce targeting and attack speed importance.

---

### Waves 7-9

Enemies:

* Basic Enemy
* Fast Enemy
* Heavy Enemy
* Flying Enemy

Purpose:

* Force the player to diversify towers.

---

### Wave 10

Enemies:

* Mixed enemies
* Boss Enemy

Purpose:

* First major challenge.

---

# 15.2 Level 2 - Advanced Defense

## Purpose

The second level introduces more complex layouts and requires better planning.

---

## Configuration

| Parameter     | Value |
| ------------- | ----: |
| Waves         |    15 |
| Starting Gold |   600 |
| Base Health   |   100 |
| Build Spots   |    14 |

---

## Differences from Level 1

* Longer enemy path.
* More difficult enemy combinations.
* Less efficient tower placement positions.
* More frequent heavy enemies.

---

# 16. User Interface

## HUD

The HUD displays important gameplay information.

---

## HUD Elements

### Base Health

Position:

Top-left corner

Display:

```
Base: 100 / 100
```

---

### Gold

Position:

Top-right corner

Display:

```
Gold: 500
```

---

### Wave Counter

Display:

```
Wave 3 / 10
```

---

### Wave Progress

Display:

```
Enemies Remaining: 15
```

---

# 16.1 Build Menu

## Purpose

Allows the player to select towers.

---

## Elements

Each tower entry displays:

* Tower icon.
* Name.
* Cost.
* Short description.

Example:

```
Archer Tower

Cost: 100

Fast single target damage
```

---

# 16.2 Tower Information Panel

Appears when a tower is selected.

Displays:

* Tower name.
* Current level.
* Current statistics.
* Upgrade options.
* Sell button.

Example:

```
Archer Tower

Level 2

Damage: 40
Range: 7
Attack Speed: 1.8

Upgrade:
200 Gold

Sell:
120 Gold
```

---

# 16.3 Pause Menu

Available options:

* Resume.
* Settings.
* Restart Level.
* Main Menu.

---

# 16.4 Main Menu

Options:

* Play.
* Level Select.
* Settings.
* Exit Game.

---

# 16.5 Victory Screen

Displayed after successful level completion.

Contains:

* Completion message.
* Statistics.
* Continue button.
* Main Menu button.

Example:

```
Victory!

Enemies defeated: 120
Gold earned: 850

Continue
Main Menu
```

---

# 16.6 Defeat Screen

Displayed when the base is destroyed.

Contains:

* Failure message.
* Retry button.
* Main Menu button.

---

# 17. Audio System

## Audio Categories

The game uses three audio groups.

---

# 17.1 Sound Effects

Examples:

| Event           | Sound           |
| --------------- | --------------- |
| Tower placement | Build sound     |
| Tower upgrade   | Upgrade sound   |
| Tower selling   | Sell sound      |
| Archer attack   | Arrow shot      |
| Cannon attack   | Explosion       |
| Magic attack    | Magic effect    |
| Enemy death     | Hit/death sound |
| UI click        | Button sound    |

---

# 17.2 Background Music

Tracks:

| Location  | Music         |
| --------- | ------------- |
| Main Menu | Calm theme    |
| Gameplay  | Battle theme  |
| Victory   | Victory theme |
| Defeat    | Defeat theme  |

---

# 18. Save System

The game stores:

## Player Progress

Saved data:

* Completed levels.
* Current unlocked level.

---

## Settings

Saved data:

* Master volume.
* Music volume.
* Effects volume.

---

## Save Format

Initial implementation:

JSON save file.

Example:

```json
{
  "completedLevels": [
    1
  ],
  "settings": {
    "masterVolume": 1.0,
    "musicVolume": 0.8,
    "effectsVolume": 1.0
  }
}
```

---

# 19. Technical Design

## Architecture Overview

The project uses:

* Component-based gameplay objects.
* ScriptableObject data.
* Event-based communication.
* Object pooling.

---

# 19.1 Scriptable Objects

## EnemyConfig

Contains:

* Name.
* Health.
* Speed.
* Reward.
* Prefab reference.

---

## TowerConfig

Contains:

* Name.
* Cost.
* Damage.
* Range.
* Attack speed.
* Upgrade data.

---

## WaveConfig

Contains:

* Enemy groups.
* Spawn amount.
* Spawn interval.

---

## AudioConfig

Contains:

* Sound references.
* Volume settings.

---

# 19.2 Core Systems

## Game Manager

Responsible for:

* Game state.
* Victory.
* Defeat.

---

## Wave System

Responsible for:

* Starting waves.
* Tracking progress.
* Completing waves.

---

## Currency System

Responsible for:

* Gold storage.
* Transactions.

---

## Object Pool

Used for:

* Enemies.
* Projectiles.
* Effects.

---

## Event System

Used for communication between:

* Towers.
* Enemies.
* UI.
* Game systems.

---

# 20. Project Structure

Recommended structure:

```
Assets
|
├── Scripts
│   ├── Core
│   ├── Towers
│   ├── Enemies
│   ├── UI
│   ├── Systems
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
│   ├── MainMenu
│   ├── Level1
│   └── Level2
│
└── Art
```

---

# 21. Development Scope

## Included

* Complete tower defense gameplay.
* Four tower types.
* Five enemy types.
* Two levels.
* Upgrade system.
* Save system.
* UI.
* Audio.
* Release build.

---

## Not Included

* Multiplayer.
* Procedural levels.
* Additional abilities.
* Complex enemy AI.
* Infinite mode.
* Online features.

---

# 22. Final Goal

Create a complete small-scale Tower Defense game that demonstrates:

* Gameplay programming.
* Unity architecture.
* System design.
* UI implementation.
* Data-driven configuration.

The project should be playable, finished, and suitable for public release.

