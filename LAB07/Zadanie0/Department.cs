using OOP_COLLECTIONS;

public class Department
{
    public string Name { get; set; }
    private List<Employee> employees;

    public Department(string name)
    {
        Name = name;
        employees = new List<Employee>();
    }

    // Добавление сотрудника
    public void AddEmployee(Employee employee)
    {
        if (FindEmployeeById(employee.ID) == null)
        {
            employees.Add(employee);
            Console.WriteLine($"Добавлен: {employee.Name} (ID: {employee.ID})");
        }
        else
        {
            Console.WriteLine($"Сотрудник с ID {employee.ID} уже существует!");
        }
    }

    // Добавление нескольких сотрудников
    public void AddEmployees(params Employee[] newEmployees)
    {
        foreach (var employee in newEmployees)
        {
            AddEmployee(employee);
        }
    }

    // Поиск по ID
    public Employee? FindEmployeeById(int id)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i].ID == id)
            {
                return employees[i];
            }
        }
        return null;
    }

    // Удаление сотрудника по ID
    public bool RemoveEmployee(int id)
    {
        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i].ID == id)
            {
                string name = employees[i].Name;
                employees.RemoveAt(i);
                Console.WriteLine($"Удален: {name} (ID: {id})");
                return true;
            }
        }
        return false;
    }

    // Получение всех сотрудников
    public List<Employee> GetAllEmployees()
    {
        return new List<Employee>(employees);
    }

    // Получение количества сотрудников
    public int EmployeeCount => employees.Count;

    // Повышение сотрудника по ID
    public void PromoteEmployee(int id)
    {
        var employee = FindEmployeeById(id);
        if (employee is IPromotable promotable)
        {
            if (promotable.IsEligibleForPromotion())
            {
                promotable.Promote();
            }
            else
            {
                Console.WriteLine($"{employee.Name} не может быть повышен");
            }
        }
        else if (employee != null)
        {
            Console.WriteLine($"{employee.Name} не поддерживает повышение");
        }
        else
        {
            Console.WriteLine($"Сотрудник с ID {id} не найден");
        }
    }

    // Получение зарплаты сотрудника по ID
    public decimal? GetEmployeeSalary(int id)
    {
        var employee = FindEmployeeById(id);
        if (employee is ISalariedEmployee salariedEmployee)
        {
            return salariedEmployee.TotalSalary();
        }
        return null;
    }

    // Статистика отдела
    public void PrintDepartmentInfo()
    {
        Console.WriteLine($"\n=== Отдел: {Name} ===");
        Console.WriteLine($"Всего сотрудников: {employees.Count}");
        
        Dictionary<string, int> stats = new Dictionary<string, int>();
        for (int i = 0; i < employees.Count; i++)
        {
            string typeName = employees[i].GetType().Name;
            if (stats.ContainsKey(typeName))
            {
                stats[typeName]++;
            }
            else
            {
                stats[typeName] = 1;
            }
        }
        
        foreach (var stat in stats)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value}");
        }

        decimal totalSalary = 0;
        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i] is ISalariedEmployee salariedEmployee)
            {
                totalSalary += salariedEmployee.TotalSalary();
            }
        }
        
        Console.WriteLine($"Общие расходы на зарплаты: {totalSalary:C}");
    }

    // Получить всех сотрудников с зарплатой
    public Dictionary<int, decimal> GetAllSalaries()
    {
        Dictionary<int, decimal> salaries = new Dictionary<int, decimal>();
        
        for (int i = 0; i < employees.Count; i++)
        {
            if (employees[i] is ISalariedEmployee salariedEmployee)
            {
                salaries[employees[i].ID] = salariedEmployee.TotalSalary();
            }
        }
        
        return salaries;
    }

    // === НОВЫЙ МЕТОД (ЗАДАНИЕ 3) ===
    public decimal GetAverageSalary()
    {
        decimal totalSalary = 0;
        int count = 0;

        foreach (var employee in employees)
        {
            // Учитываем только тех, кто получает зарплату (исключаем Trainee)
            if (employee is ISalariedEmployee salariedEmployee)
            {
                totalSalary += salariedEmployee.TotalSalary();
                count++;
            }
        }

        // Защита от деления на ноль, если в отделе нет сотрудников с зарплатой
        return count > 0 ? totalSalary / count : 0;
    }
}