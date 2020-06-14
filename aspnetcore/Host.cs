using System.Security.Cryptography;
using Wasmtime;

namespace Raffle
{
    class WasmHost : IHost
    {
        // These are from the current WASI proposal.
        const int WASI_ERRNO_NOTSUP = 58;
        const int WASI_ERRNO_SUCCESS = 0;

        const int WASI_ERRNO_NOSYS = 52;

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

        [Import("environ_get", Module = "wasi_snapshot_preview1")]
        public int GetEnvironmentVariable(int environ, int environ_buf)
        {
            return WASI_ERRNO_NOSYS;
        }

        [Import("environ_sizes_get", Module = "wasi_snapshot_preview1")]
        public int GetEnvironmentVariableSize(int environc, int environ_buf_size)
        {
            return WASI_ERRNO_NOSYS;
        }

        [Import("proc_exit", Module = "wasi_snapshot_preview1")]
        public void TerminateProcess(int rval)
        {
            // yeah, like I'm gonna let some WASM code terminate my entire process...
        }
    }
}
