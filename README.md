# DinoAR (English)

An early exploratory version of an AR-based dinosaur metaverse system developed for a dinosaur fossil museum.

## Project Overview

DinoAR is an augmented reality application developed with Unity using NRSDK, designed to run on XREAL X and other AR glasses. Through augmented reality technology, users can observe 3D dinosaur models in their real environment, interact with the dinosaurs, and enjoy an immersive exhibition experience.

### Key Features

- **Plane Detection**: Identifies planes in the real environment to provide walking surfaces for dinosaurs
- **Gesture Interaction**: Control dinosaur behavior and movement through gestures
- **Gaze Tracking**: A reticle indicates the user's focus point, and dinosaurs move according to the reticle position
- **Animations and Sound Effects**: Realistic dinosaur animations and sound effects enhance immersion
- **Screen Recording**: Ability to record AR interactions and save to device gallery

![启动游戏](/images/启动游戏.png)

## Technical Architecture

- **Development Environment**: Unity 2022.3.x
- **Target Platforms**: XREAL X AR glasses, supported Android phones
- **Key Technologies**:
  - NRSDK (plane detection, gesture recognition, motion tracking, etc.)
  - Unity 3D model rendering and animation
  - C# scripting

## Installation and Usage

### System Requirements

- XREAL X AR glasses
- Supported Android phone (e.g., OPPO Find X5)
- Unity 2022.3 (only required for development)

### Installation Steps

1. Install the APK file on a supported Android device
2. Connect the AR glasses
3. Launch the application; it will automatically begin plane detection
4. When a plane is detected, use gestures or controller to point at the plane, and dinosaurs will appear and follow the reticle

## Developer Guide

### Project Directory Structure

- `Assets/Scripts/`: Main application scripts
- `Assets/PBRVelociraptor/`: Dinosaur models, animations, sound effects, and related scripts
- `Assets/NRSDK/`: NREAL SDK resources
- `Assets/Scenes/`: Application scenes
- `Assets/PlaneDetectionStarterPackage/`: Plane detection resources
- `ProjectSettings/`: Unity project settings

### Key Scripts

- Plane Detection: `PlaneDetector`
- Reticle Tracking: `ReticleBehaviour.cs`
- Dinosaur Behavior: `DinoBehaviour`
- Dinosaur Sound Effects: `RaptorSoundEffects.cs`
- Gem Generation: `GemSpawner.cs`
- Screen Recording: `VideoCapture2LocalExample`

## Contribution Guidelines

Contributions to the DinoAR project are welcome! If you find bugs or have suggestions for improvements, please submit an issue or pull request.

## License

MIT

---

# DinoAR（简体中文）

基于AR眼镜的恐龙元宇宙系统，为某恐龙化石博物馆开发的AR展示应用的初期探索版本。

## 项目概述

DinoAR是一款基于Unity开发的AR应用，使用NRSDK开发，可在XREAL X等AR眼镜上运行。通过增强现实技术，用户可以在现实环境中观察3D恐龙模型，与恐龙互动，获得身临其境的展示体验。

### 主要功能

- **平面检测**：识别现实环境中的平面，为恐龙提供行走表面
- **手势交互**：通过手势控制恐龙行为和移动
- **视线跟踪**：通过准星指示用户的注视点，恐龙会根据准星位置移动
- **动画与音效**：逼真的恐龙动画和音效，提升沉浸感
- **屏幕录制**：可记录AR交互过程，保存至设备相册

## 技术架构

**开发环境**：Unity 2022.3

**目标平台**：XREAL X AR眼镜、支持的Android手机

**主要技术**：

- NRSDK（平面检测、手势识别、运动追踪等）
- Unity 3D模型渲染与动画
- C#脚本编程

## 安装与使用

### 系统要求

- XREAL X AR眼镜
- 支持的Android手机（例如OPPO Find X5）
- Unity 2022.3（仅开发时需要）

### 安装步骤

1. 在支持的Android设备上安装APK文件
2. 连接AR眼镜
3. 启动应用，应用将自动开始平面检测
4. 当检测到平面后，使用手势或控制器指向平面位置，恐龙将出现并跟随准星移动

## 开发者指南

### 项目目录结构

- `Assets/Scripts/`: 应用主要脚本文件
- `Assets/PBRVelociraptor/`: 恐龙模型、动画、音效及相关脚本
- `Assets/NRSDK/`: NREAL SDK资源
- `Assets/Scenes/`: 应用场景
- `Assets/PlaneDetectionStarterPackage/`: 平面检测相关资源
- `ProjectSettings/`: Unity项目设置

### 关键脚本

- 平面检测：`PlaneDetector`
- 准星跟踪：`ReticleBehaviour.cs`
- 恐龙行为：`DinoBehaviour`
- 恐龙音效：`RaptorSoundEffects.cs`
- 钻石生成：`GemSpawner.cs`
- 屏幕录制：`VideoCapture2LocalExample`

## 贡献指南

欢迎为DinoAR项目做出贡献！如果您发现bug或有改进建议，请提交issue或pull request。

## 许可证

MIT
