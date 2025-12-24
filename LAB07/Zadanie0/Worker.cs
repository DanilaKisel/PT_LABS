// Worker.cs
namespace OOP_COLLECTIONS
{
    public class Worker : Employee, ISalariedEmployee, IPromotable
    {
        private int monthlyShifts;

        public int MonthlyShifts 
        { 
            get => monthlyShifts; 
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value, nameof(MonthlyShifts));
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 31, nameof(MonthlyShifts));
                monthlyShifts = value;
            }
        }
        
        public decimal StartSalary => 1000m;

        public Worker(string name, DateTime birth, DateTime hire, int shifts) : base(name, birth, hire)
        {
            MonthlyShifts = shifts;
        }

        // ISalariedEmployee implementation
        public decimal SalaryBonus()
        {
            decimal bonus = 0;
            
            if (MonthlyShifts > 25)
            {
                bonus += 300m;
            }
            else if (MonthlyShifts > 20)
            {
                bonus += 150m;
            }
            else if (MonthlyShifts > 15)
            {
                bonus += 50m;
            }
            
            if (Experience > 10)
            {
                bonus += 200m;
            }
            else if (Experience > 5)
            {
                bonus += 100m;
            }
            else if (Experience > 2)
            {
                bonus += 50m;
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
            return Experience >= 2 && MonthlyShifts >= 20 && Age < 60;
        }

        public void Promote()
        {
            if (IsEligibleForPromotion())
            {
                Console.WriteLine($"{Name} повышен до бригадира!");
            }
            else
            {
                Console.WriteLine($"{Name} не соответствует критериям для повышения");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Shifts={MonthlyShifts}, Salary={TotalSalary():C}";
        }
    }
}