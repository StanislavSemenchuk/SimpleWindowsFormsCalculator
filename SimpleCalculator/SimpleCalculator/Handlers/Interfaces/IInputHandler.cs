
namespace SimpleCalculator.Handlers.Interfaces
{
    interface IInputHandler
    {
        /// <summary>
        /// Process inputed string, and if allowed perform choosen opetation
        /// </summary>
        /// <param name="inputedChar"></param>
        public void InputChecker(string inputedChar);
    }
}
