﻿using ModernStore.Domain.Repositories;
using ModernStore.Domain.Entities;
using ModernStore.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using ModernStore.Domain.Commands.Results;
using System.Linq;
using Dapper;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly ModerStoreDataContext _context;

        public CustomerRepository(ModerStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document) =>
            _context.Customers.AnyAsync(x => x.Document.Number == document).Result;

        public Customer Get(Guid id)
            => _context.Customers.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id).Result;

        public GetCustomerCommandResult Get(string username)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                var query = "SELECT * FROM GetCustumerInfoView WHERE [Active] = 1 AND [Username] = @username";
                conn.Open();
                return conn.QueryFirst<GetCustomerCommandResult>(query, new { username = username });
            }
        }

        // public GetCustomerCommandResult Get(string username) =>
        //     _context.Customers.Include(x=>x.User).AsNoTracking()
        //     .Select(x => new GetCustomerCommandResult()
        //     {
        //         Name = x.Name.ToString(),
        //         Active = x.User.Active,
        //         Document = x.Document.Number,
        //         Email = x.Email.Address,
        //         Password = x.User.Password,
        //         Username = x.User.Username
        //     }).FirstOrDefaultAsync(x=> x.Username == username).Result;


        public Customer GetByUsername(string username)
            => _context.Customers.Include(x => x.User).AsNoTracking().FirstOrDefaultAsync(x => x.User.Username == username).Result;


        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
