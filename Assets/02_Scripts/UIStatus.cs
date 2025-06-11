using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI attackTxt;
    public TextMeshProUGUI defTxt;
    public TextMeshProUGUI healthTxt;
    public TextMeshProUGUI criticalTxt;

    public Button invenBtn;
    public Button statusBtn;
    public Button backBtn;

    private void Start()
    {
        backBtn.onClick.RemoveAllListeners();

        backBtn.onClick.AddListener(OnStatusBackBtn);
    }


    public void OnStatusBackBtn()
    {
        CloseStatus();
    }

    private void CloseStatus()
    {
        this.gameObject.SetActive(false);

        invenBtn.gameObject.SetActive(true);
        statusBtn.gameObject.SetActive(true);
    }

    public void StatusInfo(Character character)
    {
        attackTxt.text = $"{character.Attack}";
        defTxt.text = $"{character.Defend}";
        healthTxt.text = $"{character.Health}";
        criticalTxt.text = $"{character.Critical}";
    }
}
