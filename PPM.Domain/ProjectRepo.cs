using PPM.Model;
using PPM.Dal;

namespace PPM.Domain
{
    public class ProjectRepo :  IEntityOperation<Project>
    {
        
        
           ProjectDal projectDal = new ProjectDal();
        public void Add(Project project)
        {
           

           projectDal.AddProjectDal(project);

        }


        public List<Project> Get()
        {
            var projectList = projectDal.GetProjectsDal();
            return projectList;
        }


        public Project ViewById(int id)
        {
            var viewProjectById = projectDal.ViewProjectByIdDal(id);
            return viewProjectById;
        }

        public void Delete(int deleteid)
        {
           projectDal.DeleteProjectDal(deleteid);
        }






    }
}