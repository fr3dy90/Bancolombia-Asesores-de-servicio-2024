using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WelcomeController : BaseController
{
   public override void OnStart()
   {
      base.OnStart();
      Launch();
   }

   private async void Launch()
   {
      await UniTask.WaitForSeconds(3);
      await BaseSceneController.Instance.ChangeState(UIState.Menu);
   }
}
