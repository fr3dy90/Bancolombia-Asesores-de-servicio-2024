using System;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DragAndDropManager : MonoBehaviour
{
   [SerializeField] private Camera _camera;
   [SerializeField] private bool _isDraggin;

   private Vector3 _offset;
   private Vector3 _startPosition;
   private Transform _draggedObject;

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         StartDrag();
      }

      if (_isDraggin)
      {
         UpdateDrag();
      }

      if (Input.GetMouseButtonUp(0))
      {
         EndDrag();
      }
   }

   private void StartDrag()
   {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out RaycastHit hit))
      {
         DragHandler dragHandler = hit.collider.GetComponent<DragHandler>();
         if (dragHandler != null)
         {
            _isDraggin = true;
            _draggedObject = hit.transform;
            _offset = _draggedObject.position - hit.point;
            _startPosition = _draggedObject.position;
         }
      }
   }
   
   private void UpdateDrag()
   {
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out RaycastHit hit))
      {
         _draggedObject.position = hit.point + _offset;
      }
   }
   private void EndDrag()
   {
      if (_isDraggin)
      {
         _isDraggin = false;
         Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(ray, out RaycastHit hit))
         {
            DropZone dropZone = hit.collider.GetComponent<DropZone>();
            if (dropZone != null)
            {
               dropZone.IsCorrectDrop(_draggedObject.GetComponent<DragHandler>());
            }
            else
            {
               _draggedObject.position = _startPosition;
            }
         }
         else
         {
            _draggedObject.position = _startPosition;
         }

         _draggedObject = null;
      }      
   }
}