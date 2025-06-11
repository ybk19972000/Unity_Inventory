using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable
}


public class Item 
{
    public string ItemName { get; private set; }
    public int MaxAmount { get; private set; }
    public int Amount { get; private set; }
    public float Damage { get; private set; }
    public float Defend { get; private set; }
    public float HP { get; private set; }
    public float Critical { get; private set; }
    public Sprite Icon { get; private set; }
    public ItemType Type { get; private set; }

    public Item(string itemName, Sprite icon,ItemType itemType, int maxAmount = 1, float damage = 0f, float defend = 0f,
        float hp = 0, float critical = 0f) 
    {
        ItemName = itemName;
        MaxAmount = maxAmount;
        Icon = icon;
        Type = itemType;
        Damage = damage;
        Defend = defend;
        HP = hp;
        Critical = critical;
        Amount = 1;
    }

    public void IncreaseAmount()
    {
        if (Amount < MaxAmount) 
        {
            Amount++;
        }
    }
    public void SetAmount(int value)
    {
        Amount = value;
    }
}

