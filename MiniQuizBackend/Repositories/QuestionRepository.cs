using Microsoft.EntityFrameworkCore;
using QuizAPI.Interfaces;
using QuizAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext _databaseContext;

        public QuestionRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Question> AddQuestionAsync(Question question)
        {
            _databaseContext.Questions.Add(question);
            await _databaseContext.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _databaseContext.Questions.FindAsync(id);
            if (question == null)
                return false;

            _databaseContext.Questions.Remove(question);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _databaseContext.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _databaseContext.Questions.FindAsync(id);
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            _databaseContext.Entry(question).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return question;
        }

        public async Task<bool> QuestionExistsAsync(int id)
        {
            return await _databaseContext.Questions.AnyAsync(q => q.Id == id);
        }
    }
}
