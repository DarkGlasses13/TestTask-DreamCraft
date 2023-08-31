using Assets._Project.Architecture.DI;

namespace Assets._Project
{
    public class ProjectMonoRunner : MonoRunner
    {
        public IDIContainer Container { get; private set; }

        private void Awake()
        {
            ProjectRunner runner = new(canEnableAllControllers: false);
            Container = runner;
            _runner = runner;
        }
    }
}