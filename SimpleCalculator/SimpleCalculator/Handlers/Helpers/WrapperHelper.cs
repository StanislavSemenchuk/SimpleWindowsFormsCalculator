namespace SimpleCalculator.Handlers.Helpers
{
    /// <summary>
    ///wraper for reference type to change it in another classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class WrapperHelper<T>
    {
        public T Value { get; set; }
    }
}
