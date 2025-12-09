using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    private int health;
    private int attackDmg;
    private int magicType;
    //1 = fire
    //2 = lightning
    //3 = earth
    //4 = Air
    //5 = Water
    private int magicDmg;
    private int score = 0; 
    
    
    private void Update()
    {

        if (health <= 0)
        {
            KillPlayer(); 
        }
        
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetHealth(100);
        SetAttackDmg(25);
        SetMagicType(1);
        SetMagicDmg(5);
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void AddHealth(int health)
    {
        this.health += health;
        if (this.health > 100) 
        { 
            this.health = 100;
        }
    }

    public void LoseHealth(int health)
    {
        this.health -= health;
        if (this.health <= 0)
        {
            this.health = 0;
        }
    }

    public int GetHealth()
    {
        return this.health;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void SetAttackDmg(int dmg)
    {
        this.attackDmg = dmg;
    }

    public int GetAttackDmg()
    {
        return this.attackDmg;
    }

    public void SetMagicDmg(int dmg)
    {
        this.magicDmg = dmg;
    }

    public int GetMagicDmg()
    {
        return this.magicDmg;
    }

    public void SetMagicType(int type)
    {
        this.magicType = type;
    }

    public int GetMagicType()
    {
        return this.magicType;
    }

    private void KillPlayer()
    {
        this.gameObject.SetActive(false);
        //trigger game over screen 
        
    }
    
    
}
