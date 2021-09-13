using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item storedItem;
    private Vector2 slotPosition;

    public Vector2 SlotPosition
    {
        get => slotPosition;
        private set => slotPosition = value;
    }

    public void Click(bool holdingItem, Item item)
    {
        if(holdingItem)
            Place(item);
        else
            PickUp(item);
    }

    public void StoreItem(Item item)
    {
        
    }
    private void Place(Item item)
    {
        if (storedItem.Id != item.Id)
        {
            
        }
            
    }

    private void SwitchItem(Item itemInHand)
    {
        Item placeholderItem = itemInHand;
        itemInHand = storedItem;
        storedItem = placeholderItem;
    }
    private void PickUp(Item item)
    {
        item = storedItem;
        storedItem = null;
    }

}
