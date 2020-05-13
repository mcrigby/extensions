namespace System
{
    public static class CommonExtensions
    {
        public static TSource ThrowIfNull<TSource>(this TSource source, string sourceName)
        {
            if ( source == null)
                throw new ArgumentNullException(sourceName);

            return source;
        }
    }
}
