public class Hero
{
    public string Name;
    public int Health;
    public int Level;
    public int Experience;


    public Hero(string name, int health) {
        Name = name;
        Health = health;
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
    Health += amount;
    }

    public void GainExperience(int amount) {
    if (amount <= 0) {
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