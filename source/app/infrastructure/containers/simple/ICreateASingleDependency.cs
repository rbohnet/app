namespace app.infrastructure.containers.simple
{
    public interface ICreateASingleDependency
    {
        object create();

        void as_singleton();
    }
}