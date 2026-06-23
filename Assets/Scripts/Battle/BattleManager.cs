using UnityEngine;
using System.Collections.Generic;
using TianshiTiandi.Character;

namespace TianshiTiandi.Battle
{
    /// <summary>
    /// 战斗管理器 - 控制回合制战斗流程
    /// </summary>
    public class BattleManager : MonoBehaviour
    {
        public static BattleManager Instance { get; private set; }

        [Header("战斗设置")]
        [SerializeField] private int maxPartySize = 5;

        [Header("战斗单位")]
        [SerializeField] private List<CharacterData> playerParty = new List<CharacterData>();
        [SerializeField] private List<CharacterData> enemyParty = new List<CharacterData>();

        private int currentTurn = 0;
        private BattleState battleState = BattleState.Waiting;

        public BattleState BattleState => battleState;
        public List<CharacterData> PlayerParty => playerParty;
        public List<CharacterData> EnemyParty => enemyParty;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 开始战斗
        /// </summary>
        public void StartBattle(List<CharacterData> enemies)
        {
            enemyParty = new List<CharacterData>(enemies);
            currentTurn = 0;
            battleState = BattleState.InProgress;

            Debug.Log($"战斗开始！敌方有 {enemies.Count} 名敌人");
            StartNextTurn();
        }

        /// <summary>
        /// 开始下一回合
        /// </summary>
        private void StartNextTurn()
        {
            currentTurn++;
            Debug.Log($"=== 第 {currentTurn} 回合 ===");

            // 按速度排序，决定行动顺序
            List<CharacterData> allCharacters = new List<CharacterData>();
            allCharacters.AddRange(playerParty);
            allCharacters.AddRange(enemyParty);

            // 简单的速度排序
            allCharacters.Sort((a, b) => b.Speed.CompareTo(a.Speed));

            // 执行每个角色的行动
            foreach (var character in allCharacters)
            {
                if (character.IsAlive())
                {
                    ExecuteCharacterTurn(character);
                }
            }

            // 检查战斗是否结束
            CheckBattleEnd();
        }

        /// <summary>
        /// 执行角色回合
        /// </summary>
        private void ExecuteCharacterTurn(CharacterData character)
        {
            bool isPlayer = playerParty.Contains(character);

            if (isPlayer)
            {
                // 玩家行动（这里简化为自动攻击）
                CharacterData target = GetRandomAliveEnemy();
                if (target != null)
                {
                    ExecuteAttack(character, target);
                }
            }
            else
            {
                // 敌人行动
                CharacterData target = GetRandomAlivePlayer();
                if (target != null)
                {
                    ExecuteAttack(character, target);
                }
            }
        }

        /// <summary>
        /// 执行普通攻击
        /// </summary>
        public void ExecuteAttack(CharacterData attacker, CharacterData defender)
        {
            // 计算伤害
            int damage = Mathf.Max(1, attacker.Attack - defender.Defense / 2);

            // 添加随机波动
            damage = Mathf.RoundToInt(damage * Random.Range(0.9f, 1.1f));

            // 暴击判定（10% 概率）
            bool isCritical = Random.value < 0.1f;
            if (isCritical)
            {
                damage = Mathf.RoundToInt(damage * 1.5f);
                Debug.Log($"{attacker.CharacterName} 发动暴击！");
            }

            // 造成伤害
            defender.TakeDamage(damage);

            Debug.Log($"{attacker.CharacterName} 攻击 {defender.CharacterName}，造成 {damage} 点伤害！");

            if (!defender.IsAlive())
            {
                Debug.Log($"{defender.CharacterName} 被击败了！");
            }
        }

