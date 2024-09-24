using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetroalimentationView : BaseView
{


    [Header("Standar UI")] 
    [SerializeField] private Image _iconMoment;
    [SerializeField] private Image _icon; 
    [SerializeField] private Sprite _spriteGood;
    [SerializeField] private Sprite _spritebad;
    
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private TextMeshProUGUI _textRetroalimentation;

    [Header("Special Content")] 
    [SerializeField] private TextMeshProUGUI _textSpecialContent;
    
    [SerializeField] private GameObject _normalContent;
    [SerializeField] private GameObject _specialContent;
    [SerializeField] private Button _buttonContinue;


    public async void SetView(ModalRetroalimentation modalRetroalimentation)
    {
        foreach (RetroalimentationContent content in modalRetroalimentation.modalContent)
        {
            _iconMoment.sprite = modalRetroalimentation.iconMoment;
            _iconMoment.rectTransform.sizeDelta = modalRetroalimentation.iconMomentSize;
            
            _buttonContinue.gameObject.SetActive(false);
            _normalContent.gameObject.SetActive(content.actualUIType == UIType.Standard);
            _specialContent.gameObject.SetActive(content.actualUIType == UIType.Images);
            
            _icon.sprite = content.isGood ? _spriteGood : _spritebad;
            _textTitle.text = content.titleText;
            _textRetroalimentation.text = content.retroalimentationText;

            _textSpecialContent.text = content.retroalimentationText;

            if (content.audioClip == null)
            {
                await UniTask.WaitForSeconds(content._timeInScreen);
            }
            else
            {
                await UniTask.WaitForSeconds(content.audioFade);
                AudioManager.Instance.PlayAudio(content.audioClip);
                await UniTask.WaitForSeconds(content.audioClip.length);
            }
            
            _buttonContinue.onClick.RemoveAllListeners();
            _buttonContinue.onClick.AddListener(()=>{content.onAction?.Invoke();});
            _buttonContinue.gameObject.SetActive(content.onAction != null); 
        }
    }
}