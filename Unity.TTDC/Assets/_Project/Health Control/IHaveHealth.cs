namespace Assets._Project.Health_Control
{
    public interface IHaveHealth
    {
        void Kill();
        void TakeDamage(int damage);
        void Restore(int value);
    }
}
