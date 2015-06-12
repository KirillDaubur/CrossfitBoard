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
    public class RoundController : ApiController
    {
        DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();

        [HttpGet]
        public RoundDto Get(Int32 id)
        {
            try
            {
                Round dbRound = rep.GetRoundByID(id);
                RoundDto result = Converter.FromRoundToDto(dbRound);
                return result;
            }
            catch
            {
                return new RoundDto();
            }

         }

        [HttpPost]
        public void Add([FromBody]RoundDto value)
        {
            try
            {
                Round dbRound = Converter.FromDtoToRound(value);
                rep.AddRound(dbRound);
                value.Tacks.ForEach(item =>
                {
                    Tack dbTack = Converter.FromDtoToTack(item);
                    rep.AddTack(dbTack);
                });
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }

        [HttpPut]
        public void Edit(Int32 id, [FromBody]RoundDto value)
        {
            try
            {
                Round dbRound = Converter.FromDtoToRound(value);
                dbRound.ID = id;
                rep.UpdateRound(dbRound);
                value.Tacks.ForEach(item =>
                {
                    Tack dbTack = Converter.FromDtoToTack(item);
                    rep.UpdateTack(dbTack);
                });
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        }
    }
}
