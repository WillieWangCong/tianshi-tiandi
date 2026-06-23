using UnityEngine;

namespace TianshiTiandi.Character
{
    /// <summary>
    /// 物品数据基类
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "TianshiTiandi/Item Data")]
    public class ItemData : ScriptableObject
    {
        [Header("基础信息")]
        [SerializeField] private int itemId;
        [SerializeField] private string itemName;
        [SerializeField] private ItemType itemType;
        [TextArea(2, 4)]
        [SerializeField] private string description;
        [SerializeField] private int price;
        [SerializeField] private bool isConsumable = true;

        public int ItemId => itemId;
        public string ItemName => itemName;
        public ItemType ItemType => itemType;
        public string Description => description;
        public int Price => price;
        public bool IsConsumable => isConsumable;

        /// <summary>
        /// 使用物品
        /// </summary>
        public virtual void Use(CharacterData target)
        {
            Debug.Log($"使用了 {itemName}");
        }
    }

    /// <summary>
    /// 装备数据类
    /// </summary>
    [CreateAssetMenu(fileName = "NewEquipment", menuName = "TianshiTiandi/Equipment Data")]
    public class EquipmentData : ItemData
    {
        [Header("装备属性")]
        [SerializeField] private EquipmentSlot equipmentSlot;
        [SerializeField] private int attackBonus;
        [SerializeField] private int defenseBonus;
        [SerializeField] private int speedBonus;
        [SerializeField] private int intelligenceBonus;
        [SerializeField] private int maxHpBonus;
        [SerializeField] private int maxMpBonus;

        public EquipmentSlot EquipmentSlot => equipmentSlot;
        public int AttackBonus => attackBonus;
        public int DefenseBonus => defenseBonus;
        public int SpeedBonus => speedBonus;
        public int IntelligenceBonus => intelligenceBonus;
        public int MaxHpBonus => maxHpBonus;
        public int MaxMpBonus => maxMpBonus;
    }

    /// <summary>
    /// 消耗品类（药品等）
    /// </summary>
    [CreateAssetMenu(fileName = "NewConsumable", menuName = "TianshiTiandi/Consumable Data")]
    public class ConsumableData : ItemData
    {
        [Header("消耗品效果")]
        [SerializeField] private int hpRestore;
        [SerializeField] private int mpRestore;
        [SerializeField] private bool revive;
        [SerializeField] private StatusEffect statusEffect;

        public int HpRestore => hpRestore;
        public int MpRestore => mpRestore;
        public bool Revive => revive;

        public override void Use(CharacterData target)
        {
            base.Use(target);

            if (hpRestore > 0)
            {
                target.Heal(hpRestore);
                Debug.Log($"{target.CharacterName} 恢复了 {hpRestore} 点HP");
            }

            if (mpRestore > 0)
            {
                target.RestoreMp(mpRestore);
                Debug.Log($"{target.CharacterName} 恢复了 {mpRestore} 点MP");
            }

            if (revive && !target.IsAlive())
            {
                target.Heal(target.MaxHp / 4);
                Debug.Log($"{target.CharacterName} 复活了！");
            }

            // TODO: 实现状态效果
        }
    }

    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Consumable, // 消耗品
        Equipment,  // 装备
        Key,        // 关键道具
        Material    // 材料
    }

    /// <summary>
    /// 装备槽位
    /// </summary>
    public enum EquipmentSlot
    {
        Weapon,     // 武器
        Armor,      // 防具
        Accessory   // 饰品
    }

    /// <summary>
    /// 状态效果
    /// </summary>
    public enum StatusEffect
    {
        None,       // 无
        Poison,     // 中毒
        Paralyze,   // 麻痹
        Confuse,    // 混乱
        Sleep       // 睡眠
    }
}
