using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalIntroView : BaseView
{
    [Header("Default UI")] 
    [SerializeField] private Image _imgIconMoment;
    [SerializeField] private TextMeshProUGUI _textContent;
    [SerializeField] private Button _btnContinue;
    
    [Header("Image UI")]
    [SerializeField] private TextMeshProUGUI _alternativeText;
    [SerializeField] private Image[] _imgCollection;

    public async void SetBasicIntro(ModalWindowIntro modalWindowIntro)
    {
        _imgIconMoment.sprite = modalWindowIntro.modalSprite;
        foreach (ModalContent content in modalWindowIntro.modalContent)
        {
            SetUI(content.requiredType);
            
            _btnContinue.gameObject.SetActive(false);
            _textContent.text = content.text;
            _alternativeText.text = content.text;
            _btnContinue.onClick.RemoveAllListeners();
            SetImage(content.imageIndex -1);

            await UniTask.WaitForSeconds(content.timeInScreen);
            _btnContinue.gameObject.SetActive(content.buttonAction != null);
            _btnContinue.onClick.AddListener(() => { content.buttonAction?.Invoke(); });
        }
    }

    private void SetUI(UIType uiRequired)
    {
        _textContent.gameObject.SetActive(uiRequired == UIType.Standard);
        _alternativeText.gameObject.SetActive(uiRequired == UIType.Images);
    }

    private void SetImage(int index)
    {
        for (int i = 0; i < _imgCollection.Length; i++)
        {
            _imgCollection[i].gameObject.SetActive(i == index);
        }
    }
}