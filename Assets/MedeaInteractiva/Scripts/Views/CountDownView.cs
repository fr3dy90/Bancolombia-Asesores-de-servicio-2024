using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownView : BaseView
{

   [SerializeField] private TextMeshProUGUI _textCountDown;
   [SerializeField] private Image _background;
   [SerializeField] private int _countDown;
   

   public void InitCountDown()
   {
      _canvasGroup.alpha = 0;
      _textCountDown.text = _countDown.ToString();
      _background.fillAmount = 1;
      CountDown();
   }
   
   private async UniTask CountDown()
   {
       int countDown = _countDown;
       bool fill = true;
       while (countDown > 0)
       {
           _textCountDown.text = countDown.ToString();
           float time = 0;
           while (time <= 1)
           {
               time += Time.deltaTime;
               if (fill)
               {
                   _background.fillAmount = time;
               }
               else
               {
                   _background.fillAmount = 1 - time;   
                   
               }
               await UniTask.Yield(PlayerLoopTiming.Update);
           }
           fill = !fill;
           _background.fillClockwise = fill;
           countDown--;
       }
   }
}