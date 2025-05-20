# Space Invaders Game – Unity Implementation

A modern Unity-based recreation of the classic **Space Invaders** game, built using clean architecture and proven object-oriented design principles. This project was for me to practice good software patterns to promote extensibility and maintainability.

---

## 🚀 Key Features

- **Factory Pattern** – Dynamically generates invaders via a centralized factory.
- **Chain of Responsibility** – Modular collision handling for players and invaders.
- **Open/Closed Principle** – Extensible projectile and enemy behavior system.
- **Single Responsibility Principle** – Clean separation of game logic into dedicated classes.

---

## 🧠 Design Patterns & Principles

### 🏭 Factory Pattern
- **`InvaderFactory.cs`**  
  Centralized management and instantiation of invader objects.

### 🔗 Chain of Responsibility
- **`PlayerCollisionHandler.cs`**  
  Manages player-related collisions (e.g., invader contact, projectile hits).
  
- **`InvaderCollisionHandler.cs`**  
  Handles collisions specific to invaders.

- **`IHandler.cs`**  
  Interface for linking and extending chain logic.

### 🔓 Open/Closed Principle
- **`IProjectile.cs`**  
  Enables adding new projectile types without changing existing code.

- **`BulletProjectile.cs`**  
  Default projectile behavior implementation.

- **`Invader.cs`**  
  Easily extendable for introducing new enemy types or behaviors.

### 🎯 Single Responsibility Principle

| Class                | Responsibility                          |
|----------------------|------------------------------------------|
| `Player.cs`          | Handles player state and high-level behavior |
| `PlayerMovement.cs`  | Manages movement input and constraints  |
| `PlayerAttack.cs`    | Manages firing mechanics                |
| `Projectile.cs`      | Controls projectile logic and collision |

---

## 🎮 Controls
### Key	Action
- ← / →	Move player
- Spacebar	Shoot
- ESC	Pause game

---

## 📁 Project Structure

SpaceInvaders/
- ├── Assets/
- │   ├── Prefabs/
- │   ├── Scenes/
- │   ├── Scripts/
- │   └── Sprites/
- ├── Packages/
- └── ProjectSettings/

---

## 📌 Notes
- This implementation builds on a tutorial but is restructured with scalable, production-grade practices. Ideal for those looking to learn Unity with proper software architecture.

## ▶️ How to Run

### Prerequisites
- Unity **2021.3+**
- Git *(optional)*

### Installation
```bash
git clone https://github.com/AidanRouai/SpaceInvaders
```
- Open the project in Unity.
- Build the project
