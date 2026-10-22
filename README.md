# Escape Room VR — Virtual Escape Game

Welcome to **Escape Room VR**, an immersive virtual reality escape room experience developed in Unity using the **XR Interaction Toolkit** and **OpenXR**. Players explore atmospheric rooms, examine clues, interact with physical and electronic objects, and solve puzzles to unlock doors and escape.

---

## Current Project Status & Progress

* **Current Development Milestone:** **Level 1 ("Ordinary Room") is Complete and Fully Playable.**
* **Level 2 ("Pharaoh's Temple"):** In Development / Partially Implemented (Environment and core puzzle logic scripted; polish and level flow ongoing).
* **Testing & Device Support:** Fully playable on VR headsets (Oculus Quest / Meta Quest, Windows Mixed Reality) and in the Unity Editor using the integrated **XR Device Simulator** (no headset required).

---

## Gameplay & Features

### 1. Main Menu (`MainMenu.unity`) — Complete
* **Setting:** Front yard exterior of a mysterious suburban house.
* **Interaction:** Players approach the front entrance and press the interactive physical doorbell (via direct hand poke or XR ray interactor) to trigger the opening sequence and enter the house.
* **Simulator Ready:** Includes pre-configured `XR Device Simulator` and adjusted VR eye-height camera tracking.

### 2. Level 1: Ordinary Room (`Level1.unity`) — Complete & Playable
* **Setting:** An ordinary-looking living room concealing hidden puzzles.
* **Interactive Puzzles:**
  * **Color Sequence Clue:** Framed color paintings (Red, Yellow, Green, Blue) and color-coded books placed throughout the room provide the sequence hint.
  * **Interactive Combination Safe (`SafeManager.cs` & `SafeButtons.cs`):** A heavy electronic safe with 4 interactive pushbuttons and real-time numeric displays. Correctly setting the sequence (`3 - 4 - 2 - 5`) unlocks the safe with audio feedback and smooth door animation.
  * **Digital Keypad Door Lock (`KeypadManager.cs`):** A 10-digit wall-mounted keypad controlling the room's main exit door. Entering the 4-digit code (`5 2 9 7`) confirms the input and triggers the exit door opening animation.
  * **Level Transition Gateway (`NextLevel.cs`):** Passing through the exit door triggers the transition to the next stage.
  * **Live Stopwatch Timer (`TimerManager.cs`):** An on-screen escape room timer formatted in `mm:ss:fff`.

### 3. Level 2: Pharaoh's Temple (`Level2.unity`) — Under Development
* **Setting:** An ancient Egyptian tomb with pillars, sarcophagi, and historical artifacts.
* **Implemented Mechanics (In Progress):**
  * **5-Lever Wall Puzzle (`LeversManager.cs` & `LeverFlip.cs`):** Specific lever combinations raise the chamber door.
  * **Relic Socketing System (`SocketObject.cs`):** Snapping three relics (*Pyramid*, *Magic Box*, and *Scarab*) into designated sockets triggers the opening of the Pharaoh's coffin.
  * **Ankh Treasure System (`AnkhSocket.cs`):** Placing the sacred Ankh key into the socket unlocks hidden treasure.

### 4. Game End (`GameEnd.unity`) — Complete
* Celebratory victory scene displaying completion status with options to replay or quit.

---

## Technical Specifications & Requirements

* **Engine Version:** Unity **2021.3.11f1 (LTS)**
* **Render Pipeline:** Built-in Render Pipeline (Standard Shaders with GPU Instancing variants enabled)
* **XR Framework:** 
  * Unity XR Interaction Toolkit (`2.0.4`)
  * Unity OpenXR Plugin (`1.4.2`)
  * Microsoft Mixed Reality OpenXR Plugin (`1.9.0`)
  * Oculus XR Plugin (`3.0.2`)
  * Unity ProBuilder (`5.0.7`)
  * TextMeshPro (`3.0.6`)

---

