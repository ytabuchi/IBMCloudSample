using System;
using System.Threading.Tasks;

namespace CloudServices.Core
{
    public interface ICloudService
    {
        Task<string> GetResponseAsync(string input);
    }
}
