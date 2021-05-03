using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Interfaces;

namespace Digital_Library.BL.Interfaces
{
    public interface IQestionnarieService
    {
        QuestionnarieDTO GetQuestionnarie(int id);
        IEnumerable<QuestionnarieDTO> GetQuestionnaries();
        IEnumerable<QuestionnarieDTO> GetActiveQuestionnaries();
        QuestionnarieDTO AddQuestionnarie(QuestionnarieDTO questionnarie );
        QuestionDTO AddQuestion(QuestionDTO question);
        AnswerVariantDTO AddAnswerVariant(AnswerVariantDTO answerVariant);
        void AddAnswers(IEnumerable<AnswerDTO> answers);
        void AddAnswer(AnswerDTO answer);
        void ActivateQuestionnarie(int id);
        bool CheckExistingQuestionntarie(string name);
    }
}
