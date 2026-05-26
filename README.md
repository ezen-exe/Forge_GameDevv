# 2D Platformer & Stealth AI System

A robust 2D platformer project built in Unity, showcasing advanced player mechanics and a highly modular, object-oriented Enemy AI system. 

This repository is divided into two primary scenes, each demonstrating core gameplay programming concepts.

## 🎮 Project Structure

### Scene 1: Task 1 - Player Movement
A highly responsive 2D character controller built around Unity's `Rigidbody2D` physics system. 
* **Fluid Locomotion:** Smooth acceleration, deceleration, and crisp directional changes.
* **Platformer Physics:** Optimized jumping mechanics with gravity tuning to ensure the player character feels heavy and responsive, rather than "floaty."
* **State Detection:** Reliable ground detection for accurate jump resets and movement states.

### Scene 2: Task 2 - Advanced Enemy AI & Stealth
A fully functioning stealth and combat ecosystem. Rather than writing duplicate code for every enemy, this system uses **C# Class Inheritance** (a parent `EnemyManager`) to create clean, scalable, and highly optimized AI behaviors.

#### 🧠 AI Ecosystem Features:
* **Melee Brawlers (`MeleeEnemyManager`):** * Actively patrols between dynamic waypoints.
  * Uses 360-degree radial vision to detect the player.
  * Sprints at the player and executes physical attacks managed by a strict `Time.deltaTime` cooldown system.
* **Ranged Snipers (`RangedEnemyManager`):** * Uses tactical spacing logic to maintain a "sweet spot" distance.
  * Automatically backs away if the player gets too close, and pushes forward if the player runs away.
  * Fires projectile prefabs on a cooldown timer.
* **Security Cameras (`ScoutManager`):**
  * Sweeps back and forth between rotational target points using `Quaternion.RotateTowards`.
  * Overrides standard radial vision with a strict directional **Vision Cone** (calcul
