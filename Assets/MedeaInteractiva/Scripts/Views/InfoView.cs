using TMPro;
using UnityEngine;

public class InfoView : BaseView
{
    [SerializeField] private TextMeshProUGUI _textToDisplay;
    [SerializeField] private TextMeshProUGUI _shadowtextToDisplay;

    public void SetInfoText(string str)
    {
        _textToDisplay.text = str;
        _shadowtextToDisplay.text = str;
    }
}