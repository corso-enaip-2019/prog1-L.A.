using Microsoft.AspNetCore.Mvc;
using P19_Web_Dynamic_07_FullStack.DataAccess;
using P19_Web_Dynamic_07_FullStack.Infrastructure.Exceptions;
using System.Linq;

namespace P19_Web_Dynamic_07_FullStack.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly AppDbContext _context;

        protected BaseController(AppDbContext context)
        {
            _context = context;
        }

        protected void CheckInput()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value
                        .Errors
                        .Select(y => y.ErrorMessage));

                var errorMessage = string.Join("; ", errors);

                throw new InvalidInputException(errorMessage);
            }
        }
    }
}
