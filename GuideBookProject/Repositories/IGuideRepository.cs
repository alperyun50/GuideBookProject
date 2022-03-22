using GuideBookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Repositories
{
    interface IGuideRepository
    {
        Task<Person> Add_Person(Person person);

        Task<Person> Update_Person(Person person);

        //Task<Person> Get_Person(int userId);

        Task<IEnumerable<Person>> Get_Persons();

        Task Delete_Person(int userId);

        Task Remove_Person(int userId);


        Task<CommInfo> Add_CommInfo(CommInfo commInfo);

        Task Remove_CommInfo(int commInfoID);

        Task<CommInfo> Get_CommInfo(int commInfoID);

        //Task<> Location_Report();
    }
}
