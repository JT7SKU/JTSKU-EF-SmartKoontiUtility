using Nethereum.KeyStore;
using Nethereum.KeyStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraktit
{
    internal class EFKeystore
    {
        public KeyStoreService keyStoreService = new KeyStoreService();
        public Task EfCrypt()
        {
            var scryptParams = new ScryptParams { Dklen = 32, N = 26144, R = 1, P = 8 };
            return Task.CompletedTask;

        }
    }
}