        /// <summary>
        /// 使用技能
        /// </summary>
        public void ExecuteSkill(CharacterData user, CharacterData target, SkillData skill)
        {
            if (!user.UseMp(skill.mpCost))
            {
                Debug.Log($"{user.CharacterName} MP不足，无法使用 {skill.skillName}！");
                return;
            }

            switch (skill.skillType)
            {
                case SkillType.Physical:
                case SkillType.Magic:
                    int damage = Mathf.Max(1, skill.baseDamage + user.Intelligence / 2);
                    target.TakeDamage(damage);
                    Debug.Log($"{user.CharacterName} 对 {target.CharacterName} 使用 {skill.skillName}，造成 {damage} 点伤害！");
                    break;

                case SkillType.Heal:
                    int healAmount = skill.baseDamage + user.Intelligence;
                    target.Heal(healAmount);
                    Debug.Log($"{user.CharacterName} 对 {target.CharacterName} 使用 {skill.skillName}，恢复 {healAmount} 点HP！");
                    break;

                case SkillType.Buff:
                    Debug.Log($"{user.CharacterName} 对 {target.CharacterName} 使用 {skill.skillName}！");
                    // TODO: 实现增益效果
                    break;

                case SkillType.Debuff:
                    Debug.Log($"{user.CharacterName} 对 {target.CharacterName} 使用 {skill.skillName}！");
                    // TODO: 实现减益效果
                    break;
            }
        }

        /// <summary>
        /// 获取随机存活的敌人
        /// </summary>
        private CharacterData GetRandomAliveEnemy()
        {
            List<CharacterData> aliveEnemies = enemyParty.FindAll(e => e.IsAlive());
            if (aliveEnemies.Count == 0) return null;
            return aliveEnemies[Random.Range(0, aliveEnemies.Count)];
        }

        /// <summary>
        /// 获取随机存活的玩家角色
        /// </summary>
        private CharacterData GetRandomAlivePlayer()
        {
            List<CharacterData> alivePlayers = playerParty.FindAll(p => p.IsAlive());
            if (alivePlayers.Count == 0) return null;
            return alivePlayers[Random.Range(0, alivePlayers.Count)];
        }

        /// <summary>
        /// 检查战斗是否结束
        /// </summary>
        private void CheckBattleEnd()
        {
            bool playerAlive = playerParty.Exists(p => p.IsAlive());
            bool enemyAlive = enemyParty.Exists(e => e.IsAlive());

            if (!playerAlive)
            {
                EndBattle(false);
            }
            else if (!enemyAlive)
            {
                EndBattle(true);
            }
            else
            {
                // 继续下一回合
                StartNextTurn();
            }
        }

        /// <summary>
        /// 结束战斗
        /// </summary>
        private void EndBattle(bool victory)
        {
            battleState = BattleState.Ended;

            if (victory)
            {
                Debug.Log("战斗胜利！");
                AwardBattleRewards();
            }
            else
            {
                Debug.Log("战斗失败...");
            }
        }

        /// <summary>
        /// 发放战斗奖励
        /// </summary>
        private void AwardBattleRewards()
        {
            int totalExp = 0;
            foreach (var enemy in enemyParty)
            {
                totalExp += enemy.Level * 10;
            }

            foreach (var player in playerParty)
            {
                if (player.IsAlive())
                {
                    player.AddExp(totalExp / playerParty.Count);
                }
            }

            Debug.Log($"获得经验值：{totalExp}");
        }

        /// <summary>
        /// 添加角色到队伍
        /// </summary>
        public void AddToParty(CharacterData character)
        {
            if (playerParty.Count < maxPartySize)
            {
                playerParty.Add(character);
                Debug.Log($"{character.CharacterName} 加入了队伍！");
            }
            else
            {
                Debug.Log("队伍已满！");
            }
        }

        /// <summary>
        /// 从队伍移除角色
        /// </summary>
        public void RemoveFromParty(CharacterData character)
        {
            if (playerParty.Remove(character))
            {
                Debug.Log($"{character.CharacterName} 离开了队伍。");
            }
        }
    }

    /// <summary>
    /// 战斗状态
    /// </summary>
    public enum BattleState
    {
        Waiting,    // 等待中
        InProgress, // 战斗中
        Ended       // 已结束
    }
}
