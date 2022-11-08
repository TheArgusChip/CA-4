using DeleteConsole;
using System.Text.RegularExpressions;

namespace CA_3_Final
{
    internal class CellMachine
    {
        public int Cycle(string info)
        {
            int result;
            if (int.TryParse(info, out result))
            {
                return result;
            }

            if (info.Contains("not"))
            {
                return Cycle(info.Replace("not", "1xor"));
            }

            if (info.Contains('('))
            {
                var lastOpenIndex = -1;
                int firstClosed = -1;
                for (int i = 0; i < info.Length; i++)
                {
                    if (info[i] == '(')
                    {
                        lastOpenIndex = i;
                    }
                    else if (info[i] == ')')
                    {
                        firstClosed = i;
                        break;
                    }
                }

                var test1 = info.Substring(lastOpenIndex, firstClosed - lastOpenIndex + 1);
                var test2 = info.Substring(lastOpenIndex + 1, firstClosed - lastOpenIndex - 1);

                return Cycle(info.Replace(test1, Cycle(test2).ToString()));
            }

            foreach (var operation in Operations.LogicalOperations.Keys)
            {
                if (info.Contains(operation))
                {
                    Regex regex = new Regex($@"\d+{operation}\d+");

                    var test = regex.Replace(info, new Calculator(new Parser(regex.Matches(info)[0].Value)).ResultLine.ToString());
                    return Cycle(test);
                }
            }

            return 0;
        }
    }
}
