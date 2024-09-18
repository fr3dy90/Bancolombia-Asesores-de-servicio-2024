
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
   
   public override void Init()
   {
      base.Init();
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
      ToolBox.SimpleFade(0, .5f, _baseView.GetCanvasGroup(), () =>
      {
         ToolBox.PlayAvatar(_avatarMarcela, MAT_ALPHA, 0f, 16f, MateoEntrance);
      });
   }

   private void MateoEntrance()
   {
      ToolBox.PlayAvatar(_avatarMateo, MAT_ALPHA,15f, 23, ()=> BaseSceneController.Instance.ChangeState(UIState.Cinematic));
   }
   
   
}

[Serializable]
public struct Avatar
{
   public Material _matAvatar;
   public VideoPlayer _videoAvatar;
}


