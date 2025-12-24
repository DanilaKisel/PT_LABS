// Program.cs
using OOP_COLLECTIONS;

try
{
    Console.WriteLine("=== CREATING DEPARTMENTS ===");
    Department itDepartment = new Department("IT Department");
    Department productionDepartment = new Department("Production Department");

    Console.WriteLine("\n=== CREATING EMPLOYEES ===");
    // IT Department Employees
    Employee p1 = new Programmer("Alice Johnson", new DateTime(1990, 5, 15), new DateTime(2020, 3, 1), Level.SENIOR);
    Employee p2 = new Programmer("Bob Smith", new DateTime(1995, 8, 22), new DateTime(2022, 6, 15), Level.MIDDLE);
    Employee p3 = new Programmer("Carol Davis", new DateTime(1998, 12, 3), new DateTime(2023, 1, 10), Level.JUNIOR);
    Employee m1 = new Manager("David Wilson", new DateTime(1985, 3, 10), new DateTime(2018, 7, 1), 25, true);
    Employee t1 = new Trainee("Eva Brown", new DateTime(2000, 7, 30), new DateTime(2024, 1, 15), 
        "Software Development", new DateTime(2024, 7, 15));

    // Production Department Employees
    Employee w1 = new Worker("Frank Miller", new DateTime(1980, 1, 20), new DateTime(2015, 5, 10), 28);
    Employee w2 = new Worker("Grace Lee", new DateTime(1988, 9, 14), new DateTime(2019, 8, 20), 22);
    Employee w3 = new Worker("Henry Clark", new DateTime(1992, 11, 5), new DateTime(2021, 2, 28), 18);
    Employee w4 = new Worker("Ivy Taylor", new DateTime(1983, 4, 18), new DateTime(2017, 11, 15), 30);
    Employee w5 = new Worker("Jack Anderson", new DateTime(1995, 6, 25), new DateTime(2022, 9, 5), 15);

    // Add employees to departments
    Console.WriteLine("\n=== ADDING EMPLOYEES TO IT DEPARTMENT ===");
    itDepartment.AddEmployees(p1, p2, p3, m1, t1);

    Console.WriteLine("\n=== ADDING EMPLOYEES TO PRODUCTION DEPARTMENT ===");
    productionDepartment.AddEmployees(w1, w2, w3, w4, w5);

    // Test ToString() method
    Console.WriteLine("\n=== EMPLOYEE INFORMATION ===");
    Console.WriteLine("IT Department Employees:");
    List<Employee> itEmployees = itDepartment.GetAllEmployees();
    foreach (Employee employee in itEmployees)
    {
        Console.WriteLine($"  {employee}");
    }

    Console.WriteLine("\nProduction Department Employees:");
    List<Employee> productionEmployees = productionDepartment.GetAllEmployees();
    foreach (Employee employee in productionEmployees)
    {
        Console.WriteLine($"  {employee}");
    }

    // Test department statistics
    Console.WriteLine("\n=== DEPARTMENT STATISTICS ===");
    itDepartment.PrintDepartmentInfo();
    productionDepartment.PrintDepartmentInfo();

    // Test salary functionality
    Console.WriteLine("\n=== SALARY INFORMATION ===");
    Console.WriteLine("IT Department Salaries:");
    Dictionary<int, decimal> itSalaries = itDepartment.GetAllSalaries();
    foreach (KeyValuePair<int, decimal> salary in itSalaries)
    {
        Console.WriteLine($"  Employee ID {salary.Key}: {salary.Value:C}");
    }

    Console.WriteLine("\nProduction Department Salaries:");
    Dictionary<int, decimal> productionSalaries = productionDepartment.GetAllSalaries();
    foreach (KeyValuePair<int, decimal> salary in productionSalaries)
    {
        Console.WriteLine($"  Employee ID {salary.Key}: {salary.Value:C}");
    }

    // Test promotion functionality
    Console.WriteLine("\n=== PROMOTION TESTING ===");
    Console.WriteLine("IT Department Promotions:");
    foreach (Employee employee in itEmployees)
    {
        Console.WriteLine($"\nTesting promotion for {employee.Name}:");
        itDepartment.PromoteEmployee(employee.ID);
    }

    Console.WriteLine("\nProduction Department Promotions:");
    foreach (Employee employee in productionEmployees)
    {
        Console.WriteLine($"\nTesting promotion for {employee.Name}:");
        productionDepartment.PromoteEmployee(employee.ID);
    }

    // Test employee search and removal
    Console.WriteLine("\n=== EMPLOYEE MANAGEMENT ===");
    Console.WriteLine("Searching for employee with ID 3:");
    Employee? foundEmployee = itDepartment.FindEmployeeById(3);
    if (foundEmployee != null)
    {
        Console.WriteLine($"Found: {foundEmployee}");
    }

    Console.WriteLine("\nRemoving employee with ID 6:");
    productionDepartment.RemoveEmployee(6);

    // Test updated department statistics
    Console.WriteLine("\n=== UPDATED DEPARTMENT STATISTICS ===");
    itDepartment.PrintDepartmentInfo();
    productionDepartment.PrintDepartmentInfo();

    // Test individual salary retrieval
    Console.WriteLine("\n=== INDIVIDUAL SALARY CHECKS ===");
    for (int i = 1; i <= 10; i++)
    {
        decimal? itSalary = itDepartment.GetEmployeeSalary(i);
        if (itSalary.HasValue)
        {
            Console.WriteLine($"Employee ID {i} salary: {itSalary.Value:C}");
        }
        
        decimal? productionSalary = productionDepartment.GetEmployeeSalary(i);
        if (productionSalary.HasValue)
        {
            Console.WriteLine($"Employee ID {i} salary: {productionSalary.Value:C}");
        }
    }

    // === ЗАДАНИЕ 3: ПРОВЕРКА СРЕДНЕЙ ЗАРПЛАТЫ ===
    Console.WriteLine("\n=== AVERAGE SALARY TEST ===");
    // IT отдел содержит 1 стажера (без зарплаты), он не должен влиять на расчет средней ЗП тех, кто получает деньги
    Console.WriteLine($"Средняя зарплата в IT Department: {itDepartment.GetAverageSalary():C}");
    Console.WriteLine($"Средняя зарплата в Production Department: {productionDepartment.GetAverageSalary():C}");
    // ============================================

    // Test property validation
    Console.WriteLine("\n=== PROPERTY VALIDATION TESTING ===");
    try
    {
        Worker worker = (Worker)w1;
        worker.MonthlyShifts = 40; // This should throw exception
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Property validation error: {ex.Message}");
    }

    try
    {
        Manager manager = (Manager)m1;
        manager.NumberOfEmployees = -5; // This should throw exception
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Property validation error: {ex.Message}");
    }

    try
    {
        Trainee trainee = (Trainee)t1;
        trainee.TrainingProgram = "   "; // This should throw exception
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Property validation error: {ex.Message}");
    }

    // Test adding duplicate employee
    Console.WriteLine("\n=== DUPLICATE EMPLOYEE TEST ===");
    itDepartment.AddEmployee(p1);

    // Test finding non-existent employee
    Console.WriteLine("\n=== NON-EXISTENT EMPLOYEE TEST ===");
    Employee? nonExistentEmployee = itDepartment.FindEmployeeById(999);
    if (nonExistentEmployee == null)
    {
        Console.WriteLine("Employee with ID 999 not found (as expected)");
    }

    // Test removing non-existent employee
    Console.WriteLine("\n=== REMOVE NON-EXISTENT EMPLOYEE TEST ===");
    bool removeResult = productionDepartment.RemoveEmployee(999);
    if (!removeResult)
    {
        Console.WriteLine("Failed to remove employee with ID 999 (as expected)");
    }

    // Final department overview
    Console.WriteLine("\n=== FINAL DEPARTMENT OVERVIEW ===");
    Console.WriteLine($"IT Department has {itDepartment.EmployeeCount} employees");
    Console.WriteLine($"Production Department has {productionDepartment.EmployeeCount} employees");

    // Display all remaining employees
    Console.WriteLine("\n=== ALL REMAINING EMPLOYEES ===");
    List<Employee> allItEmployees = itDepartment.GetAllEmployees();
    List<Employee> allProductionEmployees = productionDepartment.GetAllEmployees();

    Console.WriteLine("IT Department:");
    foreach (Employee employee in allItEmployees)
    {
        Console.WriteLine($"  {employee}");
    }

    Console.WriteLine("\nProduction Department:");
    foreach (Employee employee in allProductionEmployees)
    {
        Console.WriteLine($"  {employee}");
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Argument Error: {ex.Message}");
}

catch (InvalidOperationException ex)
{
    Console.WriteLine($"Operation Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected Error: {ex.Message}");
}
finally
{
    Console.WriteLine("\nProgram execution completed.");
}