using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Controllers
{
    class QuestionController
    {
        private QuestionRepository questionRepository;

        public QuestionController(stuff_shopContext db)
        {
            questionRepository = new QuestionRepository(db);
        }

        public List<Question> GetAllQuestions()
        {
            return questionRepository.Items.ToList();
        }

        public List<Question> GetQuestionsForUser(Person user)
        {
            return questionRepository.GetByUser(user).ToList();
        }

        public List<Question> GetQuestionsForConsultant(Person consultant)
        {
            return questionRepository.GetByConsultant(consultant).ToList();
        }

        public List<Question> GetUnanswered(int consultantId)
        {
            return questionRepository.GetUnanswered(consultantId).ToList();
        }

        public List<Question> GetByTheme(QTheme theme)
        {
            return questionRepository.GetByQTheme(theme).ToList();
        }

        public void AddQuestion(Question question)
        {
            questionRepository.Add(question);
        }

        public void UpdateQuestion(Question question)
        {
            questionRepository.Update(question);
        }

        async public Task RemoveQuestionAsync(int id)
        {
            await questionRepository.RemoveAsync(id, new System.Threading.CancellationToken());
        }

        public void RemoveQuestion(int id)
        {
            questionRepository.Remove(id);
        }

        public Question GetQuestion(int id)
        {
            return questionRepository.Get(id);
        }
    }
}
