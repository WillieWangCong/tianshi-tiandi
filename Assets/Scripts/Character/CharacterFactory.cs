using UnityEngine;

namespace TianshiTiandi.Character
{
    /// <summary>
    /// 武将工厂类 - 创建预定义的武将数据
    /// </summary>
    public static class CharacterFactory
    {
        /// <summary>
        /// 创建刘备（蜀汉昭烈帝）
        /// </summary>
        public static CharacterData CreateLiuBei()
        {
            CharacterData liubei = ScriptableObject.CreateInstance<CharacterData>();
            
            // 使用反射设置私有字段（在实际Unity项目中，这些应该通过Inspector设置）
            SetPrivateField(liubei, "characterName", "刘备");
            SetPrivateField(liubei, "characterId", 1);
            SetPrivateField(liubei, "characterType", CharacterType.Warrior);
            SetPrivateField(liubei, "description", "蜀汉昭烈帝，仁德之主，桃园结义大哥。");
            
            SetPrivateField(liubei, "level", 1);
            SetPrivateField(liubei, "maxHp", 120);
            SetPrivateField(liubei, "currentHp", 120);
            SetPrivateField(liubei, "maxMp", 60);
            SetPrivateField(liubei, "currentMp", 60);
            SetPrivateField(liubei, "attack", 15);
            SetPrivateField(liubei, "defense", 8);
            SetPrivateField(liubei, "speed", 12);
            SetPrivateField(liubei, "intelligence", 15);
            
            return liubei;
        }

        /// <summary>
        /// 创建关羽（武圣）
        /// </summary>
        public static CharacterData CreateGuanYu()
        {
            CharacterData guanyu = ScriptableObject.CreateInstance<CharacterData>();
            
            SetPrivateField(guanyu, "characterName", "关羽");
            SetPrivateField(guanyu, "characterId", 2);
            SetPrivateField(guanyu, "characterType", CharacterType.Warrior);
            SetPrivateField(guanyu, "description", "武圣，忠义无双，桃园结义二哥。");
            
            SetPrivateField(guanyu, "level", 1);
            SetPrivateField(guanyu, "maxHp", 140);
            SetPrivateField(guanyu, "currentHp", 140);
            SetPrivateField(guanyu, "maxMp", 40);
            SetPrivateField(guanyu, "currentMp", 40);
            SetPrivateField(guanyu, "attack", 20);
            SetPrivateField(guanyu, "defense", 10);
            SetPrivateField(guanyu, "speed", 10);
            SetPrivateField(guanyu, "intelligence", 12);
            
            return guanyu;
        }

        /// <summary>
        /// 创建张飞（猛将）
        /// </summary>
        public static CharacterData CreateZhangFei()
        {
            CharacterData zhangfei = ScriptableObject.CreateInstance<CharacterData>();
            
            SetPrivateField(zhangfei, "characterName", "张飞");
            SetPrivateField(zhangfei, "characterId", 3);
            SetPrivateField(zhangfei, "characterType", CharacterType.Warrior);
            SetPrivateField(zhangfei, "description", "猛将，勇猛无敌，桃园结义三弟。");
            
            SetPrivateField(zhangfei, "level", 1);
            SetPrivateField(zhangfei, "maxHp", 150);
            SetPrivateField(zhangfei, "currentHp", 150);
            SetPrivateField(zhangfei, "maxMp", 30);
            SetPrivateField(zhangfei, "currentMp", 30);
            SetPrivateField(zhangfei, "attack", 22);
            SetPrivateField(zhangfei, "defense", 7);
            SetPrivateField(zhangfei, "speed", 8);
            SetPrivateField(zhangfei, "intelligence", 8);
            
            return zhangfei;
        }

