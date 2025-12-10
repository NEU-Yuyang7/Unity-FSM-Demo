# Unity FSM Demo

This project demonstrates a simple **Finite State Machine (FSM)** implementation for enemy AI within Unity.  
The goal is to teach core game AI concepts through a clean, minimal, easy‑to‑understand example.

---

##  Project Overview

This demo contains:

- A controllable **Player** (cube)
- An AI‑controlled **Enemy** (cube) using an FSM
- A simple ground plane and waypoints
- Four AI states:
  - **Idle**
  - **Patrol**
  - **Chase**

This project is designed for educational use and accompanies a teaching assignment on AI in game development.

---

## Show-and-Tell Video (Google Drive)
Click the link below to watch the final demonstration video:

**[Show-and-Tell Video]([https://drive.google.com/file/d/FILE_ID/view?usp=sharing](https://drive.google.com/file/d/1SS9PEcTp3dql3jp1Dxzlwqe0Gm79V367/view?usp=drive_link))**

## FSM States Explained

### **1. Idle**
Enemy stays still for a short duration or until it detects the player.

### **2. Patrol**
Enemy walks between preset waypoints in a loop.

### **3. Chase**
Enemy moves toward the player when within sight range.

---

## Key Scripts

### **EnemyFSM.cs**
Implements the FSM with:
- State switching
- Patrol logic
- Player detection
- Chase movement

### **PlayerController.cs**
Simple movement script for control.

---

## How to Use

1. Clone the repository:
   ```bash
   git clone https://github.com/NEU-Yuyang7/Unity-FSM-Demo.git
   ```
2. Open the folder in **Unity 2022 or 2023**.
3. Open the scene:
   ```
   Assets/Scenes/Main.unity
   ```
4. Press **Play** — move the player cube with WASD.
5. Enemy will behave based on FSM rules.

---

## Important: GitHub Large File Handling

This project intentionally **excludes the Library folder** using `.gitignore` to prevent oversized commits.

Only these folders should be committed:

```
Assets/
Packages/
ProjectSettings/
.gitignore
README.md
LICENSE.md
FSM_Tutorial.pdf
FSM_Self_Test.pdf
demo.mp4
```

---

## Educational Purpose

This project is part of the take‑home final for:

**Teaching AI in Game Development**  
The FSM demo is used to introduce students to:

- AI behavior modeling
- State transitions
- Game logic design
- Debugging AI systems

---

## License

MIT License — free for educational and personal use.

