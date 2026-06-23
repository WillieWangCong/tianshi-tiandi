using UnityEngine;
using System.Collections.Generic;

namespace TianshiTiandi.Character
{
    /// <summary>
    /// 队伍管理器 - 管理玩家队伍
    /// </summary>
    public class PartyManager : MonoBehaviour
    {
        public static PartyManager Instance { get; private set; }

        [Header("队伍设置")]
        [SerializeField] private int maxPartySize = 5;

        [Header("当前队伍")]
        [SerializeField] private List<CharacterData> party = new List<CharacterData>();

        [Header("物资")]
        [SerializeField] private int gold = 0;
        [SerializeField] private Dictionary<int, int> inventory = new Dictionary<int, int>();

        public List<CharacterData> Party => party;
        public int Gold => gold;
        public int MaxPartySize => maxPartySize;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 添加角色到队伍
        /// </summary>
        public bool AddCharacter(CharacterData character)
        {
            if (party.Count >= maxPartySize)
            {
                Debug.Log("队伍已满，无法添加新角色！");
                return false;
            }

            if (party.Contains(character))
            {
                Debug.Log($"{character.CharacterName} 已经在队伍中！");
                return false;
            }

            party.Add(character);
            Debug.Log($"{character.CharacterName} 加入了队伍！");
            return true;
        }

        /// <summary>
        /// 从队伍移除角色
        /// </summary>
        public bool RemoveCharacter(CharacterData character)
        {
            if (party.Remove(character))
            {
                Debug.Log($"{character.CharacterName} 离开了队伍。");
                return true;
            }

            Debug.Log($"{character.CharacterName} 不在队伍中！");
            return false;
        }

        /// <summary>
        /// 获取存活的队员数量
        /// </summary>
        public int GetAliveCount()
        {
            int count = 0;
            foreach (var character in party)
            {
                if (character.IsAlive()) count++;
            }
            return count;
        }

        /// <summary>
        /// 检查队伍是否全军覆没
        /// </summary>
        public bool IsPartyWiped()
        {
            return GetAliveCount() == 0;
        }

        /// <summary>
        /// 恢复全体队员HP/MP
        /// </summary>
        public void RecoverAll()
        {
            foreach (var character in party)
            {
                character.Heal(character.MaxHp);
                character.RestoreMp(character.MaxMp);
            }
            Debug.Log("队伍已完全恢复！");
        }

        /// <summary>
        /// 增加金钱
        /// </summary>
        public void AddGold(int amount)
        {
            gold += amount;
            Debug.Log($"获得金币 {amount}，当前金币：{gold}");
        }

        /// <summary>
        /// 消耗金钱
        /// </summary>
        public bool SpendGold(int amount)
        {
            if (gold >= amount)
            {
                gold -= amount;
                Debug.Log($"消耗金币 {amount}，剩余金币：{gold}");
                return true;
            }

            Debug.Log("金币不足！");
            return false;
        }

        /// <summary>
        /// 添加物品到背包
        /// </summary>
        public void AddItem(int itemId, int count = 1)
        {
            if (inventory.ContainsKey(itemId))
            {
                inventory[itemId] += count;
            }
            else
            {
                inventory[itemId] = count;
            }

            Debug.Log($"获得物品 ID:{itemId} x{count}");
        }

        /// <summary>
        /// 使用物品
        /// </summary>
        public bool UseItem(int itemId, CharacterData target)
        {
            if (!inventory.ContainsKey(itemId) || inventory[itemId] <= 0)
            {
                Debug.Log("没有该物品！");
                return false;
            }

            // TODO: 从资源加载物品数据
            // ItemData item = Resources.Load<ItemData>($"Items/{itemId}");
            // if (item != null)
            // {
            //     item.Use(target);
            //     inventory[itemId]--;
            //     if (inventory[itemId] <= 0) inventory.Remove(itemId);
            //     return true;
            // }

            Debug.Log("物品不存在！");
            return false;
        }

        /// <summary>
        /// 获取物品数量
        /// </summary>
        public int GetItemCount(int itemId)
        {
            return inventory.ContainsKey(itemId) ? inventory[itemId] : 0;
        }

        /// <summary>
        /// 获取队伍序列化数据（用于存档）
        /// </summary>
        public string GetSaveData()
        {
            // TODO: 实现存档序列化
            return JsonUtility.ToJson(this);
        }

        /// <summary>
        /// 从存档数据恢复队伍
        /// </summary>
        public void LoadSaveData(string saveData)
        {
            // TODO: 实现存档反序列化
            JsonUtility.FromJsonOverwrite(saveData, this);
        }
    }
}
