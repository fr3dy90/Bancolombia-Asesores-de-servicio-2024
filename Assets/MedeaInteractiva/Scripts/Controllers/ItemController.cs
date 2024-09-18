using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    [SerializeField] private ItemView _itemView;
    [SerializeField] private ItemInfo _itemInfo;
    [SerializeField] private Button _btnItem;


    public void SetItemInfo(ItemInfo itemInfo)
    {
        _itemInfo = itemInfo;
        if (_itemInfo != null)
        {
            SetView(itemInfo);
        }
    }

    public void SetView(ItemInfo itemInfo)
    {
        _itemView.SetView(itemInfo);
    }

    public ItemInfo GetIteminfo()
    {
        if (_itemInfo != null)
        {
            return _itemInfo;
        }

        return null;
    }
}
