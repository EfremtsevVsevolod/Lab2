using System;
using System.Numerics;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace Lab1
{
    struct Grid2D
    {
        public int NodesNumberX { get; set; }
        public int NodesNumberY { get; set; }
        public float StepSizeX { get; set; }
        public float StepSizeY { get; set; }
        public Grid2D(int nodesNumberX, int nodesNumberY, float stepSizeX, float stepSizeY)
        {
            NodesNumberX = nodesNumberX;
            NodesNumberY = nodesNumberY;
            StepSizeX = stepSizeX;
            StepSizeY = stepSizeY;
        }
        public override string ToString()
        {
            return $"NodesNumberX:{NodesNumberX} NodesNumberY: {NodesNumberY}\n" +
                $"StepSizeX: {StepSizeX} StepSizeY: {StepSizeY}";
        }
        public string ToString(string format)
        {
            return $"NodesNumberX: {NodesNumberX} NodesNumberY: {NodesNumberY}\n" +
                $"StepSizeX: {StepSizeX.ToString(format)}" +
                $"StepSizeY: {StepSizeY.ToString(format)}";
        }
    }

    struct DataItem
    {
        public Vector2 PointCoord { get; set; }
        public Vector2 FieldValue { get; set; }
        public DataItem(Vector2 pointCoord, Vector2 fieldValue)
        {
            PointCoord = pointCoord;
            FieldValue = fieldValue;
        }
        public override string ToString()
        {
            return $"PointCoord={PointCoord}  FieldValue={FieldValue}";
        }
        public string ToString(string format)
        {
            return $"PointCoord={PointCoord.ToString(format)}  " +
                $"FieldValue={FieldValue.ToString(format)}";
        }
    }

    abstract class V5Data: IEnumerable
    {
        public string ServiceInfo { get; set; }
        public DateTime MeasurementTime { get; set; }

        public V5Data(string serviceInfo, DateTime measurementTime)
        {
            ServiceInfo = serviceInfo;
            MeasurementTime = measurementTime;

        }
        public abstract Vector2[] NearEqual(float eps);

        public abstract string ToLongString();
        public abstract string ToLongString(string format);

        public override string ToString()
        {
            return $"ServiceInfo: {ServiceInfo}\nMeasurementTime: {MeasurementTime}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public abstract IEnumerator<DataItem> GetEnumerator();
    }

    class Program
    {
        static void Main()
        {
            DataItem data = new DataItem(new Vector2(1, 2),
                new Vector2(3, 4));
            Console.WriteLine(data.ToString());
            Console.WriteLine(data.ToString("N3"));
            Console.WriteLine();

            string project_path = @"C:\Users\sevak\source\repos\Lab2\";
            string full_path = Path.Combine(project_path, "input.txt");

            V5DataOnGrid v5DataOnGridInstance = new V5DataOnGrid(full_path);
            Console.WriteLine(v5DataOnGridInstance.ToLongString("N1"));

            foreach (DataItem elem in v5DataOnGridInstance)
            {
                Console.WriteLine(elem);
            }

            //Console.WriteLine("1)");
            //Grid2D grid = new Grid2D(3, 3, 1f, 1f);
            //V5DataOnGrid v5DataOnGridInstance =
            //    new V5DataOnGrid("Example of service info",
            //                     DateTime.Now, grid);
            //v5DataOnGridInstance.InitRandom(-100f, 100f);
            //Console.WriteLine(v5DataOnGridInstance.ToLongString() + "\n");
            //Console.WriteLine(((V5DataCollection)v5DataOnGridInstance).ToLongString() + "\n");

            //Console.WriteLine("2)");
            //V5MainCollection v5MainCollectionInstance = new V5MainCollection();
            //v5MainCollectionInstance.AddDefaults();
            //Console.WriteLine(v5MainCollectionInstance.ToString());

            //Console.WriteLine("3)");
            //foreach (V5Data dataElem in v5MainCollectionInstance)
            //{
            //    Console.Write("---In---\n" + dataElem.ToLongString());
            //    Console.WriteLine("---This elements are near equal---");
            //    foreach (Vector2 measurement in dataElem.NearEqual(20.0f))
            //    {
            //        Console.WriteLine(measurement.ToString());
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("\nProgram finished successfully!");
        }
    }
}
