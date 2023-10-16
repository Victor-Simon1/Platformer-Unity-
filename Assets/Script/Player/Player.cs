using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    private bool isInvisible;
    public HealthBar healthBar;
    public SpriteRenderer graphics;
    private float invicibilityFlashTime = 0.2f;


    public static Player instance;
    public int level;
    public int currentXp;
    public int maxXp;
    public XpBar xpBar;

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("Already have PlayerHealthScript");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentXp = 0;
        maxXp = 100;
        xpBar.SetLevel(currentXp,maxXp,level);
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }*/
    }

    public void TakeDamage(int damage)
    {
        if(!isInvisible)
        {
            health -=damage;
            healthBar.SetHealth(health);
            isInvisible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());
        }
        
    }
    
    public void HealPlayer(int amount)
    {
        if(health+amount>maxHealth) health= maxHealth;
        else health+= amount;
        healthBar.SetHealth(health);
    }
    public IEnumerator InvincibilityFlash()
    {
        while(isInvisible)
        {
            graphics.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(invicibilityFlashTime);
            graphics.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(invicibilityFlashTime);
        }
        
    }

     public IEnumerator InvincibilityDelay()
     {
        yield return new WaitForSeconds(3f);
        isInvisible = false;
     }

    public void PassLevel()
    {
        level++;
        currentXp -= maxXp;
        maxXp = maxXp + (int)(0.2f*maxXp);
        xpBar.SetLevel(currentXp,maxXp,level);
    }

    public void AddXp(int xp)
    {
        currentXp += xp;
        if(currentXp>=maxXp)PassLevel();
        else xpBar.AddXp(xp);
    }
}
