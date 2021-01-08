using MindYourMoodWeb.Entities;
using MindYourMoodWeb.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MindYourMoodWeb.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MindYourMoodWeb.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
            return await _context.Contacts
                .Include(u => u.User)
                .SingleOrDefaultAsync(c => c.Id == contactId);
        }

        public async Task<IEnumerable<ContactDto>> GetContactsAsync(int userId)
        {
            var contacts = await _context.Contacts
                .Include(u => u.User)
                .Where(u => u.User.Id == userId)
                .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return contacts;
        }

        public void RemoveContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
        }
    }
}
