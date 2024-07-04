using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalIntroView : BaseView
{
   [SerializeField] private Image _imgIconMoment;
   [SerializeField] private TextMeshProUGUI _textContent;
   [SerializeField] private Button _btnContinue;
   
   public async void SetBasicIntro(ModalWindowIntro modalWindowIntro)
   {
       _imgIconMoment.sprite = modalWindowIntro.modalSprite;
       foreach (ModalContent content in modalWindowIntro.modalContent)
       {
           _btnContinue.gameObject.SetActive(false);
           _textContent.text = content.text;
           _btnContinue.onClick.RemoveAllListeners();
           
           await UniTask.WaitForSeconds(content.timeInScreen);
           _btnContinue.gameObject.SetActive(content.buttonAction != null);
           _btnContinue.onClick.AddListener(() =>
           {
               content.buttonAction?.Invoke();
           });
       }
   }
}