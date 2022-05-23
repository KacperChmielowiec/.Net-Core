
namespace Api_mini.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parametrs, string connectionId = "Default");
        Task SaveData<U>(string procedure, U parametrs, string connectionId = "Default");
    }
}