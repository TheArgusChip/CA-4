namespace DeleteConsole
{
    internal class Calculator
    {
        private int[] _startLine;
        private string _rule;

        public Calculator(Parser settings)
        {
            _startLine = settings.FirstLine.Select(symbol => int.Parse(symbol.ToString())).ToArray();
            _rule = settings.Rule;
        }

        public int ResultLine
        {
            get
            {
                var ruled = FillValuesWithRules(new int[_startLine.Length]);

                var result = new int[ruled.Length / 2];
                for (int i = 1, counter = 0; i < ruled.Length; i += 2)
                {
                    result[counter++] = ruled[i];
                }

                return String.Join(null, result).ToDecimal();
            }
        }

        private int[] FillValuesWithRules(int[] result)
        {
            for (int i = 1; i < _startLine.Length - 1; i++)
            {
                result[i] = CalculateCurrentCell(i);
            }

            return result;
        }

        private int CalculateCurrentCell(int i)
        {
            int multiplier = 4;
            int ruleIndex = 0;
            for (int t = i - 1; t < i + 2; t++)
            {
                ruleIndex += _startLine[t] * multiplier;
                multiplier /= 2;
            }

            return Convert.ToInt32(_rule[ruleIndex].ToString());
        }
    }
}
