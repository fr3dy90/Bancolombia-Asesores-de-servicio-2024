using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseView
{
    [SerializeField] private GameObject[] _buttons;
    
    public void OnSetMenuState(MainMenu menuState)
    {
       _buttons[(int)menuState].SetActive(true);
       InitializeButtons();
    }

    public void InitializeButtons()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            var i1 = i;
            _buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
            _buttons[i].GetComponent<Button>().onClick.AddListener(
               () =>
               {
                   BsseSceneController.Instance._currentMenuState = (MainMenu)i1;
                   BsseSceneController.Instance.ChangeState(UIState.ModalIntro);
               }
           );
        }
    }
}