namespace OOP_COLLECTIONS
{
    public abstract class Employee
    {
        private static int nextID = 1;
        private string name;
        private DateTime dateOfBirth;
        private DateTime dateOfHiring;

        public int ID { get; }
        
        public string Name 
        { 
            get => name; 
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(Name));
                ArgumentOutOfRangeException.ThrowIfLessThan(value.Trim().Length, 2, nameof(Name));
                name = value.Trim();
            }
        }
        
        public DateTime DateOfBirth 
        { 
            get => dateOfBirth; 
            set
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, DateTime.Now, nameof(DateOfBirth));
                if (value < DateTime.Now.AddYears(-100))
                {
                    throw new ArgumentException("Employee cannot be older than 100 years", nameof(DateOfBirth));
                }
                dateOfBirth = value;
            }
        }
        
        public DateTime DateOfHiring 
        { 
            get => dateOfHiring; 
            set
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThan(value, DateTime.Now, nameof(DateOfHiring));
                ArgumentOutOfRangeException.ThrowIfLessThan(value, DateOfBirth, nameof(DateOfHiring));
                dateOfHiring = value;
            }
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public int Experience => DateTime.Now.Year - DateOfHiring.Year;

        protected Employee(string name, DateTime birth, DateTime hire)
        {
            ArgumentOutOfRangeException.ThrowIfEqual(nextID, int.MaxValue, nameof(nextID));
            
            ID = nextID;
            Name = name;
            DateOfBirth = birth;
            DateOfHiring = hire;
            nextID++;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: ID={ID}, Name={Name}, Age={Age}, Experience={Experience} years";
        }
    }
}