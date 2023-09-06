using Assets._Project.Architecture.Core;
using Assets._Project.Input;

namespace Assets._Project.Items.Equip_Control
{
    public class CharacterItemEquipController : Controller, IItemEquiper
    {
        private readonly ItemEquiper _itemEquiper;
        private readonly IPlayerInput _playerInput;

        public IItem Selected => _itemEquiper.Selected;

        public CharacterItemEquipController(ItemEquiper itemEquiper, IPlayerInput playerInput)
        {
            _itemEquiper = itemEquiper;
            _playerInput = playerInput;
        }

        protected override void OnEnable()
        {
            _playerInput.OnItemSwap += Swap;
        }

        protected override void OnDisable() 
        {
            _playerInput.OnItemSwap -= Swap;
        }

        public void Swap(float value = 0) => _itemEquiper.Swap(value);
    }
}
