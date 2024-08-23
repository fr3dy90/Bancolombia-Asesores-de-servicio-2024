using UnityEngine;

public class CameraReporter : MonoBehaviour
{
   public int cameraIndex;
   public bool changeState = false;
   [SerializeField] private CinematicController _cinematicController;

   public void SetConreoller(CinematicController controller)
   {
      _cinematicController = controller;
   }

   public void SetCamera()
   {
      if (!changeState)
      {
         _cinematicController.PlayCameraAnimation(cameraIndex);  
      }
      else
      {
         _cinematicController.ChangeState();
      }
   }
}