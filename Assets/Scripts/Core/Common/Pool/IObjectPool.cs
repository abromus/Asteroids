namespace Asteroids.Core
{
    public interface IObjectPool<T> where T : class, IPoolable
    {
        public T Get();

        public void Release(T pooledObject);

        public void Clear();
    }
}
