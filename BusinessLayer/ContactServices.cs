using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ContactServices
    {
        private IContactRepository contactRepository;

        private static ContactServices instance;

        public static ContactServices Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new ContactServices();
                }
                return instance;
            }
        }

        private ContactServices()
        {
            contactRepository = new ContactRepository();
        }


        #region Methods
        public List<Contact> GetAll()
        {
            return contactRepository.GetAll();
        }
        public Contact GetContactByID(int id)
        {
            return contactRepository.GetContactByID(id);
        }
        public Contact Insert(Contact contact)
        {
            return contactRepository.Insert(contact);
        }
        public void Update(Contact contact)
        {
            contactRepository.Update(contact);
        }
        public void Delete(Contact contact)
        {
            contactRepository.Delete(contact);
        }

        #endregion
    }
}
