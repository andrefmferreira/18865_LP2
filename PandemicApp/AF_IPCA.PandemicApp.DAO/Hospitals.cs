/*
 * ********************************************************************************
 * <copyright file = "Hospitals"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/16/2020 3:47:50 PM</date>
 * <description>This class handles the hospitals portfolio</description>
 * ********************************************************************************
 */

using System;
using System.Collections.Generic;
using System.IO;
using AF_IPCA.PandemicApp.BO;
using System.Runtime.Serialization.Formatters.Binary;


/// <summary>
/// This is the lowest level dll. This handles all file and lists mediation.
/// It stores information.
/// </summary>
namespace AF_IPCA.PandemicApp.DAO
{

    /// <summary>
    /// this class handles hospitals.
    /// </summary>
    [Serializable]
    public class Hospitals
    {
        #region ------- MEMBER VARIABLES -------

        private static List<Hospital> hospitalList = new List<Hospital>();

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public Hospitals()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// checks if a given hospital is already on the list of hospitals and if not, it will add it up.
        /// </summary>
        /// <param name="nameOfHospital">Name o</param>
        /// <returns>returns true or false. If true, it will also adds up the hospital to the List.</returns>
        public static bool AddToHospitalList(Hospital h, out int x)
        {
            if (hospitalList != null)
            {
                if (hospitalList.Contains(h))
                {
                    x = -1;
                    return false;
                }
            }
            hospitalList.Add(h);                                                        //Adds hospital to List
            x = h.HospId;                                                               //passes the id using the out parameter
                                                                                        //probably not the best way to get the "dynamic directory"
            string fPath = AppDomain.CurrentDomain.BaseDirectory;

            if (fPath.Contains("Debug"))
            {
                fPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), @"../"));
            }

            SaveAll(fPath + @"\db\hDB.bin");
            return true;
        }

        /// <summary>
        /// This method prints on the screen all hospitals, that met the district criteria
        /// </summary>
        /// <param name="hDistrict">Input from user. It will define what hospitals are printed</param>
        /// <param name="ids">Out parameter, that gives the ids the user can choose. If user chooses a value out of range, it will give an error msg</param>
        /// <returns>true if there are hospitals found, or false if no hospitals in the given district</returns>
        public static bool PrintHospitalsFromDistrict(string hDistrict, out int[] ids)
        {
            int i = 0;
            ids = new int[hospitalList.Count];
            if (hospitalList != null)
            {
                foreach (Hospital hospital in hospitalList)
                {
                    if (string.Compare(hospital.HospitalDistrict, hDistrict) == 0)
                    {
                        Console.WriteLine(hospital.HospId + ".........." + hospital.HospitalName + ".........." + hospital.HospitalCity);
                        ids[i] = hospital.HospId;
                        i++;
                    }
                }
                return i > 0 ? true : false;
            }
            ids = null;
            return false;
        }

        /// <summary>
        /// This method searches for an hospital, in the hospitals portfolio, by id.
        /// </summary>
        /// <param name="id">Its the id of the hospital</param>
        /// <returns>The object hospital, or null if not found</returns>
        public static Hospital GetHospitalByID(int id)
        {
            if (hospitalList != null)
            {
                foreach (Hospital h in hospitalList)
                {
                    if (h.HospId == id) return h;
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
                binForm.Serialize(fs, hospitalList);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch (IOException io)
            {
                throw new Exception("Erro de gravação no ficheiro dos hospitais: " + io.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro de gravação não previsto no ficheiro de hospitais : ", e);
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
                hospitalList = (List<Hospital>)binForm.Deserialize(s);
                s.Close();
                return true;
            }
            catch (IOException io)
            {
                throw new Exception("Erro de carregamento no ficheiro pessoas infetadas: " + io.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro de carregamento não previsto no ficheiro de pessoas infetadas : ", e);
            }
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}