using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level;
    public int currentXp;
    public int maxXp;
    public XpBar xpBar;
    // Start is called before the first frame update
    void Start()
    {
        currentXp = 0;
        maxXp = 100;
        xpBar.SetLevel(currentXp,maxXp);
    }

   public void PassLevel()
   {
        level++;
        currentXp -= maxXp;
        maxXp = maxXp + (int)(0.2f*maxXp);
        xpBar.SetLevel(currentXp,maxXp);
   }

   public void AddXp(int xp)
   {
        Debug.Log("Xp");
        currentXp += xp;
        if(currentXp>=maxXp)PassLevel();
        else xpBar.AddXp(xp);
   }
}
