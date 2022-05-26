using System.Windows.Media;

namespace IdealGas_Simulator.Models
{
    public class PixelParticle
    {
        public int Seed { get; set; }
        public int Energy { get; set; } // for random invoker, 역할만 비슷함. (온도 대신이라고 봐도 되고)

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