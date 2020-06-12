using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wasmtime;

namespace Raffle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var engine = new Engine();
            using var store = engine.CreateStore();
            using var module = store.CreateModule(@"..\rust\target\wasm32-wasi\release\raffle_core.wasm");
            using var instance = module.Instantiate(new WasmHost());

            var memory = instance.Externs.Memories.SingleOrDefault() ??
                throw new InvalidOperationException("Module must export a memory.");

            var allocator = new Allocator(memory, instance.Externs.Functions);
            
            string data = @"Magnus,Mårtensson
Alon,Fliess
Eran,Stiller
Amir,Zuker
Vitali,Zaidman
Erez,Pedro
Alex,Pshul
Moaid,Hathot
Ronen,Levinson
Nir,Dobovizki
Eyal,Ellenbogen
Michael,Donkhin
Vered,Flis Segal";
        
            (int inputAddress, int inputLength) = allocator.AllocateString(data);

            try
            {
                object[] results = (instance as dynamic).text_raffle(inputAddress, data.Length);

                var outputAddress = (int)results[0];
                var outputLength = (int)results[1];

                try
                {
                    string winner = memory.ReadString(outputAddress, outputLength);
                    Console.WriteLine($"The winner is... {winner}!");
                }
                finally
                {
                    allocator.Free(outputAddress, outputLength);
                }
            }
            finally
            {
                allocator.Free(inputAddress, data.Length);
            }
        }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //         });
    }
}
