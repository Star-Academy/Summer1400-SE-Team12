using Microsoft.AspNetCore.Mvc;
using Phase11_ASP.Interfaces;

namespace Phase11_ASP.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private const string FolderPath = @"D:\programming\codestar_internship\Phase11_ASP\Phase11_ASP\EnglishData";
        private readonly ISearchEngine _searchEngine;

        public SearchController(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
        }

        [HttpGet]
        public IActionResult GetDocuments([FromBody]string query)
        {
            var queries = query.ToLower().Split(" ");
            var answers = _searchEngine.Search(queries, FolderPath);
            return Ok(answers);
        }
    }
}