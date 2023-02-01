using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task<IEnumerable<UserModel>> GetUsers { get; }
        Task DeleteUser(int id);
        Task<UserModel> GetUser(int id);
        Task InsertUser(UserModel user);
        Task UpdateUser(UserModel user);
    }
}