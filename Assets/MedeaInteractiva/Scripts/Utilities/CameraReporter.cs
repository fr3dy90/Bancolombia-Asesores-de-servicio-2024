using UnityEngine;

public class CameraReporter : MonoBehaviour
{
   public int cameraIndex;
   public bool changeState = false;
   [SerializeField] private CinematicController _cinematicController;

   [Header("Camera Target")] 
   [SerializeField] private float duration;

   [SerializeField] private Transform target;
   [SerializeField] private Transform start;
   [SerializeField] private Transform finish;
   

   public void SetController(CinematicController controller)
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

   public void StartTargetMovement()
   {
      ToolBox.DesirePos(target, start.position, finish.position, duration);
   }

   public void CameraExitInfo()
   {
      BaseSceneController.Instance.ChangeState(UIState.Info);
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.cyan;
      Gizmos.DrawSphere(start.position, .5f);
      Gizmos.DrawLine(start.position, finish.position);
      Gizmos.color = Color.green;
      Gizmos.DrawSphere(finish.position, .5f);
   }
}