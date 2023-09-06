using Assets._Project.Actors;
using Assets._Project.Actors.Player_Character;
using Assets._Project.Architecture.DI;
using Assets._Project.Architecture.Parent_Container_Creation;
using Assets._Project.Camera_Control;
using Assets._Project.Input;
using Assets._Project.Items;
using Assets._Project.Items.Equip_Control;
using Assets._Project.Items.Use_Control;
using Assets._Project.Motion_Control;
using Assets._Project.Projectiles;
using Cinemachine;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets._Project
{
    public class LevelRunner : Runner
    {
        private IDIContainer _container;
        private ItemDatabase _itemDatabase;
        private PlayerInputController _playerInput;
        private Inventory _inventory;

        public LevelRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
        }

        protected override async Task CreateControllers()
        {
            _container = Object.FindAnyObjectByType<ProjectMonoRunner>().Container;
            ParentContainerCreator containerCreator = _container.GetDependency<ParentContainerCreator>();
            CharacterConfig characterConfig = _container.GetDependency<CharacterConfig>();
            IList<ItemReference> loadedItemReferences = await Addressables.LoadAssetsAsync<ItemReference>("Item Data", null).Task;
            ProjectileController projectileController = new();
            ItemFactory itemFactory = new(projectileController);
            _itemDatabase = new ItemDatabase(itemFactory, loadedItemReferences.ToArray());
            _playerInput = _container.GetDependency<PlayerInputController>();
            Transform cameraContainer = containerCreator.Create("[ CAMERAS ]");
            Transform entityContainer = containerCreator.Create("[ ENTITIES ]");
            Camera playerCamera = await new PlayerCameraLoader().LoadAndInstantiateAsync(cameraContainer);
            CinemachineVirtualCamera followingCamera = await new CharacterFollowingCameraLoader().LoadAndInstantiateAsync(cameraContainer);
            CharacterFactory characterFactory = new();
            Character character = await characterFactory.GetCreatedAsync(Vector3.zero + Vector3.up * 1, Quaternion.identity, entityContainer);
            _inventory = _container.GetDependency<Inventory>();
            CharacterMotionController characterMotionController = new(characterConfig, _playerInput, playerCamera, character);
            CharacterItemEquipController characterItemEquipController = new(new(selected: 0, _inventory, character), _playerInput);
            CharacterItemUseController characterItemUseController = new(_playerInput, characterItemEquipController, character);
            followingCamera.Follow = character.transform;

            _controllers = new IController[]
            {
                characterMotionController,
                characterItemEquipController,
                projectileController,
                characterItemUseController,
            };
        }

        protected override void OnControllersInitializedAndEnabled()
        {
            _inventory.TryAdd(_itemDatabase.GetByIDs("wpn_Ptl", "wpn_Sgn", "wpn_Mcg"));
            _playerInput.Enable();
        }
    }
}