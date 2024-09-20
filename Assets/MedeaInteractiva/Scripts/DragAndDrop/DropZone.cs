using UnityEngine;

public class DropZone : MonoBehaviour
{
   public Category _dropCategory;
   public Option _currentOption;
   [SerializeField] private LoaderManager _loaderManager;
   [SerializeField] private Item _lastItem;   
}
