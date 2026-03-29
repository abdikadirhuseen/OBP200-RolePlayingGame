
namespace OBP200_RolePlayingGame;

public class Player
{
    public string Name { get; private set; }
    public IPlayerClass PlayerClass { get; private set; }
    public string Class => PlayerClass.Name;

    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }

    public int Gold { get; private set; }
    public int XP { get; private set; }
    public int Level { get; private set; }
    public int Potions { get; private set; }

    public string Inventory { get; private set; }

    public Player(string name, IPlayerClass playerClass, int hp, int maxhp, int atk, int def, int gold, int potions)
    {
        Name = name;
        PlayerClass = playerClass;
        HP = hp;
        MaxHP = maxhp;
        Attack = atk;
        Defense = def;
        Gold = gold;
        XP = 0;
        Level = 1;
        Potions = potions;
        Inventory = "Wooden Sword;Cloth Armor";
    }

    public void TakeDamage(int dmg)
    {
        HP = Math.Max(0, HP - Math.Max(0, dmg));
    }

    public void Heal(int amount)
    {
        HP = Math.Min(MaxHP, HP + Math.Max(0, amount));
    }

    public void FullHeal()
    {
        HP = MaxHP;
    }

    public void AddGold(int amount)
    {
        Gold += Math.Max(0, amount);
    }

    public void SpendGold(int amount)
    {
        Gold = Math.Max(0, Gold - Math.Max(0, amount));
    }

    public void AddXP(int amount)
    {
        XP += Math.Max(0, amount);
    }

    public bool UsePotion(out int healedAmount)
    {
        healedAmount = 0;

        if (Potions <= 0)
        {
            return false;
        }

        int before = HP;
        Potions--;
        Heal(12);
        healedAmount = HP - before;
        return true;
    }

    public void AddPotion(int amount)
    {
        Potions += Math.Max(0, amount);
    }

    public void IncreaseAttack(int amount)
    {
        Attack += Math.Max(0, amount);
    }

    public void IncreaseDefense(int amount)
    {
        Defense += Math.Max(0, amount);
    }

    public void IncreaseMaxHP(int amount)
    {
        MaxHP += Math.Max(0, amount);

        if (HP > MaxHP)
        {
            HP = MaxHP;
        }
    }

    public void LevelUp()
    {
        Level++;
    }

    public void AddInventoryItem(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            return;
        }

        Inventory = string.IsNullOrWhiteSpace(Inventory) ? item : $"{Inventory};{item}";
    }

    public List<string> GetInventoryItems()
    {
        if (string.IsNullOrWhiteSpace(Inventory))
        {
            return new List<string>();
        }

        return Inventory
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();
    }

    public void SetInventoryItems(IEnumerable<string> items)
    {
        var cleaned = items
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Trim())
            .ToList();

        Inventory = cleaned.Count == 0 ? "" : string.Join(";", cleaned);
    }
}