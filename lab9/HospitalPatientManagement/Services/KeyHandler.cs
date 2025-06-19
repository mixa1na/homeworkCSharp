namespace HospitalPatientManagement.Services
{
    /// <summary>
    /// Delegate type for methods that handle key press events.
    /// </summary>
    /// <param name="key">Character representing the key pressed.</param>
    public delegate void KeyPressedHandler(char key);

    /// <summary>
    /// Provides an event-based mechanism to notify subscribers about key presses.
    /// </summary>
    public class KeyHandler
    {
        private event KeyPressedHandler _keyPressed;

        /// <summary>
        /// Event to subscribe or unsubscribe handlers for key press notifications.
        /// </summary>
        public event KeyPressedHandler KeyPressed
        {
            add { _keyPressed += value; }
            remove { _keyPressed -= value; }
        }

        /// <summary>
        /// Raises the KeyPressed event, notifying all subscribers of the key press.
        /// </summary>
        /// <param name="key">Character of the key that was pressed.</param>
        public void OnKeyPressed(char key)
        {
            if (_keyPressed != null)
            {
                _keyPressed.Invoke(key);
            }
        }
    }
}
