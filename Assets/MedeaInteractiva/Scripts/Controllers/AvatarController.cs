using System;
using UnityEngine;
using UnityEngine.Video;

public class AvatarController : BaseController
{
   [SerializeField] private AvatarView _avatarView;
   [SerializeField] private Avatar _avatarMateo;
   [SerializeField] private Avatar _avatarMarcela;
   
   private const string MAT_ALPHA = "_GlobalAlpha";
   private const float ZERO = 0;

   public static AvatarMoment CurrentMoment;
   
   public override void Init()
   {
      base.Init();
      _avatarMateo._videoAvatar.url = Application.streamingAssetsPath + "/" +"bc2_Mateo.mp4";
      _avatarMarcela._videoAvatar.url = Application.streamingAssetsPath + "/" +"bc1_Marcela.mp4";
      //_avatarMateo._videoAvatar.url = "https://drive.google.com/file/d/1M7uiOsyO_Si7vLIxb840sfDs15CAaJZD/view?usp=drive_link";
      //_avatarMarcela._videoAvatar.url = "https://drive.google.com/file/d/1Dz0G2Mgp1Zy2KC0-WfQQzXYU8oxf-wSz/view?usp=drive_link";
      _avatarView = GetComponentInChildren<AvatarView>();
      _avatarMateo._matAvatar.SetFloat(MAT_ALPHA, ZERO);
      _avatarMarcela._matAvatar.SetFloat(MAT_ALPHA, ZERO);
      _avatarMateo._videoAvatar.playOnAwake = false;
      _avatarMarcela._videoAvatar.playOnAwake = false;
      _avatarMateo._videoAvatar.Pause();
      _avatarMarcela._videoAvatar.Pause();
   }

   public override void OnStart()
   {
      base.OnStart();
      switch (CurrentMoment)
      {
         case AvatarMoment.Intro:
            
            AvatarIntro();
            break;
         case AvatarMoment.Retate:
            AvatarRetate();
            break;
         case AvatarMoment.Exit:
            AvatarExit();
            break;
      }
   }

  

   private void AvatarRetate()
   {
      ToolBox.SimpleFade(0, .5f, _baseView.GetCanvasGroup(), () =>
      {
         ToolBox.PlayAvatar(_avatarMarcela,  MAT_ALPHA, 40f, 59f, _avatarMarcela._matAvatar, () => BaseSceneController.Instance.ChangeState(UIState.ModalIntro));
      });
   }

   private void AvatarIntro()
   {
      ToolBox.SimpleFade(0, .5f, _baseView.GetCanvasGroup(), () =>
      {
         ToolBox.PlayAvatar(_avatarMarcela,  MAT_ALPHA, 0f, 16f, _avatarMarcela._matAvatar, MateoEntrance);
      });
   }
   
   private void AvatarExit()
   {
      ToolBox.SimpleFade(0, .5f, _baseView.GetCanvasGroup(), () =>
      {
         ToolBox.PlayAvatar(_avatarMateo,  MAT_ALPHA, 23f, 37f, _avatarMateo._matAvatar,() =>
         {
            ToolBox.SimpleFade(1, .5f, _baseView.GetCanvasGroup(),
               () =>
               {
                  CinematicController.IsExit = true;
                  BaseSceneController.Instance.ChangeState(UIState.Cinematic);
               });
         });
      });
   }

   private void MateoEntrance()
   {
      ToolBox.PlayAvatar(_avatarMateo, MAT_ALPHA, 15f, 23, _avatarMateo._matAvatar, ()=> BaseSceneController.Instance.ChangeState(UIState.Cinematic));
   }
   
   
}

[Serializable]
public struct Avatar
{
   public Material _matAvatar;
   public VideoPlayer _videoAvatar;
}


