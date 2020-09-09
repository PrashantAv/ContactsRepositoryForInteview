using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ContactProject.Repository
{
    public class ContactRepository:IContactRepository
    {
        private MVCEntities context;

        public ContactRepository(MVCEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return context.Contact.ToList();
        }

        public Contact GetContactByID(int ContactId)
        {
            return context.Contact.Find(ContactId);
        }

        public void InsertContact(Contact Contact)
        {
            context.Contact.Add(Contact);
        }

        public void DeleteContact(Contact Contact)
        {
            context.Entry(Contact).State = EntityState.Modified;
        }

        public void UpdateContact(Contact Contact)
        {
            context.Entry(Contact).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}