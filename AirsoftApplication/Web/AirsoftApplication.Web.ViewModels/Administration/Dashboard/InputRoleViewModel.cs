namespace AirsoftApplication.Web.ViewModels.Administration.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    public class InputRoleViewModel
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
