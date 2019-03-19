using DAO;
using LogLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UtilsLibrary;

namespace LoginProject
{
    /// <summary>
    /// Class in charge to excecute the threads and sub-processes of the program
    /// </summary>
    class MainProcess
    {
        /// <summary>
        /// default path for the report files
        /// </summary>
        private static string writePath = "C:\\Users\\sarredondo\\source\\repos\\LoginProject\\LoginProject\\People\\";
       
        /// <summary>
        /// Returns user from a line in csv
        /// </summary>
        /// <param name="line"> The line you want to transform </param>
        /// <returns> The user object </returns>
        public static User LineToModel(string line)
        {
            line = FileUtils.changeCSV(line);
            string[] columns = line.Split(';');
            try
            {
                return new User
                {
                    Id = NumberUtils.ToInt(columns[0]),
                    Title = columns[1],
                    FirstName = columns[2],
                    MiddleName = columns[3],
                    LastName = columns[4],
                    Suffix = columns[5],
                    AddressLine1 = columns[6],
                    AddressLine2 = columns[7],
                    City = columns[8],
                    StateProvinceName = columns[9],
                    CountryRegionName = columns[10],
                    PostalCode = columns[11],
                    PhoneNumber = columns[12],
                    BirthDate = DateUtils.ToDate(columns[13]),
                    Education = columns[14],
                    Occupation = columns[15],
                    Gender = columns[16],
                    MaritalStatus = columns[17],
                    HomeOwnerFlag = NumberUtils.ToInt(columns[18]),
                    NumberCarsOwned = NumberUtils.ToInt(columns[19]),
                    NumberChildrenAtHome = NumberUtils.ToInt(columns[20]),
                    TotalChildren = NumberUtils.ToInt(columns[21]),
                    YearlyIncome = NumberUtils.ToInt(columns[22])
                };
            }
            catch
            {
                Log.showErrorMessage("Can't convert the line to a model");
                throw new Exception("Can't convert the line to a model");
            }
        }

        /// <summary>
        /// Reads, inserts and create reports for each register in the file
        /// </summary>
        /// <param name="filePath"> file you wnat to read </param>
        public static void ReadFile(string filePath, List<bool> checkList)
        {
            int count = 1;
            try
            {
                foreach (string line in File.ReadLines(filePath, Encoding.UTF8))
                {
                    try
                    {
                        if (count != 1)
                        {
                            try
                            {
                                User currentUser = LineToModel(line);
                                DateTime currentUserBirthdate = currentUser.BirthDate.Value;
                                if (checkList[0])
                                {
                                    Thread thread1 = new Thread(() => InsertDB.Excecute(currentUser));
                                    thread1.Start();
                                }
                                if (checkList[1])
                                {
                                    Thread thread2 = new Thread(() => ReportLibrary.Report.GenerateReport(writePath + currentUser.Id + ".csv", currentUser.GetUserInfo()));
                                    thread2.Start();
                                }
                                if (checkList[2])
                                {
                                    Thread thread3 = new Thread(() => Log.showInformationMessage("User: (id:" + currentUser.Id + ",age:" + DateUtils.CalculateAge(currentUserBirthdate) + ")"));
                                    thread3.Start();
                                }
                            }
                            catch (Exception processException)
                            {
                                Log.showErrorMessage("Error excecuting the processes: " + processException.ToString());
                            }
                        }
                    }
                    catch
                    {
                        Log.showErrorMessage("Error reading line: " + count);
                    }
                    count++;
                }
            }
            catch
            {
                Log.showErrorMessage("Can´t read correctly the file: " + filePath);
            }
        }
    }
}
