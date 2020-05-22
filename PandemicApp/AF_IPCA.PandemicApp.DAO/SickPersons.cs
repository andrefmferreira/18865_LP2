/*
 * ********************************************************************************
 * <copyright file = "SickPersons"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/16/2020 9:25:43 PM</date>
 * <description>This class handles the sickpersons information</description>
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
    /// this class handles all the sickpersons objects.
    /// </summary>
    [Serializable]
    public static class SickPersons
    {
        #region ------- MEMBER VARIABLES -------

        private static List<SickPerson> allSickPersons;                                 //creates just one list of sickPerson's.

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// default constructor for sickPerson's class
        /// </summary>
        static SickPersons()
        {
            allSickPersons = new List<SickPerson>();
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// This methodo seeks for a sick person in the database, and sets the status of isAlive to false (person's death)
        /// </summary>
        /// <param name="fullName">Uses the full name (not ideal) for searching</param>
        /// <returns>returns true if sucess, or false if not</returns>
        public static bool SetDeathOfSickPerson(string fullName)
        {
            if (allSickPersons.Count != 0)
            {
                foreach (SickPerson sp in allSickPersons)
                {
                    if (sp.FullName == fullName && sp.IsAlive == true)
                    {
                        sp.IsAlive = false;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Methodo responsible to add a sickperson to a list of sickPerson's.
        /// </summary>
        /// <param name="sickPer">Sick Person object</param>
        /// <returns></returns>
        public static bool AddSickPerson(SickPerson sickPerson)
        {
            if (allSickPersons.Count != 0)
            {
                foreach (SickPerson sp in allSickPersons)
                {
                    if (sp.FullName == sickPerson.FullName)                   // checks by name (not ideal. It should have more information)
                    return false;
                }
            }
            allSickPersons.Add(sickPerson);
            return true;
                
        }

        /// <summary>
        /// This method queries the list of sickpersons, in order to get information from sickPerson
        /// </summary>
        /// <param name="sickPerson">Sick Person object </param>
        /// <returns></returns>
        public static string GetGenderFromList(SickPerson sickPerson)
        {
            if (allSickPersons.Count != 0)
            {
                foreach (SickPerson sp in allSickPersons)
                {
                    if (sp.Gender != null && sp.FullName == sickPerson.FullName)
                    {
                        return sp.Gender;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// This method sets the values for contact information of a person.
        /// </summary>
        /// <param name="sickPerson">Sick Person object</param>
        /// <param name="phoneNum">Phone Number</param>
        /// <param name="email">Email address</param>
        /// <param name="addDesc">Address street description</param>
        /// <param name="addZipCode">Address zip code</param>
        /// <param name="addCity">Address city</param>
        /// <param name="addDistrict">Address district</param>
        /// <param name="addCountry">Address Country</param>
        /// <returns>Returns truee if insertion is ok!</returns>
        public static bool SetPersonsContact(
            SickPerson sickPerson,
            string phoneNum,
            string email,
            string addDesc,
            string addZipCode,
            string addCity,
            string addDistrict,
            string addCountry
            )
        {
            sickPerson.ContactInfo.PhoneNumber = phoneNum;
            sickPerson.ContactInfo.Email = email;
            sickPerson.ContactInfo.AddressDesc = addDesc;
            sickPerson.ContactInfo.AddressZipCode = addZipCode;
            sickPerson.ContactInfo.AddressCity = addCity;
            sickPerson.ContactInfo.AddressDistrict = addDistrict;
            sickPerson.ContactInfo.AddressCountry = addCountry;

            return true;
        }

        /// <summary>
        /// Method responsible to set the emergency contact of a sickPerson. It will store the information in the sickperson's "object"
        /// </summary>
        /// <param name="sickPerson">SickPerson's object</param>
        /// <param name="emrPerson">Emergency contact person object</param>
        /// <returns>true if succeed or false if not</returns>
        public static bool SetEmrContactPerson(SickPerson sickPerson, EmergencyContactPerson emrPerson)
        {
            sickPerson.EmrContactPerson = emrPerson;

            return true;
        }

        /// <summary>
        /// This method adds a disease to the person's disease history.
        /// </summary>
        /// <param name="sickPerson">sick person</param>
        /// <param name="personDisease">virus disease</param>
        /// <returns>true if sucess false if not</returns>
        public static bool AddDiseaseToSickPersonHistory(SickPerson sickPerson, DiseaseHistory personDisease)
        {
            if (personDisease != null)
            {
                sickPerson.diseases.Add(personDisease);
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method adds more information to the person's file
        /// </summary>
        /// <param name="sickPerson">sick person</param>
        /// <param name="bdate">birthdate</param>
        /// <param name="pCountry">country</param>
        /// <param name="pCitizen">citzenship</param>
        /// <param name="pLang">language</param>
        /// <returns>true if sucess false if not</returns>
        public static bool AddBaseInfoToSickPerson(SickPerson sickPerson, DateTime bdate, string pCountry, string pCitizen, string pLang)
        {
            if (sickPerson != null)
            {
                sickPerson.BirthDate = bdate;
                sickPerson.Country = pCountry;
                sickPerson.Citizenship = pCitizen;
                sickPerson.Language = pLang;
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method searches all persons registered as sick persons, and pulls the information out.
        /// </summary>
        /// <param name="fullName">person's full name</param>
        /// <returns>object sickPerson</returns>
        public static SickPerson GetSickPerson(string fullName)
        {
            if (allSickPersons.Count != 0)
            {
                foreach (SickPerson sp in allSickPersons)
                {
                    if (sp.FullName == fullName && sp.IsAlive == true)
                    {
                        return sp;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// This methodo seeks for all listed sick persons in the "database", using as criteria the full name (not ideal). If found, seeks for the
        /// pandemic virus wich is not cured, and set it to cured, assigning the date when this change is made as medical discharge date.
        /// </summary>
        /// <param name="spName">sick person's full name</param>
        /// <returns>true if found and updated, or false if not</returns>
        public static bool MedDischargeSickPerson(string spName)
        {
            if (allSickPersons.Count != 0)
            {
                foreach (SickPerson sp in allSickPersons)
                {
                    if (sp.FullName == spName && sp.IsAlive == true)
                    {
                        foreach (DiseaseHistory spDh in sp.diseases)
                        {
                            if (!spDh.IsCured)
                            {
                                spDh.IsCured = true;
                                spDh.MedDischargeDate = DateTime.Today;                             //sets the discharge date
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
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
                binForm.Serialize(fs, allSickPersons);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                return true;
            }
            catch (IOException io)
            {
                throw new Exception("Erro de gravação no ficheiro pessoas infetadas: " + io.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro de gravação não previsto no ficheiro de pessoas infetadas : ", e);
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
                allSickPersons = (List<SickPerson>)binForm.Deserialize(s);
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

        /// <summary>
        /// This functiion gets data from the database in order to print a dashboard
        /// </summary>
        /// <param name="numSP">number of active sickperson</param>
        /// <param name="totSP">number of sickperson</param>
        /// <param name="numDeaths">number of deaths</param>
        /// <returns>true if success or false if not</returns>
        public static bool ListSickPersonDashBoard(out int numSP, out int totSP, out int numDeaths)
        {
            numSP = 0;
            totSP = allSickPersons.Count;
            numDeaths = totSP;
            if (totSP != 0)
            {
                foreach (SickPerson sp in allSickPersons)
                {
                    if (sp.IsAlive)
                    {
                        numDeaths--;                                            //counts the number of dead people
                        foreach (DiseaseHistory d in sp.diseases)
                        {
                            numSP += d.IsCured ? 0 : 1;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}