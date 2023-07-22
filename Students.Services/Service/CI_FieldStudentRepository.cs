using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;
using Students.Persistence.DbContexts;
using Students.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Services.Service
{
    public class CI_FieldStudentRepository : ICI_FieldStudent
    {


        private StudentDbContext db;
        public CI_FieldStudentRepository(StudentDbContext _context)
        {
            this.db = _context;
        }

        public IEnumerable<CI_FieldStudent> GetAllCI_FieldStudents()
        {
            return db.CI_FieldStudents.ToList();
        }

        public CI_FieldStudent GetCI_FieldStudentById(int cI_FieldStudentId)
        {
            return db.CI_FieldStudents.Find(cI_FieldStudentId);
        }

        public bool InsertCI_FieldStudent(CI_FieldStudent cI_FieldStudent)
        {
            try
            {
                db.CI_FieldStudents.Add(cI_FieldStudent);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateCI_FieldStudent(CI_FieldStudent cI_FieldStudent)
        {
            try
            {
                db.Entry(cI_FieldStudent).State= EntityState.Modified;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCI_FieldStudent(CI_FieldStudent cI_FieldStudent)
        {
            try
            {
                db.Entry(cI_FieldStudent).State = EntityState.Deleted;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCI_FieldStudent(int cI_FieldStudent)
        {
            try
            {

                var cIFieldStudent = GetCI_FieldStudentById(cI_FieldStudent);
                DeleteCI_FieldStudent(cIFieldStudent);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

       
        public void Save()
        {
            db.SaveChanges();
        }

   
    }
}
