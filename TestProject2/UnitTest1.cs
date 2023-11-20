using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Xml;
using PPM.Domain;
using PPM.Model;
using NUnit.Framework;
using PPM.UiConsole;
using System.Data.Common;



namespace TestProject2;

public class Tests
{
    // [SetUp]
    // public void Setup()
    // {
    // }
    ProjectRepo projectRepo = new ProjectRepo();
    EmployeeProjectRepo employeeProjectRepo = new EmployeeProjectRepo();
    EmployeeRepo employeeRepo = new EmployeeRepo();
    RolesRepo rolesRepo = new RolesRepo();


    [Test]
    public void AddProjectValidTest()
    {
        Project project = new Project()
        {
            ProjectId = 01,
            ProjectName = "Nano",
            StartDate = new DateTime(2000, 01, 01),
            EndDate = new DateTime(2001,02,02)
        };
        projectRepo.Add(project);
            // Assert.That(ProjectRepo.projectList.Count, Is.EqualTo(1));

            // Assert.That(ProjectRepo.projectList[0].ProjectName, Is.EqualTo("Nano"));



        Project projectObj = ProjectRepo.projectList.Find(p => p.ProjectId == project.ProjectId);

        Assert.IsNotNull(projectObj);
        Assert.That(projectObj.ProjectId, Is.EqualTo(project.ProjectId));
        Assert.That(projectObj.ProjectName, Is.EqualTo(project.ProjectName));
        Assert.That(projectObj.StartDate, Is.EqualTo(project.StartDate));
        Assert.That(projectObj.EndDate, Is.EqualTo(project.EndDate));
    }




    [TestCase(02, "Nano")]
    // [TestCase(04, "nanao")]
    public void AddProjectInvalidTest(int projectId, string projectName)
    {
        try
        {
            Project projectInvalid = new Project()
            {
                ProjectId = 02,
                ProjectName = "Nano",
                StartDate = new DateTime(2000, 2, 2),
                EndDate = new DateTime(2001, 12, 13)
            };

            projectRepo.Add(projectInvalid);
            Project project1 = ProjectRepo.projectList.Find(p => p.ProjectId == projectInvalid.ProjectId);


            Assert.IsNotNull(project1);
            Assert.That(projectId, Is.EqualTo(project1.ProjectId));
            Assert.That(projectName, Is.EqualTo(project1.ProjectName));
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Exception Occured " + ex.Message);
            Assert.Fail("Caught exception: " + ex.Message);
        }
    }








    [Test]
    public void ViewProjectTest()
    {
        Project projectView = new Project()
        {
            ProjectId = 1,
            ProjectName = "Nano",
            StartDate = new DateTime(2023, 10, 11),
            EndDate = new DateTime(2023, 11, 11)
        };
        ProjectRepo.projectList.Add(projectView);
        List<Project> projects = projectRepo.Get();

        Assert.IsTrue(projects.Contains(projectView));
    }


    [Test]
    public void AddEmployeeValidTest()
    {
        Employee employeeValid = new Employee()
        {
            EmployeeId = 2,
            EmployeeFirstName = "sunder",
            EmployeeLastName = "dasari",
            Email = "sunder@gmail",
            MobileNumber = +919392639701,
            Address = "Hyd",
            RoleId = 1

        };
        employeeRepo.Add(employeeValid);
        //     Assert.That(EmployeeRepo.employeeList.Count, Is.EqualTo(1));
        //     Assert.That(EmployeeRepo.employeeList[0].EmployeeFirstName, Is.EqualTo("sunder"));



        Employee employeeObj = EmployeeRepo.employeeList.Find(p => p.EmployeeId == employeeValid.EmployeeId);

        Assert.IsNotNull(employeeObj);
        Assert.That(employeeObj.EmployeeId, Is.EqualTo(employeeValid.EmployeeId));
        Assert.That(employeeObj.EmployeeFirstName, Is.EqualTo(employeeValid.EmployeeFirstName));
        Assert.That(employeeObj.EmployeeLastName, Is.EqualTo(employeeValid.EmployeeLastName));
        Assert.That(employeeObj.Email, Is.EqualTo(employeeValid.Email));
        Assert.That(employeeObj.MobileNumber, Is.EqualTo(employeeValid.MobileNumber));
        Assert.That(employeeObj.Address, Is.EqualTo(employeeValid.Address));
        Assert.That(employeeObj.RoleId, Is.EqualTo(employeeValid.RoleId));
    }



    [TestCase(2, "sunder")]
    // // [TestCase(3,"mami")]
    public void AddEmployeeInValidTest(int employeeId, string employeeFirstName)
    {
        try
        {
            Employee employeeInValid = new Employee()
            {
                EmployeeId = 2,
                EmployeeFirstName = "sunder",
                EmployeeLastName = "dasari",
                Email = "sunder@gmail",
                MobileNumber = +919392639701,
                Address = "Hyd",
                RoleId = 1

            };

            employeeRepo.Add(employeeInValid);



            Employee employee1 = EmployeeRepo.employeeList.Find(p => p.EmployeeId == employeeInValid.EmployeeId);


            Assert.IsNotNull(employee1);
            Assert.That(employeeId, Is.EqualTo(employee1.EmployeeId));
            Assert.That(employeeFirstName, Is.EqualTo(employee1.EmployeeFirstName));
        }
        catch (Exception exe)
        {
            Console.WriteLine("Exception Occured : " + exe.Message);
            Assert.Fail("Caught exception:" + exe.Message);
        }
    }


