# AI-MR Engine Assembly Trainer

AI-powered Mixed Reality training system for interactive engine assembly using controller-free hand gestures.

## 📌 Overview

AI-MR Engine Assembly Trainer is a Unity-based Android AR application designed to provide an interactive and immersive environment for engine assembly training.

The system combines Augmented Reality, AI-based hand tracking, gesture recognition, 3D engine components, physics-based interaction, and guided assembly workflows.

Instead of using traditional controllers, the user can interact with virtual engine components using natural hand movements and pinch gestures.

---

## 🎯 Objectives

- Develop a controller-free AR interaction system.
- Track the user's hand and finger movements in real time.
- Detect gestures such as pointing and pinching.
- Select and highlight required engine components.
- Grab and move virtual components using hand gestures.
- Guide the user through a step-by-step assembly process.
- Provide snap-point based guidance for component placement.
- Create a foundation for industrial, military, and engineering training.

---

## ✨ Key Features

### 🥽 Augmented Reality

- Real-world plane detection.
- AR surface detection.
- Virtual engine placement using a placement reticle.
- Android AR deployment using ARCore.

### ✋ AI-Based Hand Tracking

- Real-time hand tracking.
- 21 hand landmark detection.
- Index fingertip tracking.
- Controller-free interaction.

### 🤏 Gesture Interaction

The system supports natural hand gestures:

- Pointing
- Pinching
- Grabbing
- Moving
- Releasing

### 🎯 Component Selection

The user's index fingertip is used to identify nearby interactive engine components.

The system checks the currently required assembly component before selecting it.

### 🟡 Component Highlighting

The selected component is visually highlighted to provide clear feedback to the user.

### 🖐️ Grab & Move

Users can pinch an engine component, move their hand, and release the component at the desired position.

### 📍 Snap-Point Guidance

Predefined snap points are used to identify the intended assembly location of a component.

### 📋 Step-by-Step Assembly

The assembly process is controlled using an Assembly Manager that guides the user through different assembly steps.

---

# 🧠 AI & Computer Vision

The project uses **MediaPipe BlazeHand** for real-time hand tracking.

The hand-tracking system detects **21 hand landmarks**, which are used to determine finger positions and recognize gestures.

### Hand Tracking Pipeline

Camera Feed  
↓  
Hand Detection  
↓  
Hand Landmark Detection  
↓  
21 Hand Landmarks  
↓  
Index Finger Tracking  
↓  
Pinch Detection  
↓  
Component Selection  
↓  
Grab & Move  
↓  
Assembly / Snap Guidance

---

# 🥽 AR Workflow

Launch Application  
↓  
Detect Real-World Surface  
↓  
Display Placement Reticle  
↓  
User Taps Surface  
↓  
Engine Model Spawned  
↓  
Assembly Instructions Displayed  
↓  
Hand Tracking Starts  
↓  
User Interacts With Engine Components

---

# 🔧 Assembly Workflow

The current assembly workflow contains multiple guided steps.

### Current Assembly Sequence

1. Install Connecting Rod
2. Install Piston
3. Install Camshaft
4. Install Timing Belt
5. Assembly Complete

### Assembly Process

Current Assembly Step  
↓  
Required Part Identified  
↓  
User Locates Part  
↓  
Part Highlighted  
↓  
Pinch to Grab  
↓  
Move Component  
↓  
Move Towards Snap Point  
↓  
Assembly Position Detected  
↓  
Complete Assembly Step  
↓  
Next Assembly Step

---

# 🏗️ System Architecture

```text
                    Android Camera
                           │
                           ▼
                  ┌─────────────────┐
                  │  AR Foundation  │
                  │    + ARCore     │
                  └────────┬────────┘
                           │
                           ▼
                    Engine Placement
                           │
                           │
                           ▼
                  ┌─────────────────┐
                  │  MediaPipe      │
                  │   BlazeHand     │
                  └────────┬────────┘
                           │
                           ▼
                    Hand Landmarks
                           │
                    ┌──────┴──────┐
                    ▼             ▼
             Selection        Pinch
             Manager         Detector
                    │             │
                    └──────┬──────┘
                           ▼
                     Grab Manager
                           │
                           ▼
                  Engine Components
                           │
                           ▼
                     Snap Manager
                           │
                           ▼
                   Assembly Manager
