// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Barcode.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Drawing
{
    #region usings

    using System.Drawing;

    using ZXing;
    using ZXing.QrCode;

    #endregion

    /// <summary>
    ///     The barcode helper.
    /// </summary>
    public static class Barcode
    {
        /// <summary>
        /// The decode from image.
        /// </summary>
        /// <param name="bitmap">
        /// The bitmap.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string DecodeFromImage(Bitmap bitmap)
        {
            // create a barcode reader instance
            var reader = new BarcodeReader();

            // detect and decode the barcode inside the bitmap
            var result = reader.Decode(bitmap.ToByteArray());

            return result?.Text;
        }

        /// <summary>
        /// The generate bar code.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static byte[] GenerateBarCode(string code, int width, int height)
        {
            var barcodeWriters = new BarcodeWriterPixelData
                                     {
                                         Format = BarcodeFormat.CODE_128,
                                         Options = new QrCodeEncodingOptions
                                                       {
                                                           DisableECI = true, Height = height, Width = width

                                                           // ,Margin = 10
                                                       }
                                     };

            var image = barcodeWriters.Write(code);

            return image.Pixels;
        }

        /// <summary>
        /// The generate bar code.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static string GenerateBarCodeSvg(string code, int width, int height)
        {
            var barcodeWriter = new BarcodeWriterSvg
                                    {
                                        Format = BarcodeFormat.CODE_128,
                                        Options = new QrCodeEncodingOptions
                                                      {
                                                          DisableECI = true, Height = height, Width = width

                                                          // ,Margin = 10
                                                      }
                                    };

            var svgImage = barcodeWriter.Write(code);

            return svgImage.Content;
        }
    }
}