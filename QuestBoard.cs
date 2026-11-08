public class QuestBoard {
    private readonly Guild _guild;
    private readonly List<Quest> _quests = new List<Quest>();

    public QuestBoard(Guild guild) {
        _guild = guild;
    }

    public bool AddQuest(Quest quest) {
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

    return quest.TryAssign(hero);
}

public bool TryComplete(int questId) {
    Quest? quest = FindQuest(questId);
    if (quest == null) {
        return false;
    }
    return quest.TryComplete();
}

}

