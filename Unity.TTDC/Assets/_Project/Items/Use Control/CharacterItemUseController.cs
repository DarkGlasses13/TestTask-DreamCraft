using Assets._Project.Architecture.Core;
using Assets._Project.Input;
using Assets._Project.Items;

namespace Assets._Project.Use_Control
{
    public class CharacterItemUseController : Controller
    {
        private readonly IPlayerInput _playerInput;
        private readonly IItemEquiper _equip;
        private readonly ICanUseItem _user;
        private bool _isUsing;

        public CharacterItemUseController(IPlayerInput playerInput, IItemEquiper equip, ICanUseItem user)
        {
            _playerInput = playerInput;
            _equip = equip;
            _user = user;
        }

        protected override void OnEnable()
        {
            _playerInput.OnStartLooking += StartAttack;
            _playerInput.OnLookEnded += StopAttack;
        }

        private void StartAttack()
        {
            _isUsing = true;
            _equip?.Selected?.StartUse(_user);
        }

        public override void Tick()
        {
            if (_isUsing)
                _equip?.Selected?.Use(_user);

        }

        public override void FixedTick()
        {
            if (_isUsing)
                _equip?.Selected?.FixedUse(_user);
        }

        private void StopAttack()
        {
            _isUsing = false;
            _equip?.Selected?.StopUse(_user);
        }

        protected override void OnDisable()
        {
            _playerInput.OnStartLooking -= StartAttack;
            _playerInput.OnLookEnded -= StopAttack;
        }
    }
}
