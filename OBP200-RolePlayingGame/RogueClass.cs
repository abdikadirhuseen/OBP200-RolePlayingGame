namespace OBP200_RolePlayingGame;

public class RogueClass : IPlayerClass
{
    public string Name => "Rogue";

    public int CalculateAttackDamage(Player player, int enemyDef, Random rng)
    {
        int baseDmg = Math.Max(1, player.Attack - (enemyDef / 2));
        int roll = rng.Next(0, 3);
        baseDmg += (rng.NextDouble() < 0.2) ? 4 : 0;
        return Math.Max(1, baseDmg + roll);
    }

    public int UseSpecial(Player player, int enemyDef, bool vsBoss, Random rng)
    {
        int dmg;

        if (rng.NextDouble() < 0.5)
        {
            Console.WriteLine("Rogue utför en lyckad Backstab!");
            dmg = Math.Max(4, player.Attack + 6);
        }
        else
        {
            Console.WriteLine("Backstab misslyckades!");
            dmg = 1;
        }

        if (vsBoss)
        {
            dmg = (int)Math.Round(dmg * 0.8);
        }

        return Math.Max(0, dmg);
    }

    public bool TryRunAway(Random rng)
    {
        return rng.NextDouble() < 0.5;
    }

    public void ApplyLevelUp(Player player)
    {
        player.IncreaseMaxHP(5);
        player.IncreaseAttack(3);
        player.IncreaseDefense(1);
    }
}