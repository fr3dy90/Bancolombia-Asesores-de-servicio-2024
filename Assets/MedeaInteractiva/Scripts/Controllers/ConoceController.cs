using UnityEngine;
using UnityEngine.UI;

public class ConoceController : BaseController
{
   [SerializeField] private ConoceView _view;
   [SerializeField] private GameObject _prefItem;
   [SerializeField] private ItemInfo[] _itemInfoList;

   public override void Init()
   {
      base.Init();
      _view = GetComponentInChildren<ConoceView>();
      OnSetItems();
      
      _view.GetContainer(Category.Dispositivos).GetChild(0).GetComponentInChildren<Button>().onClick?.Invoke();
      _view.GetButton().onClick.AddListener(()=> BaseSceneController.Instance.ChangeState(UIState.Menu));
  
   }

   public void OnStart()
   {
      
   }

   private void OnSetItems()
   {
      for (int i = 0; i < _itemInfoList.Length; i++)
      {
         GameObject go = Instantiate(_prefItem, _view.GetContainer(_itemInfoList[i].actualCategory));
         ItemController ic = go.GetComponent<ItemController>();
         _itemInfoList[i].isViewed = false;
         ic.SetItemInfo(_itemInfoList[i]);
         go.name = _itemInfoList[i].itemName;
         go.GetComponentInChildren<Button>().onClick.AddListener(() => { 
            SetConoceView(ic.GetIteminfo());
            ic.SetView(ic.GetIteminfo());
         });
      }
   }

   private void SetConoceView(ItemInfo itemInfo)
   {
      itemInfo.isViewed = true;
      _view.SetConoceView(itemInfo);
   }
}
