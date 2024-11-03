using Cinemachine;
using UnityEngine;

public class CinematicController : BaseController
{
   public static bool IsExit = false;
   
   [SerializeField] private Transform[] _camerasTr;
    
   
   public override void Init()
   {
      foreach (Transform cam in _camerasTr)
      {
         cam.GetComponent<CameraReporter>().SetController(this);
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
      for (int i = 0; i < _camerasTr.Length; i++)
      {
         _camerasTr[i].GetComponentInChildren<CinemachineVirtualCamera>().Priority = i == cameraIndex ? 1 : 0;
      }
   }

   public void PlayCameraAnimation(int cameraIndex)
   {
      SetCameraPriority(cameraIndex);
      
      _camerasTr[cameraIndex].GetComponent<Animator>().SetTrigger("Play");
      _camerasTr[cameraIndex].GetComponent<CameraReporter>().StartTargetMovement();
   }

   public void ChangeState()
   {
      BaseSceneController.Instance.ChangeState(UIState.Welcome);
   }

   private void PlayCameraAnimationExit()
   {
      SetCameraPriority(2);
      _camerasTr[2].GetComponent<Animator>().SetTrigger("Exit");
   }
}
