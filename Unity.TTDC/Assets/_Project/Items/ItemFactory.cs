using Assets._Project.Projectiles;

namespace Assets._Project.Items
{
    public class ItemFactory
    {
        private readonly ProjectileController _projectileFactory;

        public ItemFactory(ProjectileController projectileController)
        {
            _projectileFactory = projectileController;
        }

        public IItem Create(IItemDatabase database, ItemReference reference) 
            => reference.Item.ConstructAndClone(database, _projectileFactory);
    }
}
