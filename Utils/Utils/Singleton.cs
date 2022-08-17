namespace Utils.Utils
{
    /// <summary>
    /// Base singleton class
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    public abstract class Singleton<T> 
        where T: new()
    {
        private static T _instance;
        
        public static T I
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                    (_instance as Singleton<T>)?.Init();
                }

                return _instance;
            }
        }

        protected Singleton() {}

        protected abstract void Init();
    }
}