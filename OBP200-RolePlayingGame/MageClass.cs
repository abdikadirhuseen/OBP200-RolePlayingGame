namespace OBP200_RolePlayingGame;

public class MageClass : IPlayerClass
{
    public string Name => "Mage";

    public int CalculateAttackDamage(Player player, int enemyDef, Random rng)
    {
        int baseDmg = Math.Max(1, player.Attack - (enemyDef / 2));
        int roll = rng.Next(0, 3);
        baseDmg += 2;
        return Math.Max(1, baseDmg + roll);
    }

    public int UseSpecial(Player player, int enemyDef, bool vsBoss, Random rng)
    {
        int dmg = 0;

        if (player.Gold >= 3)
        {
            Console.WriteLine("Mage kastar Fireball!");
            player.SpendGold(3);
            dmg = Math.Max(3, player.Attack + 5 - (enemyDef / 2));
        }
        else
        {
            Console.WriteLine("Inte tillräckligt med guld för att kasta Fireball (kostar 3).");
        }

        if (vsBoss)
        {
            dmg = (int)Math.Round(dmg * 0.8);
        }

        return Math.Max(0, dmg);
    }

    public bool TryRunAway(Random rng)
    {
        return rng.NextDouble() < 0.35;
    }

    public void ApplyLevelUp(Player player)
    {
        player.IncreaseMaxHP(4);
        player.IncreaseAttack(4);
        player.IncreaseDefense(1);
    }
}