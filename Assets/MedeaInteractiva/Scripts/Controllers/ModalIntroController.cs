using UnityEngine;
using UnityEngine.Serialization;

public class ModalIntroController : BaseController
{
   public ModalIntroView _view;
   [SerializeField] private ModalWindowIntro[] _modalWindowIntros;
   public override void Init()
   {
      base.Init();
      _modalWindowIntros[0].modalContent[0].buttonAction = ()=>
      {
         BsseSceneController.Instance._currentMenuState = MainMenu.Clasifica;
         BsseSceneController.Instance.ChangeState(UIState.Menu);
      };
      
      _modalWindowIntros[1].modalContent[3].buttonAction = ()=>
      {
         BsseSceneController.Instance._currentMenuState = MainMenu.Conecta;
         BsseSceneController.Instance.ChangeState(UIState.Menu);
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
