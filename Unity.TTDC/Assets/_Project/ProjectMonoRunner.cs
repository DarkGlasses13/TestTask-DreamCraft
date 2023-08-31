namespace Assets._Project
{
    public class ProjectMonoRunner : MonoRunner
    {
        private void Awake()
        {
            _runner = new ProjectRunner(canEnableAllControllers: false);
        }
    }
}