using System;
using System.Drawing;
using System.IO;

public static class Convertidor
{
    public static byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image), "La imagen no puede ser nula.");

        using (MemoryStream ms = new MemoryStream())
        {
            // Guarda la imagen en el MemoryStream en el formato especificado
            image.Save(ms, format);
            return ms.ToArray();
        }
    }

    public static Image BytesToImage(byte[] imageBytes)
    {
        if (imageBytes == null || imageBytes.Length == 0)
            throw new ArgumentException("El array de bytes está vacío o es nulo.", nameof(imageBytes));

        using (MemoryStream ms = new MemoryStream(imageBytes))
        {
            // Crea un objeto Image desde el MemoryStream
            return Image.FromStream(ms);
        }
    }

    public static byte[] StringToBytes(string str)
    {
        if (str == null)
            throw new ArgumentNullException(nameof(str), "La cadena no puede ser nula.");
        return System.Text.Encoding.UTF8.GetBytes(str);
    }

    public static string BytesToString(byte[] bytes)
    {
        if (bytes == null)
            throw new ArgumentNullException(nameof(bytes), "El array de bytes no puede ser nulo.");
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}
