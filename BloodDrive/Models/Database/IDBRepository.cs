using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDrive.Models.Database
{
    public interface IDBRepository
    {
        public Task<List<Donator>> GetDonators();
        public List<BloodType> GetListOfBloodTypes();
        public Task AddDonator(Donator donator);
        public BloodType GetBloodType(int id);
        public Task DeleteDonator(int id);
        public bool DonatorExists(int? id);
        public Task<Donator> GetDonator(int? id);
        public Task UpdateDonator(Donator donator);
        public Donator GetDonatorNAsync(int? id);
        public Task<int> AddRecordAsync(Record record);
        public int AddRecord(Record record);
    }
}
