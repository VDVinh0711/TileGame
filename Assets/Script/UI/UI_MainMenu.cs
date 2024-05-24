
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
        { SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
           GameManager.Instance.PlayGame();
        }

        private void ActionChoseLevel()
        {
            SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
            UI_Manager.Instance.OpenUiChoseLevel();
        }

        private void ActionClickSetting()
        {
            SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
            UI_Manager.Instance.OpenUiSetting();
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
