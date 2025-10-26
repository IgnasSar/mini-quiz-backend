using QuizAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task<Question> AddQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task<bool> DeleteQuestionAsync(int id);
        Task<bool> QuestionExistsAsync(int id);
    }
}
