using Adrenochrome;

namespace AdrenochromeViewer
{
    class OneView
    {
        public readonly int TrackTolLoValue;
        public readonly int TrackTolHiValue;
        public readonly int SoftenMethod;
        public readonly int TrackSoftenValue;

        public readonly string Foreground;
        public readonly string Background;

        public int ForegroundPercentage;
        public int BackgroundPercentage;

        public Pixel[] TheMask;

        public OneView(
            ViewerData vd,
            string foreground,
            string background,
            int trackTolLoValue,
            int trackTolHiValue,
            int softenMethod,
            int trackSoftenValue)
        {
            Foreground = foreground;
            Background = background;
            TrackTolLoValue = trackTolLoValue;
            TrackTolHiValue = trackTolHiValue;
            SoftenMethod = softenMethod;
            TrackSoftenValue = trackSoftenValue;
            if (vd.CreateMask(TrackTolLoValue, TrackTolHiValue, SoftenMethod, TrackSoftenValue, Foreground, Background))
            {
                TheMask = vd.TheMask;
                ConstructBackgroundMask.CalculatePercentageSpread(TheMask, out ForegroundPercentage, out BackgroundPercentage);
            }
        }

        public override string ToString()
        {
            return string.Format("Tol:{0}/{1} / Soft:{2}/{3}",
                TrackTolLoValue,
                TrackTolHiValue,
                SoftenMethod+1,
                TrackSoftenValue);
        }

        public override int GetHashCode()
        {
            return TrackTolHiValue;
        }

        public override bool Equals(object obj)
        {
            var other = obj as OneView;
            return other != null &&
                TrackTolLoValue == other.TrackTolLoValue &&
                TrackTolHiValue == other.TrackTolHiValue &&
                SoftenMethod == other.SoftenMethod &&
                TrackSoftenValue == other.TrackSoftenValue;
        }

    }

}
