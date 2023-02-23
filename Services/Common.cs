namespace BitacoraAPP.Services
{
    public class Common : ICommon
    {
        public async Task<string> GetImageHttpClientAsync(Uri uri)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(uri);
                    byte[] content =  await response.Content.ReadAsByteArrayAsync();
                    string img =  Convert.ToBase64String(content);
                    
                    string ImgString =string.Format("data:image/jpg;base64, {0}", img);
                  return ImgString; 
                }
            
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());  
                return "Imagen No Encontrada";
            }
        }


    }

}
