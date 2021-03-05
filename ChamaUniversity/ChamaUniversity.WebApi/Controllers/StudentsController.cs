using ChamaUniversity.Application.Courses;
using ChamaUniversity.Dtos.Courses;
using ChamaUniversity.Dtos.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaUniversity.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //[Authorize]           //For now, not necessary
        [HttpPost("")]
        public async Task<ActionResult<ResultDto>> SignUpStudentAsync(
            [FromBody] SignUpToCourseDto signupCourseParameter,
            [FromServices] CourseBusiness courseBusiness)
        {
            if (!this.ModelState.IsValid)
                return this.BadRequest(this.ModelState);

            return await courseBusiness.SignUpStudentAsync(signupCourseParameter);
        }

    }
}
