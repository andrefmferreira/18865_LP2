/*
 * ********************************************************************************
 * <copyright file = "TestScripting"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/21/2020 12:21:00 AM</date>
 * <description>This class handles a test procedure calling methods as a test. Those mehods shall be implemented in further versions of this aplication</description>
 * ********************************************************************************
 */

using System;
using System.IO;
using System.Linq;
using AF_IPCA.PandemicApp.BL;
using AF_IPCA.PandemicApp.BO;

/// <summary>
/// This is the mainspace of this application. The frondend
/// </summary>
namespace AF_IPCA.PandemicApp.ConsoleApp
{
     /// <summary>
     /// This is a testing class. It contains code to test and call functions in a testing environment
     /// </summary>
    public class TestScripting
    {
        #region ------- MEMBER VARIABLES -------

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public TestScripting()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// This method handles several steps to add a new sick person, with complementary information.
        /// </summary>
        /// <returns>true if success false if not</returns>
        public static bool TestAddingUser()
        {
            SickPerson sickPerson = new SickPerson("Filipe", "Ferreira", "M");

            if (SickPersonRules.InsertsSickPerson(sickPerson))
            {
                Console.WriteLine(SickPersonRules.GetGender(sickPerson).ToString() + " " + sickPerson.FullName + " inserido\n");

                //+++++++++++++++++++++++ adds more info on the person +++++++++++++++++++++++
                Console.WriteLine("Por favor indique a seguinte informação para complementar a ficha do doente " + SickPersonRules.GetGender(sickPerson).ToString() + " " + sickPerson.FullName);
                Console.ResetColor();

                string birthdate, country, citizenship, language;

                //Console.Write("Data de nascimento: ");
                birthdate = "31-03-1988";                                                                       //hardcoded for testing purpose

                //Console.Write("Pais de origem: ");
                country = "portugal";                                                                           //hardcoded for testing purpose

                //Console.Write("Nacionalidade: ");
                citizenship = "portuguese";                                                                     //hardcoded for testing purpose

                //Console.WriteLine("Lingua materna: ");
                language = "Portuguese";                                                                        //hardcoded for testing purpose

                SickPersonRules.AddBaseInfoToSickPersonRequest(sickPerson, birthdate, country, citizenship, language);

                //+++++++++++++++++++++++ adds contact information of sick person +++++++++++++++++++++++

                Console.WriteLine("Por favor indique a informação de contacto sobre " + SickPersonRules.GetGender(sickPerson).ToString() + " " + sickPerson.FullName);
                bool b = SickPersonRules.SetContactInfo(
                    sickPerson,
                    "917458779",                                        //phone number
                    "lp24ever@gmail.com",                               //email address
                    "Rua do Ipca, n 555",                               //address
                    "4750-106",                                         //zip code
                    "Barcelos",                           //city
                    "Braga",                                            //district
                    "Portugal"                                          //country
                    );

                if (b)
                {
                    Console.WriteLine("Informação de contacto de " + sickPerson.FullName + " inserida com sucesso!\n");
                }
                else
                {
                    Console.WriteLine("Informação de contacto de " + sickPerson.FullName + " não inserida!\n");
                }

                // +++++++++++++++++++++++ adds emergency contact person information +++++++++++++++++++++++

                Console.WriteLine("Por favor indique um contacto de emergência do " + SickPersonRules.GetGender(sickPerson).ToString() + " " + sickPerson.FullName);

                if (SickPersonRules.SetEmrContact(sickPerson, "Rui", "Vitoria", "911212121", "Padrinho"))
                {
                    Console.WriteLine("Contacto de emergência de " + sickPerson.FullName + " inserido com sucesso!\n");
                }
                else
                {
                    Console.WriteLine("Contacto de emergência de " + sickPerson.FullName + " não inserido!\n");
                }

                // +++++++++++++++++++++++ adds sickness +++++++++++++++++++++++

                //1 - shoes possibilities
                Console.WriteLine("Indique qual a patologia! Se não constar, pf selecione 0 para adicionar");
                int id;
                do
                {
                    DiseaseRules.ShowDiseasesRequest();

                    Console.Write(">> ");
                    //2 allows the user to either enter a new virus disease, or select one from db
                    b = int.TryParse(Console.ReadLine(), out id);

                    if (id == 0)   //adds new disease to diseases portfolio
                    {
                        if (DiseaseRules.AddDiseaseRequest("Sarampo", "Benfiquismo", "36"))                    //hardcoded for testing purpose
                        {
                            Console.WriteLine("Doença pandémica adicionada com sucesso!");
                        }
                    }
                    else if (!b || id < 0)
                    {
                        Console.WriteLine("Opção errada!\n");
                    }
                } while (id <= 0 || !b);

                Disease disease = DiseaseRules.GetDiseaseRequest(id);                                                   //gets the disease from diseases portfolio
                Console.WriteLine("Seleccionou a doença pandémica: {0}. Indique os sintomas: ", disease.TypeOfDisease);
                string sickPersonSintoms = "Benfiquismo extremo!";                                                      //hardcoded for testing purpose
                SickPersonRules.AddDiseaseToSickPersonHistoryRequest(sickPerson, disease, sickPersonSintoms);           // adds this sickness to sickperson disease history

                // +++++++++++++++++++++++ adds the hospital information +++++++++++++++++++++++

                Console.WriteLine("O paciente " + sickPerson.FullName + " foi admitido num hospital?");
                sickPerson.IsAdmited = true;                                                                            //hardcoded for testing purpose

                if (sickPerson.IsAdmited)
                {
                    Console.Write("Qual o distrito do hospital: ");

                    bool h = HospitalRules.PrintHospitalsFromDistrictRequest(Console.ReadLine(), out int[] ids);
                    if (!h)
                    {
                        Console.WriteLine("Não existem hospitais registados no distrito que indicou!\n");
                        Console.WriteLine("Pretende adicionar um novo hospital sendo este o hospital em que está " + sickPerson.FullName + "?");

                        Boolean.TryParse(Console.ReadLine(), out bool a);
                        if (a)
                        {
                            Console.WriteLine("Indique os seguintes dados: \n");
                            Console.WriteLine("Nome do hospital: \n");
                            //string hName = Console.ReadLine();
                            Console.WriteLine("Distrito: \n");
                            //string hDistrict = Console.ReadLine();
                            Console.WriteLine("Concelho: \n");
                            //string hCity = Console.ReadLine();
                            Console.WriteLine("É publico? \n");
                            //string hPublic = Console.ReadLine();

                            //Hardcoded for testing purpose
                            if (HospitalRules.AddNewHospitalRequest("Hospital Benfica", "Lisboa", "Lisboa", "false", out id))
                            {
                                sickPerson.HospitalId = id;
                                Console.WriteLine("Hospital Benfica inserido com sucesso e adicionado a ficha de " + sickPerson.FullName + "!");
                            }
                            else
                            {
                                Console.WriteLine("Hospital Benfica não inserido!");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        int hID;
                        Console.WriteLine("Seleccione um ID");
                        Console.Write(">> ");

                        while ((int.TryParse(Console.ReadLine(), out hID) && hID != 0 ? !ids.Contains(hID) : true))       //checks if option is valid, and if it is in the range of valid options
                        {
                            Console.WriteLine("Opção errada!\n");
                        }
                        Hospital hosp = HospitalRules.GetHospitalByIDRequest(hID);
                        sickPerson.HospitalId = hosp.HospId;
                        Console.WriteLine("Hospital " + hosp.HospitalName + " inserido com sucesso e adicionado a ficha de " + sickPerson.FullName + "!");
                    }
                }

                //probably not the best way to get the "dynamic directory"
                string fPath = AppDomain.CurrentDomain.BaseDirectory;

                if (fPath.Contains("Debug"))
                {
                    fPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), @"../"));
                }
                SickPersonRules.SaveAllRequest(fPath + @"\db\spDB.bin");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine(SickPersonRules.GetGender(sickPerson).ToString() + " " + sickPerson.FullName + " não inserido\n");
                Console.ReadKey(); 
                return false;
            }
        }

