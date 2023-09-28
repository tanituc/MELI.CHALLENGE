namespace Challenge.ToolKit.Interfaces
{
    using System.Net.Http.Headers;
    public interface IWebRequestAdapter
    {
        public byte[] GetRemoteData(string url);
        public byte[] GetRemoteData(string url, Dictionary<string, string> headers);
    }
}
