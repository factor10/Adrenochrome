using Adrenochrome;

namespace AdrenochromeViewer
{
    class OneView
    {
        public readonly int TrackTolLoValue;
        public readonly int TrackTolHiValue;
        public readonly bool MedianFilter;
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
            bool medianFilter,
            int trackSoftenValue)
        {
            Foreground = foreground;
            Background = background;
            TrackTolLoValue = trackTolLoValue;
            TrackTolHiValue = trackTolHiValue;
            MedianFilter = medianFilter;
            TrackSoftenValue = trackSoftenValue;
            if (vd.CreateMask(TrackTolLoValue, TrackTolHiValue, MedianFilter, TrackSoftenValue, Foreground, Background))
            {
                TheMask = vd.TheMask;
                ConstructBackgroundMask.CalculatePercentageSpread(TheMask, out ForegroundPercentage, out BackgroundPercentage);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} / {1} / {2} / {3}",
                TrackTolLoValue,
                TrackTolHiValue,
                TrackSoftenValue,
                MedianFilter ? "J" : "N");
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
                MedianFilter == other.MedianFilter &&
                TrackSoftenValue == other.TrackSoftenValue;
        }

    }

}
