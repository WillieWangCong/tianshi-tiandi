using UnityEngine;
using UnityEngine.SceneManagement;

namespace TianshiTiandi.Core
{
    /// <summary>
    /// 游戏管理器 - 单例模式
    /// 负责游戏的整体流程控制
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Game Settings")]
        [SerializeField] private float gameSpeed = 1f;
        [SerializeField] private bool isPaused = false;

        public float GameSpeed => gameSpeed;
        public bool IsPaused => isPaused;

        private void Awake()
        {
            // 单例模式
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

        private void Start()
        {
            Debug.Log("吞食天地 - Unity 复刻版启动！");
            Debug.Log("GameManager initialized.");
        }

        /// <summary>
        /// 暂停游戏
        /// </summary>
        public void PauseGame()
        {
            isPaused = true;
            Time.timeScale = 0f;
            Debug.Log("Game Paused");
        }

        /// <summary>
        /// 继续游戏
        /// </summary>
        public void ResumeGame()
        {
            isPaused = false;
            Time.timeScale = gameSpeed;
            Debug.Log("Game Resumed");
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// 退出游戏
        /// </summary>
        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
