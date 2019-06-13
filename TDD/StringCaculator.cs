namespace StringCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringCalculator
    {
        private int position;
        private float sum;
        public List<string> allPossibility = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." };

        public string Add(string numbers)
        {
            string[] separator = null;
            this.sum = 0;
            this.position = 0;

            var validateNumber = this.ValidateNumbers(numbers);
            if (numbers != validateNumber)
            {
                return validateNumber;
            }

            if (numbers[0].ToString().Equals("/"))
            {
                return this.CustomNumber(numbers, separator);
            }

            return this.AddNumbersOnString(numbers, Separators.SupportSeparators);
        }

        public string CustomNumber(string numbers, string[] separator)
        {
            var separatorNumbers = numbers.Remove(0, 2).Split('\n');
            separator = new string[] { separatorNumbers[0] };

            if (separator.Contains(numbers[numbers.Length - 1].ToString()))
            {
                return "Number expected but EOF found.";
            }

            return this.AddNumbersOnString(numbers.Remove(0, separator[0].Length + 3), separator);
        }

        private string AddNumbersOnString(string numbers, string[] separators)
        {
            this.allPossibility.AddRange(separators);

            foreach (var number in numbers.Split(separators, StringSplitOptions.None))
            {
                if (string.Empty == number)
                {
                    return $"Number expected but '{numbers[this.position]}' found at position {this.position}.";
                }

                try
                {
                    this.AddNumber(number);
                    this.position += number.Length + 1;
                }
                catch (Exception)
                {
                    foreach (var charnumber in number)
                    {
                        if (!this.allPossibility.Contains(charnumber.ToString()))
                        {
                            return $"'{separators[0]}' expected but '{charnumber}' found at position {this.position}.";
                        }

                        this.position++;
                    }
                }
            }

            return (this.sum + "").Replace(",", ".");
        }

        public string ValidateNumbers(string numbers)
        {
            if (numbers == string.Empty)
            {
                return "0";
            }

            if (Separators.SupportSeparators.Contains(numbers[numbers.Length - 1].ToString()))
            {
                return "Number expected but EOF found.";
            }

            return numbers;
        }

        private void AddNumber(string number)
        {
            if (number.Contains(","))
            {
                throw new Exception();
            }

            var newNumber = number.Replace(".", ",");
            this.sum += float.Parse(newNumber);
        }
    }
}