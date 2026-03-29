namespace OBP200_RolePlayingGame;

public interface IPlayerClass
{
    string Name { get; }
    int CalculateAttackDamage(Player player, int enemyDef, Random rng);
    int UseSpecial(Player player, int enemyDef, bool vsBoss, Random rng);
    bool TryRunAway(Random rng);
    void ApplyLevelUp(Player player);
}
