namespace ISpire.Core.Helpers;

public static class EnvironmentHelper
{
    public static string? GetEnvironmentVariableOrFile(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);

        if (!string.IsNullOrEmpty(value) && value.StartsWith("/"))
        {
            try
            {
                if (File.Exists(value))
                {
                    return File.ReadAllText(value).Trim();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error reading file {value}: {e.Message}");
            }
        }

        return value;
    }
}
