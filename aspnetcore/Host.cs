using System.Security.Cryptography;
using Wasmtime;

namespace Raffle
{
    class WasmHost : IHost
    {
        // These are from the current WASI proposal.
        const int WASI_ERRNO_NOTSUP = 58;
        const int WASI_ERRNO_SUCCESS = 0;

        private RNGCryptoServiceProvider _random = new RNGCryptoServiceProvider();

        public Instance Instance { get; set; }

        [Import("fd_write", Module = "wasi_snapshot_preview1")]
        public int WriteFile(int fd, int iovs, int iovs_len, int nwritten)
        {
            return WASI_ERRNO_NOTSUP;
        }

        [Import("random_get", Module = "wasi_snapshot_preview1")]
        public int GetRandomBytes(int buf, int buf_len)
        {
            _random.GetBytes(Instance.Externs.Memories[0].Span.Slice(buf, buf_len));
            return WASI_ERRNO_SUCCESS;
        }

        
    }
}
