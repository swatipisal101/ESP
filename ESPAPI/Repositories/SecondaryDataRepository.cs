using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESPAPI.Models;

namespace ESPAPI.Repositories
{
    public class SecondaryDataRepository : ISecondaryDataRepository
    {
        private IespContext _context;

        public SecondaryDataRepository(IespContext context)
        {
            _context = context;
        }

        public SecondaryDesignData[] GetSecondaryData()
        {
            return _context.secondarydata.ToArray();

        }


        public SecondaryDataList[] GetSecondaryDataList()
        {
            var result = _context.secondarydata.Select(SecondaryDataList =>
                                   new SecondaryDataList
                                   {
                                       id = SecondaryDataList.id,
                                       CustomerName = SecondaryDataList.CustomerName,
                                       ESP = SecondaryDataList.ESP,
                                       OriginalManufacturer = SecondaryDataList.OriginalManufacturer,
                                       Model = SecondaryDataList.Model,
                                       ProcessApplication = SecondaryDataList.ProcessApplication
                                   }).ToArray();
            return result;
        }

        public SecondaryDesignData GetSecondaryDataByID(int id)
        {
            var p = _context.secondarydata.SingleOrDefault(a => a.id == id);
            return p;
        }

        public int AddNewSecondaryData(SecondaryDesignData Secondarydata)
        {
            int insertSuccess = 0;
            int maxId = 0;
            try
            {
                maxId = _context.secondarydata.Max(p => p.id);
            }
            catch
            {
                maxId = 0;

            }
            Secondarydata.id = (short)(maxId + 1);
            _context.secondarydata.Add(Secondarydata);
            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }


        //// Better to use EntityState.Modified to update for unit testing
        public int UpdateSecondaryById(int id, SecondaryDesignData p)
        {
            int updateSuccess = 0;
            var target = _context.secondarydata.SingleOrDefault(a => a.id == id);
            if (target != null)
            {
                _context.Entry(target).CurrentValues.SetValues(p);
                updateSuccess = _context.SaveChanges();
            }
            return updateSuccess;
        }


        public int DeleteSecondaryDataById(int id)
        {
            int deleteSuccess = 0;
            var p = _context.secondarydata.SingleOrDefault(a => a.id == id);
            if (p != null)
            {
                _context.secondarydata.Remove(p);
                deleteSuccess = _context.SaveChanges();
            }
            return deleteSuccess;
        }



        public int AddNewSecondaryOperatingData(SecondaryOperatingData Secondaryoperdata)
        {
            int insertSuccess = 0;
          
            int maxId = 0;
            try
            {
                maxId = _context.secondaryoperatingdata.Max(p => p.id);
            }
            catch
            {
                maxId = 0;

            }
            Secondaryoperdata.id = (short)(maxId + 1);
            _context.secondaryoperatingdata.Add(Secondaryoperdata);
            insertSuccess = _context.SaveChanges();

            return insertSuccess;

        }
    }
}
