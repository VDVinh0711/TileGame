
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace  UI_Game
{
    public class UI_ChoseLevel : MonoBehaviour
    {
        
        [SerializeField] private Transform _buttonPrefap;
        [SerializeField] private RectTransform _panel;
        [SerializeField] private List<UI_ButtonChoseLevel> _listUILevel = new();
    
        private void Start()
        {
            SetUpUiChoseLevel();
            
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
                    btnSpawn.SetParent(_panel);
                    btnUI = btnSpawn.GetComponent<UI_ButtonChoseLevel>();
                    _listUILevel.Add(btnUI);
                }
                btnUI.SetUpLevel(levelManager.Levels[i],i);
            }
        }


      
    }

}
