using System.Collections.Generic;

//������ ����
public class Inventory
{
    public List<Item> items = new List<Item>(); //������ ������ ����Ʈ ����

    public void AddItem(Item item)
    {
        if (item.Type == ItemType.Consumable)
        {
            Item existingItem = items.Find(i => i.ItemName == item.ItemName && i.Amount < i.MaxAmount);

            if (existingItem != null)
            {
                existingItem.IncreaseAmount();
            }
            else
            {
                Item newItem = new Item(item.ItemName, item.Icon, item.Type, item.MaxAmount, item.Damage, item.Defend, item.HP, item.Critical);
                item.SetAmount(1);
                items.Add(item);
            }
        }
        else
        {
            items.Add(item);
        }
    }
    public void RemoveItem(Item item) //������ ����
    {
        items.Remove(item);
    }

    public List<Item> GetItems() { return items; } //������ ����Ʈ �� ��ȯ
}
