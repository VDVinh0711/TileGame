using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI _txtHeader;

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
            SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
            GameManager.Instance.NextLevel();
            UI_Manager.Instance.OpenUIInGame();
        }

        private void ActionClickReload()
        {
            SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
            UI_Manager.Instance.OpenUIInGame();
            GameManager.Instance.Reload();        }

        private void ActionClickBackMenu()
        {
            SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
            UI_Manager.Instance.OpenUIMainMenu();
            GameManager.Instance.Clear();
        }

        private void ActionClickResume()
        {
            SoundManager.Instance.PlayAudioSFX(Sound.clickbutton);
            GameManager.Instance.ResumeGame();
        }

        private void SetUpBegin()
        {
            bool isWin = GameManager.Instance.IsWin;
            bool isLose = GameManager.Instance.IsLose;
            _panelInfor.gameObject.SetActive(isWin || isLose);
            if (isWin)
            {
                SetUpUIWin();
            }
            else
            {
                SetUpUILose();
            }
            _btnNextLevel.gameObject.SetActive(isWin);
            _btnResume.gameObject.SetActive(GameManager.Instance.IsPause);
        }

        private void SetUpUIWin()
        {
            _txtHeader.SetText("Win");
            int star = GameManager.Instance.CaculatorStar();
            SetUpStar(star,true);
        }

        private void SetUpUILose()
        {
            _txtHeader.SetText("Lose");
            SetUpStar(0,false);
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

        private void SetUpStar(int Star, bool isShow)
        {
            var lengthStart = _stars.Count;
            for (int i = 0; i < lengthStart; i++)
            { 
                _stars[i].enabled = i <= (Star - 1) && isShow;
            }
        }
    }
}


