using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public static class Convertidor
{
    public static byte[] ImageABytes(Image image, System.Drawing.Imaging.ImageFormat format)
    {
        if (image != null)
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

    public static Image BytesAImage(byte[] imageBytes)
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

    public static byte[] StringABytes(string str)
    {
        if (str == null)
            throw new ArgumentNullException(nameof(str), "La cadena no puede ser nula.");
        return System.Text.Encoding.UTF8.GetBytes(str);
    }

    public static string BytesAString(byte[] bytes)
    {
        if (bytes == null)
            throw new ArgumentNullException(nameof(bytes), "El array de bytes no puede ser nulo.");
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    public static byte[] DateTimeABytes(DateTime dateTime)
    {
        long ticks = dateTime.Ticks; // Obtiene los ticks de DateTime
        return BitConverter.GetBytes(ticks); // Convierte los ticks a un array de bytes
    }

    // Convierte bytes a DateTime
    public static DateTime BytesADateTime(byte[] bytes)
    {
        if (bytes == null || bytes.Length != 8) // DateTime usa 8 bytes (long)
            throw new ArgumentException("El array de bytes no es válido para convertir a DateTime.", nameof(bytes));

        long ticks = BitConverter.ToInt64(bytes, 0); // Convierte los bytes a un entero largo (long)
        return new DateTime(ticks); // Crea el objeto DateTime a partir de los ticks
    }

    // Convierte float a bytes
    public static byte[] FloatABytes(float value)
    {
        return BitConverter.GetBytes(value); // Convierte el float a un array de bytes
    }

    // Convierte bytes a float
    public static float BytesAFloat(byte[] bytes)
    {
        if (bytes == null || bytes.Length != 4) // Un float usa 4 bytes
            throw new ArgumentException("El array de bytes no es válido para convertir a float.", nameof(bytes));

        return BitConverter.ToSingle(bytes, 0); // Convierte los bytes al valor float
    }
}