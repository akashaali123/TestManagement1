using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestManagement1.Model;
using TestManagement1.Presenter;
using TestManagement1.RepositoryInterface;
using TestManagement1.ViewModel;

namespace TestManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        //webHostEnviroment Declaration but not used I used for furture configuration it provides the property such
        //as webRootPath webRootFile Provider
        private readonly IWebHostEnvironment _webHostEnvironment;

        CategoryPresenter cp;

        private readonly ILogger<CategoryPresenter> _logger;

        public CategoryController(IWebHostEnvironment webHostEnvironment,ICategory repository, ILogger<CategoryPresenter> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            cp = new CategoryPresenter(_webHostEnvironment, repository, _logger);
        }

        
        
        
        [HttpPost]
        [Route("create")]
        //POST : api/Category/create

        public IActionResult Add(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                return Ok(cp.Add(category));
            }
            else
            {
                return BadRequest();
            }
        }

        
        
        
        [HttpGet]
        [Route("getall")]
        //GET : api/Category/getall
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(cp.GetAllCategory());
            }
            else
            {
                return BadRequest();
            }
        }

        
        
        [HttpDelete]
        [Route("Delete")]
        //DELETE : api/Category/Delete
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(cp.Delete(id));
            }
            else
            {
                return BadRequest();
            }
        }


    }
}