using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDrive.Models.Database
{
    public class EFDBRepository : IDBRepository
    {
        private readonly DBContext context;
        public EFDBRepository(DBContext context)
        {
            this.context = context;
        }

        public async Task AddDonator(Donator donator)
        {
            context.Add(donator);
            await context.SaveChangesAsync();
        }

        public async Task<int> AddRecordAsync(Record record)
        {
            Record newRecord = new Record();
            newRecord.DateDonated = record.DateDonated;
            newRecord.DonatorID = record.DonatorID;
           
            context.Entry(newRecord).State = EntityState.Added;
            return await context.SaveChangesAsync();
            
            
        }

        public void AddRecord(Record record)
        {
            context.Add(record);
            record.donator.Elligible = false;
            context.SaveChanges();
        }

        public async Task DeleteDonator(int id)
        {
            context.Donators.Remove(await context.Donators.FindAsync(id));
            await context.SaveChangesAsync();
        }

        public bool DonatorExists(int? id)
        {
            if (context.Donators.Any(d => d.ID == id))
                return true;
            return false;
        }

        public BloodType GetBloodType(int id)
        {
            var bloodtype = context.BloodTypes.Find(id);
            return bloodtype;
        }

        public async Task<Donator> GetDonator(int? id)
        {
            var donator = await context.Donators.Where(d => d.ID == id).Include(d => d.BloodType).FirstOrDefaultAsync();
            donator.Records = context.Records.Where(f => f.DonatorID == id).ToList();
            return donator;
        }

        public Donator GetDonatorNAsync(int? id)
        {
            var donator = context.Donators.Where(d => d.ID == id).Include(d => d.BloodType).FirstOrDefault();
            return donator;
        }

        public async Task<List<Donator>> GetDonators()
        {
            return await context.Donators.Include(d => d.BloodType).ToListAsync();
        }

        public List<BloodType> GetListOfBloodTypes()
        {
            return (from bloodtypes in context.BloodTypes
                          select bloodtypes).ToList();
        }

        public async Task UpdateDonator(Donator donator)
        {
            context.Donators.Update(donator);
            await context.SaveChangesAsync();
        }

        public bool DonatorIsElligible(int id)
        {
            var donator = context.Donators.Find(id);
            if (donator.Elligible)
                return true;
            return false;
        }


        public int DonorCount()
        {
            return context.Donators.Count();
        }
    }
}
