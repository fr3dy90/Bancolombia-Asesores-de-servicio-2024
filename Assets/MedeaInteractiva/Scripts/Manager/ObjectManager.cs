using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class ObjectManager : MonoBehaviour
{
   public static ObjectManager Instance;
   [SerializeField] private List<Item> _objects;

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
      }
      else
      {
         Destroy(this);
      }
   }

   public void MixObjects()
   {
      Random random = new Random();
      _objects = _objects.OrderBy(x => random.Next()).ToList();
   }

   public void HandleObjects(bool isActive)
   {
      foreach (Item item in _objects)
      {
         item.gameObject.SetActive(isActive);
      }
   }

   public Item GetItem(int index)
   {
      return index < _objects.Count ? _objects[index] : null;
   }

   public int GetObjsCount()
   {
      return _objects.Count;
   }
}
