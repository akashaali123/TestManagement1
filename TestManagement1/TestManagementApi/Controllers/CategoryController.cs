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

       
        
        /// <summary>
        /// url: http://localhost:55377/category/create
        /// Body
        /// 
        ///{
        ///"Name": "PHPa",
        ///}
        /// </summary>
        /// <param name="category"></param>
        /// <returns>
        /// {
        /// "success": true,
        ///"status": 200,
        ///"message": "category",
        ///"data": {
        /// "category": {
        ///  "categoryId": 29,
        ///"name": "PHPa",
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": "2020-02-25T00:00:00+05:00"
        ///}
        ///}
        ///}
        /// </returns>
        #region Category Create
        [HttpPost]
        [Route("/category/create")]
        //POST : api/Category/create
        public IActionResult Add(CategoryViewModel category)
        {
            //string userid = GetUserId();

            var model = cp.Add(category);
            
            return helperMethode(model, "category");//My helper methode just for standard api response just like status code etc
            //its implementation in base controller

        }
        #endregion






        /// <summary>
        /// url : http://localhost:55377/category/getall
        /// </summary>
        /// <returns>
        /// {
        /// "success": true,
        ///"status": 200,
        ///"message": "categories",
        ///"data": {
        /// "categories": [
        ///  {
        ///   "categoryId": 19,
        ///"name": "PHP",
        ///"isActive": true,
        ///"createdBy": null,
        ///"createdDate": "2020-02-19T14:57:31.6765813"
        ///}
        /// </returns>

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



        /// <summary>
        /// url : http://localhost:55377/category/delete?id=29
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// {
        ///"success": true,
        ///"status": 200,
        ///"message": "category",
        ///"data": {
        ///"category": {
        ///"categoryId": 29,
        ///"name": "PHPa",
        ///"isActive": true,
        ///"createdBy": null,
        ///   "createdDate": "2020-02-25T00:00:00"
        ///  }
        /// }
        ///}
        /// </returns>
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