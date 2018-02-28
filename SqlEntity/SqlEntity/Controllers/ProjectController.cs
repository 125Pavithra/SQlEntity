using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SqlEntity.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            ProjectDetailsEntities entities = new ProjectDetailsEntities();
            return View(from project in entities.ProjectTbls
                        select project);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(ProjectTbl pro)
        {
            using (ProjectDetailsEntities entities = new ProjectDetailsEntities())
            {
                ProjectTbl updatedProject = (from c in entities.ProjectTbls
                                            where c.ProjectId == pro.ProjectId
                                       select c).FirstOrDefault();
                updatedProject.ProjectName = pro.ProjectName;
                updatedProject.CreatedBy = pro.CreatedBy;
                updatedProject.CreatedOn = pro.CreatedOn;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }
    }
}