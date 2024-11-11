using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConectaView: BaseView
{
    [SerializeField] private Image _imgIntro;
    [SerializeField] private Sprite _dispositivos;
    [SerializeField] private Sprite _seguridad;
    [SerializeField] private Sprite _papeleria;
    [SerializeField] private TextMeshProUGUI _textIntro;

    [SerializeField] private GameObject _introImgae;
    [SerializeField] private GameObject _interacioGameObject;

    [SerializeField] [CanBeNull] private TextMeshProUGUI _txtOption_A;
    [SerializeField] [CanBeNull] private TextMeshProUGUI _txtOption_B;
    [SerializeField] [CanBeNull] private TextMeshProUGUI _txtOption_C;

    [SerializeField] private StrDropZone _dropZoneA;     
    [SerializeField] private StrDropZone _dropZoneB;     
    [SerializeField] private StrDropZone _dropZoneC;
    
    private const string nivel = "Nivel";
    
    public void SetDropZones(StrDropZone a, StrDropZone b, StrDropZone c)
    {
        _dropZoneA = a;
        _dropZoneB = b;
        _dropZoneC = c;
    }
    
    public void SetView(bool intro, Category actualCategory)
    {
        _introImgae.SetActive(intro);
        _interacioGameObject.SetActive(!intro);

        _imgIntro.sprite = actualCategory switch
        {
            Category.Dispositivos => _dispositivos,
            Category.Seguridad => _seguridad,
            Category.Papeleria => _papeleria
        };
        _imgIntro.SetNativeSize();
        _imgIntro.rectTransform.sizeDelta = new Vector2(_imgIntro.rectTransform.sizeDelta.x * .18f,
            _imgIntro.rectTransform.sizeDelta.y * .18f);
        string cat = actualCategory switch
        {
            Category.Papeleria => "1",
            Category.Dispositivos => "2",
            Category.Seguridad => "3"
        };
        _textIntro.text = $"{nivel} {cat}";

        _txtOption_A.text = "";
        _txtOption_B.text = "";
        _txtOption_C.text = "";
    }

    public void SetAnswerText(int index, string answer,  bool isSpecial)
    {
        switch (index)
        {
            case 0:
                _txtOption_A.text = answer;
                SetImg(_dropZoneA.dropZoneUI.GetComponent<Image>(), isSpecial);
                _dropZoneA.dropZoneUI.gameObject.SetActive(true);
                _dropZoneA.dropZoneCollider.enabled = true;
                break;
            case 1:
                _txtOption_B.text = answer;
                SetImg(_dropZoneB.dropZoneUI.GetComponent<Image>(), isSpecial); 
                _dropZoneB.dropZoneUI.gameObject.SetActive(true);
                _dropZoneB.dropZoneCollider.enabled = true;
                break;
            case 2:
                _txtOption_C.text = answer;
                SetImg(_dropZoneC.dropZoneUI.GetComponent<Image>(), isSpecial); 
                _dropZoneC.dropZoneUI.gameObject.SetActive(true);
                _dropZoneC.dropZoneCollider.enabled = true;
                break;
        }
    }

    private void SetImg(Image content, bool isSpecial)
    {
        if (isSpecial)
        {
            content.type = Image.Type.Sliced;
            content.rectTransform.sizeDelta = new Vector2(content.rectTransform.sizeDelta.x, 150);
            content.pixelsPerUnitMultiplier = 12;
        }
        else
        {
            content.type = Image.Type.Simple;
            content.rectTransform.sizeDelta = new Vector2(content.rectTransform.sizeDelta.x, 88.65f);
        }
    }

    public void SetColorUI(RectTransform rt, int colorInt)
    {
        rt.GetComponent<Image>().color = colorInt switch
        {
            0 => ColorManager.Instance.colorLibrary.NormalColor,
            1 => ColorManager.Instance.colorLibrary.correctColor,
            2 => ColorManager.Instance.colorLibrary.incorrectColor
        };
    }
}
