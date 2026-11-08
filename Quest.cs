public class Quest {
    public int Id { get; private set; }
    public string Title { get; private set; }
    public int MinHealth { get; private set; }
    public int Reward { get; private set; }
    public Hero? AssignedHero { get; private set; }
    public bool IsCompleted { get; private set; }

    public Quest(int id, string title, int minHealth, int reward) {
        Id = id;

        if (string.IsNullOrWhiteSpace(title)) {
            Title = "Безымянное поручение";
        } else {
            Title = title.Trim();
        }

        MinHealth = minHealth;
        if (MinHealth < 0) {
            MinHealth = 0;
        }

        Reward = reward;
        if (Reward < 1) {
            Reward = 1;
        }

        AssignedHero = null;
        IsCompleted = false;
    }


public bool TryAssign(Hero hero) {
    if (IsCompleted) {
        return false;
    }
    if (AssignedHero != null) {
        return false;
    }
    if (!hero.IsAlive()) {
        return false;
    }
    if (hero.Health < MinHealth) {
        return false;
    }

    AssignedHero = hero;
    return true;
}

public bool TryComplete() {
    if (IsCompleted) {
        return false;
    }

    Hero? hero = AssignedHero;
    if (hero == null) {
        return false;
    }
    if (!hero.IsAlive()) {
        return false;
    }
    if (hero.Health < MinHealth) {
        return false;
    }
    if (!hero.CanGainExperience(Reward)) {
        return false;
    }

    hero.GainExperience(Reward);
    IsCompleted = true;
    return true;
}

    public string GetInfo() {
        string text = "не назначен";
        if (AssignedHero != null) {
            text = AssignedHero.Name;
        }
        string textcomplete = "нет";
        if (IsCompleted) {
            textcomplete = "да";
        }

        return $"№{Id} «{Title}»: исполнитель {text}, выполнено: {textcomplete}";
    }


}