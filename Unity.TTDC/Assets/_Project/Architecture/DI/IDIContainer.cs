namespace Assets._Project.Architecture.DI
{
    public interface IDIContainer
    {
        void Bind<T>(T dependency);
        T GetDependency<T>();
        void Unbind<T>(T dependency);
    }
}