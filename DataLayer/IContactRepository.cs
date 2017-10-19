using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DataLayer
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetContactByID(int id);
        Contact Insert(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);

    }
}
