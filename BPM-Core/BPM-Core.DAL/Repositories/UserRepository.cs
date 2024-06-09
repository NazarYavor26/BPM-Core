﻿using BPM_Core.DAL.DbContexts;
using BPM_Core.DAL.Entities;

namespace BPM_Core.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User? GetById(Guid? userId)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
