using MyIoTService.Entities;

namespace MyIoTService.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserModel() { }
        public UserModel(EndUser endUser)
        {
            Id = endUser.Id;
            FirstName = endUser.FirstName;
            LastName = endUser.LastName;
            Username = endUser.Username;
            Password = endUser.Password;
        }
        public EndUser EndUserEntity()
        {
            return new EndUser()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Username = Username,
                Password = Password
            };
        }
    }
}
