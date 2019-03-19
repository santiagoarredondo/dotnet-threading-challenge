using LogLibrary;
using System;

namespace UtilsLibrary
{
    public class DateUtils
    {

        /// <summary>
        /// Parse a string in format ("YY/MM/DD") into a date showing log messages
        /// </summary>
        /// <param name="field"> the string you want to transform </param>
        /// <returns> a DateTime value </returns>
        public static DateTime ToDate(string field)
        {
            if (String.IsNullOrEmpty(field))
            {
                throw new Exception("Date is null or an empty String");
            }
            DateTime date = new DateTime();
            try
            {
                string[] fields = field.Split('/');
                date = new DateTime(NumberUtils.ToInt(fields[2]), NumberUtils.ToInt(fields[0]), NumberUtils.ToInt(fields[1]));
            }
            catch
            {
                Log.showErrorMessage("Date can´t be readed: " + field);
                throw new Exception("Date can´t be readed");
            }
            return date;
        }

        /// <summary>
        /// Calculate the age from a birthdate
        /// </summary>
        /// <param name="birthDate"> the date you want to calculate the age </param>
        /// <returns> the age </returns>
        public static int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
                age--;
            return age;
        }

        /// <summary>
        /// Returns the UTC time format for a date 
        /// </summary>
        /// <param name="dateTime"> Date you want to transform </param>
        /// <returns> String UTC date </returns>
        public static string ToUTC(DateTime dateTime)
        {
            DateTime utcDate = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            return $"{utcDate} {utcDate.Kind}";
        }

    }
}
