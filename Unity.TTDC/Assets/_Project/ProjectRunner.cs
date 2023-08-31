using Assets._Project.Architecture.DI;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project
{
    public class ProjectRunner : Runner, IDIContainer
    {
        private readonly List<object> _container = new();

        public ProjectRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
            _controllers = new IController[]
            {

            };
        }

        public void Bind<T>(T dependency)
        {
            if (dependency != null && _container.Contains(dependency) == false)
            {
                _container.Add(dependency);
            }
        }

        public T GetDependency<T>()
        {
            return (T)_container.SingleOrDefault(service => service is T);
        }

        public void Unbind<T>(T dependency) => _container.Remove(dependency);

        protected override void OnControllersInitializedAndEnabled()
        {

        }
    }
}