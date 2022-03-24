using GuideBookProject.Models;
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
            var result = await _guideDbContext.Persons.Where(x => x.Status == true).FirstOrDefaultAsync(e => e.UserID == userId);

            if (result != null)
            {
                _guideDbContext.Persons.Remove(result);
                await _guideDbContext.SaveChangesAsync();
            }
        }

        public async Task Remove_Person(int userId)
        {
            var result = await _guideDbContext.Persons.Where(x => x.Status == true).FirstOrDefaultAsync(e => e.UserID == userId);
            result.Status = false;

            _guideDbContext.Persons.Update(result);
            await _guideDbContext.SaveChangesAsync();
        }

        public async Task<Person> Get_Person(int userId)
        {
            var result = await _guideDbContext.Persons.Where(x => x.Status == true).FirstOrDefaultAsync(x => x.UserID == userId);

            return result;
        }

        public async Task<IEnumerable<Person>> Get_Persons()
        {
            var result = await _guideDbContext.Persons.Where(x => x.Status == true).ToListAsync();

            return result;
        }

        public async Task<Person> Update_Person(Person person)
        {
            var result = await _guideDbContext.Persons.Where(x => x.Status == true).FirstOrDefaultAsync(e => e.UserID == person.UserID);

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



        public async Task<List<CommInfo>> Add_CommInfo(CommInfoDTO commInfoDto)
        {
            var person = await _guideDbContext.Persons.FindAsync(commInfoDto.PersonID);

            var newCommInfo = new CommInfo
            {
                Email = commInfoDto.Email,
                Location = commInfoDto.Location,
                TelNo = commInfoDto.TelNo,
                Status = commInfoDto.Status,
                Person = person
            };

            _guideDbContext.CommInfos.Add(newCommInfo);
            await _guideDbContext.SaveChangesAsync();

            return await Get_CommInfo(newCommInfo.PersonID);
        }


        public async Task Remove_CommInfo(int commInfoID)
        {
            var result = await _guideDbContext.CommInfos.Where(x => x.Status == true).FirstOrDefaultAsync(e => e.CommInfoID == commInfoID);

           if(result != null)
            { 
                result.Status = false;

                _guideDbContext.CommInfos.Update(result);
                await _guideDbContext.SaveChangesAsync();
            }
        }

       

        public async Task<List<CommInfo>> Get_CommInfo(int commInfoID)
        {
            var results = await _guideDbContext.CommInfos.Where(x => x.PersonID == commInfoID && x.Status == true).ToListAsync();

            return results;
        }


        public async  Task<List<Report>> Reportx()
        {
            List<Report> result = null;

            try
            {
               result = await (
                             from p in _guideDbContext.CommInfos
                             group p by p.Location into g
                                   select new Report()
                                    {
                                      Location = g.Key,
                                      LocationCount = g.Select(m => m.Location).Count(),
                                      TelCount = g.Select(c => c.TelNo).Count(),
                                      PersonCount=g.Select(l => l.PersonID).Count()
                                    }
                              ).OrderByDescending(x => x.LocationCount).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
                  
            return result;

        }
    }
}
