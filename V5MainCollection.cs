using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Lab1
{
    class V5MainCollection : IEnumerable
    {
        List<V5Data> LstData = new List<V5Data>();
        public int Count { get; set; } = 0;

        public void Add(V5Data item)
        {
            LstData.Add(item);
            Count++;
        }

        public bool Remove(string id, DateTime date)
        {
            int removedCount = LstData.RemoveAll(elem => elem.ServiceInfo == id &&
                                              elem.MeasurementTime == date);
            Count -= removedCount;
            return removedCount > 0;
        }

        public void AddDefaults()
        {
            Grid2D grid = new Grid2D(3, 3, 1.0f, 1.0f);

            for (int i = 0; i < 3; ++i)
            {
                V5DataOnGrid v5DataOnGridDefaultInstance =
                    new V5DataOnGrid("Default V5DataOnGrid service info",
                                     new DateTime(1970, 1, 1), grid);
                v5DataOnGridDefaultInstance.InitRandom(-100.0f, 100.0f);
                LstData.Add(v5DataOnGridDefaultInstance);
            }

            for (int i = 0; i < 3; ++i)
            {
                V5DataCollection v5DataCollectionDefaultInstance =
                    new V5DataCollection("Default V5MainCollection service info",
                                         new DateTime(1970, 1, 1));
                v5DataCollectionDefaultInstance.InitRandom(5, 10.0f, 10.0f, -100.0f, 100.0f);
                LstData.Add(v5DataCollectionDefaultInstance);
            }
        }

        public override string ToString()
        {
            StringBuilder strBulder = new StringBuilder();

            foreach (V5Data dataElem in LstData)
            {
                strBulder.Append(dataElem.ToString() + "\n\n");
            }

            return strBulder.ToString();
        }

        string ToLongString(string format)
        {
            StringBuilder strBulder = new StringBuilder();

            foreach (V5Data dataElem in LstData)
            {
                strBulder.Append(dataElem.ToLongString(format) + "\n\n");
            }

            return strBulder.ToString();
        }

        public IEnumerator<V5Data> GetEnumerator()
        {
            return ((IEnumerable<V5Data>)LstData).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)LstData).GetEnumerator();
        }

        public float Min
        {
            get
            {
                return (from lstElem in LstData
                       where lstElem.GetType() == typeof(V5DataCollection)
                       from KeyValuePair<Vector2, Vector2> kvp in ((V5DataCollection)lstElem).ValuesDct
                       select kvp.Value.Length()).Min();
            }
        }

        public IEnumerable<DataItem> IterDataItemsFromCollectionWithMin
        {
            get
            {
                float minLengh = Min;
                return from lstElem in LstData
                       from elem in lstElem

            }
        }
    }
}
