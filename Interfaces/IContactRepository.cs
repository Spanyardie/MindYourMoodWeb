using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindYourMoodWeb.Interfaces
{
    public interface IContactRepository
    {
        void Update(Contact contact);
        Task<IEnumerable<ContactDto>> GetContactsAsync(int userId);
        Task<Contact> GetContactAsync(int contactId);
        void AddContact(Contact contact);
        void RemoveContact(Contact contact);
    }
}