    [Test]
    public void ViewEmployee()
    {
        Employee employeeView = new Employee()
        {
            EmployeeId = 2,
            EmployeeFirstName = "sunder",
            EmployeeLastName = "dasari",
            Email = "sunder@gmail.com",
            MobileNumber = +919392639701,
            Address = "Hyd",
            RoleId = 1

        };
        employeeRepo.Add(employeeView);

        EmployeeRepo.employeeList.Add(employeeView);
        List<Employee> employees = employeeRepo.Get();

        Assert.IsTrue(employees.Contains(employeeView));
    }


    [Test]
    public void AddRoleValid()
    {
        Role addRoleValid = new Role()
        {
            RoleId = 1,
            RoleName = "lead"
        };
        rolesRepo.Add(addRoleValid);
        // Assert.That(RolesRepo.rolesList.Count, Is.EqualTo(1));

        // Assert.That(RolesRepo.rolesList[0].RoleName, Is.EqualTo("lead"));

        Role roleObj = RolesRepo.rolesList.Find(p => p.RoleId == addRoleValid.RoleId);


        Assert.IsNotNull(roleObj);

        Assert.That(roleObj.RoleId, Is.EqualTo(addRoleValid.RoleId));
        Assert.That(roleObj.RoleName, Is.EqualTo(addRoleValid.RoleName));

    }




    [TestCase(1, "lead")]
    // [TestCase(2,"manager")]
    public void AddRoleInvalid(int roleId, string roleName)
    {

        try
        {
            Role addRoleInvalid = new Role()
            {
                RoleId = 1,
                RoleName = "lead"
            };

            rolesRepo.Add(addRoleInvalid);


              Role role1 = RolesRepo.rolesList.Find(p => p.RoleId == addRoleInvalid.RoleId);


            Assert.IsNotNull(role1);
            Assert.That(role1.RoleId, Is.EqualTo(roleId));
            Assert.That(role1.RoleName, Is.EqualTo(roleName));
        }
        catch (Exception exe)
        {
            System.Console.WriteLine("The Problem is " + exe.Message);
            Assert.Fail("Caught exception:" + exe.Message);
        }

    }



    [Test]
    public void ViewRole()
    {
        Role viewRole = new Role()
        {
            RoleId = 1,
            RoleName = "lead"
        };
        rolesRepo.Add(viewRole);
        // Assert.That(RolesRepo.rolesList.Count, Is.EqualTo(2));

        // Assert.That(RolesRepo.rolesList[0].RoleName, Is.EqualTo("lead"));


        RolesRepo.rolesList.Add(viewRole);
        List<Role> roles = rolesRepo.Get();

        Assert.IsTrue(roles.Contains(viewRole));

    }




    [Test]
    public void EmployeeToProjectTest()
    {
        EmployeeProject employeeProjectObject = new EmployeeProject()
        {
            ProjectId = 1,
            EmployeeId = 1,
            EmployeeFirstName = "sunder",
            EmployeeLastName = "dasari",
            RoleId = 1
        };

        employeeProjectRepo.EmployeeToProject(employeeProjectObject.ProjectId, employeeProjectObject.ProjectName, employeeProjectObject.EmployeeId, employeeProjectObject.EmployeeFirstName, employeeProjectObject.EmployeeLastName, employeeProjectObject.RoleId);


        Assert.That(EmployeeProjectRepo.projectEmployeeMember.Count, Is.EqualTo(1));

        // Assert.That(EmployeeProjectRepo.projectEmployeeMember[0].EmployeeFirstName, Is.EqualTo("sunder"));

        EmployeeProject employeeProject = EmployeeProjectRepo.projectEmployeeMember.Find(p => p.ProjectId == employeeProjectObject.ProjectId);

        Assert.IsNotNull(employeeProject);
        Assert.That(employeeProject.ProjectId, Is.EqualTo(employeeProjectObject.ProjectId));
        Assert.That(employeeProject.ProjectName, Is.EqualTo(employeeProjectObject.ProjectName));
        Assert.That(employeeProject.EmployeeFirstName, Is.EqualTo(employeeProjectObject.EmployeeFirstName));
        Assert.That(employeeProject.EmployeeLastName, Is.EqualTo(employeeProjectObject.EmployeeLastName));
        Assert.That(employeeProject.RoleId, Is.EqualTo(employeeProjectObject.RoleId));

    }




    [Test]

    public void ViewProjectDetailsTest()
    {
        EmployeeProject viewEmployeeProjectObject = new EmployeeProject()
        {
            ProjectId = 1,
            ProjectName = "nano",
            EmployeeId = 1,
            EmployeeFirstName = "sunder",
            EmployeeLastName = "dasari",
            RoleId = 1
        };


        EmployeeProjectRepo.projectEmployeeMember.Add(viewEmployeeProjectObject);
        List<EmployeeProject> employeeProjects = employeeProjectRepo.GetEmployeeProjects();

        Assert.IsTrue(employeeProjects.Contains(viewEmployeeProjectObject));

    }



    [Test]
    public void DeleteEmployeeFromProjectTest()
    {
        // Arrange
        EmployeeProject employeeProjectProperties = new EmployeeProject()
        {
            ProjectId = 1,
            EmployeeId = 1,
        };
        bool employeeDeleted;

        // Act
        employeeProjectRepo.DeleteEmployeeFromProject(employeeProjectProperties.ProjectId, employeeProjectProperties.EmployeeId, out employeeDeleted);

        // Assert


        bool containsItem = EmployeeProjectRepo.projectEmployeeMember.Any(item =>
            item.ProjectId == employeeProjectProperties.ProjectId &&
            item.EmployeeId == employeeProjectProperties.EmployeeId);

        // Check if the item was removed
        Assert.IsFalse(containsItem);

        // Check if the employeeDeleted flag is set to true
        //  

        System.Console.WriteLine("Remove Employee project test case passed");
    }
}