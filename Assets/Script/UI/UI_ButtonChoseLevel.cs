

using System.Collections.Generic;
using TMPro;

using UnityEngine;

using UnityEngine.UI;


namespace  UI_Game
{
    public class UI_ButtonChoseLevel : MonoBehaviour
    {
        public int indexLevel;
        [SerializeField] private TextMeshProUGUI _nameLevel;
        [SerializeField] private Image _uiLockLevel;
        [Header("Star")]
        [SerializeField] private List<RectTransform> _stars = new();
        [SerializeField] private Button _button;


        private void Awake()
        {
            _button.onClick.AddListener(ActionButtonClick);
        }
        public void SetUpLevel(LevelConfig levelConfig, int indexlevel)
        {
           if(levelConfig == null) return;
           indexLevel = indexlevel;
           _uiLockLevel.enabled = levelConfig.IsLock;
           _nameLevel.SetText(indexlevel+"");
           SetUpStart(levelConfig.Star);
        }

        private void SetUpStart(int quantityStar)
        {
            for (int i = 0; i < _stars.Count; i++)
            {
                    _stars[i].gameObject.SetActive(i<quantityStar);
            }
        }


        private void ActionButtonClick()
        {
            LevelManager.Instance.CurrentLevel = indexLevel;
            GameManager.Instance.PlayGame();
        }


     
    }

}
