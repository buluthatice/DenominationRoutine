
var ammountArray = new int[9] { 30, 50, 60, 80, 140, 230, 370, 610, 980 };
Console.WriteLine($"************************WELCOME************************");

foreach (var item in ammountArray)
{
    Console.WriteLine($"-------------{item}-----------------");
    WritePossiblePayment(item);
}
Console.WriteLine($"************************END************************");
Console.ReadKey();

void WritePossiblePayment(int amount)
{
    int mod100 = 0;
    int count100 = CalculateUnitCount(amount, 100, ref mod100);
    int mod50 = 0;
    int count50 = CalculateUnitCount(mod100, 50, ref mod50);
    int mod10 = 0;
    int count10 = CalculateUnitCount(mod50, 10, ref mod10);
    WriteToConsole(count10, count50, count100);

    int _count100 = count100; int _count50 = count50; int _count10 = count10;
    for (int i = count100; i > 0; i--)
    {
        _count100--;
        _count50 += +2;
        WriteToConsole(_count10, _count50, _count100);
    }
    count50 = _count50;
    for (int j = count50; j > 0; j--)
    {
        _count50--;
        _count10 += +5;
        WriteToConsole(_count10, _count50, _count100);
    }
}

int CalculateUnitCount(int payout, int unit, ref int mod)
{
    int div = payout / unit;
    mod = payout % unit;

    return div;
}

void WriteToConsole(int count10, int count50, int count100)
{
    string combination = "";
    bool plusFlag = false;
    if (count10 > 0)
    {
        combination += $"{count10} x 10 EUR";
        plusFlag = true;
    }
    if (count50 > 0)
    {
        combination += plusFlag ? " + " : "";
        combination += $"{count50} x 50 EUR";
        plusFlag = true;
    }
    if (count100 > 0)
    {
        combination += plusFlag ? " + " : "";
        combination += $"{count100} x 100 EUR";
    }

    Console.WriteLine(combination);
}