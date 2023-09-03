using Assets._Project.Actors;
using Assets._Project.Actors.Player_Character;
using Assets._Project.Architecture.DI;
using Assets._Project.Architecture.Parent_Container_Creation;
using Assets._Project.Input;
using Assets._Project.Items;
using Assets._Project.Motion_Control;
using Cinemachine;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project
{
    public class LevelRunner : Runner
    {
        private IDIContainer _container;
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
            _playerInput = _container.GetDependency<PlayerInputController>();
            Transform cameraContainer = containerCreator.Create("[ CAMERAS ]");
            Transform entityContainer = containerCreator.Create("[ ENTITIES ]");
            Camera playerCamera = await new PlayerCameraLoader().LoadAndInstantiateAsync(cameraContainer);
            CinemachineVirtualCamera followingCamera = await new CharacterFollowingCameraLoader().LoadAndInstantiateAsync(cameraContainer);
            CharacterFactory characterFactory = new();
            Character character = await characterFactory.GetCreatedAsync(Vector3.zero + Vector3.up * 1, Quaternion.identity, entityContainer);
            _inventory = _container.GetDependency<Inventory>();
            InputItemEquipController inputItemSwapController = new(new(selected: 0, _inventory, character), _playerInput);
            CharacterMotionController characterMotionController = new(characterConfig, _playerInput, playerCamera, character);
            followingCamera.Follow = character.transform;

            _controllers = new IController[]
            {
                characterMotionController,
                inputItemSwapController,
            };
        }

        protected override void OnControllersInitializedAndEnabled()
        {
            _inventory.TryAdd("wpn_Ptl", "wpn_Lsr", "wpn_Sgn", "wpn_Knf");
            _playerInput.Enable();
        }
    }
}