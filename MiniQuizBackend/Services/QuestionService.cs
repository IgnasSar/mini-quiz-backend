using QuizAPI.Interfaces;
using QuizAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> CreateQuestionAsync(Question question)
        {
            return await _questionRepository.AddQuestionAsync(question);
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            return await _questionRepository.DeleteQuestionAsync(id);
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _questionRepository.GetAllQuestionsAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _questionRepository.GetQuestionByIdAsync(id);
        }

        public async Task<Question> UpdateQuestionAsync(int id, Question question)
        {
            if (id != question.Id)
                return null;

            var exists = await _questionRepository.QuestionExistsAsync(id);

            if (!exists)
                return null;

            return await _questionRepository.UpdateQuestionAsync(question);
        }
    }
}
