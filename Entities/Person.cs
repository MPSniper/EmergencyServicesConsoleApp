using PhaseOne.Enums;

namespace PhaseOne.Entities
{
    public class Person
    {
        public string Name
        {
            get; set;
        }
        public string FamilyName
        {
            get; set;
        }
        public GenderType Gender
        {
            get; set;
        }
        public string NationalCode
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
    }
}
