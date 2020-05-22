/*
 * ********************************************************************************
 * <copyright file = "Diseases"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/16/2020 6:06:09 PM</date>
 * <description>This class handles the diseases portfolio</description>
 * ********************************************************************************
 */

using System;
using System.Collections.Generic;
using AF_IPCA.PandemicApp.BO;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// This is the lowest level dll. This handles all file and lists mediation.
/// It stores information.
/// </summary>
namespace AF_IPCA.PandemicApp.DAO
{
    /// <summary>
    /// this class manages diseases.
    /// </summary>
    [Serializable]
    public class Diseases
    {
        #region ------- MEMBER VARIABLES -------

        private static List<Disease> allDiseases;

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// Default constructor for Diseases class
        /// </summary>
        static Diseases()
        {
            allDiseases = new List<Disease>();
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// Method responsible to add new pandemic diseases to the list
        /// </summary>
        /// <param name="d">This is an object of type Disease. It represents the disease it self</param>
        /// <returns>true if added, or false if it already exists</returns>
        public static bool AddToDiseases(Disease d)
        {
            if (allDiseases != null)
            {
                foreach (Disease dd in allDiseases)
                {
                    if (dd.TypeOfDisease == d.TypeOfDisease)
                    {
                        return false;
                    }
                }
            }
            allDiseases.Add(d);

            //probably not the best way to get the "dynamic directory"
            string fPath=AppDomain.CurrentDomain.BaseDirectory;

            if (fPath.Contains("Debug"))
            {
                fPath=Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), @"../"));
            }
                
            SaveAll(fPath + @"\db\dDB.bin");
            return true;
        }

        /// <summary>
        /// This method prints the list on the screen
        /// </summary>
        public static void ShowDiseases()
        {
            if (allDiseases != null)
            {
                foreach (Disease d in allDiseases)
                {
                    Console.WriteLine(d.DiseaseID + "      | " + d.TypeOfDisease + "      | " + d.IncubationPeriod + "      | " + d.DiseaseSintoms);
                }
            }
        }

        /// <summary>
        /// Method that seeks for an id in the diseases collection, and retrieves it in order to add it to the sick persons disease history
        /// </summary>
        /// <param name="id">integer with id</param>
        /// <returns>disease or null if not found</returns>
        public static Disease GetDisease(int id)
        {
            if (allDiseases != null)
            {
                foreach (Disease d in allDiseases)
                {
                    if (d.DiseaseID == id)
                    {
                        return d;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Method that handles the save procedure of data into a file
        /// </summary>
        /// <param name="fileName">Full path and name of the file</param>
        /// <returns>true if save is ok. False if not</returns>
        public static bool SaveAll(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryFormatter binForm = new BinaryFormatter();
                binForm.Serialize(fs, allDiseases);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch (IOException io)
            {
                throw new Exception("Erro de gravação ficheiro doenças: " + io.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro de gravação ficheiro doenças não previsto: ", e);
            }
        }

        /// <summary>
        /// Method that handles the load procedure of data from a file
        /// </summary>
        /// <param name="fileName">Full path and name of the file</param>
        /// <returns>true if file is loaded, or false if something whent wrong</returns>
        public static bool LoadAll(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter binForm = new BinaryFormatter();
                allDiseases = (List<Disease>)binForm.Deserialize(s);
                s.Close();
                return true;
            }
            catch (IOException io)
            {
                throw new Exception("Erro de carregamento ficheiro doenças: " + io.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro de carregamento ficheiro doenças não previsto: ", e);
            }
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}