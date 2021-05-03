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
            viewModel.Questionnaries = questionnaries.ToList();
            return View(viewModel);
        }

        public ActionResult IndexUpdate()
        {
            var questionnaries = _qestionnarieService.GetActiveQuestionnaries().ToList();
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

        public ActionResult AddAnswerVariant(EditQuestionsViewModel editQuestions, int id)
        {
            editQuestions.NewAnswerVariant.QuestionId = id;
            _qestionnarieService.AddAnswerVariant(editQuestions.NewAnswerVariant);
            var viewModel = FillEditQuestionsView(editQuestions.Questionnarie.Id);
            return PartialView("_EditQuestionsPartial", viewModel);
        }

        public ActionResult ActivateQuestionnarie(int id)
        {
            _qestionnarieService.ActivateQuestionnarie(id);
            return RedirectToAction("Index");
        }

        public ActionResult RegisterAnswer(int questionnarieId, List<AnswerDTO> answers)
        {
            _qestionnarieService.AddAnswers(answers);
            var questionnarie = _qestionnarieService.GetQuestionnarie(questionnarieId);
            var questions = questionnarie.Questions;
            List<QuestionStats> questionStats = new List<QuestionStats>();
            foreach(var question in questions)
            {
                var aStats = question.Answers.GroupBy(a => a.Text)
                    .Select(ag => new AnswerStat { Text = ag.Key, Count = ag.Count() });
                var qStats = new QuestionStats { Question = question, AnswerStats = aStats.ToList() };
                questionStats.Add(qStats);
            }
            var viewModel = new ResultViewModel { Questionnarie = questionnarie, QuestionStats = questionStats };
            return View("Result", viewModel);
        }

        #region HELPERS
        private EditQuestionsViewModel FillEditQuestionsView(int id)
        {
            var questionnarie = _qestionnarieService.GetQuestionnarie(id);
            var questions = questionnarie.Questions;
            var viewModel = new EditQuestionsViewModel { Questionnarie = questionnarie, NewAnswerVariant = null };
            viewModel.Questions = questions;

            return viewModel;
        }
        #endregion HELPERS
    }
}