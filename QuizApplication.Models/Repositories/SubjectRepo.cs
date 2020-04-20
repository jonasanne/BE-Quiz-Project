using Microsoft.EntityFrameworkCore;
using QuizApplication.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplication.Models.Repositories
{
    public class SubjectRepo : ISubjectRepo
    {
        private readonly ApplicationDbContext context;

        public SubjectRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            try
            {
                return await context.Subjects.OrderBy(n => n.SubjectName).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            try
            {
                subject.SubjectId = Guid.NewGuid();
                var result = context.Subjects.AddAsync(subject);//ChangeTracking
                await context.SaveChangesAsync();
                return subject; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }
        public Task<Subject> GetsubjectById(Guid Id)
        {
            try
            {
                return context.Subjects.FirstOrDefaultAsync<Subject>(e => e.SubjectId == Id);
            }

            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task DeleteSubject(Guid Id)
        {
            try
            {
                Subject subject = await GetsubjectById(Id);

                if (subject == null)
                {
                    return;
                }

                var result = context.Subjects.Remove(subject);
                ////doe hier een archivering van education ipv delete -> veiliger
                await context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            return;
        }



        public async Task<Subject> Update(Subject subject)
        {
            try
            {
                context.Subjects.Update(subject);
                await context.SaveChangesAsync();
                return subject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw null;

            }
        }
    }
}
