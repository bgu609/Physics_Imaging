using System.Windows.Media;

namespace IdealGas_Simulator.Models
{
    public class PixelParticle
    {
        public int Seed { get; set; }
        public int Entropy { get; set; } // ??? for random invoker, 아마 정확히 하려면 에너지가 아닐까?

        public Color Color { get; set; }
        public int Radius { get; set; }

        // Cartesian Coordinate System, Distance Unit == Pixel
        public int Dimension { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        // 환산되지 않음. 추후 Graphic Rendering Test용
        public float Mass { get; set; }
        public float Speed { get; set; }
    }
}