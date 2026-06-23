using UnityEngine;
using System.Collections.Generic;
using TianshiTiandi.Character;

namespace TianshiTiandi.Data
{
    /// <summary>
    /// 技能数据库 - 存储游戏中所有技能
    /// </summary>
    [CreateAssetMenu(fileName = "SkillDatabase", menuName = "TianshiTiandi/Skill Database")]
    public class SkillDatabase : ScriptableObject
    {
        [SerializeField] private List<SkillData> skills = new List<SkillData>();

        public List<SkillData> Skills => skills;

        /// <summary>
        /// 获取所有物理技能
        /// </summary>
        public List<SkillData> GetPhysicalSkills()
        {
            return skills.FindAll(s => s.skillType == SkillType.Physical);
        }

        /// <summary>
        /// 获取所有法术技能
        /// </summary>
        public List<SkillData> GetMagicSkills()
        {
            return skills.FindAll(s => s.skillType == SkillType.Magic);
        }

        /// <summary>
        /// 获取所有治疗技能
        /// </summary>
        public List<SkillData> GetHealSkills()
        {
            return skills.FindAll(s => s.skillType == SkillType.Heal);
        }
    }

    /// <summary>
    /// 预定义技能数据
    /// </summary>
    public static class SkillDefinitions
    {
        // 物理技能
        public static readonly SkillData StrongSlash = new SkillData
        {
            skillName = "强力斩击",
            mpCost = 5,
            baseDamage = 25,
            skillType = SkillType.Physical,
            description = "强力的一击，造成大量物理伤害"
        };

        public static readonly SkillData WhirlwindSlash = new SkillData
        {
            skillName = "旋风斩",
            mpCost = 12,
            baseDamage = 35,
            skillType = SkillType.Physical,
            description = "旋转斩击，攻击全体敌人"
        };

        public static readonly SkillData DragonSlash = new SkillData
        {
            skillName = "龙斩",
            mpCost = 20,
            baseDamage = 60,
            skillType = SkillType.Physical,
            description = "传说中龙的斩击，威力巨大"
        };

        // 法术技能
        public static readonly SkillData FireBall = new SkillData
        {
            skillName = "火球术",
            mpCost = 8,
            baseDamage = 30,
            skillType = SkillType.Magic,
            description = "发射火球攻击敌人"
        };

        public static readonly SkillData IceBolt = new SkillData
        {
            skillName = "冰箭",
            mpCost = 10,
            baseDamage = 35,
            skillType = SkillType.Magic,
            description = "冰冻之箭，可减缓敌人速度"
        };

        public static readonly SkillData ThunderStrike = new SkillData
        {
            skillName = "落雷",
            mpCost = 15,
            baseDamage = 50,
            skillType = SkillType.Magic,
            description = "召唤雷电攻击敌人"
        };

        public static readonly SkillData FireRain = new SkillData
        {
            skillName = "火雨",
            mpCost = 25,
            baseDamage = 80,
            skillType = SkillType.Magic,
            description = "召唤火雨攻击全体敌人"
        };

        // 诸葛亮专属技能
        public static readonly SkillData EightDiagramFormation = new SkillData
        {
            skillName = "八卦阵",
            mpCost = 30,
            baseDamage = 100,
            skillType = SkillType.Magic,
            description = "诸葛亮的绝技，八卦阵法攻击"
        };

        public static readonly SkillData BorrowingEastWind = new SkillData
        {
            skillName = "借东风",
            mpCost = 40,
            baseDamage = 150,
            skillType = SkillType.Magic,
            description = "传说技能，借东风之力攻击敌人"
        };

        // 治疗技能
        public static readonly SkillData MinorHeal = new SkillData
        {
            skillName = "小回复",
            mpCost = 5,
            baseDamage = 30,
            skillType = SkillType.Heal,
            description = "恢复少量HP"
        };

        public static readonly SkillData MediumHeal = new SkillData
        {
            skillName = "中回复",
            mpCost = 12,
            baseDamage = 60,
            skillType = SkillType.Heal,
            description = "恢复中等量HP"
        };

        public static readonly SkillData MajorHeal = new SkillData
        {
            skillName = "大回复",
            mpCost = 25,
            baseDamage = 100,
            skillType = SkillType.Heal,
            description = "恢复大量HP"
        };

        public static readonly SkillData Resurrection = new SkillData
        {
            skillName = "复活术",
            mpCost = 50,
            baseDamage = 50,
            skillType = SkillType.Heal,
            description = "复活倒下的同伴"
        };

        // 增益技能
        public static readonly SkillData AttackUp = new SkillData
        {
            skillName = "攻击提升",
            mpCost = 8,
            baseDamage = 0,
            skillType = SkillType.Buff,
            description = "提升我方攻击力"
        };

        public static readonly SkillData DefenseUp = new SkillData
        {
            skillName = "防御提升",
            mpCost = 8,
            baseDamage = 0,
            skillType = SkillType.Buff,
            description = "提升我方防御力"
        };

        public static readonly SkillData SpeedUp = new SkillData
        {
            skillName = "加速",
            mpCost = 10,
            baseDamage = 0,
            skillType = SkillType.Buff,
            description = "提升我方速度"
        };

        // 减益技能
        public static readonly SkillData AttackDown = new SkillData
        {
            skillName = "攻击削弱",
            mpCost = 6,
            baseDamage = 0,
            skillType = SkillType.Debuff,
            description = "降低敌方攻击力"
        };

        public static readonly SkillData DefenseDown = new SkillData
        {
            skillName = "防御削弱",
            mpCost = 6,
            baseDamage = 0,
            skillType = SkillType.Debuff,
            description = "降低敌方防御力"
        };

        public static readonly SkillData PoisonMist = new SkillData
        {
            skillName = "毒雾",
            mpCost = 12,
            baseDamage = 10,
            skillType = SkillType.Debuff,
            description = "释放毒雾，使敌人中毒"
        };

        /// <summary>
        /// 获取武将的默认技能列表
        /// </summary>
        public static SkillData[] GetDefaultSkillsForCharacter(string characterName)
        {
            switch (characterName)
            {
                case "刘备":
                    return new SkillData[] { StrongSlash, AttackUp, MediumHeal };

                case "关羽":
                    return new SkillData[] { StrongSlash, WhirlwindSlash, DragonSlash };

                case "张飞":
                    return new SkillData[] { StrongSlash, AttackUp, WhirlwindSlash };

                case "赵云":
                    return new SkillData[] { StrongSlash, WhirlwindSlash, SpeedUp };

                case "诸葛亮":
                    return new SkillData[] { FireBall, ThunderStrike, EightDiagramFormation, BorrowingEastWind, MajorHeal };

                case "黄忠":
                    return new SkillData[] { StrongSlash, WhirlwindSlash, AttackUp };

                case "马超":
                    return new SkillData[] { StrongSlash, WhirlwindSlash, SpeedUp };

                default:
                    return new SkillData[] { StrongSlash };
            }
        }
    }
}
