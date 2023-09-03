namespace Assets._Project.Items
{
    public interface IItemUseStrategy
    {
        void Start(ICanUseItem user);
        void Update(ICanUseItem user);
        void FixedUpdate(ICanUseItem user);
        void Stop(ICanUseItem user);
    }
}