        /// <summary>
        /// 创建诸葛亮（卧龙先生）
        /// </summary>
        public static CharacterData CreateZhugeLiang()
        {
            CharacterData zhugeliang = ScriptableObject.CreateInstance<CharacterData>();
            
            SetPrivateField(zhugeliang, "characterName", "诸葛亮");
            SetPrivateField(zhugeliang, "characterId", 4);
            SetPrivateField(zhugeliang, "characterType", CharacterType.Strategist);
            SetPrivateField(zhugeliang, "description", "卧龙先生，蜀汉丞相，智谋无双。");
            
            SetPrivateField(zhugeliang, "level", 1);
            SetPrivateField(zhugeliang, "maxHp", 80);
            SetPrivateField(zhugeliang, "currentHp", 80);
            SetPrivateField(zhugeliang, "maxMp", 100);
            SetPrivateField(zhugeliang, "currentMp", 100);
            SetPrivateField(zhugeliang, "attack", 8);
            SetPrivateField(zhugeliang, "defense", 5);
            SetPrivateField(zhugeliang, "speed", 15);
            SetPrivateField(zhugeliang, "intelligence", 25);
            
            return zhugeliang;
        }

        /// <summary>
        /// 创建赵云（常胜将军）
        /// </summary>
        public static CharacterData CreateZhaoYun()
        {
            CharacterData zhaoyun = ScriptableObject.CreateInstance<CharacterData>();
            
            SetPrivateField(zhaoyun, "characterName", "赵云");
            SetPrivateField(zhaoyun, "characterId", 5);
            SetPrivateField(zhaoyun, "characterType", CharacterType.Warrior);
            SetPrivateField(zhaoyun, "description", "常胜将军，浑身是胆，七进七出救阿斗。");
            
            SetPrivateField(zhaoyun, "level", 1);
            SetPrivateField(zhaoyun, "maxHp", 130);
            SetPrivateField(zhaoyun, "currentHp", 130);
            SetPrivateField(zhaoyun, "maxMp", 50);
            SetPrivateField(zhaoyun, "currentMp", 50);
            SetPrivateField(zhaoyun, "attack", 18);
            SetPrivateField(zhaoyun, "defense", 9);
            SetPrivateField(zhaoyun, "speed", 18);
            SetPrivateField(zhaoyun, "intelligence", 14);
            
            return zhaoyun;
        }

        /// <summary>
        /// 创建黄忠（老将）
        /// </summary>
        public static CharacterData CreateHuangZhong()
        {
            CharacterData huangzhong = ScriptableObject.CreateInstance<CharacterData>();
            
            SetPrivateField(huangzhong, "characterName", "黄忠");
            SetPrivateField(huangzhong, "characterId", 6);
            SetPrivateField(huangzhong, "characterType", CharacterType.Warrior);
            SetPrivateField(huangzhong, "description", "老当益壮，百步穿杨，五虎上将之一。");
            
            SetPrivateField(huangzhong, "level", 1);
            SetPrivateField(huangzhong, "maxHp", 110);
            SetPrivateField(huangzhong, "currentHp", 110);
            SetPrivateField(huangzhong, "maxMp", 45);
            SetPrivateField(huangzhong, "currentMp", 45);
            SetPrivateField(huangzhong, "attack", 19);
            SetPrivateField(huangzhong, "defense", 6);
            SetPrivateField(huangzhong, "speed", 14);
            SetPrivateField(huangzhong, "intelligence", 11);
            
            return huangzhong;
        }

        /// <summary>
        /// 创建马超（锦马超）
        /// </summary>
        public static CharacterData CreateMaChao()
        {
            CharacterData machao = ScriptableObject.CreateInstance<CharacterData>();
            
            SetPrivateField(machao, "characterName", "马超");
            SetPrivateField(machao, "characterId", 7);
            SetPrivateField(machao, "characterType", CharacterType.Warrior);
            SetPrivateField(machao, "description", "锦马超，西凉猛将，五虎上将之一。");
            
            SetPrivateField(machao, "level", 1);
            SetPrivateField(machao, "maxHp", 135);
            SetPrivateField(machao, "currentHp", 135);
            SetPrivateField(machao, "maxMp", 35);
            SetPrivateField(machao, "currentMp", 35);
            SetPrivateField(machao, "attack", 21);
            SetPrivateField(machao, "defense", 8);
            SetPrivateField(machao, "speed", 16);
            SetPrivateField(machao, "intelligence", 10);
            
            return machao;
        }

        /// <summary>
        /// 辅助方法：通过反射设置私有字段
        /// </summary>
        private static void SetPrivateField(object obj, string fieldName, object value)
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
    }
}
