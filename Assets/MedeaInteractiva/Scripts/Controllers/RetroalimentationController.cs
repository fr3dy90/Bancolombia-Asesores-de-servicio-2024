using UnityEngine;

public class RetroalimentationController : BaseController
{
    [SerializeField] private RetroalimentationView _view;
    [Header("Clasifica")] 
    [SerializeField] private ModalRetroalimentation[] _modalClasifica;

    [Header("Conecta")] 
    [SerializeField] private ModalRetroalimentation[] _modalConecta;

    [Header("Retate")]
    [SerializeField] private ModalRetroalimentation[] _modalRetate;
    
    public static int SelectedRetro = 0;
    public static MainMenu ActualUIState;

    public bool isTest;
    public int indexTest;
    public MainMenu uiStateTest;

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

        _modalConecta[0].modalContent[0].onAction = () => BaseSceneController.Instance.ChangeState(UIState.Conecta);
        _modalConecta[1].modalContent[0].onAction = () =>
        {
            BaseSceneController.Instance._currentMenuState = MainMenu.Preparate;
            BaseSceneController.Instance.ChangeState(UIState.Menu);
        };

        _modalRetate[0].modalContent[0].onAction = () => BaseSceneController.Instance.ChangeState(UIState.Retate);
        _modalRetate[1].modalContent[0].onAction = () =>
        {
            AvatarController.CurrentMoment = AvatarMoment.Exit;
            BaseSceneController.Instance.ChangeState(UIState.Avatar);
            MainMenuView.Completed = true;
        };
    }

    public override void OnStart()
    {
        base.OnStart();

        if (isTest)
        {
            SelectedRetro = indexTest;
            ActualUIState = uiStateTest;
        }
        
        switch (ActualUIState)
        {
            case MainMenu.Clasifica:
                _view.SetView(_modalClasifica[SelectedRetro]);
                break;
            case MainMenu.Conecta:
                _view.SetView(_modalConecta[SelectedRetro]);
                break;
            case MainMenu.Preparate:
                _view.SetView(_modalRetate[SelectedRetro]);
                break;
        }
    }
}