using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AdrenochromeViewer
{
	public class JpegSaver : IDisposable
	{
		public static int DefaultCompressionFactor = 94;

		private static readonly ImageCodecInfo s_codec;
		private readonly EncoderParameters _encoderParameters;

		private static JpegSaver _default = null;

		static JpegSaver()
		{
			foreach ( var ici in ImageCodecInfo.GetImageEncoders() )
				if ( ici.MimeType == "image/jpeg" )
					s_codec = ici;
		}

		public JpegSaver( long compression )
		{
			_encoderParameters = new EncoderParameters( 1 );
			_encoderParameters.Param[0] = new EncoderParameter( Encoder.Quality, compression );
		}

		public JpegSaver()
			: this( DefaultCompressionFactor )
		{
		}

		public void Dispose()
		{
			_encoderParameters.Dispose();
		}

		public void save( string filename, Bitmap bmp )
		{
			using ( var fs = new FileStream( filename, FileMode.Create ) )
				save( fs, bmp );
		}

		public void save( Stream stream, Bitmap bmp )
		{
			bmp.Save( stream, s_codec, _encoderParameters );
		}

        public static JpegSaver Default
        {
            get
            {
                if (_default == null)
                    _default = new JpegSaver();
                return _default;
            }
        }

        public static void saveWithDefaultCompression(string filename, Bitmap bmp)
		{
			Default.save( filename, bmp );
		}

	}

}
