using MvcLibraryApp.McvWebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MvcLibraryApp.McvWebUI.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            LibraryAppDbEntities db = new LibraryAppDbEntities();
            var result = db.AdminLogins.FirstOrDefault(x => x.Email == username);
            var result1 = db.Members.FirstOrDefault(x => x.Mail == username);
            if (result !=null)
            {
               
                return new string[] { result.AdminRole };
            }
            else if (result1 !=null)
            {
                
                return new string[] { result1.Role };
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}