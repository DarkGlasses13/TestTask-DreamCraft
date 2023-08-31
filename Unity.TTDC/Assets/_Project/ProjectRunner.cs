using Assets._Project.Architecture.DI;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project
{
    public class ProjectRunner : Runner, IDIContainer
    {
        private readonly List<object> _cintainer = new();

        public ProjectRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
            _controllers = new IController[]
            {

            };
        }

        public void Bind<T>(T dependency)
        {
            if (dependency != null && _cintainer.Contains(dependency) == false)
            {
                _cintainer.Add(dependency);
            }
        }

        public T GetDependency<T>()
        {
            return (T)_cintainer.SingleOrDefault(service => service is T);
        }

        public void Unbind<T>(T dependency) => _cintainer.Remove(dependency);

        protected override void OnControllersInitializedAndEnabled()
        {

        }
    }
}