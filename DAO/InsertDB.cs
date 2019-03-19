using LogLibrary;
using System;

namespace DAO
{
    public class InsertDB
    {
        /// <summary>
        /// Inserts the object to the databse using the ORM
        /// </summary>
        /// <param name="user"> the object usert you want to insert to the database </param>
        public static void Excecute(User user)
        {
            try
            {
                using (UsersDBEntities1 db = new UsersDBEntities1())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return;
                }
            }
            catch (Exception e)
            {
                Log.showErrorMessage("Can't insert the object to the DB: " + e.Data);
            }
            
        }

    }
}
