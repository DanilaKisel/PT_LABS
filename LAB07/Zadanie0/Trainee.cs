// Trainee.cs
namespace OOP_COLLECTIONS
{
    public class Trainee : Employee, IPromotable
    {
        private string trainingProgram;
        private DateTime trainingEndDate;

        public string TrainingProgram 
        { 
            get => trainingProgram; 
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(TrainingProgram));
                trainingProgram = value.Trim();
            }
        }
        
        public DateTime TrainingEndDate 
        { 
            get => trainingEndDate; 
            set
            {
                ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(value, DateOfHiring, nameof(TrainingEndDate));
                trainingEndDate = value;
            }
        }
        
        public bool IsTrainingCompleted => DateTime.Now > TrainingEndDate;

        public Trainee(string name, DateTime birth, DateTime hire, string program, DateTime trainingEnd) 
            : base(name, birth, hire)
        {
            TrainingProgram = program;
            TrainingEndDate = trainingEnd;
        }

        // IPromotable implementation
        public bool IsEligibleForPromotion()
        {
            var experienceInMonths = (DateTime.Now - DateOfHiring).TotalDays / 30.0;
            return IsTrainingCompleted && experienceInMonths >= 6;
        }

        public void Promote()
        {
            if (IsEligibleForPromotion())
            {
                Console.WriteLine($"{Name} завершил стажировку и повышен до младшего сотрудника!");
            }
            else
            {
                Console.WriteLine($"{Name} не завершил стажировку или недостаточно опыта для повышения");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Program={TrainingProgram}, Training Completed={IsTrainingCompleted}, End Date={TrainingEndDate:yyyy-MM-dd}";
        }
    }
}