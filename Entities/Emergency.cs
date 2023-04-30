using PhaseOne.Enums;
using PhaseOne.Interfaces;

namespace PhaseOne.Entities
{
    public class Emergency : Department, ICallDept
    {
        public Report CallDept(Person person)
        {
            {
                var report = new Report();
                report.Person = person;
                report.ReportType = ReportType.EmergencyServices;
                Dispatch();
                return report;
            }
        }
    }
}
