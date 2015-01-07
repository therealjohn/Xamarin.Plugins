using Database.Plugin.Abstractions;
using System;

namespace Database.Plugin
{
  /// <summary>
  /// Cross platform Database implemenations
  /// </summary>
  public class CrossDatabase
  {
    static Lazy<IDatabase> Implementation = new Lazy<IDatabase>(() => CreateDatabase(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IDatabase Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IDatabase CreateDatabase()
    {
#if PORTABLE
        return null;
#else
        return new DatabaseImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
