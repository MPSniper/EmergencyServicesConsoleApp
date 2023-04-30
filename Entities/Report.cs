using PhaseOne.Enums;

namespace PhaseOne.Entities
{
    public class Report
    {
        public Person Person
        {
            get; set;
        }
        public ReportType ReportType
        {
            get; set;
        }
    }
}
