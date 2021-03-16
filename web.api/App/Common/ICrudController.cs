using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web.api.App.Common
{
    public interface ICrudController<T_ViewModelPost, T_SearchParams>
    {
        Task<ObjectResult> Get(int id);
        Task<ObjectResult> Post(T_ViewModelPost viewModel);
        Task<ObjectResult> Put(int id, T_ViewModelPost viewModel);
        Task<ObjectResult> Delete(int id);
        Task<ObjectResult> Search(T_SearchParams searchParams);
    }
}