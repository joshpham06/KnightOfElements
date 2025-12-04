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
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setHealth(100);
        setAttackDmg(25);
        setMagicType(1);
        setMagicDmg(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return this.health;
    }

    public void setAttackDmg(int dmg)
    {
        this.attackDmg = dmg;
    }

    public int getAttackDmg()
    {
        return this.attackDmg;
    }

    public void setMagicDmg(int dmg)
    {
        this.magicDmg = dmg;
    }

    public int getMagicDmg()
    {
        return this.magicDmg;
    }

    public void setMagicType(int type)
    {
        this.magicType = type;
    }

    public int getMagicType()
    {
        return this.magicType;
    }
}
