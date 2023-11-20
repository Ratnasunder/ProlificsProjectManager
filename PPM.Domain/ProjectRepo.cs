using PPM.Model;

namespace PPM.Domain
{
    public class ProjectRepo :  IEntityOperation<Project>
    {
        
        public static List<Project> projectList = new List<Project>();
        public void Add(Project project)
        {
           

            projectList.Add(project);

        }


        public List<Project> Get()
        {
            return projectList;
        }


        public Project ViewById(int id)
        {
            var viewProjectById = projectList.FirstOrDefault(p => p.ProjectId == id);
            return viewProjectById;
        }

        public void Delete(int deleteid)
        {
            projectList.RemoveAll(item => item.ProjectId == deleteid);
        }






    }
}