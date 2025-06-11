using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Button invenBtn;
    public Button statusBtn;
    public Button backBtn;

    public TextMeshProUGUI slotSize;

    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<UISlot> itemslots = new List<UISlot>();//슬롯리스트
    private Inventory inventory;

    private int maxInvenSize;
     
    private void Start()
    {
        inventory = GameManager.Instance.playerInventory;
        maxInvenSize = 50;
        backBtn.onClick.RemoveAllListeners();

        backBtn.onClick.AddListener(OnInventoryBackBtn);

        InitInventoryUI();
    }


    public void OnInventoryBackBtn()
    {
        CloseInventory();
    }

    private void CloseInventory() 
    {
        this.gameObject.SetActive(false);

       invenBtn.gameObject.SetActive(true);
       statusBtn.gameObject.SetActive(true);
    }

    public void InitInventoryUI()
    {
        for(int i =0; i< maxInvenSize; i++)//아이템 슬롯 최대 값에 따라 넣으면됨 
        {
            UISlot newSlot = Instantiate(slotPrefab, slotParent);

            if (i < inventory.GetItems().Count)
            {
                newSlot.SetItem(inventory.GetItems()[i]);
            }
            else
            {
                newSlot.SetItem(null);
            }

            itemslots.Add(newSlot);
        }
        SlotSizeUpdate();
    }
    public void UpdateInventoryUI()
    {
        foreach (UISlot slot in itemslots)
        {
            Destroy(slot.gameObject);
        }
        itemslots.Clear();

        InitInventoryUI();
        SlotSizeUpdate();
    }
    public void SlotSizeUpdate()
    {
        slotSize.text = $"{GameManager.Instance.playerInventory.GetItems().Count}/{maxInvenSize}";
    }

 
    public void AddItem(Item item)
    {
        inventory.AddItem(item);
        UpdateInventoryUI();
        SlotSizeUpdate();
    }

    public void RemoveItem(Item item)
    {
        inventory.RemoveItem(item);
        UpdateInventoryUI();
        SlotSizeUpdate(); 
    }
}
