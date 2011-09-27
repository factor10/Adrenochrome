using System;
using System.Drawing;

namespace Adrenochrome
{
	public struct Pixel
	{
		public byte B;
		public byte G;
		public byte R;
		public byte A;

		public Pixel( int a, int r, int g, int b )
		{
			A = (byte)a;
			R = (byte)r;
			G = (byte)g;
			B = (byte)b;
		}

		public static implicit operator Color( Pixel rhs )
		{
			return Color.FromArgb( rhs.A, rhs.R, rhs.G, rhs.B );
		}

		public static implicit operator Pixel( Color rhs )
		{
			return new Pixel( rhs.A, rhs.R, rhs.G, rhs.B );
		}

        public YCbCr YCbCr()
        {
            return new YCbCr(
                (int) Math.Round(128 + -0.168736*R - 0.331264*G + 0.5*B),
                (int) Math.Round(128 + 0.5*R - 0.418688*G - 0.081312*B));
        }
	}

    public struct YCbCr
    {
        public readonly int Cb;
        public readonly int Cr;

        public YCbCr( int cb, int cr )
        {
            Cb = cb;
            Cr = cr;
        }

        public float Distance( YCbCr other )
        {
            return (float)Math.Sqrt((other.Cb - Cb) * (other.Cb - Cb) + (other.Cr - Cr) * (other.Cr - Cr));
        }

    }

}
