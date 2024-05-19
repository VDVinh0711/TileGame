
using System;
using UnityEngine;
using UnityEngine.UI;


namespace  UI_Game
{
    public class UI_MainMenu : MonoBehaviour,IUiController
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnChoseLevel;
        [SerializeField] private Button _btnSetting;
        [SerializeField] private RectTransform _panel;
        private void Awake()
        {
            RegisterEvent();
        }

        private void Start()
        {
            UI_Manager.Instance.OpenUIMainMenu();
        }

        private void RegisterEvent()
        {
            _btnPlay.onClick.AddListener(ActionClickPlay);
            _btnChoseLevel.onClick.AddListener(ActionChoseLevel);
            _btnSetting.onClick.AddListener(ActionClickSetting);
        }
        
        
        private void ActionClickPlay()
        {
           GameManager.Instance.PlayGame();
        }

        private void ActionChoseLevel()
        {
            UI_Manager.Instance.OpenUiChoseLevel();
        }

        private void ActionClickSetting()
        {
            //Turn of UI Menu , Open UI Setting
        }

        public void OpenUi()
        {
            _panel.gameObject.SetActive(true);
        }

        public void CloseUI()
        {
          _panel.gameObject.SetActive(false);
        }
    }

}
