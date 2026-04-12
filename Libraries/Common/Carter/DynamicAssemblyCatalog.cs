using System.Reflection;
using Carter;

namespace Common.Carter;

public class DynamicAssemblyCatalog(Assembly assembly) : DependencyContextAssemblyCatalog
{
    public override IReadOnlyCollection<Assembly> GetAssemblies()
    {
        return [assembly];
    }
}
