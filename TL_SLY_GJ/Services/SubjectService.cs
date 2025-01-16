using Microsoft.EntityFrameworkCore;
using TL_SLY_GJ.Models;

namespace TL_SLY_GJ.Services
{
    public class SubjectService
    {
        private TlSlyGjContext _context;
        public SubjectService(TlSlyGjContext context)
        {
            _context = context;
        }
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
    }
}
