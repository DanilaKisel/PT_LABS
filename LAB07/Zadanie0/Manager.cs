// Manager.cs
namespace OOP_COLLECTIONS
{
    public class Manager : Employee, ISalariedEmployee, IPromotable
    {
        private int numberOfEmployees;

        public bool HasEducation { get; set; }
        
        public int NumberOfEmployees 
        { 
            get => numberOfEmployees; 
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(NumberOfEmployees));
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 1000, nameof(NumberOfEmployees));
                numberOfEmployees = value;
            }
        }
        
        public decimal StartSalary => 2000m;

        public Manager(string name, DateTime birth, DateTime hire, int empCount, bool isEducated = false) 
            : base(name, birth, hire)
        {
            NumberOfEmployees = empCount;
            HasEducation = isEducated;
        }

        // ISalariedEmployee implementation
        public decimal SalaryBonus()
        {
            decimal bonus = 0;
            
            if (NumberOfEmployees > 50)
            {
                bonus += 500m;
            }
            else if (NumberOfEmployees > 10)
            {
                bonus += 200m;
            }
            
            if (HasEducation)
            {
                bonus += 300m;
            }
                
            if (Experience > 5)
            {
                bonus += 400m;
            }
            else if (Experience > 2)
            {
                bonus += 150m;
            }
                
            return bonus;
        }

        public decimal TotalSalary()
        {
            return StartSalary + SalaryBonus();
        }

        // IPromotable implementation
        public bool IsEligibleForPromotion()
        {
            return HasEducation && Experience >= 3 && NumberOfEmployees >= 20;
        }

        public void Promote()
        {
            if (IsEligibleForPromotion())
            {
                Console.WriteLine($"{Name} повышен до старшего менеджера!");
            }
            else
            {
                Console.WriteLine($"{Name} не соответствует критериям для повышения");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Employees={NumberOfEmployees}, Education={HasEducation}, Salary={TotalSalary():C}";
        }
    }
}