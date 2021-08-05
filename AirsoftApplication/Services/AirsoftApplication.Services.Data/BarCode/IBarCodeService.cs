namespace AirsoftApplication.Services.Data.BarCode
{
    public interface IBarCodeService
    {
        void CreateBarCode(string userId, string roleName);

        string ReadingBarCode(string codeName);
    }
}
