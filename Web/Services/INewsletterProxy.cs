using System.Threading.Tasks;
using webapi.DTO;
using System.Collections.Generic;
namespace Web.Services
{
    public interface INewsletterProxy
    {
    
        Task<List<Meet>> Signup(Meet meet);
             Task<List<Meet>> UpdateList(Meet meet);
    }
}