using Microsoft.EntityFrameworkCore;

namespace CPW219_CRUD_Troubleshooting.Models
{
    public static class StudentDb
    {
        public static async Task<Student> Add(Student p, SchoolContext db)
        {
            //Add student to context
            db.Students.Add(p);

            await db.SaveChangesAsync();
            return p;
        }

        public static async Task<List<Student>> GetStudents(SchoolContext context)
        {
            return await (from s in context.Students
                    select s).ToListAsync();
        }

        public static async Task<Student> GetStudent(SchoolContext context, int id)
        {
            Student p2 = await context
                            .Students
                            .Where(s => s.StudentId == id)
                            .SingleAsync();
            return p2;
        }

        public static void Delete(SchoolContext context, Student p)
        {
            context.Students.Update(p);
            context.SaveChanges();
        }

        public static void Update(SchoolContext context, Student p)
        {
            //Mark the object as deleted
            context.Students.Remove(p);

            //Send delete query to database
            context.SaveChanges();
        }
    }
}
