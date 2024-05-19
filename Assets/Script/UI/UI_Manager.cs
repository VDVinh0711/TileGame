
using UnityEngine;

namespace UI_Game
{
    public class UI_Manager : Singleton<UI_Manager>
    {
        [SerializeField] private RectTransform _uiMainMenu;
        [SerializeField] private RectTransform _uiChoseLevel;
        [SerializeField] private RectTransform _uiInGame;
        [SerializeField] private RectTransform _uiMenuInGame;
         private IUiController _currentUI;
        
        private void OpenUI(IUiController uiController)
        {
            if (_currentUI != null)
            {
                _currentUI.CloseUI();
                _currentUI = uiController;
                _currentUI.OpenUi();
                return;
            }

            _currentUI = uiController;
            _currentUI.OpenUi();
        }

        public void CloseUI()
        {
            _currentUI?.CloseUI();
        }
        
        public void OpenUiChoseLevel()
        {
          HelpOpenUI(_uiChoseLevel);
        }

        public void OpenUIMainMenu()
        {
            HelpOpenUI(_uiMainMenu);
        }

        public void OpenUiMenuInGame()
        {
            HelpOpenUI(_uiMenuInGame);
        }
        

        public void OpenUIInGame()
        {
            HelpOpenUI(_uiInGame);
        }
        


        private void HelpOpenUI(RectTransform rectTransform)
        {
            var uicontroller = rectTransform.GetComponent<IUiController>();
            if(uicontroller == null) return;
            OpenUI(uicontroller);
        }
        
        
        
        
        
        
    }

}
