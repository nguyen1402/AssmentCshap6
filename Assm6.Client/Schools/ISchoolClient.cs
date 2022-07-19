using AssmentCshap6.Data.ViewModels;

namespace Assm6.Client.Schools
{
    public interface ISchoolClient
    {
        Task<List<SchoolVM>> GetAll();
    }
}