## Getting Started & Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/samrudhirdivekar22-rgb/Escape-Room-VR.git
```

### 2. Open the Project in Unity Hub
1. Open **Unity Hub**.
2. Click **Add** and browse to the cloned `Escape-Room-VR` directory.
3. Select **Unity 2021.3.11f1** as the Editor version.
4. Open the project. Allow Unity to import and compile packages on first launch.

### 3. Playing the Game

#### Option A: Playing with a VR Headset (Meta Quest / Oculus / PCVR)
1. Connect your headset to your PC via Oculus Link, AirLink, or OpenXR-compatible runtime.
2. In Unity, ensure **Project Settings > XR Plug-in Management > OpenXR / Oculus** is enabled.
3. Open `Assets/Scenes/MainMenu.unity` and click **Play**.

#### Option B: Playing in Editor without a Headset (XR Device Simulator)
The project includes the pre-configured **XR Device Simulator** in each scene, allowing full keyboard & mouse control:
* **WASD:** Move player forward / left / backward / right.
* **Right Mouse Button (Hold) + Mouse Movement:** Look around (rotate head/camera).
* **Left Mouse Button / Left Controller Trigger:** Interact / Press buttons / Grab objects.
* **Spacebar (Hold):** Control right hand controller.
* **Left Shift (Hold):** Control left hand controller.
* **Scroll Wheel:** Move controller closer or farther away.

---

## Script Architecture Overview

| Script | Purpose & Functionality |
| :--- | :--- |
| [`DoorBell.cs`](Assets/Scripts/DoorBell.cs) | Handles physical poke and XR interaction on the entrance doorbell, audio cues, and scene transition. |
| [`MenuManager.cs`](Assets/Scripts/MenuManager.cs) | UI menu management for starting Level 1, returning to menu, restarting, or quitting. |
| [`KeypadManager.cs`](Assets/Scripts/KeypadManager.cs) | Numeric keypad input, code validation (`5297`), and exit door opening animation. |
| [`SafeManager.cs`](Assets/Scripts/SafeManager.cs) | Electronic safe logic, combination validation (`3425`), and safe opening animation. |
| [`SafeButtons.cs`](Assets/Scripts/SafeButtons.cs) | Interactive increment buttons on the safe display. |
| [`TimerManager.cs`](Assets/Scripts/TimerManager.cs) | Real-time stopwatch HUD tracking escape completion time. |
| [`NextLevel.cs`](Assets/Scripts/NextLevel.cs) | Trigger zone collider loading the next build index scene. |
| [`SocketObject.cs`](Assets/Scripts/SocketObject.cs) | Multi-socket interactor validating relic placement for coffin opening in Level 2. |
| [`LeversManager.cs`](Assets/Scripts/LeversManager.cs) | Multi-lever state manager controlling temple chamber door progression. |
| [`LeverFlip.cs`](Assets/Scripts/LeverFlip.cs) | Individual interactive lever toggle animation. |
| [`AnkhSocket.cs`](Assets/Scripts/AnkhSocket.cs) | Dedicated socket for the Ankh relic triggering treasure room reveal. |
| [`ChestOpen.cs`](Assets/Scripts/ChestOpen.cs) | Treasure chest opening animation and sound effects. |
| [`AnimateHandOnInput.cs`](Assets/Scripts/AnimateHandOnInput.cs) | VR hand model pinch and grip animations driven by controller input. |

---

## Future Roadmap

1. **Complete Level 2 (Pharaoh's Temple):**
   * Finalize relic socket snapping physics and feedback.
   * Add particle effects (dust, torch flames) and Egyptian atmospheric soundscapes.
   * Complete end-to-end level trigger into the victory scene.
2. **Additional Escape Rooms:**
   * Design Level 3 concept (Sci-Fi Laboratory / Cyberpunk vault).
3. **VR Accessibility & Polish:**
   * Add customizable teleportation and continuous locomotion options.
   * Add VR haptic feedback on button presses and object interactions.

---

## Attribution & Credits

* **Original Project Foundation:**
  * Original creator: **Sherif Ahmed** ([@Sherif-2001](https://github.com/Sherif-2001)).
  * Based on the original prototype repository *Virtual Escape - VR Escape Room Game*.
* **Current Lead Developer & Maintainer:**
  * **Samrudhi Divekar** ([@samrudhirdivekar22-rgb](https://github.com/samrudhirdivekar22-rgb)).
  * Active development: Level 1 puzzle implementation and balancing, XR Device Simulator integration, OpenXR/MRTK compatibility, lighting, and project maintenance.
* **Third-Party 3D Assets & Packages:**
  * 3D models and textures utilized for environment dressing (PBR Combination Safe, HousePack, Gabie's Keys, Ankh Asset, Coffin of Mut-iy-iy, Egyptian Scarab & Mummy assets) remain the intellectual property of their respective creators under their applicable Creative Commons and store distribution licenses.
