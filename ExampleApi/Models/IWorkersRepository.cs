using System.Collections.Generic;

namespace ExampleApi.Models
{
    public interface IWorkersRepository
    {
        IEnumerable<Workers> Get();

        Workers Get(int id);

        void Create(Workers workers);

        void Update(Workers workers);

        Workers Delete(int id);
    }
}