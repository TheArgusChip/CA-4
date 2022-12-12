using CA_3_Final;

string input = Console.ReadLine();

var numbers = input.Split("+").Select(number => number.ToEightBitBinary()).ToArray();

var summator = new Summator(numbers);
summator.Work();

Console.WriteLine(summator.Result);