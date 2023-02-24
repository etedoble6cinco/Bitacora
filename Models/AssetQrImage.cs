namespace BitacoraAPP.Models
{
    public class AssetQrImage
    {
        public int IdAssetQrImage { get; set; }
        public Int64 IdAssetFK { get; set; }  
        public string QrImageData { get; set; }    
        public decimal QrHeight { get; set; }
        public decimal QrWidth { get; set; }  
        public string NameQrCode { get; set; }
        public string QrCodeDetails { get; set; }   
       
    }
}
