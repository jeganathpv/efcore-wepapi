using WebApiEFCore.BusinessObjects;
using WebApiEFCore.Models;
using WebApiEFCore.Repository;

namespace WebApiEFCore.Services;

public class UserService
{
    private readonly UserRepository userRepository;

    public UserService(UserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public List<User> GetUsers()
    {
        return this.userRepository.GetAll();
    }

    public UserResponse GetUserDetailByEmailId(string emailId)
    {
        var user = this.userRepository.GetByEmail(emailId);
        var result = new UserResponse();
        if(user != null)
        {
            result.IsAvailable = true;
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
        }
        else
        {
            result.FirstName = string.Empty;
            result.LastName = string.Empty;
        }

        return result;
    }

    public User GetUserById(string id)
    {
        return this.userRepository.GetById(id);
    }

    public User AddUser(User user)
    {
        return this.userRepository.Add(user);
    }

    public bool DeleteUser(string id)
    {
        if(id == null)
        {
            return false;
        }

        return this.userRepository.Delete(id);
    }

    public bool UpdateUser(string id, User user)
    {
        return this.userRepository.Update(id, user);
    }
}
