using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EquippedSlot : MonoBehaviour, IDropHandler
{
    public IItemEffect EquippedItem;

    public void OnDrop(PointerEventData eventData)
    {
        if (EquippedItem == null)
        {
            EquippedItem = eventData.pointerDrag.GetComponent<IItemEffect>();
            eventData.pointerDrag.transform.SetParent(this.gameObject.transform);
        }
        if (!EquippedItem.IsActive)
            EquippedItem.ActivateEffect();
    }
}
