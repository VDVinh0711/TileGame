
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Game
{
    public class UI_InGame : MonoBehaviour,IUiController
    {
        private const string beginTextLevel = "Level : ";
        [SerializeField] private RectTransform _panel;
        [SerializeField] private TextMeshProUGUI _textTime;
        [SerializeField] private TextMeshProUGUI _textLevel;
        [SerializeField] private Button _pauseGame;
        [Header("Star")]
        [SerializeField] private List<Image> _uiStars;


        private void Start()
        {
            RegisterEvent();
        }

        private void RegisterEvent()
        {
            GameManager.Instance.TimeManager.ActionChangeTime -= SetUpTextTime;
            GameManager.Instance.TimeManager.ActionChangeTime += SetUpTextTime;
            GameManager.Instance.TimeManager.ActionChangeTime -= ActionSetUpStarInTime;
            GameManager.Instance.TimeManager.ActionChangeTime += ActionSetUpStarInTime;
            _pauseGame.onClick.AddListener(ActionClickPause);
        }

        private void ActionClickPause()
        {
            GameManager.Instance.PauseGame();
        }
        public void SetUpTextTime(int time)
        {
            int minute = time / 60;
            int second = time - (minute * 60);
            _textTime.SetText(minute + " : " + second);
        }
        public void SetUpLevel(int level)
        {
            _textLevel.SetText(beginTextLevel+ level);
        }

        public void ActionSetUpStarInTime(int time)
        {
            var quantityStar = GameManager.Instance.CaculatorStar();
            SetUpStar(quantityStar);
        }
        public void SetUpStar(int star)
        {
            var lengthStart = _uiStars.Count;
            for (int i = 0; i < lengthStart; i++)
            {
                if (i > star-1)
                {
                    _uiStars[i].gameObject.SetActive(false);
                }
                    
            }
        }
        
        
        
        public void OpenUi()
        {
            SetUpLevel(LevelManager.Instance.CurrentLevel);
           _panel.gameObject.SetActive(true);
        }

        public void CloseUI()
        {
           _panel.gameObject.SetActive(false);
        }
    }

}
