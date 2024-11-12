using UnityEngine;
using UnityEngine.UI;

public class InfoController : BaseController
{
   [SerializeField] private InfoView _view;
   [SerializeField, TextArea(3, 3)] private string _startText;
   [SerializeField, TextArea(3, 3)] private string _endText;
   [SerializeField] private SetInfoText _actualInfoText;
   [SerializeField] private Button _button;

   [SerializeField] private Camera _ui_cam;

   public override void Init()
   {
      base.Init();
      _view = GetComponentInChildren<InfoView>();
      _actualInfoText = SetInfoText.Start;
   }

   public override void OnStart()
   {
      _ui_cam.gameObject.SetActive(true);
      base.OnStart();
      SetText();
   }

   private void SetText()
   {
      if (_actualInfoText == SetInfoText.Start)
      {
         _view.SetInfoText(_startText);
         _actualInfoText = SetInfoText.End;
         _button.onClick.AddListener(OnClick);
      }
      else
      {
         _view.SetInfoText(_endText);
      }
   }

   private void OnClick()
   {
      _button.onClick.RemoveAllListeners();
      BaseSceneController.Instance.ChangeState(UIState.Avatar);
   }
}
