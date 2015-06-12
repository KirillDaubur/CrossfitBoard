using DALviaWebAPI.DAL;
using DALviaWebAPI.Models.DatabaseEntities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DALviaWebAPI.Controllers
{
    public class ExerciseController : ApiController
    {
        DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();
    
        [HttpGet]
        public IEnumerable<ExerciseDto> GetAll()
        {
            try
            {
                List<Exercise> dbExercises = rep.GetAllExercises();
                List<ExerciseDto> result = Converter.FromExerciseListToDtoList(dbExercises);
                return result;
            }
            catch 
            {
                return new List<ExerciseDto>();
            }                         
        }

        [HttpGet]
        public ExerciseDto Get(Int32 id)
        {
            try
            {
                Exercise dbExercise = rep.GetExerciseByID(id);
                ExerciseDto result = Converter.FromExerciseToDto(dbExercise);
                return result;
            }
            catch
            {
                return new ExerciseDto();
            }  
        }

        [HttpPost]
        public void Add([FromBody]ExerciseDto dtoExercise)
        {
            try
            {
                Exercise exercise = Converter.FromDtoToExercise(dtoExercise);
                rep.AddExercise(exercise);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpPut]
        public void Edit(Int32 id, [FromBody]ExerciseDto dtoExercise)
        {
            try
            {
                Exercise exercise = Converter.FromDtoToExercise(dtoExercise);
                exercise.ID = id;
                rep.UpdateExercise(exercise);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
