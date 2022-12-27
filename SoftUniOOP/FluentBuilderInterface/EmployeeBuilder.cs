namespace FluentBuilderInterface
{
    public class EmployeeBuilderDirector 
        : EmployeeSalaryBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector NewEmployee => new();
    }

    public class EmployeeSalaryBuilder<T> 
        : EmployeePositionBuilder<EmployeeSalaryBuilder<T>> where T 
        : EmployeeSalaryBuilder<T>
    {
        public T SetSalary(double salary)
        {
            employee.Salary = salary;
            return (T)this;
        }
    }

    public class EmployeePositionBuilder<T> 
        : EmployeeInfoBuilder<EmployeePositionBuilder<T>> where T 
        : EmployeePositionBuilder<T>
    {
        public T SetPosition(string position)
        {
            employee.Position = position;
            return (T)this;
        }
    }

    public class EmployeeInfoBuilder<T> 
        : EmployeeBuilder where T 
        : EmployeeInfoBuilder<T>
    {
        public T SetName(string name)
        {
            employee.Name = name;
            return (T)this;
        }
    }

    public abstract class EmployeeBuilder
    {
        protected Employee employee;

        public EmployeeBuilder()
        {
            employee = new Employee();
        }

        public Employee Build() => employee;
    }
}
