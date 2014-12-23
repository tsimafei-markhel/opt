using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace opt.UI.Helpers
{
    internal static class LicenseValidator
    {
        private static string PassKey = "==GrgYRJHRBbr78787y87HRHJjhB=";
        private static string DateFormat = "yyyy-MM-dd";

        public static bool ValidateLicense(string licenseFilePath)
        {
            if (!File.Exists(licenseFilePath))
            {
                throw new ApplicationException("License file not found");
            }

            DateTime now = DateTime.Now;

            XmlDocument license = new XmlDocument();
            license.Load(licenseFilePath);

            string name;
            string startDate;
            string validTo;
            string lastStart;
            string fileSignature;
            try
            {
                name = license.ChildNodes[0].SelectSingleNode(@"/license/name", null).InnerText;
                startDate = license.ChildNodes[0].SelectSingleNode(@"/license/startDate", null).InnerText;
                validTo = license.ChildNodes[0].SelectSingleNode(@"/license/validTo", null).InnerText;
                lastStart = license.ChildNodes[0].SelectSingleNode(@"/license/lastStart", null).InnerText;
                fileSignature = license.ChildNodes[0].SelectSingleNode(@"/license/signature", null).InnerText;
            }
            catch (Exception)
            {
                throw new ApplicationException("Unregistered version");
            }

            DateTime start = DateTime.Parse(startDate);
            DateTime last = DateTime.Parse(lastStart);
            DateTime valid = DateTime.Parse(validTo);

            StringBuilder dataBuilder = new StringBuilder();
            dataBuilder.Append(name);
            dataBuilder.Append(start.ToString(DateFormat));
            dataBuilder.Append(valid.ToString(DateFormat));
            dataBuilder.Append(last.ToString(DateFormat));
            dataBuilder.Append(PassKey);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(dataBuilder.ToString());
            byte[] hash = md5.ComputeHash(data);
            string fileHash = Convert.ToBase64String(hash);
            
            // Проверим, не редактировался ли файл вручную
            if (fileHash != fileSignature)
            {
                throw new ApplicationException("Unregistered version");
            }

            // Часы переведены раньше старотвой даты
            if (now < start)
            {
                throw new ApplicationException("Unregistered version");
            }
            // Часы переведены раньше последнего запуска
            if (now < last)
            {
                throw new ApplicationException("Unregistered version");
            }
            // Срок действия лицензии истек
            if (now > valid)
            {
                throw new ApplicationException("Unregistered version");
            }

            // Обновим файл лицензии
            UpdateLicense(license, name, start, valid);
            try
            {
                license.Save(licenseFilePath);
            }
            catch (Exception)
            {
                throw new ApplicationException("Unregistered version");
            }

            return true;
        }

        private static void UpdateLicense(XmlDocument license, string name, DateTime startDate, DateTime validTo)
        {
            DateTime lastStart = DateTime.Now;

            StringBuilder dataBuilder = new StringBuilder();
            dataBuilder.Append(name);
            dataBuilder.Append(startDate.ToString(DateFormat));
            dataBuilder.Append(validTo.ToString(DateFormat));
            dataBuilder.Append(lastStart.ToString(DateFormat));
            dataBuilder.Append(PassKey);
            
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.UTF8.GetBytes(dataBuilder.ToString());
            byte[] hash = md5.ComputeHash(data);
            license.ChildNodes[0].SelectSingleNode(@"/license/lastStart", null).InnerText = lastStart.ToString(DateFormat);
            license.ChildNodes[0].SelectSingleNode(@"/license/signature", null).InnerText = Convert.ToBase64String(hash);
        }
    }
}