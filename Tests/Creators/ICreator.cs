using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Creators
{
    public interface ICreator<T>
    {
        public Task<T> CreateOne();
        public Task<List<T>> CreateMany(int count);
    }
}