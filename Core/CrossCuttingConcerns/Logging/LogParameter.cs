namespace Core.CrossCuttingConcerns.Logging;

public class LogParameter
{
    public string Name { get; set; }
    public object Value { get; set; }
    public string Type { get; set; }

    public LogParameter()
    {
    }

    public LogParameter(string name, object value, string type):this()
    {
        Name = name;
        Value = value;
        Type = type;
    }
}
