using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace OptLicGen
{
    class Program
    {
        private static string DateFormat = "yyyy-MM-dd";

        static void Main(string[] args)
        {
            string name = string.Empty;
            string startDate = DateTime.Now.ToString(DateFormat);
            string validTo = string.Empty;
            string lastStart = DateTime.Now.ToString(DateFormat);
            string passKey = "==GrgYRJHRBbr78787y87HRHJjhB=";

            if (args.GetLength(0) > 0)
            {
                CommandLineArgs parsedArgs = CommandLineArgs.Parse(args);
                if (parsedArgs != null)
                {
                    name = parsedArgs.Name;
                    validTo = parsedArgs.ValidTo;
                }
                else
                {
                    Console.WriteLine("Invalid command line arguments.");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Valid to (yyyy-mm-dd): ");
                validTo = Console.ReadLine();
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(@"<license>
            <name></name>
            <startDate></startDate>
            <validTo></validTo>
            <lastStart></lastStart>
            <signature></signature>
            </license>");
            doc.ChildNodes[0].SelectSingleNode(@"/license/name", null).InnerText = name;
            doc.ChildNodes[0].SelectSingleNode(@"/license/startDate", null).InnerText = startDate;
            doc.ChildNodes[0].SelectSingleNode(@"/license/validTo", null).InnerText = validTo;
            doc.ChildNodes[0].SelectSingleNode(@"/license/lastStart", null).InnerText = lastStart;

            MD5 md5 = new MD5CryptoServiceProvider();

            StringBuilder dataBuilder = new StringBuilder();
            dataBuilder.Append(name);
            dataBuilder.Append(startDate);
            dataBuilder.Append(validTo);
            dataBuilder.Append(lastStart);
            dataBuilder.Append(passKey);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(dataBuilder.ToString());
            byte[] hash = md5.ComputeHash(data);
            doc.ChildNodes[0].SelectSingleNode(@"/license/signature", null).InnerText = Convert.ToBase64String(hash);
            doc.Save("license.xml");

            Environment.Exit(0);
        }
    }
}