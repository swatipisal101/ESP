using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESPAPI.Models;



namespace ESPAPI.Repositories
{
 

    public class PrimaryDataRepository : IPrimaryDataRepository
    {
        private IespContext _context;

        public PrimaryDataRepository(IespContext context)
        {
            _context = context;
        }

        public PrimaryData[] GetPrimaryData()
        {
              return _context.primarydata.ToArray();
           
        }


        public PrimaryDataList[] GetPrimaryDataList()
        {
          //  return _context.primarydata.ToArray();
          var result= _context.primarydata.Select(PrimaryDataList =>
                                new PrimaryDataList
                                {
                                    id = PrimaryDataList.id,
                                    CustomerName = PrimaryDataList.CustomerName,
                                    ESP = PrimaryDataList.ESP,
                                    OriginalManufacturer= PrimaryDataList.OriginalManufacturer,
                                    Model= PrimaryDataList.Model,
                                    ProcessApplication= PrimaryDataList.ProcessApplication
                                }).ToArray();
            return result;
        }

        public PrimaryData GetPrimaryDataByID(int id)
        {
            var p = _context.primarydata.SingleOrDefault(a => a.id == id);
            return p;
        }

        public int AddNewPrimaryData(PrimaryData primarydata)
        {
            int insertSuccess = 0;
            int maxId = 0;
            try
            {
                maxId = _context.primarydata.Max(p => p.id);
            }
            catch
            {
                maxId = 0;

            }
            primarydata.id = (short)(maxId + 1);
            _context.primarydata.Add(primarydata);
            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }


        //// Better to use EntityState.Modified to update for unit testing
        public int UpdatePrimaryById(int id, PrimaryData p)
        {
            int updateSuccess = 0;
            var target = _context.primarydata.SingleOrDefault(a => a.id == id);
            if (target != null)
            {
                _context.Entry(target).CurrentValues.SetValues(p);
                updateSuccess = _context.SaveChanges();
            }
            return updateSuccess;
        }


        public int DeletePrimaryDataById(int id)
        {
            int deleteSuccess = 0;
            var p = _context.primarydata.SingleOrDefault(a => a.id == id);
            if (p != null)
            {
                _context.primarydata.Remove(p);
                deleteSuccess = _context.SaveChanges();
            }
            return deleteSuccess;
        }

        //public Actor GetActorById(int id)
        //{
        //    var actor = _context.Actor.SingleOrDefault(a => a.ActorId == id);
        //    return actor;
        //}

        //// Better to use EntityState.Modified to update for unit testing
        //public int UpdateActorById(int id, Actor actor)
        //{
        //    int updateSuccess = 0;
        //    var target = _context.Actor.SingleOrDefault(a => a.ActorId == id);
        //    if (target != null)
        //    {
        //        _context.Entry(target).CurrentValues.SetValues(actor);
        //        updateSuccess = _context.SaveChanges();
        //    }
        //    return updateSuccess;
        //}

        //// This is a better approach for unit testing
        //public int UpdateActorByIdEntityState(int id, Actor actor)
        //{
        //    int updateSuccess = 0;
        //    if (id != actor.ActorId)
        //    {
        //        return updateSuccess;
        //    }
        //    _context.MarkAsModified(actor);
        //    updateSuccess = _context.SaveChanges();
        //    return updateSuccess;
        //}



        //public int DeleteActorById(int id)
        //{
        //    int deleteSuccess = 0;
        //    var actor = _context.Actor.SingleOrDefault(a => a.ActorId == id);
        //    if (actor != null)
        //    {
        //        _context.Actor.Remove(actor);
        //        deleteSuccess = _context.SaveChanges();
        //    }
        //    return deleteSuccess;
        //}
    }
}
