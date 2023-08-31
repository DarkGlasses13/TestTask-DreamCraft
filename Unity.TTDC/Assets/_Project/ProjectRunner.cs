using Assets._Project.Actors.Player_Character;
using Assets._Project.Architecture.DI;
using Assets._Project.Architecture.Parent_Container_Creation;
using Assets._Project.Architecture.Scene_Switching;
using Assets._Project.Input;
using Assets._Project.Inventory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project
{
    public class ProjectRunner : Runner, IDIContainer
    {
        private readonly List<object> _container = new();
        private InventoryController _inventoryController;

        public ProjectRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
        }

        protected override async Task CreateControllers()
        {
            Application.targetFrameRate = 90;
            CharacterConfig characterConfig = await new CharacterConfigLoader().LoadAsync();
            IItemDatabase itemDatabase = await new ItemDatabaseLoader().LoadAsync();
            PlayerInputController playerInput = new();
            _inventoryController = new(characterConfig.WeaponSlotsCount, itemDatabase);
            Bind<ParentContainerCreator>(new());
            Bind<ISceneSwitcher>(new SceneSwitcher());
            Bind(characterConfig);
            Bind(itemDatabase);
            Bind(playerInput);
            Bind(_inventoryController);

            _controllers = new IController[]
            {
                playerInput,
                _inventoryController,
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
            _inventoryController.TryAdd("wpn_Blt", "wpn_Sgn", "wpn_Lsr");
            GetDependency<ISceneSwitcher>().ChangeAsync("Level");
        }
    }
}