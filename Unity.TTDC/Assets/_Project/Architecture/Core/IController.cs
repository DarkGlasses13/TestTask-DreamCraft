using System.Threading.Tasks;

public interface IController : IRunnable
{
    bool Enabled { get; }

    Task InitializeAsync();
    void Initialize();
}