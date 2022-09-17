using Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    tran.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    var exception = ex.Message;
                    return 0;
                }
            }
        }
    }
}
