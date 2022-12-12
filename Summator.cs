using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_3_Final
{
    internal class Summator
    {
        private string[] _numbers;
        private string _shuffledLine = String.Empty;
        private string _sum = String.Empty;
        public Summator(string[] numbers)
        {
            _numbers = numbers;
        }

        public int Result => _sum.ToDecimal();

        public void Work()
        {
            Shuffle();
            CalculateSum();
        }

        private void CalculateSum()
        {
            for (int i = 1; i < _shuffledLine.Length; i+=3)
            {
                var a = _shuffledLine[i - 1];
                var b = _shuffledLine[i];
                var c = _shuffledLine[i + 1];
                _sum += new CellMachine().Cycle($"{a}xor{b}xor{c}");
            }
        }

        private void Shuffle()
        {
            _shuffledLine += _numbers[0][0];
            _shuffledLine += _numbers[1][0];
            _shuffledLine += '0';
            for (int i = 1; i < _numbers[0].Length; i++)
            {
                _shuffledLine += _numbers[0][i];
                _shuffledLine += _numbers[1][i];
                var a = _shuffledLine[_shuffledLine.Length - 5];
                var b = _shuffledLine[_shuffledLine.Length - 4];
                var c = _shuffledLine[_shuffledLine.Length - 3];
                _shuffledLine += new CellMachine().Cycle($"({a}xor{b})and{c}or{a}and{b}");
            }
        }
    }
}
