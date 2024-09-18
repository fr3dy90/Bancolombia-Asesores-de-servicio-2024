using System;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class DropZone : MonoBehaviour
{
   [SerializeField] private Category _dropCategory;
   [SerializeField] private LoaderManager _loaderManager;
   [SerializeField] private Item _lastItem; 

   private void Awake()
   {
      LoaderManager.onDroppedObj +=  OnReport;
   }

   private void OnDestroy()
   {
      LoaderManager.onDroppedObj -= OnReport;
   }

   private void OnTriggerEnter(Collider other)
   {
      Item item = other.GetComponent<Item>();
      if (item != null)
      {
         _loaderManager._isFilling = true;
         _loaderManager.GetDropZone(this);
         _lastItem = item;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      Item item = other.GetComponent<Item>();
      if(item != null)
      {
         _loaderManager._isFilling = false;
         _loaderManager.GetDropZone(null);
         _lastItem = null;
      }
   }

   private void OnReport(DropZone dz)
   {
      if (dz == this)
      {
         _lastItem.gameObject.SetActive(false);
         _lastItem.OnSuccessfullDrop(_dropCategory);
         _lastItem = null;
      }
   }
}
