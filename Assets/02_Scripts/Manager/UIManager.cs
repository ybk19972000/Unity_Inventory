using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] public UIInventory uiInventory;
    [SerializeField] public UIStatus uiStatus;
    [SerializeField] public UIMainMenu uiMainMenu;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
