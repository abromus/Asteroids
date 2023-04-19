namespace Asteroids.Core
{
    public struct Bounds
    {
        private Float3 _extents;
        private Float3 _center;

        public Float3 Center
        {
            get => _center;
            set => _center = value;
        }

        public Float3 Extents
        {
            get => _extents;
            set => _extents = value;
        }

        public Float3 Size
        {
            get => _extents * 2f;
            set => _extents = value / 2f;
        }

        public Float3 Min
        {
            get => _center - _extents;
            set => SetMinMax(value, Max);
        }

        public Float3 Max
        {
            get => _center + _extents;
            set => SetMinMax(Min, value);
        }

        public Bounds(Float3 center, Float3 size)
        {
            _center = center;
            _extents = size / 2f;
        }

        public void SetMinMax(Float3 min, Float3 max)
        {
            _extents = (max - min) / 2f;
            _center = min + _extents;
        }
    }
}
