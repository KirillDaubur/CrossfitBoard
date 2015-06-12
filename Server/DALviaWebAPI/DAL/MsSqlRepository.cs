using DALviaWebAPI.Models.DatabaseEntities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DALviaWebAPI.DAL
{
    public class MsSqlRepository : IRepository 
    {

        private DALviaWebAPI.Models.CrossfitBoardContext context = new Models.CrossfitBoardContext(); 

        #region Getters
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }
        public List<Exercise> GetAllExercises()
         {
            return context.Exercises.ToList();
        }
        public List<Round> GetAllRounds()
        {
            return context.Rounds.ToList();
        }
        public List<TrainerAndWard> GetAllTrainersAndWardsRelations()
        {
            return context.TrainersAndWards.ToList();
        }

        public List<Tack> GetTacksForCurrentRound(Int32 RoundID)
        {
            List<Tack> result = new List<Tack>();
            context.TacksInRounds.ToList().ForEach(x => {
                if(x.RoundID == RoundID)
                {
                    result.Add(GetTackByID(x.TackID));
                }
            });
            return result;
        }

        public List<Int32> GetWardIDsOfCurrentTrainer(Int32 trainerID)
        {
            List<Int32> result = new List<Int32>();
             context.TrainersAndWards.ToList().ForEach(x => {
                if(x.TrainerID == trainerID)
                {
                    result.Add(x.WardID);
                }
            });
            return result;
        }

        public Role GetRoleByID(Int32 RoleID)
        {
           return context.Roles.FirstOrDefault(x => x.ID == RoleID);
        }
        public Role GetRoleByName(String name)
        {
            return context.Roles.FirstOrDefault(r => r.Name == name);
        }
        public User GetUserByID(Int32 UserID)
        {
            User res = context.Users.FirstOrDefault(x => x.ID == UserID);
            return res;
        }
        public User GetUserByEmail(String email)
        {
            return context.Users.FirstOrDefault(r => r.Email == email);
        }
        public Wod GetWodByID(Int32 WodID)
        {
            return context.Wods.FirstOrDefault(x => x.ID == WodID);
        }
        public Wod GetWodByWardID(Int32 id)
        {
            return context.Wods.FirstOrDefault(x => x.WardID == id);
        }
        public WodResult GetWodResultByID(Int32 WodResultID)
        {
            return context.WodResults.FirstOrDefault(x => x.ID == WodResultID);
        }
        public WodResult GetWodResultByWodID(Int32 wodID)
        {
            WodResult result = context.WodResults.FirstOrDefault(wodr => wodr.WodID == wodID);
            return result;
        }
        public Exercise GetExerciseByID(Int32 ExerciseID)
        {
            return context.Exercises.FirstOrDefault(x => x.ID == ExerciseID);
        }
        public Tack GetTackByID(Int32 TackID)
        {
            return context.Tacks.FirstOrDefault(x => x.ID == TackID);
        }
        public Round GetRoundByID(Int32 RoundID)
        {
            return context.Rounds.FirstOrDefault(x => x.ID == RoundID);
        }

        public bool HasTrainer(Int32 wardID)
        {
            if (context.TrainersAndWards.Where(item=>item.WardID == wardID).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

     

        #endregion

        #region Adders

        public void AddUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddExercise(Exercise exercise)    
        {
            try
            {
                context.Exercises.Add(exercise);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddTack(Tack tack)
        {
            try
            {
                context.Tacks.Add(tack);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRound(Round round)
        {
            try
            {
                context.Rounds.Add(round);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddWod(Wod wod)
        {
            try
            {
                context.Wods.Add(wod);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddWodResult(WodResult wodResult)
        {
            try
            {
                context.WodResults.Add(wodResult);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddWardToTrainer(Int32 wardID, Int32 trainerID)
        {
            TrainerAndWard item = new TrainerAndWard() { TrainerID = trainerID, WardID = wardID };
            try
            {
                context.TrainersAndWards.Add(item);
                context.SaveChanges();
            }       
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Updaters

        public void UpdateUser(User user)
        {
             try
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public void UpdateExercise(Exercise exercise)
        {
            try
            {
                context.Entry(exercise).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateRound(Round round)
        {
            try
            {
                context.Entry(round).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateTack(Tack tack)
        {
            try
            {
                context.Entry(tack).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateWod(Wod wod)
        {
            try
            {
                context.Entry(wod).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateWodResult(WodResult wodResult)
        {
            try
            {
                context.Entry(wodResult).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}