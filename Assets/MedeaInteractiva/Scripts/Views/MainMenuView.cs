using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseView
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image _imgInicia;
    public static bool Completed = false ;
    
    public void OnSetMenuState(MainMenu menuState)
    {
        if (!Completed)
        {   
           _buttons[(int)menuState].GameObject().SetActive(true);
           _imgInicia.transform.parent = _buttons[(int)menuState].transform;
           _imgInicia.rectTransform.localPosition = new Vector2(0, _imgInicia.rectTransform.localPosition.y);
           
           for (int i = 0; i < _buttons.Length; i++)
           {
               _buttons[i].interactable = (int)menuState >= i;
           }
        }
       
        _imgInicia.gameObject.SetActive(!Completed);
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
                   BaseSceneController.Instance._currentMenuState = (MainMenu)i1;
                   BaseSceneController.Instance.ChangeState(UIState.ModalIntro);
               }
           );
        }
        
        _buttons[3].onClick.RemoveAllListeners();
        _buttons[3].onClick.AddListener(
            () =>
            {
                BaseSceneController.Instance._currentMenuState = MainMenu.Preparate;
                AvatarController.CurrentMoment = AvatarMoment.Retate;
                BaseSceneController.Instance.ChangeState(UIState.Avatar);
            }
        );
    }
}