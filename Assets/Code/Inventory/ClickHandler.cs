using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Code.Inventory;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerCursor.Instance.Click(eventData.pointerClick.GetComponent<ItemSlot>());
    }
}
