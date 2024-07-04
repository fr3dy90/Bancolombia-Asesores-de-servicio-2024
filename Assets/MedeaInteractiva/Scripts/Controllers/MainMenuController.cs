using UnityEngine;
using UnityEngine.Serialization;

public class MainMenuController : BaseController
{
   [SerializeField] private MainMenuView _view;

    public override void Init()
    {
        base.Init();
        _view = GetComponentInChildren<MainMenuView>();
    }
    public override void OnStart()
    {
        base.OnStart();
        _view.OnSetMenuState(BsseSceneController.Instance._currentMenuState);
    }  
}

