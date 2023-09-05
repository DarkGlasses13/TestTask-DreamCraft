using Assets._Project.Architecture.Core;
using Assets._Project.Input;

namespace Assets._Project.Items.Use_Control
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
            _playerInput.OnStartLooking += StartUse;
            _playerInput.OnLookEnded += StopUse;
        }

        private void StartUse()
        {
            _isUsing = true;
        }

        //public override void Tick()
        //{
        //    if (_isUsing)
        //        _equip?.Selected?.Use(_user);

        //}

        //public override void FixedTick()
        //{
        //    if (_isUsing)
        //        _equip?.Selected?.FixedUse(_user);
        //}

        private void StopUse()
        {
            _isUsing = false;
            _equip?.Selected?.Use(_user);
        }

        protected override void OnDisable()
        {
            _playerInput.OnStartLooking -= StartUse;
            _playerInput.OnLookEnded -= StopUse;
        }
    }
}
