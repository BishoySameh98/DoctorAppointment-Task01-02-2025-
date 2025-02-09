using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public IActionResult ListDoctors()
        {
            var Doctors = dbContext.Doctors.ToList();
            return View(Doctors);
        }

        public IActionResult BookAppointment(int id)
        {
            var doctor = dbContext.Doctors.Find(id);
            if (doctor != null)
            {
                return View(doctor);

            }
            return RedirectToAction("Error" , "Home");

        }

        public IActionResult SaveAppointment(Appointment appointment, string AppointmentTime)
        {
            appointment.AppointmentDate = appointment.AppointmentDate + " " + AppointmentTime;

            dbContext.Appointments.Add(new Appointment()
            {
                PatientName = appointment.PatientName,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.DoctorName,
                AppointmentDate = appointment.AppointmentDate,
                Status = "Completed",
            });

            dbContext.SaveChanges();

            return RedirectToAction("SaveAppointment");
        }

        public IActionResult ShowAllAppointments()
        {
            var completedAppointments = dbContext.Appointments.ToList();
            return View(completedAppointments);
        }

    }
}
