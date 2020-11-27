using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Lab2
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

    abstract class V5Data : IEnumerable<DataItem>
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
}
