namespace Api_mini.Data;

using Api_mini.DbAccess;
using Api_mini.Models;
public class UserData : IUserData
{
    private readonly ISqlDataAccess _dataAccess;
    public UserData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public Task<IEnumerable<UserModel>> GetUsers() =>

         _dataAccess.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });


    public async Task<UserModel?> GetUser(int id)
    {
        var result = await _dataAccess.LoadData<UserModel, dynamic>("dbo.spGet_ById", new { Id = id });
        return result.FirstOrDefault();
    }



    public Task InsertUser(UserModel user) => _dataAccess.SaveData("spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) => _dataAccess.SaveData("spUser_Update", new { user });

    public Task DeleteUser(int id) => _dataAccess.SaveData("spUser_Delete", new { Id = id });

}
