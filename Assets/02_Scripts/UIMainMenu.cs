using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public Button inventoryBtn;
    public Button statusBtn;
    public Button monsterKillBtn;

    public Image expBar;

    public TextMeshProUGUI playerGold;
    public TextMeshProUGUI playerLv;
    public TextMeshProUGUI playerExp;
    public TextMeshProUGUI playerDescribe;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerClass;


    private void Start()
    {
        inventoryBtn.onClick.RemoveAllListeners();
        statusBtn.onClick.RemoveAllListeners();
        monsterKillBtn.onClick.RemoveAllListeners();

        inventoryBtn.onClick.AddListener(OpenInventory);
        statusBtn.onClick.AddListener(OpenStatus);
        monsterKillBtn.onClick.AddListener(() => GameManager.Instance.MonsterKill()); 
    }

    private void OpenStatus()
    {
        UIManager.instance.uiStatus.gameObject.SetActive(true);

        inventoryBtn.gameObject.SetActive(false);
        statusBtn.gameObject.SetActive(false);
    }

    private void OpenInventory()
    {
        UIManager.instance.uiInventory.gameObject.SetActive(true);
        UIManager.instance.uiInventory.InitInventoryUI();

        inventoryBtn.gameObject.SetActive(false);
        statusBtn.gameObject.SetActive(false);
    }

   
    public void CharacterInfo(Character character)
    {
        expBar.fillAmount = (float)character.Exp / character.MaxExp;

        playerGold.text = $"{character.Gold}G";
        playerLv.text = $"{character.Level}";
        playerName.text = $"{character.PlayerName}";
        playerExp.text = $"{character.Exp}/{character.MaxExp}";
        playerDescribe.text = $"{character.Describe}";
        playerClass.text = $"{PlayerClass.Coder}"; //{character.PlayerClass}로 나중에 수정
    }

    
}
