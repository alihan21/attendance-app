﻿namespace AttendanceApp.Data
{
    public class Game
    {
        public String GameId{ get; set; }

        public String Title{ get; set; }

        public String Date{ get; set; }

        public String Address{ get; set; }
        public List<Attendee> Attendees { get; set; }
    }
}
