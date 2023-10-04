using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    private bool isInvisible;
    public HealthBar healthBar;
    public SpriteRenderer graphics;
    private float invicibilityFlashTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isInvisible)
        {
            health -=20;
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
}
