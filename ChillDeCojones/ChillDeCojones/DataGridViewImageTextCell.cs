using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChillDeCojones
{
    public class DataGridViewImageTextCell : DataGridViewTextBoxCell
    {
        private object contenido; // Puede ser una imagen o un texto

        public DataGridViewImageTextCell(object contenido)
        {
            if (contenido is Image || contenido is string)
            {
                this.contenido = contenido;
            }
            else
            {
                throw new ArgumentException("El contenido debe ser una imagen (Image) o un texto (string).");
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
                                      int rowIndex, DataGridViewElementStates cellState, object value,
                                      object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
                                      DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            if (contenido is Image image) // Si es una imagen
            {
                // Dibujar la imagen
                int imgWidth = 16, imgHeight = 16; // Tamaño de la imagen
                int x = cellBounds.X + 4; // Margen izquierdo
                int y = cellBounds.Y + (cellBounds.Height - imgHeight) / 2; // Centrar verticalmente
                graphics.DrawImage(image, x, y, imgWidth, imgHeight);
            }

            if (contenido is string texto) // Si es texto
            {
                // Dibujar el texto
                using (Brush brush = new SolidBrush(cellStyle.ForeColor))
                {
                    int textX = cellBounds.X + 4; // Margen izquierdo para texto
                    int textY = cellBounds.Y + (cellBounds.Height - cellStyle.Font.Height) / 2; // Centrar verticalmente
                    graphics.DrawString(texto, cellStyle.Font, brush, textX, textY);
                }
            }
        }
    }
}
