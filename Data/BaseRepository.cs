﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Data
{
    public class BaseRepository<T, TDto> : IRepository<T, TDto> where T : Entity where TDto : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _items;
        private readonly IMapper _mapper;
        private readonly IList<string> _includes;

        public BaseRepository(DataContext context, IMapper mapper, IList<string> includes)
        {
            _context = context;
            _mapper = mapper;
            if (includes == null)
            {
                _includes = new List<string>();
            }
            else
            {
                _includes = includes;
            }
            _items = _context.Set<T>();
        }

        public void AddItem(T t)
        {
            _items.Add(t);
        }

        public async Task<T> GetItemAsync(int Id)
        {
            var query = AddIncludes();
            return await query.SingleOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<IEnumerable<TDto>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            var query = AddIncludes();
            if (predicate != null)
                query = query.Where(predicate);
            var items = await query.ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return items;
        }

        public void RemoveItem(T t)
        {
            _context.Remove(t);
        }

        public void Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }

        private IQueryable<T> AddIncludes()
        {
            IQueryable<T> query = _items;
            foreach (var include in _includes)
                query = query.Include(include);

            return query;
        }
    }
}
