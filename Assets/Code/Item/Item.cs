using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    protected enum Rarity { White, Green, Pink, Lime, Purple };
    protected enum Type { Tile, Consumable, Furniture, Weapon, Tool, Equipable };

    [SerializeField] private Rarity rarity = Rarity.White;
    [SerializeField] private Type type;
    [SerializeField] private int quantity;
    [SerializeField] private bool stackable;
    
    protected int id;
    [SerializeField] TextMeshProUGUI quantityText;
    private int maxQuantity = 999;
    public int Id
    {
        get => id;
        set => id = value;
    }
    private Item newItem;
    public int Quantity
    { 
        get => quantity;
        private set
        {
            quantity = value;
            quantityText.text = quantity.ToString();
        }
    }
    
    public void Stack(Item item)
    {
        Quantity += item.Quantity;
        if (Quantity > maxQuantity)
            item.Quantity = Quantity - maxQuantity;
        if (item.quantity < 1)
            item = null;
    }

    protected virtual void Start()
    {
        SetupQuantityText();
    }

    private void SetupQuantityText()
    {
        if (!stackable)
            return;
        quantityText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        quantity = Random.Range(1, 1000);
        quantityText.text = quantity.ToString();
    }
}
