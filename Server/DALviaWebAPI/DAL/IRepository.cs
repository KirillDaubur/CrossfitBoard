using DALviaWebAPI.Models.DatabaseEntities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.DAL
{
    public interface IRepository
    {

        #region Getters
            List<User> GetAllUsers();
            List<Exercise> GetAllExercises();
            List<Round> GetAllRounds();
            List<TrainerAndWard> GetAllTrainersAndWardsRelations();


            List<Tack> GetTacksForCurrentRound(Int32 RoundID);
            List<Int32> GetWardIDsOfCurrentTrainer(Int32 TrainerID);

            Role GetRoleByID(Int32 RoleID);
            Role GetRoleByName(String name);

            User GetUserByID(Int32 UserID);
            User GetUserByEmail(String email);

            Wod GetWodByID(Int32 WodID);
            Wod GetWodByWardID(Int32 id);

            WodResult GetWodResultByID(Int32 WodResultID);
            WodResult GetWodResultByWodID(Int32 wodID);

            Exercise GetExerciseByID(Int32 ExerciseID);

            Tack GetTackByID(Int32 TackID);

            Round GetRoundByID(Int32 RoundID);

            bool HasTrainer(Int32 WardID);            
            

        #endregion

        #region Adders

            void AddUser(User user);
            void AddExercise(Exercise exercise);
            void AddTack(Tack tack);
            void AddRound(Round round);
            void AddWod(Wod wod);
            void AddWodResult(WodResult wodResult);
            void AddWardToTrainer(Int32 WardID, Int32 TrainerID);

        #endregion

        #region Updaters

            void UpdateUser(User user);
            void UpdateExercise(Exercise exercise);
            void UpdateRound(Round round);
            void UpdateTack(Tack tack);
            void UpdateWod(Wod wod);
            void UpdateWodResult(WodResult wodResult);
         
        #endregion

            
    }
}