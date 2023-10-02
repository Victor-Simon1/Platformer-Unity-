using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textLevel;

    public void SetMaxXp(int Xp)
    {
        slider.maxValue = Xp;
        slider.value = Xp;
    }
    public void SetLevel(int Xp,int maxXp)
    {
        slider.maxValue = maxXp;
        slider.value = Xp;
    }
    public void AddXp(int xp)
    {
        slider.value +=xp;
        Debug.Log("Xp");
    }
}
