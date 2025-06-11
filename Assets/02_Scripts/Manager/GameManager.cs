using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Character player;
    public Inventory playerInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerInventory = new Inventory();
        }
    }

    private void Start()
    {
        player = new Character("Chad", 1,5000,10,5,50,10, "코딩노예입니다.");
        SetData();

        InitializeItems();
 
    }
    public void SetData()
    {
        UIManager.instance.uiMainMenu.CharacterInfo(player);
        UIManager.instance.uiStatus.StatusInfo(player);
    }

    private void InitializeItems()
    {
        Item woodSword = new Item("Wood Sword", Resources.Load<Sprite>("Wooden Sword"), ItemType.Weapon, 1, 50f,0,0,10);
        Item hpPotion = new Item("HP Potion", Resources.Load<Sprite>("Red Potion"), ItemType.Consumable, 5, 0f, 0f, 50f);
        Item helm = new Item("Helm", Resources.Load<Sprite>("Helm"), ItemType.Armor, 1, 0, 30f);

        playerInventory.AddItem(woodSword); 
        playerInventory.AddItem(hpPotion);
        playerInventory.AddItem(helm);
    }

    public void MonsterKill()
    {
        float damageTaken = 5f;
        int expReward = 5;
        int goldReward = 100; 
        playerInventory.AddItem(GetRandomItem()); 

        player.KillReward(goldReward, expReward, damageTaken);

        UIManager.instance.uiInventory.UpdateInventoryUI();
        UIManager.instance.uiStatus.StatusInfo(player);
        UIManager.instance.uiMainMenu.CharacterInfo(player);
    }

    private Item GetRandomItem()
    {
        List<Item> itemPool = new List<Item>
        {
           new Item("Wood Sword", Resources.Load<Sprite>("Wooden Sword"), ItemType.Weapon, 1, 50f,0,0,10),
           new Item("HP Potion", Resources.Load<Sprite>("Red Potion"), ItemType.Consumable, 5, 0f, 0f, 50f),
           new Item("Helm", Resources.Load<Sprite>("Helm"), ItemType.Armor, 1, 0, 30f)
        };

        return itemPool[Random.Range(0, itemPool.Count)]; 
    }
}
