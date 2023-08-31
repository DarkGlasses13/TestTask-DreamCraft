namespace Assets._Project
{
    public class LevelRunner : Runner
    {
        public LevelRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
            _controllers = new IController[]
            {

            };
        }

        protected override void OnControllersInitializedAndEnabled()
        {
            throw new System.NotImplementedException();
        }
    }
}