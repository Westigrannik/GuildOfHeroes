// Probe.Run();

Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);
Hero alexander = new Hero("Александр", 150);
Hero sergey = new Hero("Сергей", 110);

Guild guild = new Guild("Гильдия героев");

guild.AddHero(yaroslav);
guild.AddHero(anastasia);
guild.AddHero(artem);
guild.AddHero(alexander);
guild.AddHero(sergey);
List<Hero> members = guild.GetMembers();

Console.WriteLine($">>> {guild.Name}: перекличка <<<");
Console.WriteLine($"Участников: {guild.MemberCount}");

Console.WriteLine();
foreach (Hero hero in members)
{
    Console.WriteLine(hero.GetInfo());
    Console.WriteLine();
}

Console.WriteLine($"Могут нести тяжёлые ящики (здоровье от 120): {guild.CountHealthy(120)}");

Hero? strongest = guild.FindStrongest();
if (strongest != null) {
    Console.WriteLine($"Самый здоровый: {strongest.Name} ({strongest.Health})");
}

Hero? found = guild.FindHeroByName(" аРтЁм ");
if (found != null) {
    Console.WriteLine($"Найден по запросу « аРтЁм »: {found.Name}");
} else {
    Console.WriteLine("По запросу « аРтЁм » никого нет.");
}


Console.WriteLine($"Повтор Александра принят: {guild.AddHero(alexander)}");

Console.WriteLine($"Удалён отсутствующий: {guild.RemoveHero("Борис")}");
Console.WriteLine($"Участников после проверок: {guild.MemberCount}");