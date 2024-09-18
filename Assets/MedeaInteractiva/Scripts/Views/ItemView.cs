using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _itemImage;

    public void SetView(ItemInfo itemInfo)
    {
        _background.color = itemInfo.isViewed
            ? ColorManager.Instance.colorLibrary.itemInfo_ViewColor
            : ColorManager.Instance.colorLibrary.itemInfo_UnviewColor;

        _itemImage.sprite = itemInfo.spriteItem;
    }
}
