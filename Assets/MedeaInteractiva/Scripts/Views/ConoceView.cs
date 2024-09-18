using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConoceView : BaseView
{
    [Header("Item View")] 
    [SerializeField] private Image _itemImg;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemDescription;
    
    [Header("Containers")]
    [SerializeField] private Transform _dispositivosContainer;
    [SerializeField] private Transform _seguridadContainer;
    [SerializeField] private Transform _papeleriaContainer;

    [Header("Button")] 
    [SerializeField] private Button _btnContinue;
    
    

    public Transform GetContainer(Category currentCategory)
    {
        switch (currentCategory)
        {
            case Category.Dispositivos:
                return _dispositivosContainer;
                break;
            case Category.Seguridad:
                return _seguridadContainer;
                break;
            case Category.Papeleria:
                return _papeleriaContainer;
                break;
        }
        return null;
    }

    public void SetConoceView(ItemInfo itemInfo)
    {
        _itemImg.sprite = itemInfo.spriteItem;
        _itemName.text = itemInfo.itemName;
        _itemDescription.text = itemInfo.itemDescription;
    }

    public Button GetButton()
    {
        if (_btnContinue != null) return _btnContinue;

        return null;
    }
}
