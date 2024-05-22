using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Game
{
    public class UI_MenuIngame : MonoBehaviour,IUiController
    {
        [SerializeField] private RectTransform _panel;
        [Header("Button")] 
        [SerializeField] private Button _btnNextLevel;
        [SerializeField] private Button _btnReLoad;
        [SerializeField] private Button _btnBackMenu;
        [SerializeField] private Button _btnResume;
        [Header("Info")]
        [SerializeField] private RectTransform _panelInfor;
        [SerializeField] private List<Image> _stars = new();

        private void Awake()
        {
            RegisterEvent();
        }


        private void RegisterEvent()
        {
            _btnBackMenu.onClick.AddListener(ActionClickBackMenu);
            _btnReLoad.onClick.AddListener(ActionClickReload);
            _btnNextLevel.onClick.AddListener(AcitonClickNextLevel);
            _btnResume.onClick.AddListener(ActionClickResume);
        }

        private void AcitonClickNextLevel()
        {
            SoundManager.Instance.PlayAudioSFX("ClickButton");
            GameManager.Instance.NextLevel();
            UI_Manager.Instance.OpenUIInGame();
        }

        private void ActionClickReload()
        {
            SoundManager.Instance.PlayAudioSFX("ClickButton");
            UI_Manager.Instance.OpenUIInGame();
            GameManager.Instance.Reload();        }

        private void ActionClickBackMenu()
        {
            SoundManager.Instance.PlayAudioSFX("ClickButton");
            UI_Manager.Instance.OpenUIMainMenu();
            GameManager.Instance.Clear();
        }

        private void ActionClickResume()
        {
            SoundManager.Instance.PlayAudioSFX("ClickButton");
            GameManager.Instance.ResumeGame();
        }

        private void SetUpBegin()
        {
            bool isWin = GameManager.Instance.IsWin;
            _panelInfor.gameObject.SetActive(isWin);
            _btnNextLevel.gameObject.SetActive(isWin);
            _btnResume.gameObject.SetActive(GameManager.Instance.IsPause);
        }

        public void OpenUi()
        {
            SetUpBegin();
            SetUpStar(GameManager.Instance.CaculatorStar());
            _panel.gameObject.SetActive(true);   
        }

        public void CloseUI()
        {
            _panel.gameObject.SetActive(false); 
        }

        public void SetUpStar(int Star)
        {
            var lengthStart = _stars.Count;
            for (int i = 0; i < lengthStart; i++)
            {
                if (i > Star-1)
                {
                    _stars[i].gameObject.SetActive(false);
                }
                    
            }
        }
    }
}


