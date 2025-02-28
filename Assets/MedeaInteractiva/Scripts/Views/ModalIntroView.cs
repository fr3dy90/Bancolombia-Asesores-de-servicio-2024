using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ModalIntroView : BaseView
{
    [Header("Default UI")] 
    [SerializeField] private Image _imgIconMoment;
    [SerializeField] private TextMeshProUGUI _textContent;
    [SerializeField] private Button _btnContinue;
    [SerializeField] private Image[] _showInfoImg;

    
    [Header("Image UI")]
    [SerializeField] private TextMeshProUGUI _alternativeText;
    [SerializeField] private Image[] _imgCollection;

    public async void SetBasicIntro(ModalWindowIntro modalWindowIntro)
    {
        _imgIconMoment.sprite = modalWindowIntro.modalSprite;
        _imgIconMoment.rectTransform.sizeDelta = modalWindowIntro.modalSpriteSize;
        foreach (ModalContent content in modalWindowIntro.modalContent)
        {
            SetUI(content.requiredType);
            SetShowInfo(content.showInfo);
            
            _btnContinue.gameObject.SetActive(false);
            _textContent.text = content.text;
            _alternativeText.text = content.text;
            _btnContinue.onClick.RemoveAllListeners();
            SetImage(content.imageIndex -1);

            if (content.audio == null)
            {
                await UniTask.WaitForSeconds(content.timeInScreen);
            }
            else
            {
                await UniTask.WaitForSeconds(content.audioFade);
                AudioManager.Instance.PlayAudio(content.audio);
                await UniTask.WaitForSeconds(content.audio.length);
            }
            
            _btnContinue.gameObject.SetActive(content.buttonAction != null);
            _btnContinue.onClick.AddListener(() => { content.buttonAction?.Invoke(); });
        }
    }

    private void SetUI(UIType uiRequired)
    {
        _textContent.gameObject.SetActive(uiRequired == UIType.Standard);
        _alternativeText.gameObject.SetActive(uiRequired == UIType.Images);
    }

    private void SetShowInfo(ShowInfo info)
    {
       
        _showInfoImg[0].color = ColorManager.Instance.colorLibrary.modalIntroView_UnselectedColor;
        _showInfoImg[1].color = ColorManager.Instance.colorLibrary.modalIntroView_UnselectedColor;
        
        switch (info)
        {
            case ShowInfo.Intro:
                _showInfoImg[0].color = ColorManager.Instance.colorLibrary.modalIntroView_SelectedColor;
                break;
            case ShowInfo.Instructions:
                _showInfoImg[1].color = ColorManager.Instance.colorLibrary.modalIntroView_SelectedColor;
                break;
        }
    }

    private void SetImage(int index)
    {
        for (int i = 0; i < _imgCollection.Length; i++)
        {
            _imgCollection[i].gameObject.SetActive(i == index);
        }
    }
}