using PPM.Model;
using PPM.Dal;
namespace PPM.Domain
{

    public class RolesRepo : IEntityOperation<Role>
    {


       RoleDal roleDal = new RoleDal();
        public  void Add(Role role)
        {
          
         roleDal.AddRoleDal(role);

        }


        public  List<Role> Get()
        {
            var rolesList = roleDal.GetRoleDal();
            return rolesList;
        }

        public  Role ViewById(int roleId)
        {
            var viewRoleById = roleDal.ViewRoleByIdDal(roleId);
            return viewRoleById;
        }

         public  void Delete(int deleteId)
        {
           roleDal.DeleteRoleDal(deleteId);
        }

    }
}