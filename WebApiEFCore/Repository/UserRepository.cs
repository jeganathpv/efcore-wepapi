using WebApiEFCore.Context;
using WebApiEFCore.Models;

namespace WebApiEFCore.Repository;

public class UserRepository
{
    private readonly CompanyContext dbContext;

    public UserRepository(CompanyContext companyContext)
    {
        this.dbContext = companyContext;
    }

    public List<User> GetAll()
    {
        return this.dbContext.Users.ToList();
    }

    public User GetById(string userId)
    {
        var guid = new Guid(userId);

        return dbContext.Users.FirstOrDefault(x => x.Id == guid);
    }

    public User GetByEmail(string email)
    {
        return dbContext.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
    }


    public User Add(User user)
    {
        var result = dbContext.Users.Add(user).Entity;
        dbContext.SaveChanges();
        return result;
    }

    public bool Delete(string userId)
    {
        var user = GetById(userId);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
        }
        return true;
    }

    public bool Update(string userId, User user)
    {
        var oldValue = GetById(userId);
        if (oldValue != null)
        {
            dbContext.Entry<User>(user).CurrentValues.SetValues(user);
            dbContext.SaveChanges();
        }
        return true;
    }
}
