public class Quest {
    public int Id { get; private set; }
    public string Title { get; private set; }
    public int MinHealth { get; private set; }
    public int Reward { get; private set; }
    public Hero? AssignedHero { get; private set; }
    public QuestStatus Status { get; private set; }

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
        Status = QuestStatus.Open;
    }


public bool TryAssign(Hero hero) {
    if (Status != QuestStatus.Open) {
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
    Status = QuestStatus.Assigned;
    return true;
}

public bool TryComplete() {
    if (Status != QuestStatus.Assigned) {
        return false;
    }

    Hero? hero = AssignedHero;
    if (Status != QuestStatus.Assigned) {
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
    Status = QuestStatus.Completed;
    return true;
    }

    public bool TryCancel() {
    if (Status != QuestStatus.Open && Status != QuestStatus.Assigned) {
        return false;
    }

    Status = QuestStatus.Cancelled;
    return true;
}



    public string GetStatusText() {
    switch (Status) {
        case QuestStatus.Open:
            return "открыто";
        case QuestStatus.Assigned:
            return "назначено";
        case QuestStatus.Completed:
            return "выполнено";
        case QuestStatus.Cancelled:
            return "отменено";
        default:
            return "неизвестно";
    }
}

    public string GetInfo() {
    string heroText = "не назначен";
    if (AssignedHero != null) {
        heroText = AssignedHero.Name;
    }

    return $"№{Id} «{Title}»: {GetStatusText()}, исполнитель {heroText}";
}


}