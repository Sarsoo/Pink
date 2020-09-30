namespace Pink.Environment
{
    public static partial class Simulation
    {
        /// <summary>
        /// Return the simulation model instance for a class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        static public T GetModel<T>() where T : class, new()
        {
            return InstanceRegister<T>.instance;
        }
    }
}
