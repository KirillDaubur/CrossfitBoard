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
    public class TackController : ApiController
    {
        DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();

        [HttpGet]
        public IEnumerable<TackDto> GetAllTacksForCurrentRound(Int32 roundID)
        {
            try
            {
                List<Tack> curTacks = rep.GetTacksForCurrentRound(roundID);
                List<TackDto> result = Converter.FromTackListToDtoList(curTacks);
                return result;
            }
            catch
            {
                return new List<TackDto>();
            }
           
        }

        [HttpGet]
        public TackDto Get(Int32 id)
        {
            try
            {
                Tack dbTack = rep.GetTackByID(id);
                TackDto result = Converter.FromTackToDto(dbTack);
                return result;
            }
            catch
            {
                return new TackDto();
            }  
        }

        [HttpPost]
        public void Add([FromBody]TackDto dtoTack)
        {
            try
            {
                Tack tack = Converter.FromDtoToTack(dtoTack);
                rep.AddTack(tack);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpPut]
        public void Edit(Int32 id, [FromBody]TackDto dtoTack)
        {
            try
            {
                Tack tack = Converter.FromDtoToTack(dtoTack);
                tack.ID = id;
                rep.UpdateTack(tack);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
