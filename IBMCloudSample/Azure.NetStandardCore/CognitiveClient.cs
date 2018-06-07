using System;
using System.Threading.Tasks;
using CloudServices.Core;

namespace Azure.NetStandardCore
{
    public class CognitiveClient : ICloudService
    {
        public Task<string> GetResponseAsync(string input)
        {
            return Task.FromResult($"echo+ {input}");
        }
    }
}
