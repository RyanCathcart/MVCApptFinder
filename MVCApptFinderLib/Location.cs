using System;

namespace MVCApptFinderLib
{
    public class Location
    {
        public string LocationTitle { get; set; }
        public string AppointmentType { get; set; }
        public string LocationAddress { get; set; }
        public DateTime AppointmentTime { get; set; }

        public void Print()
        {
            Console.WriteLine(LocationTitle);
            Console.WriteLine(AppointmentType);
            Console.WriteLine(LocationAddress);
            Console.WriteLine($"Next Appt: {AppointmentTime:MM/dd/yyyy H:mm tt}");
            Console.WriteLine();
        }
    }
}