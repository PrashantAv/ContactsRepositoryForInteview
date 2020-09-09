#region Using Namespaces
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ContactProject.Repository;

#endregion

namespace ContactProject.Controllers
{
    /// <summary>
    /// My Controller to perform CRUD operations in MVC with the help of LINQ to SQL.
    /// </summary>
    public class MyController : Controller
    {

        #region Private member variables...
        private IContactRepository contactRepository; 
        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Controller to initialize contact Repository
        /// </summary>
        public MyController()
        {
            this.contactRepository = new ContactRepository(new MVCEntities());
        } 
        #endregion

        #region Display...
        /// <summary>
        /// Get Action for index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var contactList = from contact in contactRepository.GetContacts() select contact;
            var contacts = new List<ContactProject.Models.ContactModel>();
            if (contactList.Any())
            {
                foreach (var contact in contactList)
                {
                    contacts.Add(new ContactProject.Models.ContactModel() { ContactId = contact.ContactId, FirstName = contact.FirstName, LastName = contact.LastName, Status = contact.Status, EMail = contact.EMail, PhoneNo = contact.PhoneNo });
                }
            }
            return View(contacts);
        }

        /// <summary>
        /// Get Action for Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var contactDetails = contactRepository.GetContactByID(id);
            var contact = new ContactProject.Models.ContactModel();
            if (contactDetails != null)
            {
                contact.ContactId = contactDetails.ContactId;
                contact.FirstName = contactDetails.FirstName;
                contact.LastName = contactDetails.LastName;
                contact.PhoneNo = contactDetails.PhoneNo;
                contact.EMail = contactDetails.EMail;
                contact.Status = contactDetails.Status;
            }
            return View(contact);
        } 
        #endregion

        #region Create...
        /// <summary>
        /// Get Action for Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Action for Create
        /// </summary>
        /// <param name="contactDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ContactProject.Models.ContactModel contactDetails)
        {
            try
            {
               var contact = new Contact();
               if (ModelState.IsValid)
                {
               
                    //contact.ContactId = contactDetails.ContactId;
                    contact.FirstName = contactDetails.FirstName;
                    contact.LastName = contactDetails.LastName;
                    contact.PhoneNo = contactDetails.PhoneNo;
                    contact.EMail = contactDetails.EMail;
                    contact.Status = true; // Active
                    contactRepository.InsertContact(contact);
                    contactRepository.Save();
                    return RedirectToAction("Index");
                }
               return View();
            }
            catch
            {
                return View();
            }
        } 
        #endregion

        #region Edit...
        /// <summary>
        /// Get Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var contactDetails = contactRepository.GetContactByID(id);
            var contact = new ContactProject.Models.ContactModel();
            if (contactDetails != null)
            {
                contact.ContactId = contactDetails.ContactId;
                contact.FirstName = contactDetails.FirstName;
                contact.LastName = contactDetails.LastName;
                contact.PhoneNo = contactDetails.PhoneNo;
                contact.EMail = contactDetails.EMail;
                contact.Status = contactDetails.Status;
            }
            return View(contact);
        }

        /// <summary>
        /// Post Action for Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Contact contactDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var contact = contactRepository.GetContactByID(id);
                    contact.FirstName = contactDetails.FirstName;
                    contact.LastName = contactDetails.LastName;
                    contact.PhoneNo = contactDetails.PhoneNo;
                    contact.EMail = contactDetails.EMail;
                    contactRepository.UpdateContact(contact);
                    contactRepository.Save();
                    return RedirectToAction("Index");
                }
                return View();
            }
            
            catch
            {
                return View();
            }
        } 
        #endregion

        #region Delete...
        /// <summary>
        /// Get Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var contact = new ContactProject.Models.ContactModel();
            var contactDetails = contactRepository.GetContactByID(id);

            if (contactDetails != null)
            {
                contact.FirstName = contactDetails.FirstName;
                contact.LastName = contactDetails.LastName;
                contact.PhoneNo = contactDetails.PhoneNo;
                contact.EMail = contactDetails.EMail;
                contact.Status = contactDetails.Status;
            }
            return View(contact);
        }

        /// <summary>
        /// Post Action for Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactDetails"> </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, ContactProject.Models.ContactModel contactDetails)
        {
            try
            {
                var contact = contactRepository.GetContactByID(id);
                contact.Status = false;  // Inactive  - Soft delete functionality as per request in interview
                contactRepository.DeleteContact(contact);
                contactRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 
        #endregion
    }
}
