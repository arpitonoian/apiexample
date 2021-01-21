using System.Collections.Generic;

namespace ExampleApi.Models
{
    public class WorkersRepository : IWorkersRepository
    {
        private WorkersContext Context;

        public WorkersRepository(WorkersContext context)
        {
            Context = context;
        }
        public IEnumerable<Workers> Get()
        {
            var data = Context.Workers;
            return data;
        }

        public Workers Get(int id)
        {
            return Context.Workers.Find(id);
        }

        public void Create(Workers workers)
        {
            Context.Workers.Add(workers);
            Context.SaveChanges();
        }

        public void Update(Workers updateworkers)
        {
            Workers currentworker = Get(updateworkers.Id);

            Context.Workers.Update(currentworker);
            Context.SaveChanges();
        }

        public Workers Delete(int id)
        {
            Workers workers = Get(id);
            if(workers!=null)
            {
                Context.Workers.Remove(workers);
                Context.SaveChanges();
            }
            return workers;
        }
    }
}