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
    public void SetLevel(int Xp,int maxXp,int level)
    {
        slider.maxValue = maxXp;
        slider.value = Xp;
        textLevel.text = level.ToString();
    }
    public void AddXp(int xp)
    {
        slider.value +=xp;
    }
}
