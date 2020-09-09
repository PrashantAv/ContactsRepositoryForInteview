using System;
using System.Collections.Generic;

namespace ContactProject.Repository
{
    public interface IContactRepository:IDisposable
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContactByID(int contactId);
        void InsertContact(Contact contact);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
        void Save();
    }
}
