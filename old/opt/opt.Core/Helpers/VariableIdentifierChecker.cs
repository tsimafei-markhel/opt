using System.Text.RegularExpressions;

// TODO: Fix comments
// TODO: Is it a right place for validation?.. Maybe move to data model?

namespace opt.Helpers
{
    public static class VariableIdentifierChecker
    {
        private static readonly Regex AllowedCharsRegex = new Regex("^[a-zA-Z]+[\\w]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
        private const string RestrictedListRegexFormat = "[,]({0})[,]";

        /// <summary>
        /// Метод для проверки идентификатора переменной на валидность
        /// </summary>
        /// <param name="varIdentifier">Идентификатор переменной, который надо проверить</param>
        /// <returns>True, если идентификатор состоит только из латинских больших 
        /// и маленьких букв</returns>
        public static bool RegExCheck(string varIdentifier)
        {
            return AllowedCharsRegex.IsMatch(varIdentifier);
        }

        /// <summary>
        /// Метод для проверки вхождения идентификатора переменной в список запрещенных 
        /// идентификаторов
        /// </summary>
        /// <param name="varIdentifier">Идентификатор для проверки</param>
        /// <param name="restrictedList">Строка, содержащая список запрещенных идентификаторов</param>
        /// <returns>True если идентификатор находится в списке</returns>
        public static bool IsInRestrictedList(string varIdentifier, string restrictedList)
        {
            Regex restrictedListRegex = new Regex(string.Format(RestrictedListRegexFormat, varIdentifier), RegexOptions.CultureInvariant | RegexOptions.Singleline);
            return restrictedListRegex.IsMatch(restrictedList);
        }
    }
}