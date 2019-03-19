using LogLibrary;
using System;
using System.Collections.Generic;

namespace LoginProject
{
    class MainMenu
    {
        /// <summary>
        /// Displays and capture the data of the user
        /// </summary>
        private static List<bool> GetCheckList()
        {
            List<bool> checkList = new List<bool>();
            Log.showInformationMessage("--APP STARTED--");
            Console.WriteLine("Wellcome! ");
            bool option1 = GetOption("Do you want to insert into the DB?");
            checkList.Add(option1);
            bool option2 = GetOption("Do you want to store files?");
            checkList.Add(option2);
            bool option3 = GetOption("Do you want to show log?");
            checkList.Add(option3);
            return checkList;
        }

        /// <summary>
        /// Cptures the (Y/N) answer from a message
        /// </summary>
        /// <param name="message"> the message you want to show on console </param>
        /// <returns> the (Y/N) answer in boolean </returns>
        private static bool GetOption(string message)
        {
            string answer = "";
            do
            {
                Console.WriteLine(message + "\n" + "(Y/N)");
                answer = Console.ReadLine();
            }
            while (!"YyNn".Contains(answer) && !answer.Equals(""));
            return "Yy".Contains(answer);
        }

        /// <summary>
        /// Shows a wellcome message on console
        /// </summary>
        private static void DisplayWellcomeMessage()
        {
            Console.WriteLine("App Started");
            Log.showInformationMessage("--APP START--");
        }

        /// <summary>
        /// Show the messages and captures the (YES/NO) answer for the main procces
        /// </summary>
        public static void ShowMenu()
        {
            try
            {
                string path = "C:\\Users\\sarredondo\\Desktop\\ThreadData.csv";
                Log.showInformationMessage("Reading file: " + path);
                List<bool> checklist = GetCheckList();
                MainProcess.ReadFile("C:\\Users\\sarredondo\\Desktop\\ThreadData.csv", checklist);
                Log.showInformationMessage("user(s) was correctly inserted");
            }
            catch
            {
                Log.showErrorMessage("Error, the program can´t insert correctly the user");
            }
            Log.showInformationMessage("--APP END--");
            Console.ReadLine();
        }
    }
}
