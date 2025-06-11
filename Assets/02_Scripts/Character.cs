enum PlayerClass
{
    Coder = 1,
    Warrior,
    Mage,
    Thief,
    ChickenMaster
}
public class Character 
{
    public string PlayerName { get; private set; } = "Chad";
    public string Describe { get; private set; } = "";
    public float Exp { get; private set; } = 0f;
    public int Level { get; private set; } = 1;
    public int Gold { get; private set; } = 5000;
    public float MaxExp { get; private set; } = 0f;

    public float Attack { get; private set; } = 5f;
    public float Defend { get; private set; } = 5f;
    public float Health { get; private set; } = 50f; 
    public float MaxHealth { get; private set; } = 50f;
    public float Critical { get; private set; } = 10f;

    public Character()
    {
        PlayerName = "Youn";
        Level = 1;
        Gold = 500;
        Attack = 1;
        Defend = 1;
        Health = 10;
        Critical = 1;
        MaxExp = 1 * 10;
        Describe = "Init";
    }
    public Character(string playerName, int level, int gold, float attack, float defend, float health, float critical, string describe)
    {
        PlayerName = playerName;
        Level = level;
        Gold = gold;
        Attack = attack;
        Defend = defend;
        Health = health;
        MaxHealth = health; 
        Critical = critical;
        MaxExp = level * 10;
        Describe = describe;
    }
    
    public void KillReward(int goldReward,int expReward,float damageTaken)
    {
        Health -= damageTaken;
        Gold += goldReward;
        Exp += expReward;


        LevelUpCheck();
    }

    private void LevelUpCheck()
    {
        while (Exp >= MaxExp)
        {
            Exp -= MaxExp;
            Level++;
            MaxExp = Level * 10; 
            IncreaseStats(); 
        }
    }

    private void IncreaseStats()
    {
        MaxHealth += Level * 2 + 5;
        Health = MaxHealth;
        Attack += Level * 2 + 2;
        Defend += Level * 2 + 1;
        Critical += Level * 2 / 2;
    }
    public void UseItem(Item item)
    {
        if (item.Type != ItemType.Consumable) return; 

        Health += item.HP; 
        Attack += item.Damage; 
        Defend += item.Defend;
        Critical += item.Critical;
    }
}
