
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance!= null)
        {
            Debug.Log("Plusieurs LoadAndSave");
            return;
        }
        instance = this;
    }

    void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("coins",Inventory.instance.coinsCount);
        if(CurrentSceneManager.instance.levelToUnlock >PlayerPrefs.GetInt("levelReached",1))
            PlayerPrefs.SetInt("levelReached",CurrentSceneManager.instance.levelToUnlock);
        PlayerPrefs.SetInt("playerHealth",PlayerHealth.instance.health);
    }

    public void LoadData()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coins",0);
        Inventory.instance.UpdateTextUI();

       /* int currentHealth = PlayerPrefs.GetInt("playerHealth",PlayerHealth.instance.health);
        PlayerHealth.instance.health = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/
    }


}
