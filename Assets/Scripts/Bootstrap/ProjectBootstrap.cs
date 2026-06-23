using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TianshiTiandi.Core;
using TianshiTiandi.Character;
using TianshiTiandi.Battle;

namespace TianshiTiandi.Bootstrap
{
    /// <summary>
    /// 项目启动器 - 自动初始化所有必要的管理器
    /// 无需在 Unity 编辑器中手动创建场景，直接运行即可
    /// </summary>
    public class ProjectBootstrap : MonoBehaviour
    {
        [Header("启动设置")]
        [SerializeField] private bool autoRunBattleTest = true;
        
        private void Awake()
        {
            Debug.Log("========================================");
            Debug.Log("吞食天地 - Unity 复刻版");
            Debug.Log("版本: 0.1.0");
            Debug.Log("========================================");
            
            // 创建必要的管理器
            CreateManagers();
        }

        private void Start()
        {
            if (autoRunBattleTest)
            {
                RunBattleDemo();
            }
        }

        /// <summary>
        /// 创建游戏管理器
        /// </summary>
        private void CreateManagers()
        {
            // GameManager
            if (GameManager.Instance == null)
            {
                GameObject gameManagerObj = new GameObject("GameManager");
                gameManagerObj.AddComponent<GameManager>();
                DontDestroyOnLoad(gameManagerObj);
                Debug.Log("✓ GameManager 已创建");
            }

            // BattleManager
            if (BattleManager.Instance == null)
            {
                GameObject battleManagerObj = new GameObject("BattleManager");
                battleManagerObj.AddComponent<BattleManager>();
                DontDestroyOnLoad(battleManagerObj);
                Debug.Log("✓ BattleManager 已创建");
            }

            // PartyManager
            if (PartyManager.Instance == null)
            {
                GameObject partyManagerObj = new GameObject("PartyManager");
                partyManagerObj.AddComponent<PartyManager>();
                DontDestroyOnLoad(partyManagerObj);
                Debug.Log("✓ PartyManager 已创建");
            }
        }

        /// <summary>
        /// 运行战斗演示
        /// </summary>
        private void RunBattleDemo()
        {
            Debug.Log("\n========================================");
            Debug.Log("开始战斗演示");
            Debug.Log("========================================\n");

            // 创建玩家队伍
            List<CharacterData> playerParty = CreatePlayerParty();
            
            // 创建敌人队伍
            List<CharacterData> enemyParty = CreateEnemyParty();

            // 设置玩家队伍到 PartyManager
            foreach (var character in playerParty)
            {
                PartyManager.Instance.AddCharacter(character);
            }

            // 开始战斗
            BattleManager.Instance.StartBattle(enemyParty);
        }

        /// <summary>
        /// 创建玩家队伍（五虎将 + 诸葛亮）
        /// </summary>
        private List<CharacterData> CreatePlayerParty()
        {
            List<CharacterData> party = new List<CharacterData>
            {
                CreateCharacter("刘备", 1, CharacterType.Warrior, 
                    "蜀汉昭烈帝，仁德之主", 120, 60, 15, 8, 12, 15),
                    
                CreateCharacter("关羽", 2, CharacterType.Warrior,
                    "武圣，忠义无双", 140, 40, 20, 10, 10, 12),
                    
                CreateCharacter("张飞", 3, CharacterType.Warrior,
                    "猛将，勇猛无敌", 150, 30, 22, 7, 8, 8),
                    
                CreateCharacter("赵云", 4, CharacterType.Warrior,
                    "常胜将军，浑身是胆", 130, 50, 18, 9, 18, 14),
                    
                CreateCharacter("诸葛亮", 5, CharacterType.Strategist,
                    "卧龙先生，智谋无双", 80, 100, 8, 5, 15, 25)
            };

            Debug.Log("【玩家队伍】");
            foreach (var character in party)
            {
                Debug.Log($"  {character.CharacterName} Lv.{character.Level}");
                Debug.Log($"    HP: {character.CurrentHp}/{character.MaxHp}  MP: {character.CurrentMp}/{character.MaxMp}");
                Debug.Log($"    攻击: {character.Attack}  防御: {character.Defense}");
                Debug.Log($"    速度: {character.Speed}  智力: {character.Intelligence}");
            }

            return party;
        }

