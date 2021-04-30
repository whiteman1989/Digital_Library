using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Interfaces;
using Digital_Library.BL.Services;
using Digital_Library.PL.Models;

namespace Digital_Library.PL.Controllers
{
    public class QuestionnarieController : Controller
    {
        private IServiceCreator _serviceCreator;
        private IQestionnarieService _qestionnarieService;

        public QuestionnarieController(IServiceCreator serviceCreator)
        {
            _serviceCreator = serviceCreator;
            _qestionnarieService = _serviceCreator.CreatyeQestionnarieService();
        }


        // GET: Questionnarie
        public ActionResult Index()
        {
            var viewModel = new QuestionnariesViewModel();
            var questionnaries = _qestionnarieService.GetActiveQuestionnaries();
            viewModel.Questionnaries = questionnaries;
            return View(viewModel);
        }

        public ActionResult IndexUpdate()
        {
            var questionnaries = _qestionnarieService.GetActiveQuestionnaries();
            return PartialView("_QuestionnariesPartial",questionnaries);
        }

        public ActionResult AddQuestionnarie(QuestionnariesViewModel questionnariesView)
        {
            var questionnarie = questionnariesView.NewQuestionnarie;
            questionnarie = _qestionnarieService.AddQuestionnarie(questionnarie);
            var viewModel = new EditQuestionnarieViewModel();
            viewModel.Questionnarie = questionnarie;
            viewModel.NewQuestion = new QuestionDTO { QuestionnarieId = questionnarie.Id };
            return PartialView("EditQestionnarie", viewModel);
        }

        public ActionResult AddQuestion(EditQuestionnarieViewModel editQuestionnarie)
        {
            var question = editQuestionnarie.NewQuestion;
            _qestionnarieService.AddQuestion(question);
            var viewModel = FillEditQuestionsView(editQuestionnarie.Questionnarie.Id);

            return PartialView("_EditQuestionsPartial", viewModel);
        }

        public ActionResult AddAnswerVariant(EditQuestionsViewModel editQuestions)
        {
            foreach(var question in editQuestions.EditQuestions)
            {
                if(question.NewAnsverVariant is object)
                {
                    _qestionnarieService.AddAnswerVariant(question.NewAnsverVariant);
                }
            }
            var viewModel = FillEditQuestionsView(editQuestions.Questionnarie.Id);
            return PartialView("_EditQuestionsPartial", viewModel);
        }

        #region HELPERS
        private EditQuestionsViewModel FillEditQuestionsView(int id)
        {
            var questionnarie = _qestionnarieService.GetQuestionnarie(id);
            var questions = questionnarie.Questions;
            var viewModel = new EditQuestionsViewModel { Questionnarie = questionnarie };
            viewModel.EditQuestions = questions.Select(q => new EditQuestionViewModel
            {
                Question = q,
                NewAnsverVariant = new AnswerVariantDTO { QuestionId = q.Id }
            }).ToList();

            return viewModel;
        }
        #endregion HELPERS
    }
}