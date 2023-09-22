namespace Challenge.ToolKit.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IWebRequestAdapter
    {
        byte[] GetRemoteData(string url);
    }
}
