using PPM.Model;
namespace PPM.Domain
{

    public class RolesRepo : IEntityOperation<Role>
    {


        public static List<Role> rolesList = new List<Role>();
        public  void Add(Role role)
        {
          
            rolesList.Add(role);

        }


        public  List<Role> Get()
        {
            return rolesList;
        }

        public  Role ViewById(int roleId)
        {
            var viewRoleById = rolesList.FirstOrDefault(p => p.RoleId == roleId);
            return viewRoleById;
        }

         public  void Delete(int deleteId)
        {
            rolesList.RemoveAll(item => item.RoleId == deleteId);
        }

    }
}