using System.ComponentModel.DataAnnotations;

namespace WebClient
{
    public class User
    {
        public  User() { }
        public User(int p_id, string p_fname, string p_sname, string p_lname, string p_adr, string p_mail, int p_age)
        {
            Id = p_id;
            FirstName = p_fname;
            SecondName = p_sname;
            LastName = p_lname;
            Address = p_adr;
            Email = p_mail;
            Age = p_age;
        }
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}