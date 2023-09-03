using Assets._Project.Architecture.Core;
using Assets._Project.Input;

namespace Assets._Project.Inventory_System
{
    public class InputItemEquipController : Controller
    {
        private readonly ItemEquiper _itemEquiper;
        private readonly IPlayerInput _playerInput;

        public InputItemEquipController(ItemEquiper itemEquiper, IPlayerInput playerInput)
        {
            _itemEquiper = itemEquiper;
            _playerInput = playerInput;
        }

        protected override void OnEnable()
        {
            _playerInput.OnItemSwap += _itemEquiper.Swap;
        }

        protected override void OnDisable() 
        {
            _playerInput.OnItemSwap -= _itemEquiper.Swap;
        }
    }
}
