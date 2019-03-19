namespace UtilsLibrary
{
    public class FileUtils
    {

        /// <summary>
        /// Returns a splitable line for the cvs format
        /// </summary>
        /// <param name="line"> The line you want to transform </param>
        /// <returns> A line with ';' separator instead ',' </returns>
        public static string changeCSV(string linea)
        {
            string newLine = "";
            char current;
            bool mark = false;
            bool print;
            for (int i = 0; i < linea.Length; i++)
            {
                print = true;
                current = linea[i];
                if (current == '$')
                    print = false;
                if (current == ',' && mark == false)
                    current = ';';
                if (current == '"')
                    mark = !mark;
                if (print == true)
                    newLine += current;
            }
            return newLine;
        }

    }
}
