using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wasmtime.Externs;

namespace Raffle
{
    class Allocator
    {
        private ExternMemory _memory;
        private ExternFunction _malloc;
        private ExternFunction _free;

        public Allocator(ExternMemory memory, IReadOnlyList<ExternFunction> functions)
        {
            _memory = memory ??
                throw new ArgumentNullException(nameof(memory));

            _malloc = functions
                .Where(f => f.Name == "__wbindgen_malloc")
                .SingleOrDefault() ??
                    throw new ArgumentException("Unable to resolve malloc function.");

            _free = functions
                .Where(f => f.Name == "__wbindgen_free")
                .SingleOrDefault() ??
                    throw new ArgumentException("Unable to resolve free function.");
        }

        public int AllocateBytes(byte[] data)
        {
            int addr = Allocate(data.Length);
            var slice = _memory.Span.Slice(addr);
            data.CopyTo(slice);
            return addr;
        }

        public int AllocateBytes(Span<byte> span)
        {
            int addr = Allocate(span.Length);
            var slice = _memory.Span.Slice(addr);
            span.CopyTo(slice);
            return addr;
        }

        public int AllocateBytes(Memory<byte>[] memories)
        {
            int size = memories.Sum(s => s.Length);
            int addr = Allocate(size);
            var slice = _memory.Span.Slice(addr);
            foreach (var segment in memories) 
            {
                segment.Span.CopyTo(slice);
            }
            return addr;
        }

        public int Allocate(int length)
        {
            return (int)_malloc.Invoke(length);
        }

        public (int Address, int Length) AllocateString(string str)
        {
            var length = Encoding.UTF8.GetByteCount(str);

            int addr = Allocate(length);

            _memory.WriteString(addr, str);

            return (addr, length);
        }

        public void Free(int address, int length)
        {
            _free.Invoke(address, length);
        }
    }
}