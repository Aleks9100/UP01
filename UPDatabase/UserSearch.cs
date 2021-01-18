using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UPTableDb;

namespace UPDatabase
{
    public static class UserSearch
    {
        public static IQueryable<User> GetManyUserByLogin(this IQueryable<User> list, string login)
           => list.Where(c => c.Login == login);

        public static IQueryable<User> GetManyUserByStatus(this IQueryable<User> list, string status)
            => list.Where(c => c.Status == status);

        public static User GetUserByLogin(this IQueryable<User> list, string login)
           => list.GetManyUserByLogin(login).SingleOrDefault();
        public static User GetUserByStatus(this IQueryable<User> list, string status)
            => list.GetManyUserByStatus(status).SingleOrDefault();
    }
}
