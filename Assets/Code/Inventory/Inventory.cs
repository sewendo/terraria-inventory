using System;
using System.Collections;
using System.Collections.Generic;
using Code.Inventory;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Inventory : MonoBehaviour
{
    private ItemSlot[,] _itemSlots;
    private int height = 5;
    private int width = 10;
    [SerializeField] private Vector2 offset, origin;
    [SerializeField] private GameObject inventorySlot;
    private Canvas canvas;
    [SerializeField] private Texture2D texture;
    [SerializeField] private Texture2D favoriteTexture;
    private GameObject itemsParent;
    private void SetupInventory()
    {
        canvas = GetComponent<Canvas>();
        _itemSlots = new ItemSlot[width, height];
        ItemManager itemManager = ItemManager.Instance;
        for (int i = 0; i < width; i++)
        {
            for (int y = 0; y < height; y++)
            {
                _itemSlots[i, y] = Instantiate(inventorySlot,
                    new Vector3(i * offset.x + origin.x,
                        y * -offset.y - origin.y + canvas.pixelRect.height, 0),
                    Quaternion.identity, transform).AddComponent<ItemSlot>();
                _itemSlots[i, y].gameObject.AddComponent<ClickHandler>();
            }
        }

        itemsParent = new GameObject("Items");
        itemsParent.transform.SetParent(transform);
        
        for (int i = 0; i < width; i++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newItem = Instantiate(itemManager.items[Random.Range(0, itemManager.items.Length)].gameObject,
                    _itemSlots[i, y].transform.position, Quaternion.identity, itemsParent.transform);
                _itemSlots[i, y].storedItem = newItem.GetComponent<Item>();
            }
        }
    }
    

    private void Start()
    {
        SetupInventory();
    }

    private void SortInventory()
    {
        
    }
}
