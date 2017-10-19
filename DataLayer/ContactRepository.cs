using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class ContactRepository : IContactRepository
    {
        public void Delete(Contact contact)
        {
            using (ContactDbEntities db = new ContactDbEntities())
            {
                db.Contacts.Attach(contact);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }

        public List<Contact> GetAll()
        {
            using (ContactDbEntities db = new ContactDbEntities())
            {
                return db.Contacts.ToList();
            }
        }

        public Contact GetContactByID(int id)
        {
            using (ContactDbEntities db = new ContactDbEntities())
            {
                return db.Contacts.Find(id);
            }
        }

        public Contact Insert(Contact contact)
        {
            using (ContactDbEntities db = new ContactDbEntities())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return contact;
            }
        }

        public void Update(Contact contact)
        {
            using (ContactDbEntities db = new ContactDbEntities())
            {
                db.Contacts.Attach(contact);
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
