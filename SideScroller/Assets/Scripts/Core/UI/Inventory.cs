using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Transform> _InventorySlots;
    private GameObject _InventoryMenu;
    private UIHandler _MainUiHandler;
    private Core _CoreGame;
    public List<Item> InventoryItems = new List<Item>();


    private void Awake()
    {
        _MainUiHandler = GetComponentInParent<UIHandler>();
        _CoreGame = GetComponentInParent<Core>();
        _InventorySlots = this.gameObject
                            .GetComponentsInChildren<Transform>()
                            .Where(go => go.name.Contains("inventory0"))
                            .OrderBy(go => go.name)
                            .ToList();

        _InventoryMenu = this.gameObject.GetComponentsInChildren<Transform>().FirstOrDefault(go => go.name == "InventoryMenu")?.gameObject;
    }

    public void AddInventoryItem(Item item)
    {
        var prefab = Instantiate(item.InventoryItemPrefab);
        prefab.GetComponent<IItemEffect>().RegisterServices(_CoreGame.RegisteredDependencies);
        //InventoryItems.Add(item);
        //var gameObject = new GameObject("", 
        //    typeof(InventoryItem), 
        //    typeof(Image));
        //var image = gameObject.GetComponent<Image>();
        //image.sprite = item.Sprite;
        //image.transform.localScale = new Vector2(.01f, .01f);
        prefab.transform.SetParent(_InventorySlots.FirstOrDefault(i => i.childCount == 0));
        prefab.transform.localPosition = Vector2.zero;
        prefab.transform.localScale = new Vector2(.01f, .01f);
    }

    public void BackClicked()
    {
        _MainUiHandler.WakeGameMenu();
    }
}

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private GameObject _PotentialParent;
    private Image itemImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        //_IsDragging = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.localPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 rayPoint = ray.GetPoint(distance);
        transform.position = ray.GetPoint(0f);
    }
}
