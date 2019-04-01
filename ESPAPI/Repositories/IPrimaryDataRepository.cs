using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESPAPI.Models;

namespace ESPAPI.Repositories
{
  
    public interface IPrimaryDataRepository
    {
        int AddNewPrimaryData(PrimaryData p);       
        PrimaryData GetPrimaryDataByID(int id);
        PrimaryData[] GetPrimaryData();
        PrimaryDataList[] GetPrimaryDataList();
        int UpdatePrimaryById(int id, PrimaryData p);
        int DeletePrimaryDataById(int id);
        
        //int DeleteActorById(int id);
        //Actor GetActorById(int id);
        //PrimaryDataList[] GetPrimaryData();
        //int UpdateActorById(int id, Actor actor);
        //int UpdateActorByIdEntityState(int id, Actor actor);
    }
}
