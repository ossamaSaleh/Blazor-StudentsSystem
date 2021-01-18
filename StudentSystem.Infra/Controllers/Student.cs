using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Infra.Data.Db;
using StudentSystem.Infra.SchoolDB;
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
                obj.Id = item.Id;
                lstObj.Add(obj);
            }
            return lstObj;
        }
        [HttpPost]
        //[EnableCors("*")]
        [Route("api/Students/Create")]
        public async Task<Response<StudentProfileDTO>> CreateNew([FromBody] StudentProfileDTO studentProfile)
        {
            Response<StudentProfileDTO> response = new Response<StudentProfileDTO>();
            var obj = new StudentGeneralProfile();
            obj.Birthdate = studentProfile.Birthdate;
            obj.FirstName = studentProfile.FirstName;
            obj.Gender = studentProfile.Gender;
            obj.LastName = studentProfile.LastName;
            obj.Mobile = studentProfile.Mobile;
            obj.ParentMobile1 = studentProfile.ParentMobile1;
            obj.ParentMobile2 = studentProfile.ParentMobile2;
            try
            {
                _context.StudentGeneralProfile.Add(obj);
                _context.SaveChanges();
                response.Message = "Success";
                response.Content = studentProfile;
                response.Id = obj.Id;// _context.StudentGeneralProfile.Select(a => a.Id).LastOrDefault();
            }
            catch(Exception e) 
            {
                response.Content = studentProfile;
                response.Message = e.Message;
            }

            return await Task.FromResult(response);
        }
    }
}
