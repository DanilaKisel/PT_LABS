namespace OOP_COLLECTIONS
{
    public interface ISalariedEmployee
    {
        decimal StartSalary { get; }
        decimal SalaryBonus();
        decimal TotalSalary();
    }
}