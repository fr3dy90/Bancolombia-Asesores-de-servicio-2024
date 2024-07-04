using UnityEngine;

public class MainMenuView : BaseView
{
    [SerializeField] private GameObject[] _buttons;
    
    public void OnSetMenuState(MainMenu menuState)
    {
        switch (menuState)
        {
            case MainMenu.Conoce:
                _buttons[0].SetActive(true);
                break;
            case MainMenu.Clasifica:
                _buttons[1].SetActive(true);
                break;
            case MainMenu.Conecta:
                _buttons[2].SetActive(true);
                break;
            
        }
    }
}