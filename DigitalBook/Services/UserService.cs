using DigitalBook.Model;

namespace DigitalBook.Services
{
    public class UserService : IUserService
    {
        private readonly ConnectionDBContext _connectionDBContext;

        public UserService(ConnectionDBContext connectionDBContext)
        {
            _connectionDBContext = connectionDBContext;
        }
       
        //private readonly ConnectionDBContext _connectionDBContext;

        //public UserService(ConnectionDBContext connectionDBContext)
        //{
        //    _connectionDBContext = connectionDBContext;
        //}

        public string AddUser(User user)
        {
            string result = string.Empty;
            try
            {
                _connectionDBContext.Users.Add(user);
                _connectionDBContext.SaveChanges();
                result = "User Details Saved";
            }
            catch(Exception ex)
            {
                result = $"User details not saved{ex.Message}";    
            }
            return result;
            
        }

        public string ModifiedUser(int userId, User user)
        {
          var userlist =  _connectionDBContext.Users.Where(x=>x.userId==userId).SingleOrDefault();
            string result = string.Empty;   
            if (userlist != null)
            {
                try
                {
                    userlist.password = user.password;
                    userlist.userType = user.userType;
                    _connectionDBContext.SaveChanges();
                    result = "Details modified";
                   
                }
                catch(Exception ex)
                {
                    result = $"User Details not modified{ex.Message}";
                }
                
            }
            else
            {
                result = "UserId is not exists";
            }
            
            return result;
        }
        public string DeletedUser(int userId)
        {
            string result = string.Empty;
            var userlist = _connectionDBContext.Users.Where(x=>x.userId==userId).SingleOrDefault();
            if (userlist != null)
            {
                try
                {
                    _connectionDBContext.Remove(userlist);
                    _connectionDBContext.SaveChanges();
                    result = "UserId deleted";

                }
                catch (Exception Ex)
                {
                    result = $"UserId not exists{Ex.Message}";
                }
            }
            return result;
        }

    }
}
