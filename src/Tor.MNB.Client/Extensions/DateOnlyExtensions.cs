namespace Tor.Mnb.Client.Extensions
{
    internal static class DateOnlyExtensions
    {
        internal static string ToMnbFormat(this DateOnly date)
            => date.ToString("O");
    }
}
