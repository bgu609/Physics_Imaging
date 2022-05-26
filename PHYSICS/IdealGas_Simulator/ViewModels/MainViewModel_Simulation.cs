using IdealGas_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IdealGas_Simulator.ViewModels
{
    public partial class MainViewModel
    {
        Thread Simulation_Thread;



        private void Simulation_Loop()
        {
            //Random Random = new Random();

            int Last_X = 1200;
            int Last_Y = 750;

            int Entropy = 10;
            int Particles_Number = 1000;

            //Control_One_Particle(Last_X, Last_Y);

            //Initialize_Particles(
            //    new PixelParticle() {
            //        Quantum_Handler = new Random(0), Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Entropy = Entropy, Dimension = 2, Radius = 5, X = Last_X - 20, Y = Last_Y, X_Boundary_Min = 810, X_Boundary_Max = 1590, Y_Boundary_Min = 110, Y_Boundary_Max = 1390 },
            //    new PixelParticle() {
            //        Quantum_Handler = new Random(1), Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Entropy = Entropy, Dimension = 2, Radius = 5, X = Last_X - 10, Y = Last_Y, X_Boundary_Min = 810, X_Boundary_Max = 1590, Y_Boundary_Min = 110, Y_Boundary_Max = 1390 },
            //    new PixelParticle() {
            //        Quantum_Handler = new Random(2), Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Entropy = Entropy, Dimension = 2, Radius = 5, X = Last_X, Y = Last_Y, X_Boundary_Min = 810, X_Boundary_Max = 1590, Y_Boundary_Min = 110, Y_Boundary_Max = 1390 },
            //    new PixelParticle() {
            //        Quantum_Handler = new Random(3), Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Entropy = Entropy, Dimension = 2, Radius = 5, X = Last_X - 10, Y = Last_Y, X_Boundary_Min = 810, X_Boundary_Max = 1590, Y_Boundary_Min = 110, Y_Boundary_Max = 1390 },
            //    new PixelParticle() {
            //        Quantum_Handler = new Random(4), Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Entropy = Entropy, Dimension = 2, Radius = 5, X = Last_X + 20, Y = Last_Y, X_Boundary_Min = 810, X_Boundary_Max = 1590, Y_Boundary_Min = 110, Y_Boundary_Max = 1390 }
            //);

            PixelParticle[] Initial_Particles = new PixelParticle[Particles_Number];
            for (int i = 0; i < Initial_Particles.Length; i++)
            {
                Initial_Particles[i] = new PixelParticle() {
                    //Quantum_Handler = new Random(i),
                    Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF),
                    Seed = i,
                    Entropy = Entropy,
                    Dimension = 2,
                    Radius = 5,
                    X = Last_X,
                    Y = Last_Y,
                    //X_Boundary_Min = 810,
                    //X_Boundary_Max = 1590,
                    //Y_Boundary_Min = 110,
                    //Y_Boundary_Max = 1390,
                };
            }

            X_Boundary_Min = 810;
            X_Boundary_Max = 1590;
            Y_Boundary_Min = 110;
            Y_Boundary_Max = 1390;
            Z_Boundary_Min = 0;
            Z_Boundary_Max = 0;

            Task.Run(() => Initialize_Particles(Initial_Particles));

            while (true)
            {
                Thread.Sleep(16);

                //double Move_Radius = Random.Next(-Entropy, Entropy + 1);
                //double Move_Radius_Decimal = Random.NextDouble();
                //int Move_Radius_Decimal_Sign = Random.Next(0, 2);

                //double Move_Azimuth = Random.Next(0, 361);
                //double Move_Azimuth_Decimal = Random.NextDouble();
                //int Move_Azimuth_Decimal_Sign = Random.Next(0, 2);

                //Move_Radius += (double)(Move_Radius_Decimal * ((Move_Radius_Decimal_Sign == 1) ? 1 : -1));
                //Move_Azimuth += (double)(Move_Azimuth_Decimal * ((Move_Azimuth_Decimal_Sign == 1) ? 1 : -1));

                //// 일단 귀찮으니 사사오입 반올림 사용
                //Last_X += (int)Math.Round(Move_Radius * Math.Sin(Move_Azimuth));
                //Last_Y += (int)Math.Round(Move_Radius * Math.Cos(Move_Azimuth));


                //// Boundary Condition
                //if (Last_X < 810)
                //{
                //    Last_X = 810;
                //}
                //else if (Last_X > 1590)
                //{
                //    Last_X = 1590;
                //}

                //if (Last_Y < 110)
                //{
                //    Last_Y = 110;
                //}
                //else if (Last_Y > 1390)
                //{
                //    Last_Y = 1390;
                //}

                //Control_One_Particle(Last_X, Last_Y);

                Control_Multi_Particles();
            }
        }

        private void Initialize_Particles(params PixelParticle[] particle)
        {
            Pixel_Particles.Clear();

            List<PixelParticle> Emitter = new List<PixelParticle>();
            foreach (PixelParticle item in particle)
            {
                Emitter.Add(item);
            }

            Pixel_Particles = Emitter;
        }

        //private void Control_One_Particle(int x, int y)
        //{
        //    Task.Run(() => {
        //        Initialize_Particles(
        //            new PixelParticle() { Color = Color.FromArgb(0xFF, 0x00, 0x00, 0xFF), Radius = 5, X = x, Y = y, }
        //        );

        //        Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
        //    });
        //}

        //private async void Control_Multi_Particles()
        //{
        //    List<Task> Task_List = new List<Task>();

        //    foreach (PixelParticle item in Pixel_Particles) // 이건 비동기로 실행시키니 확률적인 게 안 되는 거 같은데
        //    {
        //        Task_List.Add(Task.Run(() => {
        //            item.Invoke_Probability_Position();
        //        }));
        //    }

        //    await Task.WhenAll(Task_List);

        //    Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
        //}

        private async void Control_Multi_Particles()
        {
            List<Task> Task_List = new List<Task>();

            foreach (PixelParticle item in Pixel_Particles)
            {
                Task_List.Add(Task.Run(() => {
                    Invoke_Probability_Position(item);
                }));
            }

            await Task.WhenAll(Task_List);

            Drawing_Space_Object.Now_Rendering_Particles(Pixel_Particles);
        }
    }
}