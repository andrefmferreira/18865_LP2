/*
 * ********************************************************************************
 * <copyright file = "Program.cs"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>25-03-2020</date>
 * <description>This application will manage people on a probable pandemic virus infection, fowarding the subject to specific care, if needed</description>
 * ********************************************************************************
 */

using AF_IPCA.PandemicApp.BL;
using System;
using System.IO;

/// <summary>
/// This is the mainspace of this application. The frondend
/// </summary>
namespace AF_IPCA.PandemicApp.ConsoleApp
{
    /// <summary>
    /// Main class. Here is the main procedure.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main procedure. Will run allways
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            /**********************************************************************************************************************************************
            * This program has the goal of managing people in a pandemic health situation.
            * It will be responsible to register a person, who is sick, mentioned from now as sick person, or patient, and will also record information
            * of contact of this person as an emergency contact person also.
            * It has the purpose to locate the sick person in a given hospital, but the user can also add one if the right hospital is not in the database.
            * After the treatment, the user may give a medical discharge to the sick person, being recorded also the date of this discharge.
            *
            * The program also keeps track of the current number of registed person, infected or recovered.
            ***********************************************************************************************************************************************/

            /**********************************************************************************************************************************************
            * On boot, this part will load into memmory all the stored data (sick persons, diseases portfolio and hospital information).
            * This is not ideal, as the data grows, more and more space in memmory will be needed. As so, in the future, a better and more efficient
            * solution will be implemented, such as query the files to get the information, when needed.
            ***********************************************************************************************************************************************/

            #region FileLoading

            //probably not the best way to get the "dynamic directory"
            string fPath = AppDomain.CurrentDomain.BaseDirectory;

            if (fPath.Contains("Debug"))
            {
                fPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), @"../"));
            }

            //loads all the recorded persons, stored in a bin file (ideal is to query the file when needed)
            SickPersonRules.LoadAllRequest(fPath + @"\db\spDB.bin");

            //loads all recorded diseases. Its the disease portfolio (ideal is to query the file when needed)
            DiseaseRules.LoadAllRequest(fPath + @"\db\dDB.bin");

            //loads all hospitals to memmory (ideal is to query the file when needed)
            HospitalRules.LoadAllRequest(fPath + @"\db\hDB.bin");

            #endregion FileLoading

            #region -------- TEST APPLICATION --------

            int menuOption; //variable that handls the program for testing in console application
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Pandemic - A solution to manage sick people!!");
                Console.ResetColor();

                Console.WriteLine("o que deseja fazer?\n");

                Console.WriteLine(
                    "1 - Listar informação\n" +
                    "2 - Abrir ficha de paciente\n" +
                    "3 - Adicionar nova pessoa infetada\n" +
                    "4 - Marcar infetado como recuperado\n" +
                    "5 - Declarar óbito de uma pessoa\n" +
                    "6 - Inserir novo hospital na base de dados\n" +
                    "7 - Inserir novo virus pandémico na base de dados\n" +
                    "8 - Sair\n"
                    );

                _ = int.TryParse(Console.ReadLine(), out menuOption) ? menuOption : 0;

                switch (menuOption)
                {
                    case 1:
                        TestScripting.TestListDashBoard(out int numSP, out int totSP, out int numDeaths);
                        break;

                    case 2:
                        TestScripting.TestPrintSickPersonsFile("Andre Ferreira");
                        break;

                    case 3:
                        TestScripting.TestAddingUser();
                        break;

                    case 4:
                        TestScripting.TestMedDischargeSickPerson();
                        break;

                    case 5:
                        TestScripting.TestSetDeathOfSickPerson("Louis Armstrong");
                        break;

                    case 6:
                        TestScripting.TestAddHospitalToList();
                        break;

                    case 7:
                        TestScripting.TestAddPandemicVirus();

                        break;

                    case 8:
                        return;//Exits program
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadLine();
                        break;
                }
            } while (menuOption != 0);

            #endregion -------- TEST APPLICATION --------
        }
    }
}