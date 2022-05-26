using System;
using System.Windows.Media;

namespace IdealGas_Simulator.Models
{
    public class PixelParticle
    {
        //public Random Quantum_Handler { get; set; }
        public int Seed { get; set; }
        public int Entropy { get; set; } // ??? for random invoker, 아마 정확히 하려면 에너지가 아닐까?

        public Color Color { get; set; }
        public int Radius { get; set; }

        // Cartesian Coordinate System, Distance Unit == Pixel
        public int Dimension { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        //public int X_Boundary_Min { get; set; }
        //public int X_Boundary_Max { get; set; }
        //public int Y_Boundary_Min { get; set; }
        //public int Y_Boundary_Max { get; set; }
        //public int Z_Boundary_Min { get; set; }
        //public int Z_Boundary_Max { get; set; }

        // 환산되지 않음. 추후 Graphic Rendering Test용
        public float Mass { get; set; }
        public float Speed { get; set; }



        //public void Invoke_Probability_Position()
        //{
        //    if (Quantum_Handler == null) return;

        //    if (Dimension == 1)
        //    {

        //    }
        //    else if (Dimension == 2)
        //    {
        //        double Move_Radius = Quantum_Handler.Next(-Entropy, Entropy + 1);
        //        double Move_Radius_Decimal = Quantum_Handler.NextDouble();
        //        int Move_Radius_Decimal_Sign = Quantum_Handler.Next(0, 2);

        //        double Move_Azimuth = Quantum_Handler.Next(0, 361);
        //        double Move_Azimuth_Decimal = Quantum_Handler.NextDouble();
        //        int Move_Azimuth_Decimal_Sign = Quantum_Handler.Next(0, 2);

        //        Move_Radius += (double)(Move_Radius_Decimal * ((Move_Radius_Decimal_Sign == 1) ? 1 : -1));
        //        Move_Azimuth += (double)(Move_Azimuth_Decimal * ((Move_Azimuth_Decimal_Sign == 1) ? 1 : -1));

        //        // 일단 귀찮으니 사사오입 반올림 사용
        //        X += (int)Math.Round(Move_Radius * Math.Sin(Move_Azimuth));
        //        Y += (int)Math.Round(Move_Radius * Math.Cos(Move_Azimuth));

        //        if (X < X_Boundary_Min)
        //        {
        //            X = X_Boundary_Min;
        //        }
        //        else if (X > X_Boundary_Max)
        //        {
        //            X = X_Boundary_Max;
        //        }

        //        if (Y < Y_Boundary_Min)
        //        {
        //            Y = Y_Boundary_Min;
        //        }
        //        else if (Y > Y_Boundary_Max)
        //        {
        //            Y = Y_Boundary_Max;
        //        }
        //    }
        //    else if (Dimension == 3)
        //    {

        //    }
        //}
    }
}