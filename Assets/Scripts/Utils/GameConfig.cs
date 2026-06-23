using UnityEngine;

namespace TianshiTiandi.Utils
{
    /// <summary>
    /// 游戏配置管理器
    /// 处理游戏设置、存档等
    /// </summary>
    public static class GameConfig
    {
        // 游戏版本
        public const string GAME_VERSION = "0.1.0";
        public const string GAME_NAME = "吞食天地";

        // 存档键名
        private const string SAVE_KEY = "SaveData";
        private const string SETTINGS_KEY = "GameSettings";

        // 音量设置
        private const string MASTER_VOLUME_KEY = "MasterVolume";
        private const string BGM_VOLUME_KEY = "BGMVolume";
        private const string SFX_VOLUME_KEY = "SFXVolume";

        // 画质设置
        private const string QUALITY_KEY = "QualityLevel";
        private const string FULLSCREEN_KEY = "Fullscreen";

        /// <summary>
        /// 保存游戏设置
        /// </summary>
        public static void SaveSettings(float masterVolume, float bgmVolume, float sfxVolume,
                                       int qualityLevel, bool fullscreen)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, masterVolume);
            PlayerPrefs.SetFloat(BGM_VOLUME_KEY, bgmVolume);
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, sfxVolume);
            PlayerPrefs.SetInt(QUALITY_KEY, qualityLevel);
            PlayerPrefs.SetInt(FULLSCREEN_KEY, fullscreen ? 1 : 0);

            PlayerPrefs.Save();
            Debug.Log("游戏设置已保存");
        }

        /// <summary>
        /// 加载游戏设置
        /// </summary>
        public static (float master, float bgm, float sfx, int quality, bool fullscreen) LoadSettings()
        {
            float master = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1f);
            float bgm = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 0.8f);
            float sfx = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f);
            int quality = PlayerPrefs.GetInt(QUALITY_KEY, QualitySettings.GetQualityLevel());
            bool fullscreen = PlayerPrefs.GetInt(FULLSCREEN_KEY, Screen.fullScreen ? 1 : 0) == 1;

            return (master, bgm, sfx, quality, fullscreen);
        }

        /// <summary>
        /// 应用设置
        /// </summary>
        public static void ApplySettings(float masterVolume, int qualityLevel, bool fullscreen)
        {
            AudioListener.volume = masterVolume;
            QualitySettings.SetQualityLevel(qualityLevel, true);
            Screen.fullScreen = fullscreen;

            Debug.Log($"设置已应用 - 音量: {masterVolume}, 画质: {qualityLevel}, 全屏: {fullscreen}");
        }

        /// <summary>
        /// 保存游戏进度
        /// </summary>
        public static void SaveGame(string saveData)
        {
            PlayerPrefs.SetString(SAVE_KEY, saveData);
            PlayerPrefs.Save();
            Debug.Log("游戏进度已保存");
        }

        /// <summary>
        /// 加载游戏进度
        /// </summary>
        public static string LoadGame()
        {
            return PlayerPrefs.GetString(SAVE_KEY, "");
        }

        /// <summary>
        /// 检查是否有存档
        /// </summary>
        public static bool HasSaveData()
        {
            return PlayerPrefs.HasKey(SAVE_KEY);
        }

        /// <summary>
        /// 删除存档
        /// </summary>
        public static void DeleteSaveData()
        {
            PlayerPrefs.DeleteKey(SAVE_KEY);
            Debug.Log("存档已删除");
        }

        /// <summary>
        /// 删除所有设置
        /// </summary>
        public static void DeleteAllSettings()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("所有设置已清除");
        }
    }
}
