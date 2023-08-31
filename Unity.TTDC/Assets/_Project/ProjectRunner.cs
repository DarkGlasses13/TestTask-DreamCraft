using Assets._Project.Architecture.DI;
using Assets._Project.Architecture.Parent_Container_Creation;
using Assets._Project.Architecture.Scene_Switching;
using Assets._Project.Input;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project
{
    public class ProjectRunner : Runner, IDIContainer
    {
        private readonly List<object> _container = new();

        public ProjectRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
        }

        protected override async Task CreateControllers()
        {
            Application.targetFrameRate = 90;
            PlayerInputController playerInput = new();
            Bind<ParentContainerCreator>(new());
            Bind<ISceneSwitcher>(new SceneSwitcher());
            Bind(playerInput);

            _controllers = new IController[]
            {
                playerInput,
            };

            await Task.CompletedTask;
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
            GetDependency<ISceneSwitcher>().ChangeAsync("Level");
        }
    }
}