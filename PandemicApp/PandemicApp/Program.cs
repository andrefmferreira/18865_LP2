/*
 * ********************************************************************************
 * <copyright file = "Program.cs"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>25-03-2020</date>
 * <description>This application will manage people on a probable pandemic virus infection, fowarding the subject to specific care, if needed</description>
 * ********************************************************************************
 */

using AF_IPCA.PandemicApp.Domain;
using System;

/// <summary>
/// This is the mainspace of this application. In this space, the main class, named Program will always be executed
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

            #region -------- TEST APPLICATION --------
            SickPerson sickPerson = new SickPerson("andre", "ferreira", "M");

            sickPerson.basicDataInsert();
            sickPerson.AddDisease();
            sickPerson.CheckHospitalStatus();

            Console.Clear();
            Console.WriteLine("Informação recolhida\n\n" +
                "Nome: {0}\n" +
                "Idade: {1}\n" +
                "Sexo: {2}\n" +
                "Pais de Origem: {3}\n" +
                "Idioma: {4}\n" +
                "Contacto: {5}\n" +
                "Email: {6}\n" +
                "Contacto de Emergência: {7}\n" +
                "Contacto: {8}\n" +
                "Email: {9}\n------------------------------------------------",
                sickPerson.FullName,
                sickPerson.Age,
                sickPerson.Gender,
                sickPerson.Country,
                sickPerson.Language,
                sickPerson.ContactInfo.PhoneNumber,
                sickPerson.ContactInfo.Email,
                sickPerson.EmrContactPerson.FullName,
                sickPerson.EmrContactPerson.ContactInfo.PhoneNumber,
                sickPerson.EmrContactPerson.ContactInfo.Email);
            

                Console.WriteLine("Histórico de doenças");
            sickPerson.ListDiseases();


            if (sickPerson.IsAdmited)
            {
                Console.WriteLine("Paciente internado\n");
                Console.WriteLine("Informação do Hospital:\n" +
                    "Hospital: {0} em {1}\n" +
                    "Distrito: {2}\n" +
                    "Hospital Público: {3}\n" +
                    "Paciente nos cuidados intensivos: {4}",
                    sickPerson.InHospital.HospitalName,
                    sickPerson.InHospital.HospitalCity,
                    sickPerson.InHospital.HospitalDistrict,
                    sickPerson.InHospital.IsPublic?"Sim":"Não",
                    sickPerson.InHospital.IsICU ? "Sim" : "Não");
            }
            else
            {
                Console.WriteLine("Paciente vai recuperar em casa\n");
                Console.WriteLine("Informação da residência:\n" +
                    "Morada: {0} - {1} - {2}\n" +
                    "Distrito: {3}\n",                    
                    sickPerson.ContactInfo.AddressDesc,
                    sickPerson.ContactInfo.AddressZipCode,
                    sickPerson.ContactInfo.AddressCity,
                    sickPerson.ContactInfo.AddressDistrict);
                sickPerson.InHome.informPatientProcedures();
            }

            Console.ReadLine();

            #endregion
        }
    }
}