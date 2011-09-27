
namespace Adrenochrome
{
    internal struct ColorClose
    {
        private readonly YCbCr _key;
        private readonly float _tola, _tolb, _tolba;

        public ColorClose(Pixel key, int tola, int tolb)
        {
            _key = key.YCbCr();
            _tola = tola;
            _tolb = tolb;
            _tolba = _tolb - _tola;
        }

        public float Calculate(Pixel p)
        {
            var temp = _key.Distance(p.YCbCr());
            if (temp < _tola)
                return 0;
            if (temp < _tolb)
                return (temp - _tola)/_tolba;
            return 1;
        }

        public float Calculate(Pixel p, Pixel key)
        {
            var temp = key.YCbCr().Distance(p.YCbCr());
            if (temp < _tola)
                return 0;
            if (temp < _tolb)
                return (temp - _tola)/_tolba;
            return 1;
        }

    }

}
