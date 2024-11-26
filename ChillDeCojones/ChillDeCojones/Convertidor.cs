using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public static class Convertidor
{
    public static byte[] ImageToBytes(Image image, System.Drawing.Imaging.ImageFormat format)
    {
        if(image != null)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();  // Inicia el cronómetro

            using (MemoryStream ms = new MemoryStream())
            {
                // Guarda la imagen en el MemoryStream en el formato especificado
                image.Save(ms, format);
                stopwatch.Stop();  // Detiene el cronómetro

                // Muestra el tiempo de ejecución
                //MessageBox.Show($"Tiempo de ejecución de ImageToBytes: {stopwatch.ElapsedMilliseconds} ms");

                return ms.ToArray();
            }
        }
        else
        {
            return null;
        }
    }

    public static Image BytesToImage(byte[] imageBytes)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();  // Inicia el cronómetro

        if (imageBytes == null || imageBytes.Length == 0)
            throw new ArgumentException("El array de bytes está vacío o es nulo.", nameof(imageBytes));

        using (MemoryStream ms = new MemoryStream(imageBytes))
        {
            // Crea un objeto Image desde el MemoryStream
            Image image = Image.FromStream(ms);
            stopwatch.Stop();  // Detiene el cronómetro

            // Muestra el tiempo de ejecución
            //MessageBox.Show($"Tiempo de ejecución de BytesToImage: {stopwatch.ElapsedMilliseconds} ms");

            return image;
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