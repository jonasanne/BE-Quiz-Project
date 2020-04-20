using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Repositories
{
    public interface ISubjectRepo
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        /// <summary>
        /// get quiz by difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        Task<Subject> GetsubjectById(Guid Id);
        Task<Subject> AddSubject(Subject subject);
        Task DeleteSubject(Guid id);
        Task<Subject> Update(Subject subject);

    }
}
