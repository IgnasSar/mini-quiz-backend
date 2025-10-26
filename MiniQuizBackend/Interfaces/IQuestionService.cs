using QuizAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(int id, Question question);
        Task<bool> DeleteQuestionAsync(int id);
    }
}
