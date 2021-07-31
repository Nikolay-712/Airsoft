namespace AirsoftApplication.Web.ViewModels.Guns
{
    using System.ComponentModel.DataAnnotations;

    using AirsoftApplication.Common;
    using AirsoftApplication.Data.Models.Guns;

    public class InputGunViewModel
    {
        [Required]
        [EnumDataType(typeof(GunType))]
        public GunType GunType { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ManufactureMaxLenght)]
        [MinLength(GlobalConstants.ManufactureMinLenght)]
        public string Manufacture { get; set; }
    }
}
