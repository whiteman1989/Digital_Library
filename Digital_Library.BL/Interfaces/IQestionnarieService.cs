using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Interfaces;

namespace Digital_Library.BL.Interfaces
{
    /// <summary>
    /// Interface for Questionnarie service
    /// </summary>
    public interface IQestionnarieService
    {
        /// <summary>
        /// Get questionnarie by id
        /// </summary>
        /// <param name="id">questionnarie id</param>
        /// <returns>qiestionnarie object</returns>
        QuestionnarieDTO GetQuestionnarie(int id);

        /// <summary>
        /// Get all questionnaries
        /// </summary>
        /// <returns>questionnaries collection</returns>
        IEnumerable<QuestionnarieDTO> GetQuestionnaries();

        /// <summary>
        /// Get only active questionnaries
        /// </summary>
        /// <returns>questionnaries collection</returns>
        IEnumerable<QuestionnarieDTO> GetActiveQuestionnaries();

        /// <summary>
        /// Add new questionnarie
        /// </summary>
        /// <param name="questionnarie">questionnarie DTO object</param>
        /// <returns>updated questionnarie DTO object with new ID</returns>
        QuestionnarieDTO AddQuestionnarie(QuestionnarieDTO questionnarie );

        /// <summary>
        /// Add new question
        /// </summary>
        /// <param name="question">question DTO object</param>
        /// <returns>updated qyestion DTO object with new ID</returns>
        QuestionDTO AddQuestion(QuestionDTO question);

        /// <summary>
        /// Add new answer variant
        /// </summary>
        /// <param name="answerVariant">answer variant DTO object</param>
        /// <returns>updated answer variant DTO object with new ID</returns>
        AnswerVariantDTO AddAnswerVariant(AnswerVariantDTO answerVariant);

        /// <summary>
        /// Add new answers to repository
        /// </summary>
        /// <param name="answers">collection of answers</param>
        void AddAnswers(IEnumerable<AnswerDTO> answers);

        /// <summary>
        /// Add new answer
        /// </summary>
        /// <param name="answer">answer DTO object</param>
        void AddAnswer(AnswerDTO answer);

        /// <summary>
        /// Activate Questionnarie by id
        /// </summary>
        /// <param name="id">questionnarie id</param>
        void ActivateQuestionnarie(int id);

        /// <summary>
        /// Check if questionntarie is existing
        /// </summary>
        /// <param name="name">questionntarie neme</param>
        /// <returns>is exist</returns>
        bool CheckExistingQuestionntarie(string name);
    }
}
