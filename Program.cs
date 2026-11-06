Hero yaroslav = new Hero("Ярослав", 100);
Hero anastasia = new Hero("Анастасия", 90);
Hero artem = new Hero("Артём", 120);


Console.WriteLine(">>> Герой 1 <<<");
Console.WriteLine($"Имя: {yaroslav.Name}");
Console.WriteLine($"Здоровье: {yaroslav.Health}");
Console.WriteLine($"Уровень: {yaroslav.Level}");
Console.WriteLine($"Опыт: {yaroslav.Experience}");

Console.WriteLine();

Console.WriteLine(">>> Герой 2 <<<");
Console.WriteLine($"Имя: {anastasia.Name}");
Console.WriteLine($"Здоровье: {anastasia.Health}");
Console.WriteLine($"Уровень: {anastasia.Level}");
Console.WriteLine($"Опыт: {anastasia.Experience}");

Console.WriteLine();

Console.WriteLine(">>> Герой 3 <<<");
Console.WriteLine($"Имя: {artem.Name}");
Console.WriteLine($"Здоровье: {artem.Health}");
Console.WriteLine($"Уровень: {artem.Level}");
Console.WriteLine($"Опыт: {artem.Experience}");

Console.WriteLine($"До вызовов: {yaroslav.Health}, {anastasia.Health}, {artem.Health}");

yaroslav.TakeDamage(25); // Такое чувство, что в задании должен стоять -25, потому что тут всё идёт нормально. Но если бы оно было всё же -25, то оно не меняет здоровье, потому что не проходит проверку
anastasia.TakeDamage(30);

Console.WriteLine($"После вызовов: {yaroslav.Health}, {anastasia.Health}, {artem.Health}");

// ||||||||||||

yaroslav.TakeDamage(-20);
Console.WriteLine($"После неверного урона: {yaroslav.Health}");

artem.TakeDamage(200);
Console.WriteLine($"После сильного урона, Артём: {artem.Health}");
// ||||||||||||

yaroslav.Heal(10);
yaroslav.GainExperience(40);
yaroslav.GainExperience(25);

Console.WriteLine($"После лечения, Ярослав: {yaroslav.Health}");
Console.WriteLine($"Опыт Ярослава: {yaroslav.Experience}");
// ||||||||||||

bool yaroslavAlive = yaroslav.IsAlive();
Console.WriteLine($"Ярослав жив: {yaroslavAlive}");
Console.WriteLine($"Артём жив: {artem.IsAlive()}");

if (yaroslavAlive) {
    Console.WriteLine("Ярослав может продолжать приключение.");
} else {
    Console.WriteLine("Ярослав больше не может сражаться.");
}

Console.WriteLine(yaroslav.GetInfo()); // Я тут исправил
Console.WriteLine();                   // Не пойму только, о чём в 3 задании говорится, может про условие? или...?
Console.WriteLine(anastasia.GetInfo()); 
Console.WriteLine();
Console.WriteLine(artem.GetInfo());