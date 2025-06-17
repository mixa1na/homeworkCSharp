namespace HospitalPatientManagement
{
    /// <summary>
    /// Handles key press events and notifies registered handlers.
    /// </summary>
    public class KeyEventDispatcher
    {
        private readonly List<Action<ConsoleKey>> _handlers = new List<Action<ConsoleKey>>();

        /// <summary>
        /// Event triggered when a key is pressed.
        /// </summary>
        public event Action<ConsoleKey> KeyPressed
        {
            add => _handlers.Add(value);
            remove => _handlers.Remove(value);
        }

        /// <summary>
        /// Dispatches the key press event to all registered handlers.
        /// </summary>
        public void Dispatch(ConsoleKey key)
        {
            foreach (var handler in _handlers)
            {
                handler.Invoke(key);
            }
        }
    }
}