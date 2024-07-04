using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalIntroView : BaseView
{
   [SerializeField] private Image _imgIconMoment;
   [SerializeField] private TextMeshProUGUI _textContent;
   [SerializeField] private Button _btnContinue;
   
   public void SetBasicIntro(Sprite icon, string text, Action buttonActon = null)
   {
       _imgIconMoment.sprite = icon;
       _textContent.text = text;
       _btnContinue.onClick.RemoveAllListeners();
       _btnContinue.gameObject.SetActive(buttonActon != null);
       _btnContinue.onClick.AddListener(() =>
       {
            buttonActon?.Invoke();
       });
   }
}