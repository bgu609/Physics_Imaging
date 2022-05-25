using System.Windows.Media;

namespace IdealGas_Simulator.Models
{
    public class PixelParticle
    {
        public Color Color { get; set; }
        public int Radius { get; set; }

        // Cartesian Coordinate System, Distance Unit == Pixel
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public float Mass { get; set; }
        public float Speed { get; set; }
    }
}