namespace exe1HW.Models
{
    public class User
    {

        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public  int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.Insert(this);
        }
        public List<User> ReadByEmail(string email,string password)
        {
            DBservices dbs = new DBservices();
            return dbs.Read(email, password);
        }
        public int Update ()
        {
            DBservices dbs = new DBservices();
            return dbs.Update(this);
        }
        public List<User> UpdateAdmin()
        {
            DBservices dbs = new DBservices();
            return dbs.UpdateAdmin(this);
        }
        public List<User> Read ()
        {
            DBservices dbs = new DBservices();
            return dbs.Readusers();
        }
        public List<User> Delete(string email)
        {
            try
            {
                DBservices dbs = new DBservices();
                return dbs.Delete(email);
            }
            catch (Exception ex)
            {
                return new List<User>();
                
            }
            
        }
    }
}
