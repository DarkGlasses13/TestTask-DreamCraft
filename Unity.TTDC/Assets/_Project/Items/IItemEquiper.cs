namespace Assets._Project.Items
{
    public interface IItemEquiper
    {
        IItem Selected { get; }

        void Swap(float value = 0);
    }
}