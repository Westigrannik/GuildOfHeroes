public class QuestBoard {
    private readonly Guild _guild;
    private readonly List<Quest> _quests = new List<Quest>();

    public QuestBoard(Guild guild) {
        _guild = guild;
    }

    public bool AddQuest(Quest quest) {
        if (quest.Status != QuestStatus.Open) {
            return false;
        }
        if (FindQuest(quest.Id) != null) {
            return false;
        }
        _quests.Add(quest);
        return true;
    }

    public Quest? FindQuest(int questId) {
        foreach (Quest quest in _quests) {
            if (quest.Id == questId) {
                return quest;
            }
        }
        return null;
    }

    public bool TryAssign(int questId, string heroName) {
    Quest? quest = FindQuest(questId);
    if (quest == null) {
        return false;
    }

    Hero? hero = _guild.FindHeroByName(heroName);
    if (hero == null) {
        return false;
    }
    if (IsAssigned(hero)) {
    return false;
    }   
    return quest.TryAssign(hero);
}

    public bool TryComplete(int questId) {
    Quest? quest = FindQuest(questId);
    if (quest == null) {
        return false;
    }
    return quest.TryComplete();
}

    public bool IsAssigned(Hero hero) {
    foreach (Quest quest in _quests) {
        if (quest.Status == QuestStatus.Assigned && quest.AssignedHero == hero) {
            return true;
        }
    }
    

    return false;
}


    public bool TryCancel(int questId) {
    Quest? quest = FindQuest(questId);
    if (quest == null) {
        return false;
    }
    return quest.TryCancel();
}

public List<Quest> GetQuests() {
    return new List<Quest>(_quests);
}

public bool TryRemoveMember(string heroName) {
    Hero? hero = _guild.FindHeroByName(heroName);
    if (hero == null) {
        return false;
    }

    foreach (Quest quest in _quests) {
        if (quest.AssignedHero == hero) {
            return false;
        }
    }

    return _guild.RemoveHero(hero.Name);
}

public int CountByStatus(QuestStatus status) {
    int cc = 0;
        foreach (Quest quest in _quests) {
            if (quest.Status == status) { cc++; }
        }
        return cc;
}

public Quest? FindActiveQuest(string heroName) {
        Hero? hero = _guild.FindHeroByName(heroName);
        if (hero == null) {
            return null;
        }
        foreach (Quest quest in _quests) {
            if (quest.Status == QuestStatus.Assigned && quest.AssignedHero == hero) {
                return quest;
            }
        }
        return null;
    }
}

