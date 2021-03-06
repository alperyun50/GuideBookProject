using GuideBookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideBookProject.Repositories
{
    public interface IGuideRepository
    {
        Task<Person> Add_Person(Person person);

        Task<Person> Update_Person(Person person);

        Task<Person> Get_Person(int userId);

        Task<IEnumerable<Person>> Get_Persons();

        Task Delete_Person(int userId);

        Task Remove_Person(int userId);


        //Task<CommInfo> Add_CommInfo(CommInfo commInfo);

        Task<List<CommInfo>> Add_CommInfo(CommInfoDTO commInfoDto);

        Task Remove_CommInfo(int commInfoID);

        //Task<CommInfo> Get_CommInfo(int commInfoID);

        Task<List<CommInfo>> Get_CommInfo(int commInfoID);

        Task<List<Report>> Reportx();
    }
}
