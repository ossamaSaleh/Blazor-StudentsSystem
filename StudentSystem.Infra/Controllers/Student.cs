using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Infra.Data.Db;
using StudentSystemServer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Infra.Controllers
{
    [ApiController]
    public class Student : Controller
    {
        private readonly SchoolContext _context;
        public Student(SchoolContext Context)
        {
            _context = Context;
        }
        [HttpGet]
        [Route("api/Students/GetAll")]
        public async Task<List<StudentProfileDTO>> GetAll()
        {
            var result = await _context.StudentGeneralProfile.AsNoTracking().ToListAsync();
            List<StudentProfileDTO> lstObj = new List<StudentProfileDTO>();
            foreach (var item in result)
            {
                StudentProfileDTO obj = new StudentProfileDTO();
                obj.Birthdate = item.Birthdate;
                obj.FirstName = item.FirstName;
                obj.Gender = item.Gender;
                obj.LastName = item.LastName;
                obj.Mobile = item.Mobile;
                obj.ParentMobile1 = item.ParentMobile1;
                obj.ParentMobile2 = item.ParentMobile2;
                lstObj.Add(obj);
            }
            return lstObj;
        }
    }
}
