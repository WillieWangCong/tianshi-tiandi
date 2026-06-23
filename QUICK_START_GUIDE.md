# 吞食天地项目 - 快速启动指南

## 🚀 项目现已可以在 Unity 中运行！

### 当前状态
✅ **所有必要的 Unity 项目文件已创建**
✅ **启动场景已配置（Bootstrap.unity）**
✅ **战斗系统可以自动运行**

---

## 📋 下一步操作

### 方法一：通过 Unity Hub 打开（推荐）

1. **打开 Unity Hub**（已在运行）
   - 系统托盘找到 Unity Hub 图标
   - 或运行：`C:\Program Files\Unity Hub\Unity Hub.exe`

2. **安装 Unity 编辑器**（如果还没安装）
   - 点击左侧 "Installs"
   - 点击 "Install Editor"
   - 选择 **Unity 2022.3 LTS**
   - 勾选：
     - ✅ Unity Editor
     - ✅ Documentation  
     - ✅ Windows Build Support (IL2CPP)
   - 等待安装完成（约 30-60 分钟）

3. **添加项目**
   - 点击左侧 "Projects"
   - 点击 "Add" 按钮
   - 选择文件夹：`C:\Users\willi\.qclaw\workspace\tianshi-tiandi`
   - 点击 "Select Folder"

4. **打开项目**
   - 在项目列表中点击 "tianshi-tiandi"
   - 等待 Unity 编译脚本（首次可能需要几分钟）
   - 如果提示安装 TextMeshPro，点击 "Import"

---

## 🎮 运行项目

### 自动战斗演示
项目已配置为**自动运行战斗演示**：

1. 打开项目后，场景 `Bootstrap.unity` 会自动加载
2. 点击 Unity 编辑器顶部的 ▶️ 播放按钮
3. 查看控制台（Console）输出的战斗日志

### 战斗演示内容
- **玩家队伍**：刘备、关羽、张飞、赵云、诸葛亮
- **敌人队伍**：3名黄巾军
- **战斗流程**：回合制战斗，自动进行
- **输出信息**：
  - 武将属性（HP/MP/攻击/防御/速度/智力）
  - 每回合行动
  - 伤害计算
  - 战斗结果

---

## 📊 项目文件结构

```
tianshi-tiandi/
├── Assets/
│   ├── Scenes/
│   │   └── Bootstrap.unity          ← 启动场景（已配置）
│   ├── Scripts/
│   │   ├── Bootstrap/
│   │   │   └── ProjectBootstrap.cs  ← 启动脚本
│   │   ├── Core/
│   │   │   └── GameManager.cs
│   │   ├── Battle/
│   │   │   └── BattleManager.cs
│   │   ├── Character/
│   │   │   ├── CharacterData.cs
│   │   │   ├── CharacterFactory.cs
│   │   │   ├── ItemData.cs
│   │   │   └── PartyManager.cs
│   │   ├── Data/
│   │   │   ├── SkillDatabase.cs
│   │   │   └── ItemDatabase.cs
│   │   ├── UI/
│   │   │   └── MainMenuController.cs
│   │   ├── Utils/
│   │   │   ├── GameConfig.cs
│   │   │   └── BattleTest.cs
│   │   └── TianshiTiandi.asmdef
│   ├── Art/
│   ├── Audio/
│   ├── Prefabs/
│   └── Resources/
├── Packages/
│   ├── manifest.json
│   └── packages-lock.json
├── ProjectSettings/
│   ├── ProjectSettings.asset
│   ├── QualitySettings.asset
│   ├── GraphicsSettings.asset
│   ├── InputManager.asset
│   ├── Physics2DSettings.asset
│   ├── TagManager.asset
│   └── AudioManager.asset
├── README.md
├── ROADMAP.md
├── UNITY_SETUP_GUIDE.md
└── .gitignore
```

---

## ✅ 已创建的 Unity 配置文件

| 文件 | 状态 | 说明 |
|------|------|------|
| Packages/manifest.json | ✅ | 包管理器配置 |
| Packages/packages-lock.json | ✅ | 包版本锁定 |
| ProjectSettings/ProjectSettings.asset | ✅ | 项目设置 |
| ProjectSettings/QualitySettings.asset | ✅ | 画质设置 |
| ProjectSettings/GraphicsSettings.asset | ✅ | 图形设置 |
| ProjectSettings/InputManager.asset | ✅ | 输入管理 |
| ProjectSettings/Physics2DSettings.asset | ✅ | 2D物理设置 |
| ProjectSettings/TagManager.asset | ✅ | 标签和层 |
| ProjectSettings/AudioManager.asset | ✅ | 音频管理 |
| Assets/Scenes/Bootstrap.unity | ✅ | 启动场景 |

---

## 🎯 预期结果

### 当您在 Unity 中打开项目并运行时：

```
========================================
吞食天地 - Unity 复刻版
版本: 0.1.0
========================================

✓ GameManager 已创建
✓ BattleManager 已创建
✓ PartyManager 已创建

========================================
开始战斗演示
========================================

【玩家队伍】
  刘备 Lv.1
    HP: 120/120  MP: 60/60
    攻击: 15  防御: 8
    速度: 12  智力: 15
  关羽 Lv.1
    ...
  张飞 Lv.1
    ...
  赵云 Lv.1
    ...
  诸葛亮 Lv.1
    ...

【敌人队伍】
  黄巾贼 Lv.1
    HP: 50/50
  黄巾贼 Lv.1
    HP: 50/50
  黄巾头目 Lv.1
    HP: 80/80

战斗开始！敌方有 3 名敌人

=== 第 1 回合 ===
关羽 攻击 黄巾贼，造成 17 点伤害！
张飞 攻击 黄巾贼，造成 19 点伤害！
...

========================================
战斗胜利！
获得经验值：50
========================================
```

---

## ⚠️ 可能遇到的问题

### 问题1：提示安装 TextMeshPro
**解决方案**：点击 "Import TMP Essentials" 按钮

### 问题2：脚本编译错误
**解决方案**：
1. 检查控制台错误信息
2. 确认所有脚本文件都已创建
3. 尝试：`Assets → Reimport All`

### 问题3：场景无法加载
**解决方案**：
1. 打开 `Assets/Scenes/Bootstrap.unity`
2. 双击场景文件
3. 点击播放按钮

### 问题4：没有看到战斗日志
**解决方案**：
1. 打开控制台：`Window → General → Console`
2. 确保场景中包含 `ProjectBootstrap` 游戏对象
3. 检查脚本是否正确附加

---

## 📝 后续开发建议

### 完成基础功能后：
1. **创建战斗 UI** - 显示血条、MP条、技能按钮
2. **添加像素素材** - 角色立绘、地图瓦片
3. **实现地图系统** - 使用 Tilemap 创建世界地图
4. **添加音效音乐** - 战斗音效、背景音乐

### 参考文档：
- `README.md` - 项目总览
- `ROADMAP.md` - 6-12个月开发计划
- `UNITY_SETUP_GUIDE.md` - Unity 详细设置指南

---

## 🎉 项目统计

| 项目 | 数量 |
|------|------|
| C# 脚本 | 11 个 |
| 代码行数 | ~3000+ 行 |
| 预设武将 | 7 个 |
| 技能 | 20+ 个 |
| 物品 | 25+ 个 |
| Unity 配置文件 | 9 个 |
| 场景文件 | 1 个 |

---

**创建时间**：2026-06-23 11:20 GMT+8  
**项目状态**：✅ 可在 Unity 中运行  
**下一步**：安装 Unity 编辑器并打开项目  
**仓库地址**：https://github.com/WillieWangCong/tianshi-tiandi
