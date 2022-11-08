//using DeleteConsole;

//Console.WriteLine("Введите операцию: ");

//string operation = Console.ReadLine();

//var parser = new Parser(operation);

//var cyclebuilder = new Calculator(parser);

//Console.Write(cyclebuilder.ResultLine.ToDecimal());

using CA_3_Final;

var cellMachine = new CellMachine();

string input = Console.ReadLine();

var result = cellMachine.Cycle(input);

Console.Write(result);