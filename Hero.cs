public class Hero
{
    private string _name = "Безымянный герой";
    public string Name {
        get {
        return _name;
    }
        private set {
        if (string.IsNullOrWhiteSpace(value)) {
            _name = "Безымянный герой";
            return;
        }
        _name = value.Trim();
    }
}

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }


    public Hero(string name, int health) {
    Name = name;
    MaxHealth = health;
    if (MaxHealth <= 0) {
        MaxHealth = 100;
    }
    if (MaxHealth > 200) {
        MaxHealth = 200;
    }
    Health = health;
    if (Health < 0) {
        Health = 0;
    }
    if (Health > MaxHealth) {
        Health = MaxHealth;
    }
    Level = 1;
    Experience = 0;
}

    public void TakeDamage(int damage) {
    if (damage <= 0) {
        return;
    }
    Health -= damage;
    if (Health < 0) {
        Health = 0;
        }
    }

    public void Heal(int amount) {
    if (amount <= 0) {
        return;
    }
    int missingHealth = MaxHealth - Health;
    if (amount >= missingHealth) {
        Health = MaxHealth;
        return;
    }
    Health += amount;
}

   public void GainExperience(int amount) {
    if (amount <= 0) {
        return;
    }
    if (amount > 2147483647 - Experience) {
        return;
    }
    Experience += amount;
}

    public bool IsAlive() {
    return Health > 0; // Если хп больше 0, то оно говорит true (герой жив), либо false, если мёртв. В отличии от takedamage тут пишется да или нет
    }

    public string GetInfo() {
    return $">>> {Name} <<<\n" +
           $"Здоровье: {Health}\n" +
           $"Уровень: {Level}\n" +
           $"Опыт: {Experience}";
    }
}