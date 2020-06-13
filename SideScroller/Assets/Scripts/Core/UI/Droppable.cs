using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Droppable : MonoBehaviour, IDropHandler
{
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (this.gameObject.transform.childCount == 0)
        {
            var itemEffect = eventData.pointerDrag.GetComponent<InventoryItem>();
            if (itemEffect.IsActive)
                itemEffect.RemoveEffect();
            eventData.pointerDrag.transform.SetParent(this.gameObject.transform);
        }
    }
}
