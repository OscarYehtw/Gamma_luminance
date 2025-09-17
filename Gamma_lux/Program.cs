// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;
using System.Linq;
using ST7701S_NB_Gamma;  // You must first add ST7701S_NB_Gamma.dll to References

namespace GammaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ST7701S_NB_Gamma.Class1 F = new Class1();

            Console.WriteLine("Gamma calculation started...");

            // === 1. Read VCOM parameters ===
            string[] vcomLines = File.ReadAllLines("vcom.csv");
            var vcomValues = vcomLines.Skip(1).First().Split(',');
            int vcm = Convert.ToInt32(vcomValues[0], 16);
            int vrh = Convert.ToInt32(vcomValues[1], 16);

            F.B0_VOP_B1_VCOM(vcm, vrh);
            Console.WriteLine($"VCOM parameters loaded: VCM={vcm}, VRH={vrh}");

            // === 2. Read gamma.csv ===
            string[] gammaLines = File.ReadAllLines("gamma.csv");
            var gammaValues = gammaLines
                .Skip(1)
                .Select(line => line.Split(',')[1]) // Take the 2nd column (Value)
                .Select(hex => Convert.ToInt32(hex, 16)) // Convert HEX to int
    .           ToArray();

            if (gammaValues.Length < 16)
                throw new Exception("gamma.csv must contain at least 16 integer parameters");

            F.Input_Gamma_Parameter(
                gammaValues[0], gammaValues[1], gammaValues[2], gammaValues[3],
                gammaValues[4], gammaValues[5], gammaValues[6], gammaValues[7],
                gammaValues[8], gammaValues[9], gammaValues[10], gammaValues[11],
                gammaValues[12], gammaValues[13], gammaValues[14], gammaValues[15]
            );

            Console.WriteLine("Gamma parameters loaded.");

            F.Calculate_Gamma_Voltage_();

            // === 3. 讀取 Read ca-310.csv ===
            string[] luminanceLines = File.ReadAllLines("ca-310.csv");
            var lumValues = luminanceLines
                .Skip(1)
                .Select(line => line.Split(',')[1])   // Take Lux values
                .Select(double.Parse)
                .ToArray();

            if (lumValues.Length < 16)
                throw new Exception("ca-310.csv must contain at least 16 luminance values");

            F.Input_Measure_luminance(
                lumValues[0], lumValues[1], lumValues[2], lumValues[3],
                lumValues[4], lumValues[5], lumValues[6], lumValues[7],
                lumValues[8], lumValues[9], lumValues[10], lumValues[11],
                lumValues[12], lumValues[13], lumValues[14], lumValues[15]
            );

            Console.WriteLine("Luminance measurements loaded.");

            F.Output_Gamma_Parameter();

            // === 4. Call ST7701S_NB_Gamma for calculation ===
            int[] temp = ST7701S_NB_Gamma.Class1.Read_Data;   // Read gamma results from DLL
            Console.WriteLine("Gamma calculation finished.");

            // === 5. Output gamma_cal.csv ===
            using (var writer = new StreamWriter("gamma_cal.csv"))
            {
                writer.WriteLine("Index,Value");
                for (int i = 0; i < temp.Length; i++)
                {
                    writer.WriteLine($"{i},{temp[i]}");
                }
            }

            Console.WriteLine("Results saved to gamma_cal.csv");
        }
    }

}
