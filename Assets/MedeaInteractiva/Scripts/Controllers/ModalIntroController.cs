using UnityEngine;

public class ModalIntroController : BaseController
{
   public ModalIntroView _view;
   [SerializeField] private ModalWindowIntro[] _modalWindowIntros;
   [SerializeField] private ModalWindowIntro[] _ImageModalWindowIntros;
   public override void Init()
   {
      base.Init();
      _modalWindowIntros[0].modalContent[0].buttonAction = ()=>
      {
         BsseSceneController.Instance._currentMenuState = MainMenu.Clasifica;
         BsseSceneController.Instance.ChangeState(UIState.Menu);
      };
      
      _modalWindowIntros[1].modalContent[4].buttonAction = ()=>
      {
         OnSetView(_ImageModalWindowIntros[0]);
      };
      
      _ImageModalWindowIntros[0].modalContent[1].buttonAction = ()=>
      {
         BsseSceneController.Instance.ChangeState(UIState.CountDown);
      };
      
      _modalWindowIntros[2].modalContent[3].buttonAction = ()=>
      {
         BsseSceneController.Instance.ChangeState(UIState.Menu);
      };
      _view = GetComponentInChildren<ModalIntroView>();
   }
   
   public override void OnStart()
   {
      base.OnStart();
      OnSetView(_modalWindowIntros[(int)BsseSceneController.Instance._currentMenuState]);
   }
   
   private void OnSetView(ModalWindowIntro modalWindowIntro)
   {
      _view.SetBasicIntro(modalWindowIntro);
   }
}
