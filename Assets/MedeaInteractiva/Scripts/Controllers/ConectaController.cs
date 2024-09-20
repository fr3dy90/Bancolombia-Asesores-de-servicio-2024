using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

public class ConectaController : Interaction
{
    [SerializeField] private Category _currentCategory;
    [SerializeField] private ConectaView _view;
    [SerializeField] private List<Item> _actualList;
    private int currentIndex = 0;
    

   public override async void Init()
   {
       base.Init();
       
       _view = GetComponentInChildren<ConectaView>();
       _view.SetView(true, _currentCategory);
       await UniTask.WaitForSeconds(3);
       SetMoment(_currentCategory);
   }
   
   public virtual void OnStart()
   {
        base.OnStart(); 
   }
   private void SetMoment(Category actualCategory)
   {
       _actualList = ObjectManager.Instance.GetItems(actualCategory);       
       currentIndex = 0;
       ToolBox.SimpleTransition(1, 0, .5f, .1f, _baseView.GetCanvasGroup(), _baseView.GetCanvasGroup(), () => _view.SetView(false, _currentCategory), () => SetItems(3));
   }

   private void SetItems(int ammount)
   {
       Random rndmSpawn = new Random();
       _spawnPoint = _spawnPoint.OrderBy(x => rndmSpawn.Next()).ToArray();
       _view.SetColorUI(_dropZoneOpt_A.dropZoneUI, 0);
       _view.SetColorUI(_dropZoneOpt_B.dropZoneUI, 0);
       _view.SetColorUI(_dropZoneOpt_C.dropZoneUI, 0);
       
       for (int i = 0; i < ammount; i++)
       {
           if (currentIndex < _actualList.Count)
           { 
               Item itm = _actualList[currentIndex];
               itm.InitItem(ToolBox.SetItemPosition(_spawnPoint[i], _mainCamera, _zOffset), _mainCamera, this);
               _view.SetAnswerText(i,  itm.GetItemInfo());
               itm.SetOption((Option)i);
               itm.gameObject.SetActive(true);
           }
           currentIndex++;
       }
   }
   
   public override void ReportDropResult(Item item, DropZone dropZoneCategory)
   {
       RectTransform rt = dropZoneCategory._currentOption switch
       {
           Option.OptionA => _dropZoneOpt_A.dropZoneUI,
           Option.OptionB => _dropZoneOpt_B.dropZoneUI,
           Option.OptionC => _dropZoneOpt_C.dropZoneUI,
       };
       int intColor = item._currentOprion == dropZoneCategory._currentOption ? 1 : 2;
       _view.SetColorUI(rt, intColor);

       if (item._currentOprion == dropZoneCategory._currentOption)
       {
           item.gameObject.SetActive(false);
           Collider coll = dropZoneCategory._currentOption switch
           {
               Option.OptionA => _dropZoneOpt_A.dropZoneCollider,
               Option.OptionB => _dropZoneOpt_B.dropZoneCollider,
               Option.OptionC => _dropZoneOpt_C.dropZoneCollider,
           };
           coll.enabled = false;
       }
       else
       {
           item.SetStartPosition();
       }
   }
}