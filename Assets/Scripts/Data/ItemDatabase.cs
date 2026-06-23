using UnityEngine;
using System.Collections.Generic;
using TianshiTiandi.Character;

namespace TianshiTiandi.Data
{
    /// <summary>
    /// 物品数据库 - 存储游戏中所有物品
    /// </summary>
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "TianshiTiandi/Item Database")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private List<ConsumableData> consumables = new List<ConsumableData>();
        [SerializeField] private List<EquipmentData> weapons = new List<EquipmentData>();
        [SerializeField] private List<EquipmentData> armors = new List<EquipmentData>();
        [SerializeField] private List<EquipmentData> accessories = new List<EquipmentData>();

        public List<ConsumableData> Consumables => consumables;
        public List<EquipmentData> Weapons => weapons;
        public List<EquipmentData> Armors => armors;
        public List<EquipmentData> Accessories => accessories;
    }

    /// <summary>
    /// 预定义物品数据
    /// </summary>
    public static class ItemDefinitions
    {
        // 消耗品
        public static readonly ConsumableData Herb = new ConsumableData
        {
            ItemName = "草药",
            ItemType = ItemType.Consumable,
            Description = "普通的草药，恢复少量HP",
            Price = 10,
            hpRestore = 30,
            mpRestore = 0
        };

        public static readonly ConsumableData Potion = new ConsumableData
        {
            ItemName = "回复药",
            ItemType = ItemType.Consumable,
            Description = "回复药，恢复中等量HP",
            Price = 50,
            hpRestore = 100,
            mpRestore = 0
        };

        public static readonly ConsumableData HiPotion = new ConsumableData
        {
            ItemName = "高级回复药",
            ItemType = ItemType.Consumable,
            Description = "高级回复药，恢复大量HP",
            Price = 200,
            hpRestore = 300,
            mpRestore = 0
        };

        public static readonly ConsumableData MagicWater = new ConsumableData
        {
            ItemName = "魔法水",
            ItemType = ItemType.Consumable,
            Description = "魔法水，恢复中等量MP",
            Price = 80,
            hpRestore = 0,
            mpRestore = 50
        };

        public static readonly ConsumableData Elixir = new ConsumableData
        {
            ItemName = "万能药",
            ItemType = ItemType.Consumable,
            Description = "万能药，同时恢复HP和MP",
            Price = 500,
            hpRestore = 200,
            mpRestore = 100
        };

        public static readonly ConsumableData PhoenixDown = new ConsumableData
        {
            ItemName = "复活草",
            ItemType = ItemType.Consumable,
            Description = "复活倒下的同伴",
            Price = 1000,
            revive = true,
            hpRestore = 25
        };

        // 武器
        public static readonly EquipmentData WoodenSword = new EquipmentData
        {
            ItemName = "木剑",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Weapon,
            Description = "普通的木剑",
            Price = 50,
            AttackBonus = 5
        };

        public static readonly EquipmentData IronSword = new EquipmentData
        {
            ItemName = "铁剑",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Weapon,
            Description = "铁制长剑",
            Price = 200,
            AttackBonus = 12
        };

        public static readonly EquipmentData SteelSword = new EquipmentData
        {
            ItemName = "钢剑",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Weapon,
            Description = "精钢打造的长剑",
            Price = 500,
            AttackBonus = 25
        };

        public static readonly EquipmentData DragonSword = new EquipmentData
        {
            ItemName = "龙牙剑",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Weapon,
            Description = "传说中龙的牙齿打造的剑",
            Price = 5000,
            AttackBonus = 50,
            SpeedBonus = 5
        };

        public static readonly EquipmentData QinglongYanyueDao = new EquipmentData
        {
            ItemName = "青龙偃月刀",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Weapon,
            Description = "关羽的专属武器，青龙偃月刀",
            Price = 10000,
            AttackBonus = 80,
            DefenseBonus = 10,
            SpeedBonus = 5
        };

        public static readonly EquipmentData ZhangbaShemao = new EquipmentData
        {
            ItemName = "丈八蛇矛",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Weapon,
            Description = "张飞的专属武器，丈八蛇矛",
            Price = 10000,
            AttackBonus = 85,
            SpeedBonus = 10
        };

        // 防具
        public static readonly EquipmentData ClothArmor = new EquipmentData
        {
            ItemName = "布衣",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Armor,
            Description = "普通的布衣",
            Price = 30,
            DefenseBonus = 3
        };

        public static readonly EquipmentData LeatherArmor = new EquipmentData
        {
            ItemName = "皮甲",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Armor,
            Description = "皮革制成的护甲",
            Price = 150,
            DefenseBonus = 8,
            SpeedBonus = -1
        };

        public static readonly EquipmentData IronArmor = new EquipmentData
        {
            ItemName = "铁甲",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Armor,
            Description = "铁制护甲",
            Price = 400,
            DefenseBonus = 15,
            SpeedBonus = -2
        };

        public static readonly EquipmentData SteelArmor = new EquipmentData
        {
            ItemName = "钢甲",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Armor,
            Description = "精钢护甲",
            Price = 1000,
            DefenseBonus = 25,
            MaxHpBonus = 20,
            SpeedBonus = -3
        };

        // 饰品
        public static readonly EquipmentData PowerRing = new EquipmentData
        {
            ItemName = "力量戒指",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Accessory,
            Description = "提升攻击力的戒指",
            Price = 300,
            AttackBonus = 8
        };

        public static readonly EquipmentData WisdomRing = new EquipmentData
        {
            ItemName = "智慧戒指",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Accessory,
            Description = "提升智力的戒指",
            Price = 300,
            IntelligenceBonus = 8
        };

        public static readonly EquipmentData SpeedRing = new EquipmentData
        {
            ItemName = "疾风戒指",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Accessory,
            Description = "提升速度的戒指",
            Price = 400,
            SpeedBonus = 10
        };

        public static readonly EquipmentData LifeRing = new EquipmentData
        {
            ItemName = "生命戒指",
            ItemType = ItemType.Equipment,
            EquipmentSlot = EquipmentSlot.Accessory,
            Description = "提升最大HP的戒指",
            Price = 500,
            MaxHpBonus = 50
        };

        /// <summary>
        /// 获取所有消耗品
        /// </summary>
        public static List<ConsumableData> GetAllConsumables()
        {
            return new List<ConsumableData>
            {
                Herb, Potion, HiPotion, MagicWater, Elixir, PhoenixDown
            };
        }

        /// <summary>
        /// 获取所有武器
        /// </summary>
        public static List<EquipmentData> GetAllWeapons()
        {
            return new List<EquipmentData>
            {
                WoodenSword, IronSword, SteelSword, DragonSword, QinglongYanyueDao, ZhangbaShemao
            };
        }

        /// <summary>
        /// 获取所有防具
        /// </summary>
        public static List<EquipmentData> GetAllArmors()
        {
            return new List<EquipmentData>
            {
                ClothArmor, LeatherArmor, IronArmor, SteelArmor
            };
        }

        /// <summary>
        /// 获取所有饰品
        /// </summary>
        public static List<EquipmentData> GetAllAccessories()
        {
            return new List<EquipmentData>
            {
                PowerRing, WisdomRing, SpeedRing, LifeRing
            };
        }
    }
}
