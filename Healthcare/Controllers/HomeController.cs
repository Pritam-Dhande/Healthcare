using Healthcare.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Healthcare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomePageViewModel
            {
                ContactForm = new ContactForm(),
                EnquiryForm = new EnquiryForm()
            };

            return View(model);
        }

        public ActionResult DisplayData()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveContact(HomePageViewModel frmdata)
        {
            ContactForm contact = frmdata.ContactForm;
            string path = Server.MapPath("~/App_Data/contacts.json");
            List<ContactForm> contacts = new List<ContactForm>();
            if (ModelState.IsValid)
            {
                 
                if (System.IO.File.Exists(path))
                {
                    string existingJson = System.IO.File.ReadAllText(path);
                    if (!string.IsNullOrWhiteSpace(existingJson))
                    {
                        contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContactForm>>(existingJson)
                                    ?? new List<ContactForm>();
                    }
                }
             int   _id = contacts.Count() + 1;
                contact.id = _id;
                
                contacts.Add(contact);

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(path, json);

                return Json(new { success = true, message = "Contact saved successfully" });
            }
            
            var errors = ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.First().ErrorMessage
                );

            return Json(new { success = false, errors });
        }

        [HttpPost]
        public JsonResult SaveEnquiry(HomePageViewModel frmdata)
        {
            EnquiryForm enquiry = frmdata.EnquiryForm;
            string path = Server.MapPath("~/App_Data/enquiry.json");
            List<EnquiryForm> enquiries = new List<EnquiryForm>();

            if (ModelState.IsValid)
            {
                if (System.IO.File.Exists(path))
                {
                    string existingJson = System.IO.File.ReadAllText(path);
                    if (!string.IsNullOrWhiteSpace(existingJson))
                    {
                        enquiries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryForm>>(existingJson)
                                    ?? new List<EnquiryForm>();
                    }
                }
                int _id = enquiries.Count() + 1;
                enquiry.id = _id;
                enquiries.Add(enquiry);

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(enquiries, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(path, json);


                return Json(new { success = true, message = "Enquiry saved successfully" });
            }

            var errors = ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.First().ErrorMessage
                );

            return Json(new { success = false, errors });
        }


        public ActionResult GetContacts()
        {
            string path = Server.MapPath("~/App_Data/contacts.json");
            List<ContactForm> contacts = new List<ContactForm>();

            if (System.IO.File.Exists(path))
            {
                string existingJson = System.IO.File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ContactForm>>(existingJson)
                                ?? new List<ContactForm>();
                }
            }

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEnquiries()
        {
            string path = Server.MapPath("~/App_Data/enquiry.json");
            List<EnquiryForm> enquiries = new List<EnquiryForm>();

            if (System.IO.File.Exists(path))
            {
                string existingJson = System.IO.File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    enquiries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EnquiryForm>>(existingJson)
                                ?? new List<EnquiryForm>();
                }
            }

            return Json(enquiries, JsonRequestBehavior.AllowGet);
        }


    }
}