namespace C_.Concepts;
//CONCEPTS:
//Is SQL like syntax in c#
//Query any type of collections that inherit from IEnumerable or IQueriable
//Example: arrays, strings, List<>, HashSet<>, Dictionary<T>
public class LINQSpecs
{
    private List<Empleado> empleados = new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Ana", Departamento = "TI", Salario = 3000, Edad = 28 },
            new Empleado { Id = 2, Nombre = "Luis", Departamento = "Ventas", Salario = 2500, Edad = 35 },
            new Empleado { Id = 3, Nombre = "Carlos", Departamento = "TI", Salario = 3200, Edad = 30 },
            new Empleado { Id = 4, Nombre = "Elena", Departamento = "RRHH", Salario = 2700, Edad = 40 },
            new Empleado { Id = 5, Nombre = "Javier", Departamento = "Ventas", Salario = 2800, Edad = 29 },
            new Empleado { Id = 6, Nombre = "Javier2", Departamento = "Ventas", Salario = 2700, Edad = 55 }
        };
    [Fact]
    public void Members()
    {
        var filterByDep = empleados.Where(emp => emp.Departamento.Equals("Ventas"));
        Assert.Equal(3, filterByDep.Count());


        var transformObj= empleados.Select(emple => new Empleado
        {
            Nombre = emple.Nombre.ToUpper(),
            Departamento = emple.Departamento.ToLower(),
        }).ToArray();
        Assert.Equal("JAVIER", transformObj[4].Nombre);
        Assert.Equal("ventas", transformObj[4].Departamento);


        var anyRes = this.empleados.Any(empl => empl.Edad == 29);
        Assert.True(anyRes);

        var allRes = this.empleados.All(empl => empl.Id != 0);
        Assert.True(allRes);

        var count = this.empleados.Count();
        Assert.Equal(6, count);
        
        var Sum = this.empleados.Sum(empl => empl.Edad);
        Assert.Equal(217, Sum);

        var Min = this.empleados.Min(empl => empl.Edad);
        Assert.Equal(28, Min);

        var Max = this.empleados.Max(empl => empl.Edad);
        Assert.Equal(55, Max);

        var average = this.empleados.Average(empl => empl.Edad);

        var orderBy = this.empleados.OrderBy(empl => empl.Departamento)
            .ThenByDescending(empl => empl.Edad);

        var orderBydesc = this.empleados.OrderByDescending(empl => empl.Departamento)
            .ThenBy(empl => empl.Edad);

    }

}


internal class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Departamento { get; set; }
    public double Salario { get; set; }
    public int Edad { get; set; }
}