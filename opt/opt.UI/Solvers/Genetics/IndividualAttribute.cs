using System;
using opt.DataModel;

namespace opt.Solvers.Genetics
{
    public class IndividualAttribute : ICloneable
    {
        private TId _id;
        
        private string _code;
        /// <summary>
        /// Код данного признака данной особи
        /// </summary>
        public string Code { get { return this._code; } set { _code = value; } }
        
        private double _value;
        /// <summary>
        /// Значение данного признака данной особи
        /// </summary>
        public double Value { get { return this._value; } set { this._value = value; } }

        private double _minValue;
        private double _maxValue;
        private int _decimalPlaces;
        
        private int _codeLength;
        /// <summary>
        /// Расчетная длина кода данного признака данной особи
        /// </summary>
        public int CodeLength { get { return this._codeLength; } set { this._codeLength = value; } }

        public IndividualAttribute(
            TId id,
            double minValue,
            double maxValue,
            int decimalPlaces)
        {
            this._id = id;
            this._minValue = minValue;
            this._maxValue = maxValue;
            this._decimalPlaces = decimalPlaces;

            this.CalcCodeLength(this.GetPrecision());
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        private IndividualAttribute(
            TId id,
            double minValue,
            double maxValue,
            double value,
            int decimalPlaces,
            string code,
            int codeLength)
        {
            this._id = id;
            this._minValue = minValue;
            this._maxValue = maxValue;
            this._value = value;
            this._decimalPlaces = decimalPlaces;
            this._code = code;
            this._codeLength = codeLength;
        }

        /// <summary>
        /// Метод, рассчитывающий точность (вида 0.01) на основе 
        /// требуемого количества знаков после запятой
        /// </summary>
        /// <returns>Точность</returns>
        private double GetPrecision()
        {
            return (1.0F / Math.Pow(10, (double)this._decimalPlaces));
        }

        /// <summary>
        /// Метод, рассчитывающий длину строки с генетическим 
        /// кодом
        /// </summary>
        /// <param name="precision">Требуемая точность (вида 0.01)</param>
        /// <returns>Длина строки с генетическим кодом</returns>
        private void CalcCodeLength(double precision)
        {
            this._codeLength = Convert.ToInt32(Math.Ceiling(
                Math.Log((this._maxValue - this._minValue) / precision, 2)
                ));
        }

        public void ResolveCodeFromValue()
        {
            double valToConvertD = 
                ((this._value - this._minValue) / (this._maxValue - this._minValue)) * (Math.Pow(2, this._codeLength) - 1);
            int valToConvert =
                Convert.ToInt32(Math.Round(valToConvertD, MidpointRounding.AwayFromZero));
            this._code = DecToBase(valToConvert, 2, this._codeLength);
        }

        public void ResolveValueFromCode()
        {
            int valToConvert = BaseToDec(this._code, 2);
            double valToConvertD = 
                ((valToConvert * (this._maxValue - this._minValue)) / (Math.Pow(2, this._codeLength) - 1)) + this._minValue;
            this._value = Math.Round(valToConvertD, this._decimalPlaces, MidpointRounding.AwayFromZero);
        }

        #region Binary routines

        private string DecToBase(int num_value, int base_value, int l)
        {
            var max_bit = l;
            var result = string.Empty;
            var result_array = new int[l];

            for (/* nothing */; num_value > 0; num_value /= base_value)
            {
                int i = num_value % base_value;
                result_array[--max_bit] = i;
            }

            for (int i = 0; i < result_array.Length; i++)
            {
                result += result_array[i].ToString();
            }

            return result;
        }

        private static int ToDecSymbol(char input)
        {
            if (input >= '0' && input <= '9')
                return (int)input - (int)'0';
            else if (input >= 'A' && input <= 'Z')
                return (int)input - (int)'A' + 10;
            else if (input >= 'a' && input <= 'z')
                return (int)input - (int)'a' + 36;
            else
                throw new FormatException("Illegal Input Character.");
        }

        public static int BaseToDec(string input, uint fromBase)
        {
            int[] values = new int[input.Length];
            int ctr = values.Length - 1;
            foreach (char c in input)
            {
                values[ctr--] = ToDecSymbol(c);
            }
            int result = (int)values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result += (int)(values[i] * Math.Pow(fromBase, i));
                if (result == int.MaxValue)
                    throw new OverflowException("The Input Number is to big, to be converted into an int.");
            }
            return result;
        }

        #endregion

        #region ICloneable Members

        public object  Clone()
        {
            return new IndividualAttribute(
                this._id,
                this._minValue,
                this._maxValue,
                this._value,
                this._decimalPlaces,
                this._code,
                this._codeLength);
        }

        #endregion
    }
}
