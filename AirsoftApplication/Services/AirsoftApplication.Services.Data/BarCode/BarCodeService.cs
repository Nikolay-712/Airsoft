namespace AirsoftApplication.Services.Data.BarCode
{
    using System.Drawing;
    using System.IO;
    using System.Linq;

    using AirsoftApplication.Common;
    using IronBarCode;

    public class BarCodeService : IBarCodeService
    {
        private const string FoldierDirectory = @"C:\Users\nikol\OneDrive\Desktop\BarCodes\";
        private const string ImageFormat = ".jpeg";

        public void CreateBarCode(string userId, string roleName)
        {
            GeneratedBarcode barCode = BarcodeWriter
                .CreateBarcode(userId, BarcodeWriterEncoding.Code128);

            var barcodeText = GlobalConstants.Team.Name + " - " + roleName;

            barCode
                .ResizeTo(300, 150)
                .SetMargins(20)
                .AddAnnotationTextAboveBarcode(barcodeText)
                .AddBarcodeValueTextBelowBarcode();
            barCode.ChangeBackgroundColor(Color.LightGoldenrodYellow);

            barCode.SaveAsJpeg(FoldierDirectory + userId + ImageFormat);
        }

        public string ReadingBarCode(string codeName)
        {
            var scanerResult = this.GetScanerResult(codeName);
            string userId = string.Empty;

            if (scanerResult == null)
            {
                return userId;
            }

            var barCodeResult = BarcodeReader.QuicklyReadOneBarcode(scanerResult);

            if (barCodeResult != null)
            {
                userId = barCodeResult.Value;
            }

            return userId;
        }

        /// The scanner must return information from the scanned bar code
        private string GetScanerResult(string name)
        {
            if (Directory.Exists(FoldierDirectory))
            {
                var result = Directory
                      .GetFiles(FoldierDirectory, name + ImageFormat);

                return result.FirstOrDefault();
            }

            return null;
        }
    }
}
