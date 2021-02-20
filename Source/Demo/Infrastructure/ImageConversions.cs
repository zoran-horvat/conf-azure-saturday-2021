using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Demo.Infrastructure
{
    public static class ImageConversions
    {
        public static string ToBase64String(this Image image) =>
            image is null ? string.Empty
            : image.GetContent().ToBase64String();

        private static string ToBase64String(this byte[] jpegContent) =>
            jpegContent.Length == 0 ? string.Empty
            : $"data:image/png;base64,{Convert.ToBase64String(jpegContent)}";

        private static byte[] GetContent(this Image image)
        {
            using Stream stream = new MemoryStream();

            image?.Save(stream, ImageFormat.Jpeg);
            stream.Position = 0;
            byte[] content = new byte[stream.Length];

            stream.Read(content, 0, content.Length);

            return content;
        }
    }
}
