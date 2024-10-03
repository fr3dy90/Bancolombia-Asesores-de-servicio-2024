using Cinemachine;
using UnityEngine;

public class CinematicController : BaseController
{
   public static bool IsExit = false;
   
   [SerializeField] private CinemachineVirtualCamera[] _cameras;
    
   
   public override void Init()
   {
      foreach (CinemachineVirtualCamera cam in _cameras)
      {
         cam.GetComponent<CameraReporter>().SetConreoller(this);
      }

      IsExit = false;
      SetCameraPriority(0);
   }

   public override void OnStart()
   {
      if (!IsExit)
      {
      PlayCameraAnimation(0);
      }
      else
      {
         PlayCameraAnimationExit();
      }
   }

   public void SetCameraPriority(int cameraIndex)
   {
      for (int i = 0; i < _cameras.Length; i++)
      {
         _cameras[i].Priority = i == cameraIndex ? 1 : 0;
      }
   }

   public void PlayCameraAnimation(int cameraIndex)
   {
      SetCameraPriority(cameraIndex);
      _cameras[cameraIndex].GetComponent<Animator>().SetTrigger("Play");
   }

   public void ChangeState()
   {
      BaseSceneController.Instance.ChangeState(UIState.Welcome);
   }

   private void PlayCameraAnimationExit()
   {
      SetCameraPriority(2);
      _cameras[2].GetComponent<Animator>().SetTrigger("Exit");
   }
}
