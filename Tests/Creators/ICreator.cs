using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.Creators
{
    public interface ICreator<T>
    {
        public Task<T> CreateOne();
        public Task<IEnumerable<T>> CreateMany(int count);
    }
}