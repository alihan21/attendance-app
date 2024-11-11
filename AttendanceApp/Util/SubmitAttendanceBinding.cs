using Microsoft.AspNetCore.Mvc;

namespace AttendanceApp.Util
{
    [BindProperties]
    public class SubmitAttendanceBinding
    {
        public int id { get; set; }
        public int gameId { get; set; }
    }
}
