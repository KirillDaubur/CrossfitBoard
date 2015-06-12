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
    public class WodController : ApiController
    {
        DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();

        [HttpGet]
        public WodDto GetWodForCurrentUser(Int32 id)
        {
            try
            {
                Wod dbWod = rep.GetWodByWardID(id);
                WodDto result = Converter.FromWodToDto(dbWod);
                return result;
            }
            catch
            {
                return new WodDto();
            }
        }

        [HttpPost]
        public void Add([FromBody]WodDto value)
        {
            try
            {
                Wod result = Converter.FromDtoToWod(value);
                rep.AddWod(result);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpPut]
        public void Edit(Int32 id, [FromBody]WodDto value)
        {
            try
            {
                Wod result = Converter.FromDtoToWod(value);
                result.ID = id;
                rep.UpdateWod(result);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
