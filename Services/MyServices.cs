using PhaseOne.Entities;
using PhaseOne.Enums;
using System.Text.RegularExpressions;

namespace PhaseOne.Services
{
    public class MyServices
    {
        private List<Report> reportList = new List<Report>();
        public void ConsoleCommands()
        {
            int request;
            do
            {
                Console.Clear();
                request = GetInput<int>("1)Request Service\n2)Print Report\nChoose an Item please:");
            } while (request != 1 && request != 2);
            if (request == (int)RequestType.Service)
                StartService();
            else if (request == (int)RequestType.Report)
                PrintReport();
            return;
        }

        private void StartService()
        {
            Console.Clear();
            Person person = ValidateUser();
            var police = new Police();
            var emergency = new Emergency();
            var fireDept = new FireDept();
            int service = GetInput<int>("What is Your emergency?\n1)Robbery\n2)Fire\n3)Asthma\nChoose an Item please:");
            while (service != 1 && service != 2 && service != 3)
            {
                Console.Clear();
                Console.WriteLine("Wrong Option!");
                service = GetInput<int>("What is Your emergency?\n1)Robbery\n2)Fire\n3)Asthma\nChoose an Item please:");
            }
            if (service == (int)ServiceType.Robbery)
                reportList.Add(police.CallDept(person));
            if (service == (int)ServiceType.Fire)
                reportList.Add(fireDept.CallDept(person));
            if (service == (int)ServiceType.Asthma)
                reportList.Add(emergency.CallDept(person));
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private void PrintReport()
        {
            if (reportList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Reports available.");
            }
            else
            {
                int filter;
                do
                {
                    Console.Clear();
                    filter = GetInput<int>("1)All Services\n2)FireDept Services\n3)Emergency Services\n4)Police For Men\n5)Police For Women\nChoose option to Filter Reports:");
                }
                while (filter != 1 && filter != 2 && filter != 3 && filter != 4 && filter != 5);
                FilterReports(filter);
            }
            Console.Write("Press Enter to continue...");
            Console.ReadLine();
        }

        private void FilterReports(int filter)
        {
            Console.Clear();
            Console.WriteLine("Report For: " + (ReportType)filter);

            switch ((ReportType)filter)
            {
                case ReportType.FireDeptServices:
                    foreach (var report in reportList)
                        if (report.ReportType == ReportType.FireDeptServices)
                            PrintLog(report);
                    break;
                case ReportType.EmergencyServices:
                    foreach (var report in reportList)
                        if (report.ReportType == ReportType.EmergencyServices)
                            PrintLog(report);
                    break;
                case ReportType.PoliceForMen:
                    foreach (var report in reportList)
                        if (report.ReportType == ReportType.PoliceForMen)
                            PrintLog(report);
                    break;
                case ReportType.PoliceForWomen:
                    foreach (var report in reportList)
                        if (report.ReportType == ReportType.PoliceForWomen)
                            PrintLog(report);
                    break;
                case ReportType.AllServices:
                    foreach (var report in reportList)
                        PrintLog(report);
                    break;
                default:
                    break;
            }
        }

        private Person ValidateUser()
        {
            var person = new Person();
            person.Name = GetInput<string>("Enter your Name: ");
            person.FamilyName = GetInput<string>("Enter your FamilyName: ");
            //Validating gender.
            string gender = GetInput<string>("What is your gender(m/f)?").ToLower();
            while (gender != "m" && gender != "f")
            {
                Console.WriteLine("Wrong Gender!");
                gender = GetInput<string>("What is your gender(m/f)?").ToLower();
            }
            person.Gender = gender == "m" ? GenderType.Male : GenderType.Female;
            //Validating nationalCode
            Regex nationalCodePattern = new Regex(@"^[0-9]+$");
            string nationalCode = GetInput<string>("Enter your NationalCode: ");
            while (!nationalCodePattern.IsMatch(nationalCode) || nationalCode.Length != 10)
            {
                Console.WriteLine("Wrong National Code!");
                nationalCode = GetInput<string>("Enter your NationalCode: ");
            }
            person.NationalCode = nationalCode;
            person.Address = GetInput<string>("Enter your Address: ");
            Console.Clear();
            return person;
        }

        private T GetInput<T>(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));//Prevents empty inputs
            if (int.TryParse(input, out int value) && value is T option)
                return option;
            else if (string.IsNullOrEmpty(input) && input is T output)
                return output;
            else if (input is T t)
                return t;
            return default;
        }

        private void PrintLog(Report report)
        {
            Console.WriteLine($"FullName:{report.Person.Name} {report.Person.FamilyName}---NationalCode:{report.Person.NationalCode}---Address:{report.Person.Address}---Service:{report.ReportType}");
        }
    }
}