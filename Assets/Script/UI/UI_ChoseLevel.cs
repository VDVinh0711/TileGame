using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace  UI_Game
{
    public class UI_ChoseLevel : MonoBehaviour,IUiController
    {
        
        [SerializeField] private Transform _buttonPrefap;
        [SerializeField] private RectTransform _panel;
        [SerializeField] private List<UI_ButtonChoseLevel> _listUILevel = new();
        [SerializeField] private Button _btnBack;
        [SerializeField] private RectTransform _panelHolLevel;


        private void Awake()
        {
            _btnBack.onClick.AddListener(ActionBackClick);
        }

        public void SetUpUiChoseLevel()
        {
            var levelManager = LevelManager.Instance;
            for(int i=0; i < levelManager.Levels.Count;i++)
            {
                var btnUI = _listUILevel.FirstOrDefault(x => x.indexLevel == i);
                if (btnUI == null)
                {
                    var btnSpawn = Instantiate(_buttonPrefap);
                    btnSpawn.SetParent(_panelHolLevel);
                    btnUI = btnSpawn.GetComponent<UI_ButtonChoseLevel>();
                    _listUILevel.Add(btnUI);
                }
                btnUI.SetUpLevel(levelManager.Levels[i],i);
            }
        }



        private void ActionBackClick()
        {
            UI_Manager.Instance.OpenUIMainMenu();
        }
        

        public void OpenUi()
        {
            SetUpUiChoseLevel();
            _panel.gameObject.SetActive(true);
          
        }

        public void CloseUI()
        {
          _panel.gameObject.SetActive(false);
        }
    }

}
