using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angular2App.Controllers
{
    public class AngularAppointmentController : ApiController
    {
        NewDBAppointmentEntities db = new NewDBAppointmentEntities();
        
        public IEnumerable<AppointmentTBL> Get()
        {
            return db.AppointmentTBLs.ToList();

        }

        [HttpGet]
        public AppointmentTBL Get(int id)
        {

            return db.AppointmentTBLs.FirstOrDefault(x => x.AppointmentId == id);

        }
        [HttpPost]
        public string Post(AppointmentTBL appointment)
        {

            var app = db.AppointmentTBLs.SingleOrDefault(c => c.ConsumerName == appointment.ConsumerName);
            if (app == null)
            {
                db.AppointmentTBLs.Add(appointment);
                db.SaveChanges();
                return "Success";
            }
            return "Already Exist";
        }
        [HttpPut]
        public string UpdateAppointment(int id, AppointmentTBL appointment)
        {

            var selectedAppointment = db.AppointmentTBLs.FirstOrDefault(x => x.AppointmentId == id);
            if (selectedAppointment == null)
            {
                return "No Such AppointmentId Exist";
            }
            selectedAppointment.AppointmentTypeId = appointment.AppointmentTypeId;
            selectedAppointment.ConsumerId = appointment.ConsumerId;
            selectedAppointment.ConsumerName = appointment.StatusCode;
            selectedAppointment.StatusCode = appointment.ConsumerName;

            db.SaveChanges();
            return "Updated Successfully";

        }
        [HttpDelete]
        public string DeleteAppointment(int id)
        {
            var deleteAppointment = db.AppointmentTBLs.FirstOrDefault(x => x.AppointmentId == id);
            if (deleteAppointment == null)
            {
                return "No Such AppointmentId Exist";
            }
            db.AppointmentTBLs.Remove(deleteAppointment);
            db.SaveChanges();
            return "Deleted Successfully";
        }
    }
}
