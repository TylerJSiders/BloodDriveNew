using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDrive.Models.Database
{
    public class MongoDbRepo : IDBRepository
    {
        public Task AddDonator(Donator donator)
        {
            throw new NotImplementedException();
        }

        public void AddRecord(Record record)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRecordAsync(Record record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDonator(int id)
        {
            throw new NotImplementedException();
        }

        public bool DonatorExists(int? id)
        {
            throw new NotImplementedException();
        }

        public bool DonatorIsElligible(int id)
        {
            throw new NotImplementedException();
        }

        public int DonorCount()
        {
            throw new NotImplementedException();
        }


        public BloodType GetBloodType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Donator> GetDonator(int? id)
        {
            throw new NotImplementedException();
        }

        public Donator GetDonatorNAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Donator>> GetDonators()
        {
            throw new NotImplementedException();
        }

        public List<BloodType> GetListOfBloodTypes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateDonator(Donator donator)
        {
            throw new NotImplementedException();
        }
    }
}
