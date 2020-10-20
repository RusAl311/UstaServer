using System.Collections.Generic;
using System.Threading.Tasks;
using UstaApi.Models;

namespace UstaApi.Services
{
    public interface IMasterService
    {
        Task<IEnumerable<Master>> ListAsync();
    }
}