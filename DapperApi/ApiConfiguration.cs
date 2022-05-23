namespace Api_mini
{
    public static class ApiConfiguration
    {


        public static void apiconfiguration(this WebApplication app)
        {
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users/{Id}", GetUser);
            app.MapPost("/Users", Insert);
            app.MapDelete("/Users/", Delete);
            app.MapPut("/Users", Update);
        }


        public static async Task<IResult> GetUsers(IUserData user)
        {
            try
            {
                return Results.Ok(await user.GetUsers());

            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
            
        }
        public static async Task<IResult> GetUser(this IUserData user, int id)
        {
            try
            {
                
                var Result = await user.GetUser(id);
                if(Result==null) return Results.NotFound();
                else return Results.Ok(Result);


            }
            catch (Exception ex) { return Results.Problem(ex.Message); }
        }

        public static async Task<IResult> Insert(this IUserData user,UserModel model)
        {
            try
            {
                await user.InsertUser(model);
                return Results.Ok();

            }
            catch (Exception ex) { return Results.Problem(ex.Message); }

        }
        public static async Task<IResult> Delete(this IUserData user, int Id)
        {
            try
            {
                await user.DeleteUser(Id);
                return Results.Ok();

            }
            catch (Exception ex) { return Results.Problem(ex.Message); }

        }
        public static async Task<IResult> Update(this IUserData user, UserModel model)
        {
            try
            {
                await user.UpdateUser(model);
                return Results.Ok();

            }
            catch (Exception ex) { return Results.Problem(ex.Message); }

        }

    }
}


