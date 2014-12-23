using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using opt.DataModel;
using opt.DataModel.New;

// TODO: Remove SuppressMessage from GenerateSobolPoints once the class is fully implemented

namespace opt.Generators
{
    /// <summary>
    /// Implements parameter value generator using Sobol Quasirandom Numbers
    /// </summary>
    /// <remarks>
    /// <see cref="SobolQuasirandomGenerator.GenerateSobolPoints"/> method
    /// implementation is a slightly modified port of C program by S. Joe and F. Y. Kuo
    /// from http://web.maths.unsw.edu.au/~fkuo/sobol/
    /// </remarks>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
        Justification = "Sobol and Quasirandom are parts of algorithm name")]
    public class SobolQuasirandomGenerator : IParameterGenerator
    {
        // Pre-caching
        private static readonly double Log2 = Math.Log(2.0);
        private static readonly double Pow2_32 = Math.Pow(2.0, 32);

        /// <summary>
        /// Binary file to take initial direction numbers from. Format is as follows:
        ///     (record_1)(record_2)...(record_N)
        /// where (record_i) is
        ///     (uint32)(uint32)(set_of_uint32)
        /// - first (uint32) is the degree of the primitive polynomial
        /// - second (uint32) is the number representing the coefficients
        /// - (set_of_uint32) is the list of initial direction numbers
        /// in the following format:
        ///     (uint32_1)(uint32_2)...(uint32_M)
        /// where M == degree of the primitive polynomial
        /// </summary>
        /// <remarks>Embedded resource; Keep an eye on the file name and default
        /// assembly namespace</remarks>
        private const string DirectionNumbersFile = "opt.new-joe-kuo-6.21201.dat";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="valueCount"></param>
        /// <returns></returns>
        public IEnumerable<RealValueDictionary> GenerateParameterValues(ParameterDictionary parameters, Int32 valueCount)
        {
            // Type check. This generator is only applicable to ContinuousParameter
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates Sobol points based on graycode order
        /// </summary>
        /// <param name="pointsCount">Number of points</param>
        /// <param name="dimensionCount">Dimension</param>
        /// <returns>A 2-dimensional <see cref="Double"/> array, where
        /// result[i][j] = the jth component of the ith point, 
        /// with i indexed from 0 to <paramref name="pointsCount"/>-1 and 
        /// j indexed from 0 to <paramref name="dimensionCount"/>-1</returns>
        /// <remarks>For initial direction numbers file currently in use
        /// maximal value of <paramref name="dimensionCount"/> is 21201</remarks>
        [SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional",
            Justification = "In this case space is not wasted as each point always has two dimensions")]
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
            Justification = "Will be fixed once class is fully implemented")]
        private static double[,] GenerateSobolPoints(uint pointsCount, uint dimensionCount)
        {
            uint maxBitsCount = (uint)Math.Ceiling(Math.Log((double)pointsCount) / Log2);

            uint[] c = new uint[pointsCount];
            for (uint i = 0; i < pointsCount; i++)
            {
                c[i] = 1;
                uint value = i;
                while ((value & 1) != 0)
                {
                    value >>= 1;
                    c[i]++;
                }
            }

            double[,] result = new double[pointsCount, dimensionCount];

            uint[] dirNumbers = new uint[maxBitsCount + 1];
            for (int i = 1; i <= maxBitsCount; i++)
            {
                dirNumbers[i] = (uint)1 << (32 - i);
            }

            uint[] unscaledPoints = new uint[pointsCount];
            for (uint i = 1; i < pointsCount; i++)
            {
                unscaledPoints[i] = unscaledPoints[i - 1] ^ dirNumbers[c[i - 1]];
                result[i, 0] = (double)unscaledPoints[i] / Pow2_32;
            }

            using (Stream inFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DirectionNumbersFile))
            using (BinaryReader inFile = new BinaryReader(inFileStream))
            {
                for (uint j = 1; j < dimensionCount; j++)
                {
                    uint dirNumCount = inFile.ReadUInt32();
                    uint dirNumCoeffs = inFile.ReadUInt32();

                    uint initDirNumber;
                    for (uint i = 0; i <= dirNumCount; i++)
                    {
                        initDirNumber = inFile.ReadUInt32();
                        if (i > 0 && i <= maxBitsCount)
                        {
                            dirNumbers[i] = initDirNumber << ((int)(32 - i));
                        }
                    }

                    if (maxBitsCount > dirNumCount)
                    {
                        for (uint i = (dirNumCount + 1); i <= maxBitsCount; i++)
                        {
                            dirNumbers[i] = dirNumbers[i - dirNumCount] ^ (dirNumbers[i - dirNumCount] >> (int)dirNumCount);
                            for (int k = 1; k < dirNumCount; k++)
                            {
                                dirNumbers[i] ^= (((dirNumCoeffs >> (int)(dirNumCount - 1 - k)) & 1) * dirNumbers[i - k]);
                            }
                        }
                    }

                    for (uint i = 1; i < pointsCount; i++)
                    {
                        unscaledPoints[i] = unscaledPoints[i - 1] ^ dirNumbers[c[i - 1]];
                        result[i, j] = (double)unscaledPoints[i] / Pow2_32;
                    }
                }
            }

            return result;
        }
    }
}