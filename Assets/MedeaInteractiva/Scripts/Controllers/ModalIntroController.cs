using UnityEngine;

public class ModalIntroController : BaseController
{
   public ModalIntroView _view;
   [SerializeField] private ModalWindowIntro[] _modalWindowIntros;
   [SerializeField] private ModalWindowIntro[] _ImageModalWindowIntros;
   public override void Init()
   {
      base.Init();
      _modalWindowIntros[0].modalContent[1].buttonAction = ()=>
      {
         BaseSceneController.Instance._currentMenuState = MainMenu.Clasifica;
         BaseSceneController.Instance.ChangeState(UIState.Conoce);
      };
      
      _modalWindowIntros[1].modalContent[4].buttonAction = ()=>
      {
         BaseSceneController.Instance.ChangeState(UIState.CountDown);
         CountDownController.onCompleteTimer = () => BaseSceneController.Instance.ChangeState(UIState.Clasifica);
      };
       
      _modalWindowIntros[2].modalContent[3].buttonAction = ()=>
      {
         BaseSceneController.Instance.ChangeState(UIState.Conecta);
      };

      _modalWindowIntros[3].modalContent[0].buttonAction = () =>
      {
         BaseSceneController.Instance.ChangeState(UIState.Retate);
      };
      
      _view = GetComponentInChildren<ModalIntroView>();
   }
   
   public override void OnStart()
   {
      base.OnStart();
      OnSetView(_modalWindowIntros[(int)BaseSceneController.Instance._currentMenuState]);
   }
   
   private void OnSetView(ModalWindowIntro modalWindowIntro)
   {
      _view.SetBasicIntro(modalWindowIntro);
   }
   
}
