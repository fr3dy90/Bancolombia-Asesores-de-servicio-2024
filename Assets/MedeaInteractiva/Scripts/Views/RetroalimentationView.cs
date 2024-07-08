using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetroalimentationView : BaseView
{
    [SerializeField] private Image _background;
    [SerializeField] private Sprite _backgroundWhite;
    [SerializeField] private Sprite _backgroundOrange;
    
    [SerializeField] private Image _icon; 
    [SerializeField] private Sprite _spriteGood;
    [SerializeField] private Sprite _spritebad;
    
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private TextMeshProUGUI _textRetroalimentation;
    
    [SerializeField] private Button _buttonContinue;


    public void SetView(ModalRetroalimentation modalRetroalimentation)
    {
        foreach (RetroalimentationContent content in modalRetroalimentation.modalContent)
        {
            _background.sprite = content.isWhite ? _backgroundWhite : _backgroundOrange;
            _icon.sprite = content.isGood ? _spriteGood : _spritebad;
            _icon.rectTransform.sizeDelta = content.isGood ? new Vector2(1,11) : new Vector2(11,1);
            _textTitle.text = content.titleText;
            _textRetroalimentation.text = content.retroalimentationText;
            _buttonContinue.onClick.RemoveAllListeners();
            _buttonContinue.gameObject.SetActive(content.onAction != null);
            _buttonContinue.onClick.AddListener(()=>{content.onAction?.Invoke();});
        }
    }
}