        /// <summary>
        /// Test method that tests the printing of a sickperson's data file
        /// </summary>
        /// <param name="fullName">Full Name</param>
        /// <returns>true if success or false if not</returns>
        public static bool TestPrintSickPersonsFile(string fullName)
        {
            SickPerson sp = SickPersonRules.GetSickPersonRequest(fullName);      //hardcoded for testing
            if (sp != null)
            {
                SickPersonRules.GetAge(sp);                                        //calculates the age
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
                    "Parentesco: {9}\n------------------------------------------------",
                    sp.FullName,
                    sp.Age,
                    sp.Gender,
                    sp.Country,
                    sp.Language,
                    sp.ContactInfo.PhoneNumber,
                    sp.ContactInfo.Email,
                    sp.EmrContactPerson.FullName,
                    sp.EmrContactPerson.ContactInfo.PhoneNumber,
                    sp.EmrContactPerson.RelativeStatus
                    );

                Console.WriteLine("Histórico de doenças");
                foreach (DiseaseHistory spD in sp.diseases)
                {
                    Console.WriteLine(
                        "Data de diagnóstico: {0}\n" +
                        "Doença: {1}\n" +
                        "Sintomas: {2}\n------------------------\n",
                        spD.DiagnosticDate.ToShortDateString(),
                        spD.TypeOfDisease,
                        spD.DiseaseSintoms);
                }

                Console.WriteLine("Paciente em recuperação: ");
                if (sp.IsAdmited)
                {
                    Hospital spH = HospitalRules.GetHospitalByIDRequest(sp.HospitalId);

                    Console.WriteLine(
                                        "Hospital: {0}\n" +
                                        "Concelho: {1}\n" +
                                        "Data de internamento: {2}\n------------------------\n",
                                        spH.HospitalName,
                                        spH.HospitalCity,
                                        spH.AdmitDate.ToShortDateString());
                }
                else
                {
                    Console.WriteLine("Em casa, na morada: {0}\n" +
                        "\t\t\t{1} {2}\n" +
                        "\t\t\t{3} ({4})\n-------------------------------------------\n",
                        sp.ContactInfo.AddressDesc,
                        sp.ContactInfo.AddressZipCode,
                        sp.ContactInfo.AddressCity,
                        sp.ContactInfo.AddressDistrict,
                        sp.ContactInfo.AddressCountry);
                }
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Paciente não encontrado!\n");
                Console.ReadKey();
                return false;
            }
        }

        /// <summary>
        /// This method handles the informatic administration of a sick person's medical discharge.
        /// </summary>
        /// <returns>true if success false if not</returns>
        public static bool TestMedDischargeSickPerson()
        {
            Console.WriteLine("Indique o nome do paciente a marcar como 'curado'");

            if (SickPersonRules.MedDischargeSickPersonRequest(Console.ReadLine()))
            {
                Console.WriteLine("Paciente curado!! Boas noticias!!!");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Algo de errado não está certo");                 //Error message. In future a more comprehensive error message will be implemented
                Console.ReadLine();
                return false;
            }
        }

        /// <summary>
        /// This method is a test method that adds up a new hospital to the hospitals portfolio
        /// </summary>
        /// <returns>true if success false if not</returns>
        public static bool TestAddHospitalToList()
        {
            Console.WriteLine("Indique os seguintes dados: \n");
            Console.WriteLine("Nome do hospital: \n");
            string hName = Console.ReadLine();
            Console.WriteLine("Distrito: \n");
            string hDistrict = Console.ReadLine();
            Console.WriteLine("Concelho: \n");
            string hCity = Console.ReadLine();
            Console.WriteLine("É publico? \n");
            string hPublic = Console.ReadLine();

            if (HospitalRules.AddNewHospitalRequest(hName, hDistrict, hCity, hPublic, out int id))
            {
                Console.WriteLine("Hospital " + hName + " inserido com sucesso!");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Hospital " + hName + " não inserido!");
                Console.ReadLine();
            }

            return false;
        }

        /// <summary>
        /// This is a test Method that adds a new pandemic virus to the portfolio
        /// </summary>
        /// <returns>true if success false if not</returns>
        public static bool TestAddPandemicVirus()
        {
            string newTypeVirus, newSintomsVirus, newPeriodIncVirus;

            Console.WriteLine("Vírus pandémicos registados:\n");
            DiseaseRules.ShowDiseasesRequest();                         //shows the current pandemic virus portfolio.
            Console.WriteLine("Indique:\n");
            Console.Write("Nome do vírus/estirpe: ");
            newTypeVirus = Console.ReadLine();
            Console.Write("Indique sintomas caracteristicos: ");
            newSintomsVirus = Console.ReadLine();
            Console.Write("Indique o periodo de incubação detectado: ");
            newPeriodIncVirus = Console.ReadLine();

            if (DiseaseRules.AddDiseaseRequest(newTypeVirus, newSintomsVirus, newPeriodIncVirus))
            {
                Console.WriteLine("Virus pandémico " + newTypeVirus + " adicionado com sucesso ao portfólio");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Virus pandémico " + newTypeVirus + " não adicionado ao portfólio!");
                Console.ReadLine();
            }
            return false;
        }

        /// <summary>
        /// This method is a test method that handles the request to set a sick person which is alive, to dead
        /// </summary>
        /// <param name="fullName">full name of sick person</param>
        /// <returns>true if sussess or false if not</returns>
        public static bool TestSetDeathOfSickPerson(string fullName)
        {
            if (SickPersonRules.SetDeathOfSickPersonRequest(fullName))
            {
                Console.WriteLine("Óbito de " + fullName + " registado com sucesso.");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine(fullName +" não encontrada!");
                Console.ReadLine();
                return false;
            }
        }

        /// <summary>
        /// This method is a test method that request information to the database in order to get information to print a dashboard
        /// </summary>
        /// <param name="numSP">number of active infected sick persons</param>
        /// <param name="totSP">total number of sick persons</param>
        /// <param name="numDeads">number of deaths</param>
        /// <returns>true if there is data or false if there is no data</returns>
        public static bool TestListDashBoard(out int numSP, out int totSP, out int numDeaths)
        {
            if(SickPersonRules.ListSickPersonDashBoardRequest(out numSP, out totSP, out numDeaths))
            {
                Console.WriteLine("Dados da pandemia a " + DateTime.Today.ToShortDateString());

                Console.WriteLine("Número actual de pessoas infetadas:  " + numSP.ToString());
                
                Console.WriteLine("Total de pessoas recuperadas:  " + (totSP-numSP).ToString());
                
                Console.WriteLine("Total de pessoas infetadas:  " + totSP.ToString());

                Console.WriteLine("Total de óbitos:  " + numDeaths.ToString());
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Nada a reportar!");
                Console.ReadKey();
            return false;
            }
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}