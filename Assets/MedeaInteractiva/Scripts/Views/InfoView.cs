using TMPro;
using UnityEngine;

public class InfoView : BaseView
{
    [SerializeField] private TextMeshProUGUI _textToDisplay;

    public void SetInfoText(string str)
    {
        _textToDisplay.text = str;
    }
}