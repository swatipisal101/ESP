using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESPAPI.Models;

namespace ESPAPI.Repositories
{
    public interface ISecondaryDataRepository
    {
        int AddNewSecondaryData(SecondaryDesignData s);
        SecondaryDesignData GetSecondaryDataByID(int id);
        SecondaryDesignData[] GetSecondaryData();
        SecondaryDataList[] GetSecondaryDataList();
        int UpdateSecondaryById(int id, SecondaryDesignData s);
        int DeleteSecondaryDataById(int id);


        int AddNewSecondaryOperatingData(SecondaryOperatingData s);
    }
}