        /// <summary>
        /// 创建敌人队伍（黄巾军）
        /// </summary>
        private List<CharacterData> CreateEnemyParty()
        {
            List<CharacterData> enemies = new List<CharacterData>
            {
                CreateCharacter("黄巾贼", 101, CharacterType.Soldier,
                    "黄巾起义军士兵", 50, 0, 8, 3, 8, 5),
                    
                CreateCharacter("黄巾贼", 102, CharacterType.Soldier,
                    "黄巾起义军士兵", 50, 0, 8, 3, 8, 5),
                    
                CreateCharacter("黄巾头目", 103, CharacterType.Soldier,
                    "黄巾军小头目", 80, 20, 12, 5, 10, 8)
            };

            Debug.Log("\n【敌人队伍】");
            foreach (var enemy in enemies)
            {
                Debug.Log($"  {enemy.CharacterName} Lv.{enemy.Level}");
                Debug.Log($"    HP: {enemy.CurrentHp}/{enemy.MaxHp}");
            }

            return enemies;
        }

        /// <summary>
        /// 创建角色（简化版，不使用反射）
        /// </summary>
        private CharacterData CreateCharacter(string name, int id, CharacterType type, 
            string desc, int hp, int mp, int atk, int def, int spd, int intl)
        {
            CharacterData character = ScriptableObject.CreateInstance<CharacterData>();
            
            // 使用公共方法或属性（需要修改 CharacterData.cs）
            // 这里我们创建一个临时解决方案
            InitializeCharacter(character, name, id, type, desc, hp, mp, atk, def, spd, intl);
            
            return character;
        }

        /// <summary>
        /// 初始化角色数据（通过反射）
        /// </summary>
        private void InitializeCharacter(CharacterData character, string name, int id, 
            CharacterType type, string desc, int hp, int mp, int atk, int def, int spd, int intl)
        {
            var characterType = typeof(CharacterData);
            
            // 设置字段
            SetField(characterType, character, "characterName", name);
            SetField(characterType, character, "characterId", id);
            SetField(characterType, character, "characterType", type);
            SetField(characterType, character, "description", desc);
            SetField(characterType, character, "level", 1);
            SetField(characterType, character, "maxHp", hp);
            SetField(characterType, character, "currentHp", hp);
            SetField(characterType, character, "maxMp", mp);
            SetField(characterType, character, "currentMp", mp);
            SetField(characterType, character, "attack", atk);
            SetField(characterType, character, "defense", def);
            SetField(characterType, character, "speed", spd);
            SetField(characterType, character, "intelligence", intl);
            SetField(characterType, character, "currentExp", 0);
            SetField(characterType, character, "expToNextLevel", 100);
        }

        /// <summary>
        /// 设置字段值
        /// </summary>
        private void SetField(System.Type type, object obj, string fieldName, object value)
        {
            var field = type.GetField($"<{fieldName}>k__BackingField",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            
            if (field == null)
            {
                field = type.GetField(fieldName,
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            }
            
            if (field != null)
            {
                field.SetValue(obj, value);
            }
        }

        /// <summary>
        /// 在编辑器中添加测试按钮
        /// </summary>
        [ContextMenu("运行战斗演示")]
        private void RunDemoFromContextMenu()
        {
            RunBattleDemo();
        }

        /// <summary>
        /// 在编辑器中添加重置按钮
        /// </summary>
        [ContextMenu("重置战斗")]
        private void ResetBattle()
        {
            Debug.Log("重置战斗...");
            RunBattleDemo();
        }
    }
}
