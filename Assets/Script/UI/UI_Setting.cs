
using UnityEngine;
using UnityEngine.UI;


namespace UI_Game
{
    public class UI_Setting : MonoBehaviour,IUiController
    {
        [SerializeField] private Button _btnSoundBackGround;
        [SerializeField] private Button _btnSoundSFX;
        [SerializeField] private RectTransform _panel;

        private void Awake()
        {
            RegisterEvent();
        }
        private void RegisterEvent()
        {
            _btnSoundBackGround.onClick.AddListener(ActionSoundBackGroundClick);
            _btnSoundSFX.onClick.AddListener(ActionSoundSFXClick);
        }
        private void ActionSoundBackGroundClick()
        {
            SoundManager.Instance.ToggleSoundBackGround();
            
        }
        private void ActionSoundSFXClick()
        {
            SoundManager.Instance.ToggleSoundSFX();    
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

