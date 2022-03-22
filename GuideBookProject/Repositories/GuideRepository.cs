﻿using GuideBookProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace GuideBookProject.Repositories
{
    public class GuideRepository : IGuideRepository
    {
        private readonly GuideDbContext _guideDbContext;


        public GuideRepository(GuideDbContext guideDbContext)
        {
            _guideDbContext = guideDbContext;
        }


        public async Task<Person> Add_Person(Person person)
        {
            var result = await _guideDbContext.Persons.AddAsync(person);
            await _guideDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete_Person(int userId)
        {
            var result = await _guideDbContext.Persons.FirstOrDefaultAsync(e => e.UserID == userId);

            if (result != null)
            {
                _guideDbContext.Persons.Remove(result);
                await _guideDbContext.SaveChangesAsync();
            }
        }

        public async Task Remove_Person(int userId)
        {
            var result = await _guideDbContext.Persons.FindAsync(userId);
            result.Status = false;

            _guideDbContext.Persons.Update(result);
            await _guideDbContext.SaveChangesAsync();
        }

        public async Task<Person> Get_Person(int userId)
        {
            return await _guideDbContext.Persons.FirstOrDefaultAsync(x => x.UserID == userId);
        }

        public async Task<IEnumerable<Person>> Get_Persons()
        {
            // please check include method
            return await _guideDbContext.Persons.ToListAsync();
        }

        public async Task<Person> Update_Person(Person person)
        {
            var result = await _guideDbContext.Persons.FirstOrDefaultAsync(e => e.UserID == person.UserID);

            if (result != null)
            {
                result.Name = person.Name;
                result.Surname = person.Surname;
                result.Company = person.Company;
                result.Status = true;

                _guideDbContext.Persons.Update(result);
                await _guideDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }



        public async Task<CommInfo> Add_CommInfo(CommInfo commInfo)
        {
            var result = await _guideDbContext.CommInfos.AddAsync(commInfo);
            await _guideDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Remove_CommInfo(int commInfoID)
        {
            var result = await _guideDbContext.CommInfos.FindAsync(commInfoID);
            result.Status = false;

            _guideDbContext.CommInfos.Update(result);
            await _guideDbContext.SaveChangesAsync();
        }

        public async Task<CommInfo> Get_CommInfo(int commInfoID)
        {
            var result = await _guideDbContext.CommInfos.Include(x => x.Person).FirstOrDefaultAsync(x => x.CommInfoID == commInfoID);

            return result;
        }

        //public async Task<Person> Report(string location)
        //{
        //    //var locationwithamount = _guideDbContext.CommInfos.OrderByDescending(x => x.Location).Count();

        //    var locationwithamount2 = _guideDbContext.CommInfos.OrderByDescending(x => x.Location)
        //        .GroupBy(x => x.Location)
        //        .Select(Location => new { Location = Location.Key, LocationNumber = Location.Count() });

        //    foreach(var locations in locationwithamount2)
        //    {

        //    }

        //    var persons = _guideDbContext.CommInfos.Where(x => x.Location == location).Select(y => y.Person.UserID).Count();

        //    var telnos = _guideDbContext.CommInfos.Where(x => x.Location == location).Select(y => y.TelNo).Count();



            
        //}
    }
}
