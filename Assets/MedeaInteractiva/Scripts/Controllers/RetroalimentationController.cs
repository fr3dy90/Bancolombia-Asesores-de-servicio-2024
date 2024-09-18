using UnityEngine;

public class RetroalimentationController : BaseController
{
    [SerializeField] private RetroalimentationView _view;
    [Header("Clasifica")] 
    [SerializeField] private ModalRetroalimentation[] _modalClasifica;

    public static int SelectedRetro = 0;
    
    public override void Init()
    {
        base.Init();
        _view = GetComponentInChildren<RetroalimentationView>();
        
        _modalClasifica[0].modalContent[0].onAction = () => BaseSceneController.Instance.ChangeState(UIState.Clasifica);
        _modalClasifica[1].modalContent[1].onAction = () =>
        {
            BaseSceneController.Instance._currentMenuState = MainMenu.Conecta;
            BaseSceneController.Instance.ChangeState(UIState.Menu);
        };
        _modalClasifica[2].modalContent[1].onAction = () =>
        {
            BaseSceneController.Instance._currentMenuState = MainMenu.Conecta;
            BaseSceneController.Instance.ChangeState(UIState.Menu);
        };
    }

    public override void OnStart()
    {
        base.OnStart();
        _view.SetView(_modalClasifica[SelectedRetro]);
    }
}