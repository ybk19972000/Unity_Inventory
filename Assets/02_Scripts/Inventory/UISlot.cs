using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


public class UISlot : MonoBehaviour
{
    [SerializeField] Image itemIcon;
    [SerializeField] Image equipStatus;
    [SerializeField] TextMeshProUGUI itemQuantity;
    [SerializeField] private Button slotButton;


    private void Start()
    {
        slotButton.onClick.AddListener(OnUseItem); 
    }
    public void SetItem(Item item)
    {
        if (item == null)
        {
            itemIcon.sprite = null;
            return;
        }
        itemIcon.sprite = item.Icon;
        RefreshUI(item);
    }
    private void OnUseItem()
    {
        Item slotItem = GameManager.Instance.playerInventory.GetItems().Find(i => i.ItemName == itemIcon.sprite.name);

        if (slotItem == null || slotItem.Type != ItemType.Consumable) return;

        GameManager.Instance.player.UseItem(slotItem); 
        GameManager.Instance.playerInventory.RemoveItem(slotItem); 

        UIManager.instance.uiInventory.UpdateInventoryUI(); 
        UIManager.instance.uiStatus.StatusInfo(GameManager.Instance.player); 
    }
    public void RefreshUI(Item item)
    {
        if (item != null)
        {
            itemIcon.sprite = item.Icon; // ������ �̹��� ����
            //itemName.text = item.name; // ������ �̸� ǥ��
            itemQuantity.text = item.Amount.ToString(); // ���� ǥ��
        }
        else
        {
            itemIcon.sprite = null;
            //itemName.text = "";
            itemQuantity.text = "";
        }
    }
}
