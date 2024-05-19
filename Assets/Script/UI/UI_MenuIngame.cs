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
            UI_Manager.Instance.OpenUIInGame();
            GameManager.Instance.NextLevel();
        }

        private void ActionClickReload()
        {
            UI_Manager.Instance.OpenUIInGame();
            GameManager.Instance.Reload();        }

        private void ActionClickBackMenu()
        {
            UI_Manager.Instance.OpenUIMainMenu();
        }

        private void ActionClickResume()
        {
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
            _panel.gameObject.SetActive(true);   
        }

        public void CloseUI()
        {
            _panel.gameObject.SetActive(false); 
        }
    }
}


