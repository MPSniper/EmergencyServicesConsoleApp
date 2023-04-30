using PhaseOne.Enums;
using PhaseOne.Interfaces;

namespace PhaseOne.Entities
{
    public class Police : Department, ICallDept
    {
        public Report CallDept(Person person)
        {
            {
                var report = new Report();
                report.Person = person;
                report.ReportType = report.Person.Gender == GenderType.Male ? ReportType.PoliceForMen : ReportType.PoliceForWomen;
                Dispatch();
                return report;
            }
        }
    }
}
