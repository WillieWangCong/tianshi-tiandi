using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using TianshiTiandi.Core;

namespace TianshiTiandi.UI
{
    /// <summary>
    /// 主菜单控制器
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        [Header("UI 组件")]
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;

        [Header("面板")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsPanel;

        [Header("文本")]
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI versionText;

        private void Start()
        {
            SetupButtons();
            UpdateUI();
        }

        /// <summary>
        /// 设置按钮事件
        /// </summary>
        private void SetupButtons()
        {
            if (newGameButton != null)
                newGameButton.onClick.AddListener(OnNewGameClicked);

            if (continueButton != null)
                continueButton.onClick.AddListener(OnContinueClicked);

            if (settingsButton != null)
                settingsButton.onClick.AddListener(OnSettingsClicked);

            if (quitButton != null)
                quitButton.onClick.AddListener(OnQuitClicked);
        }

        /// <summary>
        /// 更新 UI 显示
        /// </summary>
        private void UpdateUI()
        {
            if (titleText != null)
                titleText.text = "吞食天地";

            if (versionText != null)
                versionText.text = "Version 0.1.0 - Unity 复刻版";

            // 检查是否有存档
            if (continueButton != null)
            {
                continueButton.interactable = HasSaveData();
            }
        }

        /// <summary>
        /// 新游戏按钮点击
        /// </summary>
        private void OnNewGameClicked()
        {
            Debug.Log("开始新游戏");
            // 加载游戏场景
            SceneManager.LoadScene("GameScene");
        }

        /// <summary>
        /// 继续游戏按钮点击
        /// </summary>
        private void OnContinueClicked()
        {
            Debug.Log("继续游戏");
            LoadSaveData();
        }

        /// <summary>
        /// 设置按钮点击
        /// </summary>
        private void OnSettingsClicked()
        {
            Debug.Log("打开设置");
            if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
            if (settingsPanel != null) settingsPanel.SetActive(true);
        }

        /// <summary>
        /// 退出游戏按钮点击
        /// </summary>
        private void OnQuitClicked()
        {
            Debug.Log("退出游戏");
            GameManager.Instance.QuitGame();
        }

        /// <summary>
        /// 检查是否有存档
        /// </summary>
        private bool HasSaveData()
        {
            // TODO: 实现存档检查
            return PlayerPrefs.HasKey("SaveData");
        }

        /// <summary>
        /// 加载存档
        /// </summary>
        private void LoadSaveData()
        {
            // TODO: 实现存档加载
            string saveData = PlayerPrefs.GetString("SaveData", "");
            Debug.Log($"加载存档: {saveData}");
            SceneManager.LoadScene("GameScene");
        }

        /// <summary>
        /// 返回主菜单
        /// </summary>
        public void BackToMainMenu()
        {
            if (settingsPanel != null) settingsPanel.SetActive(false);
            if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        }
    }
}
