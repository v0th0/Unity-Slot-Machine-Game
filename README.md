# Unity Slot Machine Game

## Overview

This project is a simple slot machine game developed in Unity. It demonstrates reel animation, randomized outcomes, and a basic payout system based on symbol combinations.

---

## Features

* Smooth reel spinning with staggered start and stop
* Randomized outcomes for each spin
* Winning logic:

  * Three matching symbols: +30
  * Two matching symbols: +15
  * No match: -5
* Credit system with real-time updates
* Result panels for win, partial win, and loss
* Panels automatically hide after a short duration

---

## How to Run (WebGL)

1. Open the `Build/WebGL` folder
2. Run the `index.html` file in a browser

---

## Project Structure

* Assets/Scripts: Game logic
* Assets/Prefabs: Reusable game objects and UI
* Assets/Animations: Animation files
* Assets/UI: UI assets

---

## Approach

The project is structured using separate components:

* GameManager controls the game flow and spin sequence
* ReelController handles reel movement and alignment
* WinManager manages win conditions, payouts, and UI feedback

The system is designed to be simple, modular, and easy to extend.

---

