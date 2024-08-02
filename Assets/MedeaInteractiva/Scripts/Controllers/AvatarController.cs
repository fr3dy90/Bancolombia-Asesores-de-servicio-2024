
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
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
   }

   public override void OnStart()
   {
      base.OnStart();
      ToolBox.SimpleFade(_baseView.GetCanvasGroup(), 0, .5f, () =>
      {
         ToolBox.PlayAvatar(_avatarMarcela, MAT_ALPHA, 0f, 16f, MateoEntrance);
      });
   }

   private void MateoEntrance()
   {
      ToolBox.PlayAvatar(_avatarMateo, MAT_ALPHA,15f, 23);
   }
}

[Serializable]
public struct Avatar
{
   public Material _matAvatar;
   public VideoPlayer _videoAvatar;
}


