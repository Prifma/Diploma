using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.DataBase.Enities
{
    public class User
    {
        [MaxLength(20)]
        public string Id { get; set; }
        public UserType UserType { get; set; }
    }
}
