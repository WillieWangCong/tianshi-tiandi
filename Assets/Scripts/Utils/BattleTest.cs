using UnityEngine;
using System.Collections.Generic;
using TianshiTiandi.Core;
using TianshiTiandi.Character;
using TianshiTiandi.Battle;

namespace TianshiTiandi.Testing
{
    /// <summary>
    /// 战斗测试脚本 - 用于测试回合制战斗系统
    /// </summary>
    public class BattleTest : MonoBehaviour
    {
        [Header("测试设置")]
        [SerializeField] private bool runTestOnStart = true;
        
        private void Start()
        {
            if (runTestOnStart)
            {
                RunBattleTest();
            }
        }

        /// <summary>
        /// 运行战斗测试
        /// </summary>
        public void RunBattleTest()
        {
            Debug.Log("========== 开始战斗测试 ==========");

            // 创建测试队伍
            List<CharacterData> playerParty = CreateTestPlayerParty();
            List<CharacterData> enemyParty = CreateTestEnemyParty();

            // 设置玩家队伍
            BattleManager.Instance.PlayerParty.Clear();
            foreach (var character in playerParty)
            {
                BattleManager.Instance.AddToParty(character);
            }

            // 开始战斗
            BattleManager.Instance.StartBattle(enemyParty);

            Debug.Log("========== 战斗测试完成 ==========");
        }

        /// <summary>
        /// 创建测试玩家队伍
        /// </summary>
        private List<CharacterData> CreateTestPlayerParty()
        {
            List<CharacterData> party = new List<CharacterData>
            {
                CharacterFactory.CreateLiuBei(),
                CharacterFactory.CreateGuanYu(),
                CharacterFactory.CreateZhangFei(),
                CharacterFactory.CreateZhaoYun(),
                CharacterFactory.CreateZhugeLiang()
            };

            Debug.Log($"玩家队伍创建完成：{party.Count} 名武将");
            foreach (var character in party)
            {
                Debug.Log($"  - {character.CharacterName} (Lv.{character.Level}) - HP:{character.CurrentHp}/{character.MaxHp} MP:{character.CurrentMp}/{character.MaxMp}");
            }

            return party;
        }

        /// <summary>
        /// 创建测试敌人队伍
        /// </summary>
        private List<CharacterData> CreateTestEnemyParty()
        {
            List<CharacterData> enemies = new List<CharacterData>
            {
                CreateTestEnemy("黄巾贼", 1, 50, 0, 8, 3, 8, 5),
                CreateTestEnemy("黄巾贼", 2, 50, 0, 8, 3, 8, 5),
                CreateTestEnemy("黄巾头目", 3, 80, 20, 12, 5, 10, 8)
            };

            Debug.Log($"敌人队伍创建完成：{enemies.Count} 名敌人");
            foreach (var enemy in enemies)
            {
                Debug.Log($"  - {enemy.CharacterName} (Lv.{enemy.Level}) - HP:{enemy.CurrentHp}/{enemy.MaxHp}");
            }

            return enemies;
        }

        /// <summary>
        /// 创建测试敌人
        /// </summary>
        private CharacterData CreateTestEnemy(string name, int id, int hp, int mp, int atk, int def, int spd, int intl)
        {
            CharacterData enemy = ScriptableObject.CreateInstance<CharacterData>();
            
            // 使用反射设置属性
            SetPrivateField(enemy, "characterName", name);
            SetPrivateField(enemy, "characterId", 1000 + id);
            SetPrivateField(enemy, "characterType", CharacterType.Soldier);
            SetPrivateField(enemy, "description", $"测试敌人 - {name}");
            
            SetPrivateField(enemy, "level", 1);
            SetPrivateField(enemy, "maxHp", hp);
            SetPrivateField(enemy, "currentHp", hp);
            SetPrivateField(enemy, "maxMp", mp);
            SetPrivateField(enemy, "currentMp", mp);
            SetPrivateField(enemy, "attack", atk);
            SetPrivateField(enemy, "defense", def);
            SetPrivateField(enemy, "speed", spd);
            SetPrivateField(enemy, "intelligence", intl);
            
            return enemy;
        }

        /// <summary>
        /// 辅助方法：通过反射设置私有字段
        /// </summary>
        private void SetPrivateField(object obj, string fieldName, object value)
        {
            var field = obj.GetType().GetField($"<{fieldName}>k__BackingField", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            
            if (field == null)
            {
                field = obj.GetType().GetField(fieldName, 
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
        [ContextMenu("Run Battle Test")]
        private void RunTestFromContextMenu()
        {
            RunBattleTest();
        }
    }
}
