using UnityEngine;

namespace TianshiTiandi.Character
{
    /// <summary>
    /// 武将数据类 - 存储角色的基础属性
    /// </summary>
    [CreateAssetMenu(fileName = "NewCharacter", menuName = "TianshiTiandi/Character Data")]
    public class CharacterData : ScriptableObject
    {
        [Header("基础信息")]
        [SerializeField] private string characterName;
        [SerializeField] private int characterId;
        [SerializeField] private CharacterType characterType;
        [TextArea(3, 5)]
        [SerializeField] private string description;

        [Header("属性")]
        [SerializeField] private int level = 1;
        [SerializeField] private int maxHp = 100;
        [SerializeField] private int currentHp = 100;
        [SerializeField] private int maxMp = 50;
        [SerializeField] private int currentMp = 50;
        [SerializeField] private int attack = 10;
        [SerializeField] private int defense = 5;
        [SerializeField] private int speed = 10;
        [SerializeField] private int intelligence = 10;

        [Header("经验值")]
        [SerializeField] private int currentExp = 0;
        [SerializeField] private int expToNextLevel = 100;

        [Header("技能")]
        [SerializeField] private SkillData[] skills;

        // 属性访问器
        public string CharacterName => characterName;
        public int CharacterId => characterId;
        public CharacterType CharacterType => characterType;
        public string Description => description;

        public int Level => level;
        public int MaxHp => maxHp;
        public int CurrentHp => currentHp;
        public int MaxMp => maxMp;
        public int CurrentMp => currentMp;
        public int Attack => attack;
        public int Defense => defense;
        public int Speed => speed;
        public int Intelligence => intelligence;
        public int CurrentExp => currentExp;
        public int ExpToNextLevel => expToNextLevel;
        public SkillData[] Skills => skills;

        /// <summary>
        /// 增加经验值
        /// </summary>
        public void AddExp(int amount)
        {
            currentExp += amount;

            while (currentExp >= expToNextLevel)
            {
                LevelUp();
            }
        }

        /// <summary>
        /// 升级
        /// </summary>
        private void LevelUp()
        {
            level++;
            currentExp -= expToNextLevel;
            expToNextLevel = (int)(expToNextLevel * 1.5f);

            // 属性提升
            maxHp += Random.Range(5, 15);
            maxMp += Random.Range(2, 8);
            attack += Random.Range(1, 3);
            defense += Random.Range(1, 3);
            speed += Random.Range(0, 2);
            intelligence += Random.Range(1, 3);

            currentHp = maxHp;
            currentMp = maxMp;

            Debug.Log($"{characterName} 升级到 {level} 级！");
        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        public void TakeDamage(int damage)
        {
            currentHp = Mathf.Max(0, currentHp - damage);
        }

        /// <summary>
        /// 恢复HP
        /// </summary>
        public void Heal(int amount)
        {
            currentHp = Mathf.Min(maxHp, currentHp + amount);
        }

        /// <summary>
        /// 消耗MP
        /// </summary>
        public bool UseMp(int amount)
        {
            if (currentMp >= amount)
            {
                currentMp -= amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 恢复MP
        /// </summary>
        public void RestoreMp(int amount)
        {
            currentMp = Mathf.Min(maxMp, currentMp + amount);
        }

        /// <summary>
        /// 是否存活
        /// </summary>
        public bool IsAlive()
        {
            return currentHp > 0;
        }
    }

    /// <summary>
    /// 角色类型
    /// </summary>
    public enum CharacterType
    {
        Warrior,    // 武将
        Strategist, // 军师
        Soldier,    // 士兵
        Boss        // BOSS
    }

    /// <summary>
    /// 技能数据
    /// </summary>
    [System.Serializable]
    public class SkillData
    {
        public string skillName;
        public int mpCost;
        public int baseDamage;
        public SkillType skillType;
        public string description;
    }

    /// <summary>
    /// 技能类型
    /// </summary>
    public enum SkillType
    {
        Physical,   // 物理攻击
        Magic,      // 法术攻击
        Heal,       // 治疗
        Buff,       // 增益
        Debuff      // 减益
    }
}
