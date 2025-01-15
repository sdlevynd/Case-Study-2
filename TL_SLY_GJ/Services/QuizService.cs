using Microsoft.EntityFrameworkCore;
using TL_SLY_GJ.Models;

namespace TL_SLY_GJ.Services
{
    public class QuizService
    {
        private TlSlyGjContext _context;
        public QuizService(TlSlyGjContext context)
        {
            _context = context;
        }

        public async Task<List<Quiz>> GetQuizzesAsync()
        {
            return await _context.Quizzes.ToListAsync();
        }
        public async Task<List<Quiz>> GetQuizzesBySubjectAsync(int subjectId)
        {
            return await _context.Quizzes.Where(q => q.SubjectId == subjectId).ToListAsync();
        }
        public async Task<Quiz?> GetQuizByIdAsync(int quizId)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(q => q.QuizId == quizId);
        }
        public async Task<List<Quiz>> GetQuizzesByUserAsync(int userId)
        {
            return await _context.Quizzes.Where(q => q.UserId == userId).ToListAsync();
        }
    }
}
