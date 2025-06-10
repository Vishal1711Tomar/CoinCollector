## 🪙 CoinClicker Game

A simplified idle clicker game built in Unity, where the player taps to collect coins 

---

## 🎥 Demo

▶️ [Watch Gameplay Video](https://drive.google.com/file/d/1sU2UlPEbZ0yA1nzylmjkOZfNeFeE0Flk/view?usp=sharing)

---
## 🖼️ Screenshots

> Below are some gameplay screenshots captured from the current build:

![Screenshot 1](.Screenshot/Assets.JPEG)



## 📌 Project Summary

- Built using Unity 6000.0.31f1 LTS
- Android-compatible (APK build included)
- Focused on idle mechanics and code architecture
- Implements saving, upgrading, and UI polish

---

## ✅ Features Implemented

### 🎮 Core Gameplay
- Tap to collect coins
- Visible coin counter (TextMeshPro)
- Upgrades:
  - 🛠️ Auto Collector: adds coins every second
  - ✋ Tap Multiplier: doubles coin gain per tap

### 🎨 UI
- Unity Canvas-based UI
- Upgrade menu (basic structure ready; transition optional)

### 🗂️ Project Structure
- Organized into folders: Scripts, UI, Prefabs, Sprite

### 🌐 Version Control
- Git initialized with Unity `.gitignore`
- Clean commit history

---

## 🧮 Game Logic Theorems

### 🔢 Score Calculation

> `score = i × 2^(i + j)`

- `i`: current coin streak  
- `j`: number of bombs in the grid  
- This encourages streak-based accuracy and penalizes bomb density

### 🧱 Box Count Per Level

> `boxes = 3^a`, where `a` = current level/layer

- Level 1: 3 boxes  
- Level 2: 9 boxes  
- Level 3: 27 boxes  
- Exponentially increases challenge

---

## 🚀 How to Run

1. Open the project in **Unity 2021.3 LTS or above**
2. Open `Main.unity` from `Scenes/`
3. Press Play ▶️
4. Tap to earn coins and Check your Luck

---
