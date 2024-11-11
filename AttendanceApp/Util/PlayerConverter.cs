using AttendanceApp.Data;

namespace AttendanceApp.Util
{
    public static class PlayerConverter
    {
        public static Attendee ConvertToAttendee(Player? player, AttendanceType attendanceType)
        {
            String name = "default";
            String img = "default";
            if (player != null)
            {
                name = player.Name;
                img = player.PlayerImage;
            }

            return new Attendee()
            {
                Name = name,
                PlayerImage = img,
                IsPresent = (short)attendanceType
            };
        }
    }
}
