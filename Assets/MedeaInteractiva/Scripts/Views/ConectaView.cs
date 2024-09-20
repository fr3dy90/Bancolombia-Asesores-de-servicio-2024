using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Color = System.Drawing.Color;

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
    
    

    private const string nivel = "Nivel";
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

            string cat = actualCategory switch
            {
                Category.Papeleria => "1",
                Category.Dispositivos => "2",
                Category.Seguridad => "3"
            };
            _textIntro.text = $"{nivel} {cat}";
        
    }

    public void SetAnswerText(int index, string answer)
    {
        switch (index)
        {
            case 0:
                _txtOption_A.text = answer;
                break;
            case 1:
                _txtOption_B.text = answer;
                break;
            case 2:
                _txtOption_C.text = answer;
                break;
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
