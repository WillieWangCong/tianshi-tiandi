# Unity 项目设置指南

## 第一步：安装 Unity 编辑器

### 1. 打开 Unity Hub
Unity Hub 已安装在：`C:\Program Files\Unity Hub\Unity Hub.exe`

### 2. 安装 Unity 编辑器
1. 打开 Unity Hub
2. 点击左侧 **"Installs"（安装）**
3. 点击右上角 **"Install Editor"（安装编辑器）**
4. 选择 **Unity 2022.3 LTS**（长期支持版本）
5. 选择安装模块：
   - ✅ Unity Editor（必需）
   - ✅ Documentation（文档）
   - ✅ Windows Build Support (IL2CPP)（Windows 平台支持）
   - ⬜ Android Build Support（可选）
   - ⬜ iOS Build Support（可选）
   - ⬜ WebGL Build Support（可选）

**安装路径建议**：
- 默认路径：`C:\Program Files\Unity\Hub\Editor\2022.3.x\`
- 建议使用默认路径

---

## 第二步：创建 Unity 项目

### 方法一：从 Unity Hub 创建（推荐）

1. 打开 Unity Hub
2. 点击左侧 **"Projects"（项目）**
3. 点击右上角 **"New Project"（新建项目）**
4. 选择模板：
   - **2D Core** 模板（推荐）
   - 项目名称：`tianshi-tiandi`
   - 位置：`C:\Users\willi\.qclaw\workspace\`
5. 点击 **"Create Project"（创建项目）**

**注意**：创建项目后，Unity 会自动生成必要的文件。我们的代码已经在 `Assets/` 目录中，Unity 会自动识别。

### 方法二：添加现有项目

如果 Unity Hub 已经创建了项目：

1. 打开 Unity Hub
2. 点击左侧 **"Projects"（项目）**
3. 点击 **"Add"（添加）**
4. 选择项目文件夹：`C:\Users\willi\.qclaw\workspace\tianshi-tiandi`
5. 点击 **"Select Folder"（选择文件夹）**

---

## 第三步：配置项目设置

### 1. 项目设置（Project Settings）

打开 **Edit → Project Settings**

#### Player Settings
- **Company Name**: `TianshiTiandi`
- **Product Name**: `吞食天地`
- **Version**: `0.1.0`
- **Default Screen Width**: `640`
- **Default Screen Height**: `480`
- **Run In Background**: ✅ 启用
- **Resizable Window**: ✅ 启用

#### Quality Settings
- **Quality Level**: `Medium`（中等画质）
- **Pixel Light Count**: `4`
- **Texture Quality**: `Full Resolution`
- **Anisotropic Textures**: `Per Texture`
- **Anti Aliasing**: `2x Multi Sampling`
- **Soft Particles**: ✅ 启用

### 2. 输入设置（Input System）

使用默认的 Unity Input Manager 即可。

### 3. 标签和层（Tags and Layers）

建议添加以下标签：

**Tags（标签）**：
- `Player` - 玩家角色
- `Enemy` - 敌人
- `NPC` - NPC
- `Item` - 物品
- `Interactable` - 可交互对象

**Layers（层）**：
- `Player` - 玩家层
- `Enemy` - 敌人层
- `UI` - UI 层
- `Background` - 背景层

---

## 第四步：创建场景

### 1. 主菜单场景

创建场景：`Assets/Scenes/MainMenu.unity`

**场景结构**：
```
MainMenu Scene
├── Main Camera
├── EventSystem
├── Canvas
│   ├── Title Text
│   ├── New Game Button
│   ├── Continue Button
│   ├── Settings Button
│   └── Quit Button
└── AudioSource (BGM)
```

**步骤**：
1. 创建新场景：`File → New Scene`
2. 保存场景：`File → Save As` → `Assets/Scenes/MainMenu.unity`
3. 创建 Canvas：`GameObject → UI → Canvas`
4. 创建按钮：`GameObject → UI → Button`
5. 附加脚本：`MainMenuController.cs`

### 2. 游戏场景

创建场景：`Assets/Scenes/GameScene.unity`

**场景结构**：
```
GameScene
├── Main Camera
├── EventSystem
├── GameManager (Empty GameObject)
├── BattleManager (Empty GameObject)
├── PartyManager (Empty GameObject)
├── Canvas
│   ├── HUD
│   ├── Battle UI
│   └── Menu
└── Tilemap (地图)
```

---

## 第五步：创建预制体（Prefabs）

### 1. 角色预制体

创建文件夹：`Assets/Prefabs/Characters/`

**角色预制体结构**：
```
Character Prefab
├── Sprite Renderer
├── Animator
├── Box Collider 2D
└── Character Data (ScriptableObject Reference)
```

### 2. UI 预制体

创建文件夹：`Assets/Prefabs/UI/`

- `HealthBar.prefab` - 血条
- `DialogueBox.prefab` - 对话框
- `InventorySlot.prefab` - 背包格子

---

## 第六步：配置资源

### 1. 精灵图设置

将像素艺术图片放入 `Assets/Art/Sprites/`

**导入设置**：
- **Filter Mode**: `Point (no filter)`（像素风格）
- **Compression**: `None`
- **Pixels Per Unit**: `16` 或 `32`（根据素材）
- **Pivot**: `Center`

### 2. 音频设置

将音频文件放入：
- `Assets/Audio/BGM/` - 背景音乐
- `Assets/Audio/SFX/` - 音效

**音频设置**：
- BGM: **Load Type** = `Compressed in Memory`
- SFX: **Load Type** = `Decompress on Load`

---

## 第七步：测试战斗系统

### 1. 创建测试场景

1. 创建新场景：`Assets/Scenes/BattleTest.unity`
2. 创建空物体：`GameObject → Create Empty`
3. 命名为：`BattleTestManager`
4. 附加脚本：`BattleTest.cs`
5. 运行场景，查看控制台输出

### 2. 查看战斗日志

战斗测试会输出详细的战斗信息：
- 玩家队伍信息
- 敌人队伍信息
- 每回合的行动
- 伤害计算
- 战斗结果

---

## 常见问题

### Q1: 脚本无法编译？
**A**: 检查以下几点：
- 是否安装了 TextMeshPro（Unity 会提示安装）
- Assembly Definition 文件是否正确
- 所有命名空间是否正确引用

### Q2: 如何查看武将数据？
**A**: 在 Unity 编辑器中：
- `Project` 窗口 → 右键 → `Create → TianshiTiandi → Character Data`
- 创建 ScriptableObject 资产
- 在 Inspector 中编辑属性

### Q3: 如何运行战斗测试？
**A**: 两种方法：
1. 在测试场景中，直接运行游戏
2. 在 Inspector 中，右键点击 `BattleTest` 组件 → `Run Battle Test`

---

## 下一步

完成项目设置后，您可以：

1. ✅ **测试战斗系统** - 运行 BattleTest 场景
2. ⏳ **创建角色数据** - 使用 ScriptableObject 创建武将
3. ⏳ **设计 UI 界面** - 创建主菜单和战斗界面
4. ⏳ **制作像素素材** - 或寻找免费素材资源
5. ⏳ **实现地图系统** - 使用 Tilemap 创建地图

---

**更新时间**：2026-06-23
**版本**：1.0
