using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Progress = UnityEditor.Progress;
using Random = System.Random;

public class ConectaController : Interaction
{
    [SerializeField] private Category _currentCategory;
    [SerializeField] private ConectaView _view;
    [SerializeField] private List<Item> _actualList;
    [SerializeField] private Vector3 _itemScale;
    
    private int currentIndex = 0;
    private int localAmmount = 0;
    private int localReport = 0;
    private int itemCounter = 0;
    private bool changeCategory;
    

   public override async void Init()
   {
       base.Init();
       _view = GetComponentInChildren<ConectaView>();
       _currentCategory = Category.Papeleria;
       _view.SetView(true, _currentCategory);
   }
   
   public override void OnStart()
   {
        base.OnStart(); 
        SetMoment(_currentCategory);
        localAmmount = 0;
        itemCounter = 0;
        SetNormalStrDropZone();
        
   }
   private async void SetMoment(Category actualCategory)
   {
       
       _actualList = ObjectManager.Instance.GetItems(actualCategory);       
       currentIndex = 0;
       _view.SetView(true, _currentCategory);
       
        await UniTask.WaitForSeconds(3);
       ToolBox.SimpleTransition(1, 0, .5f, .1f, _baseView.GetCanvasGroup(), _baseView.GetCanvasGroup(), () => _view.SetView(false, _currentCategory), () => SetItems(3));
   }

   private void SetItems(int ammount)
   {
       localAmmount = ammount;
       localReport = 0;

      
       Random rndmSpawn = new Random();
       _spawnPoint = _spawnPoint.OrderBy(x => rndmSpawn.Next()).ToArray();
       SetNormalStrDropZone();

       for (int i = 0; i < ammount; i++)
       {
           if (currentIndex < _actualList.Count)
           {
               Item itm = _actualList[currentIndex];
               itm.InitItem(ToolBox.SetItemPosition(_spawnPoint[i], _mainCamera, _zOffset), _mainCamera, this);
               _view.SetAnswerText(i, itm.GetItemInfo());
               itm.SetOption((Option)i);
               itm.transform.localScale = _itemScale;
               itm.gameObject.SetActive(true);
               currentIndex++;
           }
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
           Collider coll = dropZoneCategory._currentOption switch
           {
               Option.OptionA => _dropZoneOpt_A.dropZoneCollider,
               Option.OptionB => _dropZoneOpt_B.dropZoneCollider,
               Option.OptionC => _dropZoneOpt_C.dropZoneCollider,
           };
           item.gameObject.SetActive(false);
           coll.enabled = false;
           localReport++;
           itemCounter++;
           if (itemCounter == ObjectManager.Instance.GetItems(_currentCategory).Count)
           {
               RetroalimentationController.ActualUIState = MainMenu.Conecta;
               RetroalimentationController.SelectedRetro = _currentCategory == Category.Seguridad ? 1 : 0;
               SetCategory(_currentCategory);
               BaseSceneController.Instance.ChangeState(UIState.Retroalimentation);
               
           }
           
           if (localReport >= localAmmount)
           {
               SetItems(3);
           }
       }
       else
       {
           item.SetStartPosition();
       }
   }

   private void SetNormalStrDropZone()
   {
       _view.SetColorUI(_dropZoneOpt_A.dropZoneUI, 0);
       _view.SetColorUI(_dropZoneOpt_B.dropZoneUI, 0);
       _view.SetColorUI(_dropZoneOpt_C.dropZoneUI, 0);
       _dropZoneOpt_A.dropZoneCollider.enabled = true;
       _dropZoneOpt_B.dropZoneCollider.enabled = true;
       _dropZoneOpt_C.dropZoneCollider.enabled = true;
   }

   private void SetCategory(Category currentCategory)
   {
       _currentCategory = currentCategory switch
       {
            Category.Papeleria => Category.Dispositivos,
            Category.Dispositivos => Category.Seguridad,
            Category.Seguridad => Category.Papeleria
       };
   }
}