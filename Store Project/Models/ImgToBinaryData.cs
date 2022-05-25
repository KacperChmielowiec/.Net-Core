namespace Store.Models
{
	public static class ImgToBinaryData
	{
        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileContent = null;
            fileName = @"C:\Users\kacper\Desktop\Store\Store\Store\wwwroot\"+fileName;
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
            long byteLength = new System.IO.FileInfo(fileName).Length;
            fileContent = binaryReader.ReadBytes((Int32)byteLength);
            
            fs.Close();
            fs.Dispose();
            binaryReader.Close();
            
            
            return fileContent;
        }
    }
}
