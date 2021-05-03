using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.Interfaces;
using Digital_Library.DAL.Interfaces;
using Digital_Library.DAL.Entities;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Infrastructure;
using AutoMapper;

namespace Digital_Library.BL.Services
{
    class QuestionnarieService : IQestionnarieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public QuestionnarieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<QuestionnarieDTO, Questionnarie>().ReverseMap();
                cfg.CreateMap<QuestionDTO, Question>().ReverseMap();
                cfg.CreateMap<AnswerDTO, Answer>().ReverseMap();
                cfg.CreateMap<AnswerVariantDTO, AnswerVariant>().ReverseMap();

            });

            _mapper = new Mapper(mapperConfig);
        }

        public void ActivateQuestionnarie(int id)
        {
            var questionnarie = _unitOfWork.Qestionnaries.Get(id);
            questionnarie.IsActive = true;
            _unitOfWork.Save();
        }

        public void AddAnswer(AnswerDTO answer)
        {
            var question = _unitOfWork.Questions.Get(answer.QuestionId);
            if (question is object)
            {
                var newAnswer = _mapper.Map<Answer>(answer);
                _unitOfWork.Answers.Create(newAnswer);
                _unitOfWork.Save();
            }
            else
            {
                throw new ValidationException("No question with hit id", nameof(answer.QuestionId));
            }
        }

        public void AddAnswers(IEnumerable<AnswerDTO> answers)
        {
            var newAnsvers = _mapper.Map<IEnumerable<Answer>>(answers);
            foreach(var answer in newAnsvers)
            {
                answer.Date = DateTime.Now;
                _unitOfWork.Answers.Create(answer);
            }
            _unitOfWork.Save();
        }

        public AnswerVariantDTO AddAnswerVariant(AnswerVariantDTO answerVariant)
        {
            var question = _unitOfWork.Questions.Get(answerVariant.QuestionId);
            if(question is object)
            {
                var newAnswerVariant = _mapper.Map<AnswerVariant>(answerVariant);
                _unitOfWork.AnswerVariants.Create(newAnswerVariant);
                _unitOfWork.Save();
                return _mapper.Map<AnswerVariantDTO>(newAnswerVariant);
            }
            else
            {
                throw new ValidationException("No question with hit id", nameof(answerVariant.QuestionId));
            }
        }

        public QuestionDTO AddQuestion(QuestionDTO question)
        {
            var newQestion = _mapper.Map<Question>(question);
            _unitOfWork.Questions.Create(newQestion);
            _unitOfWork.Save();
            return _mapper.Map<QuestionDTO>(newQestion);
        }

        public QuestionnarieDTO AddQuestionnarie(QuestionnarieDTO questionnarie)
        {
            var newQuestionnarie = _mapper.Map<Questionnarie>(questionnarie);
            _unitOfWork.Qestionnaries.Create(newQuestionnarie);
            _unitOfWork.Save();
            return _mapper.Map<QuestionnarieDTO>(newQuestionnarie);
        }

        public IEnumerable<QuestionnarieDTO> GetActiveQuestionnaries()
        {
            var activeQuestionnaries = _unitOfWork.Qestionnaries.Find(q => q.IsActive);
            return _mapper.Map<IEnumerable<QuestionnarieDTO>>(activeQuestionnaries.AsEnumerable());
        }

        public QuestionnarieDTO GetQuestionnarie(int id)
        {
            return _mapper.Map<QuestionnarieDTO>(_unitOfWork.Qestionnaries.Get(id));
        }

        public IEnumerable<QuestionnarieDTO> GetQuestionnaries()
        {
            return _mapper.Map<IEnumerable<QuestionnarieDTO>>
                (
                    _unitOfWork.Qestionnaries.GetAll()
                    .AsEnumerable()
                );
        }
    }
}
