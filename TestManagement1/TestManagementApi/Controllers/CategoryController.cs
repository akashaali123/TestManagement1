using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagement1.Presenter;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "SuperAdmin")]
   [Authorize]
    public class CategoryController : BaseController<CategoryPresenter>
    {

        //webHostEnviroment Declaration but not used I used for furture configuration it provides the property such
        //as webRootPath webRootFile Provider

        //Generic Methode Description in Candidate Controller
        CategoryPresenter cp;
        

        public CategoryController(IWebHostEnvironment webHostEnvironment, ICategory repository, ILogger<CategoryPresenter> logger) : base(webHostEnvironment, logger)
        {
            
            cp = new CategoryPresenter(webHostEnvironment, repository, logger);
        }


        #region Category Create
        [HttpPost]
        [Route("/category/create")]
        //POST : api/Category/create
        public IActionResult Add(CategoryViewModel category)
        {
             

            var model = cp.Add(category);
            
            return helperMethode(model, "category");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion



        #region Category get all
        [HttpGet]
        [Route("/category/getall")]
        //GET : api/Category/getall
        public IActionResult GetAll()
        {
           
            var category = cp.GetAllCategory();
            return helperMethode(category, "categories");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller
        }
        #endregion




        #region Category Delete
        [HttpDelete]
        [Route("/category/delete")]
        //DELETE : api/Category/Delete
        public IActionResult Delete(int id)
        {

            
            var category = cp.Delete(id);
            return helperMethode(category, "category");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion







    }
}