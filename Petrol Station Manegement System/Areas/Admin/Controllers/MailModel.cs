namespace Petrol_Station_Manegement_System.Areas.Admin.Controllers
{
    public class MailModel
    {
        public string? To { get; internal set; }
        public string? From { get; internal set; }
        public string? Subject { get; internal set; }
        public string? Body { get; internal set; }
    }
}