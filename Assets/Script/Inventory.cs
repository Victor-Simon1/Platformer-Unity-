using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountText;
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null) Debug.LogWarning("Plusieurs inventaire");
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount+= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
       coinsCountText.text = coinsCount.ToString();
    }
}
