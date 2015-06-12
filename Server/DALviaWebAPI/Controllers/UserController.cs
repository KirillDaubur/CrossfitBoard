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
    public class UserController : ApiController
    {
        DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();

        [HttpGet]
        public IEnumerable<UserDto> GetAllUsers()
        {
            List<UserDto> result = new List<UserDto>();
            try
            {
                return  Converter.FromUserListToDtoList(rep.GetAllUsers());
            }
            catch
            {
                return new List<UserDto>();
            }
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAllUsersWithRole(Int32 roleID)
        {
            List<UserDto> result = new List<UserDto>();

            try
            {
                Role curRole = rep.GetRoleByID(roleID);
                if(curRole == null)
                {
                    return new List<UserDto>();
                }

                List<User> UsersWithCurrentRole = rep.GetAllUsers().Where(user => user.RoleID == curRole.ID).ToList();
                if (UsersWithCurrentRole.Count == 0)
                {
                    return new List<UserDto>();
                }

                return Converter.FromUserListToDtoList(UsersWithCurrentRole); 
            }
            catch
            {
                return new List<UserDto>();
            }

            
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAllWardsWithoutTrainer()
        {
            List<UserDto> result = new List<UserDto>();

            try
            {
                Role curRole = rep.GetRoleByName("Ward");
                if (curRole == null)
                {
                    return new List<UserDto>();
                }

                List<User> UsersWithCurrentRole = rep.GetAllUsers().Where(user => user.RoleID == curRole.ID).ToList();
                if (UsersWithCurrentRole.Count == 0)
                {
                    return new List<UserDto>();
                }

                UsersWithCurrentRole.ForEach(item =>
                    {
                        if (!rep.HasTrainer(item.ID))
                        {
                            result.Add(Converter.FromUserToDto(item));
                        }
                    });

                return result;
            }
            catch
            {
                return new List<UserDto>();
            }
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAllWardsOfCurrentTrainer(Int32 trainerID)
        {
            List<User> wards = new List<User>();

            try
            {
                List<Int32> WardIDs = rep.GetWardIDsOfCurrentTrainer(trainerID);

                WardIDs.ForEach(item =>
                    {
                        wards.Add(rep.GetUserByID(item));
                    });

                return Converter.FromUserListToDtoList(wards);
            }
            catch
            {
                return new List<UserDto>();
            }
        }

        [HttpGet]
        public UserDto GetUserByID(Int32 id)
        {
            UserDto result = new UserDto();
            try
            {
                User dbUser = rep.GetUserByID(id);
                result = Converter.FromUserToDto(dbUser);               
            }
            catch (Exception ex)
            {
                return new UserDto();
            }

            return result; 
        }

        [HttpPost]
        public void Add([FromBody]UserDto userDto)
        {
            try
            {
                User user = Converter.FromDtoToUser(userDto);
                rep.AddUser(user);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
            
        }

        [HttpPut] 
        public void Edit(Int32 id, [FromBody]UserDto userDto)
        {
            try
            {
                User user = Converter.FromDtoToUser(userDto);
                user.ID = id;
                rep.UpdateUser(user);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotImplemented);
            }
        } 


        #region PrivateMethods
        
        #endregion
    }
}
