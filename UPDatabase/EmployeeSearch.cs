using System;
using System.Collections.Generic;
using System.Text;
using UPTableDb;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UPDatabase
{
    public static class EmployeeSearch
    {
        #region QueryExtensions
        public static IQueryable<Employee> GetManyEmployeeByFirstName(this IQueryable<Employee> list, string firstName)
            => list.Where(c => c.FirstName == firstName);

        public static IQueryable<Employee> GetManyEmployeeByLastName(this IQueryable<Employee> list, string lastName)
            => list.Where(c => c.LastName == lastName);

        public static IQueryable<Employee> GetManyEmployeeByMiddleName(this IQueryable<Employee> list, string middleName)
            => list.Where(c => c.MiddleName == middleName);
        #endregion

        #region EmployeeExtensions
        public static Employee GetEmployeeByFirstName(this IQueryable<Employee> list, string firstName)
           => list.Where(c => c.FirstName == firstName).SingleOrDefault();
        public static Employee GetEmployeeByLastName(this IQueryable<Employee> list, string lastName)
            => list.Where(c => c.LastName == lastName).SingleOrDefault();
        public static Employee GetEmployeeByMiddleName(this IQueryable<Employee> list, string middleName)
            => list.Where(c => c.MiddleName == middleName).SingleOrDefault();
        #endregion
    }
}
