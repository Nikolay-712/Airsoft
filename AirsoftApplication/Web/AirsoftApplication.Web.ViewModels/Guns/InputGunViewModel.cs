namespace AirsoftApplication.Web.ViewModels.Guns
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Data.Models.Guns;

    public class InputGunViewModel
    {
        [Required]
        [EnumDataType(typeof(GunType))]
        public GunType GunType { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Manufacture { get; set; }
    }
}
