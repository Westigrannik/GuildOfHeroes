public class Guild {
    private List<Hero> _heroes = new List<Hero>();
    public string Name { get; private set; }
    public int MemberCount {
        get { return _heroes.Count; }
    }

    public Guild(string name) {
        Name = name;
    }

    public bool AddHero(Hero hero) {
    if (FindHeroByName(hero.Name) != null) {
        return false;
    }

    _heroes.Add(hero);
    return true;
    }

    public Hero? FindHeroByName(string name) {
    if (string.IsNullOrWhiteSpace(name)) {
        return null;
    }

    string searchName = name.Trim();

    foreach (Hero hero in _heroes) {
        if (string.Equals(hero.Name, searchName, StringComparison.OrdinalIgnoreCase)) {
            return hero;
        }
    }

    return null;
    }

    public bool RemoveHero(string name) {
    Hero? hero = FindHeroByName(name);
    if (hero == null) {
        return false;
    }
    return _heroes.Remove(hero);
    }

    public int CountHealthy(int minimum) {
        int cc = 0;
        foreach (Hero hero in _heroes) {
            if (hero.Health >= minimum) { cc++; }
        }
        return cc;
    }

    public Hero? FindStrongest(){
    if (_heroes.Count == 0) {
            return null;
        }
        Hero strong = _heroes[0];
        foreach (Hero hero in _heroes) {
            if (hero.Health > strong.Health) {
                strong = hero;
            }
        }
        return strong;
}

    public List<Hero> GetMembers() {
        List<Hero> result = new List<Hero>();
        foreach (Hero hero in _heroes) {
            result.Add(hero);
        }
        return result;
    }
}