namespace Hospital.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int  DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string AppointmentDate { get; set; }

        public string PatientName { get; set; }

        public string Status { get; set; }

        public Doctor Doctor { get; set; }

    }
}
