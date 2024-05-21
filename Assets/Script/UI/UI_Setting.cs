
using System;
using UnityEngine;
using UnityEngine.UI;


namespace UI_Game
{
    public class UI_Setting : MonoBehaviour,IUiController
    {
       
      
        [SerializeField] private RectTransform _panel;
        [SerializeField] private Button _btnBack;
        [Header("Sound BackGround")]
        [SerializeField] private Button _btnSoundBackGround;
        [SerializeField] private Image _onSoundBackGround;
        [SerializeField] private Image _offSoundBackGround;
        
        [Header("Sound SFX")]
        [SerializeField] private Button _btnSoundSFX;
        [SerializeField] private Image _onSoundSFX;
        [SerializeField] private Image _offSFX;

        private void Awake()
        {
            RegisterEvent();
        }

        private void Start()
        {
            _onSoundBackGround.enabled = true;
            _onSoundSFX.enabled = true;
            _offSFX.enabled = false;
            _offSoundBackGround.enabled = false;
        }

        private void RegisterEvent()
        {
            _btnSoundBackGround.onClick.AddListener(ActionSoundBackGroundClick);
            _btnSoundSFX.onClick.AddListener(ActionSoundSFXClick);
            _btnBack.onClick.AddListener(ActionBackClick);
        }
        private void ActionSoundBackGroundClick()
        {
            SoundManager.Instance.ToggleSoundBackGround();
            ToggelButtonSoundBackGround();

        }
        private void ActionSoundSFXClick()
        {
            SoundManager.Instance.ToggleSoundSFX();
            ToggleButtonSoundSFX();
        }
        
        private void ToggelButtonSoundBackGround()
        {
           
            var boolCheck = _onSoundBackGround.enabled;
            _offSoundBackGround.enabled = boolCheck;
            _onSoundBackGround.enabled = !boolCheck;
        }

        private void ToggleButtonSoundSFX()
        {
            var boolCheck = _onSoundSFX.enabled;
            _offSFX.enabled = boolCheck;
            _onSoundSFX.enabled = !boolCheck;
        }


        private void ActionBackClick()
        {
            UI_Manager.Instance.OpenUIMainMenu();
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

