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
    public class WodResultController : ApiController
    {
        DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();


        [HttpGet]
        public WodResultDto GetWodResultForCurrentWod(Int32 wodID)
        {
            try
            {
            WodResult dbWodResult = rep.GetWodResultByWodID(wodID);
            WodResultDto result = Converter.FromWodResultToDto(dbWodResult);
            return result;
            }
            catch
            {
                return new WodResultDto();
            }
        }
       
        [HttpPost]
        public void Add([FromBody]WodResultDto value)
        {
            try
            {
                WodResult result = Converter.FromDtoToWodResult(value);
                rep.AddWodResult(result);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpPut]
        public void Edit(Int32 id, [FromBody]WodResultDto value)
        {
            try
            {
                WodResult result = Converter.FromDtoToWodResult(value);
                result.ID = id;
                rep.UpdateWodResult(result);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
