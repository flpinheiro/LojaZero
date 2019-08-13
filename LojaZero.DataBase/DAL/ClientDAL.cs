using LojaZero.Context;
using LojaZero.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LojaZero.DAL
{
    public class ClientDAL : DAL<Client>
    {
        public ClientDAL(LojaZeroDbContext context) : base(context)
        {
        }

        public override void Create(Client t)
        {
            _context.Clients.Add(t);
            _context.SaveChanges();
        }

        public override void Delete(Client t)
        {
            _context.Clients.Remove(t);
            _context.SaveChanges();
        }

        public override Client Read(int i) =>
            _context.Clients.Find(i);

        public override ICollection<Client> ReadAll() =>
            _context.Clients.ToList();
        

        public override void Update(Client t)
        {
            _context.Clients.Update(t);
            _context.SaveChanges();
        }
    }
}
