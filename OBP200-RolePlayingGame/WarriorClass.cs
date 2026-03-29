namespace OBP200_RolePlayingGame;

public class WarriorClass : IPlayerClass
{
    public string Name => "Warrior";

    public int CalculateAttackDamage(Player player, int enemyDef, Random rng)
    {
        int baseDmg = Math.Max(1, player.Attack - (enemyDef / 2));
        int roll = rng.Next(0, 3);
        baseDmg += 1;
        return Math.Max(1, baseDmg + roll);
    }

    public int UseSpecial(Player player, int enemyDef, bool vsBoss, Random rng)
    {
        Console.WriteLine("Warrior använder Heavy Strike!");
        int dmg = Math.Max(2, player.Attack + 3 - enemyDef);
        player.TakeDamage(2);

        if (vsBoss)
        {
            dmg = (int)Math.Round(dmg * 0.8);
        }

        return Math.Max(0, dmg);
    }

    public bool TryRunAway(Random rng)
    {
        return rng.NextDouble() < 0.25;
    }

    public void ApplyLevelUp(Player player)
    {
        player.IncreaseMaxHP(6);
        player.IncreaseAttack(2);
        player.IncreaseDefense(2);
    }
}