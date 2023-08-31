using Assets._Project.Actors;
using Assets._Project.Actors.Player_Character;
using Assets._Project.Architecture.DI;
using Assets._Project.Architecture.Parent_Container_Creation;
using Assets._Project.Input;
using Assets._Project.Motion_Controll;
using Cinemachine;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project
{
    public class LevelRunner : Runner
    {
        private IDIContainer _container;
        private PlayerInputController _playerInput;

        public LevelRunner(bool canEnableAllControllers) : base(canEnableAllControllers)
        {
        }

        protected override async Task CreateControllers()
        {
            _container = Object.FindAnyObjectByType<ProjectMonoRunner>().Container;
            ParentContainerCreator containerCreator = _container.GetDependency<ParentContainerCreator>();
            _playerInput = _container.GetDependency<PlayerInputController>();
            Transform cameraContainer = containerCreator.Create("[ CAMERAS ]");
            Transform entityContainer = containerCreator.Create("[ ENTITIES ]");
            await new PlayerCameraLoader().LoadAndInstantiateAsync(cameraContainer);
            CinemachineVirtualCamera followingCamera = await new CharacterFollowingCameraLoader().LoadAndInstantiateAsync(cameraContainer);
            CharacterConfigLoader characterConfigLoader = new();
            CharacterFactory characterFactory = new();
            Character character = await characterFactory.GetCreatedAsync(Vector3.zero + Vector3.up * 1, Quaternion.identity, entityContainer);
            CharacterMotionController characterMotionController = new(characterConfigLoader, _playerInput, character);
            followingCamera.Follow = character.transform;

            _controllers = new IController[]
            {
                characterMotionController,
            };
        }

        protected override void OnControllersInitializedAndEnabled()
        {
            _playerInput.Enable();
        }
    }
}