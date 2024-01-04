using Dapper;
using DapperProject.DapperContext;
using DapperProject.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string query = "Select * From Project";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultProjectDto>(query);
            return View(values.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto model)
        {
            string query = "insert into Project (Title,Description,ProjectCategory,CompleteDay,Price) Values (@title,@description,@projectCategory,@completeDay,@price) ";
             var parameters = new DynamicParameters();
            parameters.Add("@title", model.Title);
            parameters.Add("@description", model.Description);
            parameters.Add("@price", model.Price);
            parameters.Add("@projectCategory", model.ProjectCategory);
            parameters.Add("@completeDay", model.CompleteDay);
            return View();
        }
    }
}
  