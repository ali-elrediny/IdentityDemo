// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageExtensions.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Drawing
{
    #region usings

    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    using Framework.Core.Extensions;

    #endregion

    /// <summary>
    /// The image extensions.
    /// </summary>
    public static class ImageExtensions
    {
        /// <summary>
        /// The to byte array.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="byte[]"/>.
        /// </returns>
        public static byte[] ToByteArray(this Bitmap image)
        {
            using (var memStream = (Stream)new MemoryStream())
            {
                image.Save(memStream, ImageFormat.Jpeg);
                return memStream.ToByteArray();
            }
        }
    }
}