

using System.Drawing;

namespace BitacoraAPP.Services

{
    public interface ICommon
    {
        Task<string> GetImageHttpClientAsync(Uri uri);

    }

}
