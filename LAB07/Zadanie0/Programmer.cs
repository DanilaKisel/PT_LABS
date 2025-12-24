// Programmer.cs
namespace OOP_COLLECTIONS
{
    public enum Level { JUNIOR, MIDDLE, SENIOR }
    
    public class Programmer : Employee, ISalariedEmployee, IPromotable
    {
        private Level programmerLevel;

        public Level ProgrammerLevel 
        { 
            get => programmerLevel; 
            set
            {
                if (!Enum.IsDefined(typeof(Level), value))
                {
                    throw new ArgumentException("Invalid programmer level", nameof(ProgrammerLevel));
                }
                programmerLevel = value;
            }
        }
        
        public decimal StartSalary => 2000m;

        public Programmer(string name, DateTime birth, DateTime hire, Level level) : base(name, birth, hire)
        {
            ProgrammerLevel = level;
        }

        // ISalariedEmployee implementation
        public decimal SalaryBonus()
        {
            decimal bonus = 0;
            
            if (ProgrammerLevel == Level.SENIOR)
            {
                bonus += 1000m;
            }
            else if (ProgrammerLevel == Level.MIDDLE)
            {
                bonus += 500m;
            }
            else if (ProgrammerLevel == Level.JUNIOR)
            {
                bonus += 100m;
            }
            
            if (Experience > 8)
            {
                bonus += 600m;
            }
            else if (Experience > 5)
            {
                bonus += 300m;
            }
            else if (Experience > 2)
            {
                bonus += 100m;
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
            if (ProgrammerLevel == Level.SENIOR)
            {
                return false;
            }
            
            int requiredExperience = ProgrammerLevel == Level.JUNIOR ? 2 : 4;
            return Experience >= requiredExperience;
        }

        public void Promote()
        {
            if (!IsEligibleForPromotion())
            {
                Console.WriteLine($"{Name} не соответствует критериям для повышения");
                return;
            }

            Level newLevel = ProgrammerLevel;
            switch (ProgrammerLevel)
            {
                case Level.JUNIOR:
                    newLevel = Level.MIDDLE;
                    break;
                case Level.MIDDLE:
                    newLevel = Level.SENIOR;
                    break;
            }

            ProgrammerLevel = newLevel;
            Console.WriteLine($"{Name} повышен до уровня {newLevel}!");
        }

        public override string ToString()
        {
            return base.ToString() + $", Level={ProgrammerLevel}, Salary={TotalSalary():C}";
        }
    }
}