using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using StarPeace.Admin.Helpers;
using StarPeace.Admin.Entities;
using StarPeace.Admin.Contexts;

namespace StarPeace.Admin.Controllers
{
    public class MementoController : Controller
    {
        readonly StarPeaceAdminDbContext _dbContext;
        public MementoController(StarPeaceAdminDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        public IActionResult Index()
        {
            return View(_dbContext.Questions.ToList());            
        }

        [HttpPost]
        public IActionResult ProcessForm(List<int> question,List<string> answer,string submit,string save,string restore)
        {
            SurveyState state = new SurveyState();
            state.Questions = question;
            state.Answers = answer;
            Survey survey = new Survey(state);

            if (submit != null)
            {
                Caretaker.Snapshot = null;
                survey.Submit();
                ViewBag.Message = "Survey data submitted!";
            }
            if (save != null)
            {
                Caretaker.Snapshot = survey.CreateSnapshot();
                ViewBag.Message = "Snapshot created!";
            }

            if (restore!=null)
            {
                survey.RestoreSnapshot(Caretaker.Snapshot);
                ViewBag.Message = "Survey restored!";
            }

            ViewBag.Answers = survey.GetAnswers();

            List<Question> model = _dbContext.Questions.ToList();
                return View("Index", model);
        }

    }
}
