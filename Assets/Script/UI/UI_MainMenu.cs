
using System;
using UnityEngine;
using UnityEngine.UI;


namespace  UI_Game
{
    public class UI_MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _btnPlay;
        [SerializeField] private Button _btnChoseLevel;
        [SerializeField] private Button _btnSetting;
        
        private void Awake()
        {
            RegisterEvent();
        }


        private void RegisterEvent()
        {
            _btnPlay.onClick.AddListener(ActionClickPlay);
            _btnChoseLevel.onClick.AddListener(ActionChoseLevel);
            _btnSetting.onClick.AddListener(ActionClickSetting);
        }
        
        
        private void ActionClickPlay()
        {
            LevelManager.Instance.LoadCurrentlevel();
        }

        private void ActionChoseLevel()
        {
            //Turn of UI Menu , Open UI ChoseMap
        }

        private void ActionClickSetting()
        {
            //Turn of UI Menu , Open UI Setting
        }
        
    }

}
