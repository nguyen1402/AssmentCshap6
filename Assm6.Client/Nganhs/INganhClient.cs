using AssmentCshap6.Data.ViewModels;

namespace Assm6.Client.Nganhs
{
    public interface INganhClient
    {
        Task<List<NganhVM>> GetAll();
    }
}
