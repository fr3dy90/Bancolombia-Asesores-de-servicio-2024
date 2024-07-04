using UnityEngine;

public class MainMenuController : BaseController
{
    [SerializeField] private MainMenuView _baseView;

    public override void Init()
    {
        base.Init();
        _baseView = GetComponentInChildren<MainMenuView>();
    }
    public override void OnStart()
    {
        base.OnStart();
        _baseView.OnSetMenuState(BsseSceneController.Instance._currentMenuState);
    }  
}

