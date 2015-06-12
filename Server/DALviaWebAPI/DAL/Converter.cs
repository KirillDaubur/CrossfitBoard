using DALviaWebAPI.Models.DatabaseEntities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.DAL
{
    public static class Converter
    {
        static DALviaWebAPI.DAL.IRepository rep = new DALviaWebAPI.DAL.MsSqlRepository();

        public static UserDto FromUserToDto(User user)
        {
            return new UserDto()
            {
                ID = user.ID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Sex = user.Sex,
                Role = rep.GetRoleByID(user.RoleID).Name,
                Email = user.Email,
                ImageUrl = user.ImageUrl
            };
        }
        public static User FromDtoToUser(UserDto userDto)
        {
            return new User()
            {
                ID = userDto.ID,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Age = userDto.Age,
                Sex = userDto.Sex,
                RoleID = rep.GetRoleByName(userDto.Role).ID,
                Email = userDto.Email,
                ImageUrl = userDto.ImageUrl
            };
        }
        public static List<UserDto> FromUserListToDtoList(List<User> userList)
        {
            List<UserDto> result = new List<UserDto>();
            userList.ForEach(item =>
                {
                    result.Add(Converter.FromUserToDto(item));
                });
            return result;
        }

        internal static List<ExerciseDto> FromExerciseListToDtoList(List<Exercise> dbExercises)
        {
            List<ExerciseDto> result = new List<ExerciseDto>();
            dbExercises.ForEach(item =>
            {
                result.Add(Converter.FromExerciseToDto(item));
            });
            return result;
        }
        public static ExerciseDto FromExerciseToDto(Exercise item)
        {
            ExerciseDto result = new ExerciseDto()
            {
                ID = item.ID,
                Name = item.Name,
                Description = item.Description,
                ImageLink = item.ImageLink
            };
            return result;
        }
        internal static Exercise FromDtoToExercise(ExerciseDto dtoExercise)
        {
            Exercise result = new Exercise()
            {
                ID = dtoExercise.ID,
                Name = dtoExercise.Name,
                Description = dtoExercise.Description,
                ImageLink = dtoExercise.ImageLink
            };
            return result;
        }

        public static List<TackDto> FromTackListToDtoList(List<Tack> dbTacks)
        {
            List<TackDto> result = new List<TackDto>();
            dbTacks.ForEach(item =>
            {
                result.Add(Converter.FromTackToDto(item));
            });
            return result;
        }
        public static TackDto FromTackToDto(Tack item)
        {
            Exercise current = rep.GetExerciseByID(item.ExerciseID);
            TackDto result = new TackDto()
            {
                ID = item.ID,
                NumberOfIterations = item.NumberOfIterations,
                Exercise = FromExerciseToDto(current)
            };
            return result;
        }
        public static Tack FromDtoToTack(TackDto dtoTack)
        {
            Tack result = new Tack()
            {
                ID = dtoTack.ID,
                ExerciseID = dtoTack.Exercise.ID,
                NumberOfIterations = dtoTack.NumberOfIterations
            };
            return result;
        }

        public static RoundDto FromRoundToDto(Round round)
        {
            List<Tack> currentTacks = rep.GetTacksForCurrentRound(round.ID);
            List<TackDto> currentDtoTacks = new List<TackDto>();
            currentTacks.ForEach(item => 
            {
                currentDtoTacks.Add(FromTackToDto(item));
            });
            RoundDto result = new RoundDto()
            {
                ID = round.ID,
                TimeForRound = round.TimeForRound,
                RestAfterRound = round.RestAfterRound,
                Tacks = currentDtoTacks
            };
            return result;
        }
        public static Round FromDtoToRound(RoundDto dtoRound)
        {
            Round result = new Round()
            {
               ID = dtoRound.ID,
               TimeForRound = dtoRound.TimeForRound,
               RestAfterRound = dtoRound.RestAfterRound
            };
            return result;
        }

        public static WodDto FromWodToDto(Wod dbWod)
        {
            Round round = rep.GetRoundByID(dbWod.RoundID);
            RoundDto dtoRound = FromRoundToDto(round);

            User trainer = rep.GetUserByID(dbWod.TrainerID);
            UserDto dtoTrainer = FromUserToDto(trainer);

            User ward = rep.GetUserByID(dbWod.WardID);
            UserDto dtoWard = FromUserToDto(ward);

            WodDto result = new WodDto()
            {
                ID = dbWod.ID,
                NumberOfRounds = dbWod.NumberOfRounds,
                Round = dtoRound,
                Status = dbWod.Status,
                Trainer = dtoTrainer,
                Ward = dtoWard,
                WodResult = null
            };

            return result;
        }
        public static Wod FromDtoToWod(WodDto dtoWod)
        {        
            Wod result = new Wod()
            {
                ID = dtoWod.ID,
                NumberOfRounds = dtoWod.NumberOfRounds,
                RoundID = dtoWod.Round.ID,
                Status = dtoWod.Status,
                TrainerID = dtoWod.Trainer.ID,
                WardID = dtoWod.Ward.ID,
                WodResultID = (dtoWod.WodResult == null)?   0 : dtoWod.WodResult.ID 
        };

            return result;
        }


        public static WodResultDto FromWodResultToDto(WodResult dbWodResult)
        {
            User trainer = rep.GetUserByID(dbWodResult.TrainerID);
            UserDto dtoTrainer = FromUserToDto(trainer);

            User ward = rep.GetUserByID(dbWodResult.WardID);
            UserDto dtoWard = FromUserToDto(ward);

            WodResultDto result = new WodResultDto()
            {
                ID = dbWodResult.ID,
                HardnessLevel = dbWodResult.HardnessLevel,
                Trainer = dtoTrainer,
                Ward = dtoWard,
                TrainingDate = dbWodResult.TrainingDate,
                WardComment = dbWodResult.WardComment               
            };

            return result;
        }
        public static WodResult FromDtoToWodResult(WodResultDto dtoWodResult)
        {
            WodResult result = new WodResult()
            {
                ID = dtoWodResult.ID,
                HardnessLevel = dtoWodResult.HardnessLevel,
                TrainerID = dtoWodResult.Trainer.ID,
                WardID = dtoWodResult.Ward.ID,
                TrainingDate = dtoWodResult.TrainingDate,
                WardComment = dtoWodResult.WardComment            
            };

            return result;
        }
    }
}