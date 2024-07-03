using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WelcomeController : BaseController
{
   protected override void OnStart()
   {
      base.OnStart();
      Launch();
   }

   private async void Launch()
   {
      await ToolBox.SimpleTransition(BsseSceneController.Instance.GetCanvasGroup(), 0, _baseView.GetCanvasGroup(), 0, .5f, 1f, null);
      await UniTask.WaitForSeconds(3);
      await BsseSceneController.Instance.ChangeState(UIState.Menu);
   }
}
