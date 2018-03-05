using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB01.Models;
using WEB01.Repositories;
using Autofac;
using log4net;
using Microsoft.EntityFrameworkCore;

namespace WEB01.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContext dbContext;
        private IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork, DbContext dbContext)
        {
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IRepository<Author, int> AuthorRepository = new Repository<Author, int>(dbContext);

            AuthorRepository.Add(new Author { Name = "Daniel" });
            Update();

            IRepository<Book, int> BookRepository = new Repository<Book, int>(dbContext);

            BookRepository.Add(new Book { Title = "Clean Code" });
            Update();
          
            unitOfWork.Dispose();
            return View();
        }

        private void Update()
        {
            try
            {
                unitOfWork.Commit();
            }
            catch (DbUpdateException due)
            {
                unitOfWork.RejectChanges();
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
