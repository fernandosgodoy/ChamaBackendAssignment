using ApplicationApp.Interfaces;
using ChamaUniversity.Entities;
using Domain.Interfaces.InterfaceCourse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class CourseBusiness
        : ICourseApp
    {

        ICourse _iCourse;

        public CourseBusiness(ICourse iCourse)
        {
            _iCourse = iCourse;
        }

        public async Task Add(Course entity)
        {
            await _iCourse.Add(entity);
        }

        public async Task Delete(Course entity)
        {
            await _iCourse.Delete(entity);
        }

        public async Task<Course> GetEntityById(int id)
        {
            return await _iCourse.GetEntityById(id); 
        }

        public async Task<List<Course>> List()
        {
            return await _iCourse.List();
        }

        public async Task Update(Course entity)
        {
            await _iCourse.Update(entity);
        }
    }
}
