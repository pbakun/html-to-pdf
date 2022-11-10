using RazorEngineCore;
using System.Globalization;

namespace HTML2PDF.RazorEngine.Templates
{
    public class RazorTemplate<T> : HtmlSafeTemplate<T>
    {
        public string FormatDate(string dateString) => DateTime.ParseExact(dateString, "yyyy/MM/dd", CultureInfo.CurrentCulture).ToString("yyyy/MM/dd");

        public string ConvertImageBase64String(string path)
        {
			string base64Image = string.Empty;
			using (StreamReader reader = new StreamReader(path))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					reader.BaseStream.CopyTo(memoryStream);
					byte[] bytes = memoryStream.ToArray();
					string base64 = Convert.ToBase64String(bytes);
					base64Image = $"data:image/png;base64,{base64}";
				}
			}
			if (string.IsNullOrEmpty(base64Image))
				return string.Empty;
			return base64Image;
		}
    }
}
