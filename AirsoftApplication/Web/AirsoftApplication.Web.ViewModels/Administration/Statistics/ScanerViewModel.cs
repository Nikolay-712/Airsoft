namespace AirsoftApplication.Web.ViewModels.Administration.Statistics
{
    using System.ComponentModel.DataAnnotations;

    public class ScanerViewModel
    {
        [Required]
        public string UserId { get; set; }
    }
}
