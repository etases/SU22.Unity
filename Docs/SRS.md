


> # JumpKingGame - Software Requirements Specification

## Table of Contents
- [JumpKingGame - Software Requirements Specification](#gyrogame---software-requirements-specification)
  - [Table of Contents](#table-of-contents)
  - [1. Introduction](#1-introduction)
    - [1.1 Purpose](#11-purpose)
    - [1.2 Scope](#12-scope)
    - [1.3 Definitions, Acronyms and Abbreviations](#13-definitions-acronyms-and-abbreviations)
    - [1.4 References](#14-references)
    - [1.5 Overview](#15-overview)
  - [2. Overall Description](#2-overall-description)
    - [2.1 Vision](#21-vision)
    - [2.2 Overall Use-Case-Diagram](#22-overall-use-case-diagram)
    - [2.3 Use Cases](#23-use-cases)
    - [2.4 User Characteristics](#24-user-characteristics)
  - [3. Specific Requirements](#3-specific-requirements)
    - [3.1 Functionality](#31-functionality)
      - [3.1.1 Functionality - The Controller](#311-functionality---the-controller)
      - [3.1.2 Functionality - The Game](#312-functionality---the-game)
    - [3.2 Usability](#32-usability)
    - [3.3 Reliability](#33-reliability)
      - [3.3.1 Availability](#331-availability)
      - [3.3.2 Bugs](#332-bugs)
    - [3.4 Performance](#34-performance)
    - [3.5 Supportability](#35-supportability)
    - [3.6 Design Constraints](#36-design-constraints)
      - [3.6.1 Development tools](#361-development-tools)
      - [3.6.2 Unity](#362-unity)
      - [3.6.3 Arduino IDE](#363-arduino-ide)
    - [3.7 Purchased Components](#37-purchased-components)
    - [3.8 Interfaces](#39-interfaces)
      - [3.8.1 User Interfaces](#391-user-interfaces)
      - [3.8.2 Hardware Interfaces](#392-hardware-interfaces)
      - [3.8.3 Software Interfaces](#393-software-interfaces)
      - [3.8.4 Communications Interfaces](#394-communications-interfaces)
    - [3.9 Licensing Requirements](#310-licensing-requirements)
    - [3.10 Legal, Copyright and other Notices](#312-legal-copyright-and-other-notices)
    - [3.11 Applicable Standards](#313-applicable-standards)
  - [4. Supporting Information](#4-supporting-information)


## 1. Introduction

### 1.1 Purpose

The purpose of this document gives a general description of the JumpKingGame Project. It explains our vision and all features of the product. Also it offers insights into the hardware and software elements of the project.

### 1.2 Scope

This document is designed for internal use only and will outline the development process of the project.

### 1.3 Definitions, Acronyms and Abbreviations

| Term      |                                              |
| --------- | -------------------------------------------- |
| **SRS**   | Software Requirements Specification          |
| **Unity** | Open Source Game Engine used in this project |
| **AAA**   | A very high budget game                      |

### 1.4 References

| Title                                                                                                        | Date       |
| ----------------------------------------------------------------------------------------------------- | ---------- |
| [**Blog**](https://gyrogame.de/)                                                                             | 19/10/2019 |
| [**GitHub - Unity Project**](https://github.com/GyroInc/gyrogame-unity)                                      | 19/10/2019 |
| [**GitHub - Controller Firmware**](https://github.com/GyroInc/gyrogame-hardware)                             | 19/10/2019 |
| [**YouTrack Project Management**](https://youtrack.gyrogame.de)                                              | 10/12/2019 |
| [**Overall Use-Case-Diagram**](https://github.com/GyroInc/gyrogame-unity/blob/master/Documentation/OUCD_rev2.PNG) | 21/10/2019 |

### 1.5 Overview

The next chapters provide information about our vision based on the use case diagram as well as more detailed software requirements.

## 2. Overall Description

### 2.1 Vision

JumpKingGame's goal is to create a Platform game for gamers with puzzle adventure genre. Users have the ability to control their character to overcome obstacles, move forward, solve puzzles and find out mysteries to reach the final destination.

### 2.2 Overall Use-Case-Diagram

![UseCaseDiagram](https://github.com/GyroInc/gyrogame-unity/blob/master/Documentation/OUCD_rev2.svg)

### 2.3 Use Cases

[Use Case: Player Controler](https://github.com/GyroInc/gyrogame-unity/blob/master/Documentation/UseCases/PlayerMovement/UC_PlayerMovement.md)

[Use Case:  Power Up](https://github.com/GyroInc/gyrogame-unity/blob/master/Documentation/UseCases/PauseMenu/UC_PauseMenu.md)

[Use Case: Flatform](https://github.com/GyroInc/gyrogame-unity/blob/master/Documentation/UseCases/ConnectCube/UC_ConnectCube.md)

[Use Case: Menu](https://github.com/GyroInc/gyrogame-unity/blob/master/Documentation/UseCases/RotateObstacle/UC_RotateObstacle.md)


### 2.4 User Characteristics

Our main target group consists of people who like to play video games.

## 3. Specific Requirements

### 3.1 Functionality

#### 3.1.1 Functionality - The Controller

The game uses the character controller as a key component. Without it the game can not be played. The controller requires the player to maneuver their character across platforms, to reach a goal and avoiding obstacles along the way.

#### 3.1.2 Functionality - The Game

The game will be a 2D platform game. The user must maneuver the character through interaction with the controller. The levels will include blocked ways, ways that require the player to accurately calculate the character's jumping force, slippery and thorny surfaces that the character will need to cross to avoid or take advantage of use power up.

### 3.2 Usability

With very few user inputs e.g.  walking around and jumping around, the game will be intuitive to play. Also there will be at most a minimal user interface, to keep the game as simple as possible.

### 3.3 Reliability

#### 3.3.1 Availability

The game will be available to everyone for free.

#### 3.3.2 Bugs

We classify bugs like the following:

-   **Critical bug**: An error that crashes the game or hinders the player from progressing any further. 
-   **Non critical bug**: An issue that will not create a game breaking experience like shading issues or communication issues with the controller.

### 3.4 Performance

Unity has a baseline hardware requirement that must be met for it to work. However the game will not be an AAA title thus most computers will be able to run the game.

### 3.5 Supportability

Once the game is finished it wont be supported by us anymore. It is an open source project, so anyone who has improvements will be able to implement them und update the game.

### 3.6 Design Constraints

Due to limited time and resources we will keep the graphics simple and minimal, to reduce the time of 2d modelling and focus more on level design.

#### 3.6.1 Development tools

-   **git**: Version control system
-   **Unity**: Game engine
-   **Visual Studio**: IDE used for scripting within Unity

#### 3.6.2 Unity

Unity is a free and easy to use game engine. It is widely used by many people and has an active development and user community.
It is built on the .NET Framework and can be used like any other application.


### 3.7 Purchased Components

  We won't list any components as purchased, so we are can keep the self-built controllers.

### 3.8 Interfaces

#### 3.8.1 User Interfaces

The user will be able to navigate the menus via mouse input and a GUI, input movement commands via the W, A, S, D, E, Q, Space keys.

#### 3.8.2 Hardware Interfaces

The user will use the keyboard to communicate with the controller and the application will be displayed on the monitor.

#### 3.8.3 Software Interfaces

The game transfers serial data back and forth directly between the game and the controller hardware.

#### 3.8.4 Communications Interfaces

- N\A

### 3.9 Licensing Requirements

- N\A

### 3.10 Legal, Copyright and other Notices

This game application is for learning purposes only, not for commercial purposes. Image copyright and original ideas belong to Developer-Publisher Nexile.

### 3.11 Applicable Standards

-   N\A

## 4. Supporting Information

For a better overview, look at the table of contents and/or references.
