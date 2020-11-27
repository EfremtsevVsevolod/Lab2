using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Lab2
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
        
        void AddOneDefaultGrid(Grid2D grid)
        {
            V5DataOnGrid v5DataOnGridDefaultInstance =
                    new V5DataOnGrid("Default service info", new DateTime(1970, 1, 1), grid);
            v5DataOnGridDefaultInstance.InitRandom(-100.0f, 100.0f);
            LstData.Add(v5DataOnGridDefaultInstance);
        }

        void AddOneDefaultColection(int nItems)
        {
            V5DataCollection v5DataCollectionDefaultInstance =
                new V5DataCollection("Default service info", new DateTime(1970, 1, 1));
            v5DataCollectionDefaultInstance.InitRandom(nItems, 10.0f, 10.0f, -100.0f, 100.0f);
            LstData.Add(v5DataCollectionDefaultInstance);
        }

        void AddPairDefaultGridAndCollection(Grid2D grid)
        {
            V5DataOnGrid v5DataOnGridDefaultInstance =
                    new V5DataOnGrid("Default info", new DateTime(1970, 1, 1), grid);
            v5DataOnGridDefaultInstance.InitRandom(-100.0f, 100.0f);
            LstData.Add(v5DataOnGridDefaultInstance);
            LstData.Add((V5DataCollection)v5DataOnGridDefaultInstance);
        }

        public void AddDefaults()
        {
            Grid2D smallGrid = new Grid2D(1, 1, 1.0f, 1.0f);
            Grid2D bigGrid = new Grid2D(2, 2, 1.0f, 1.0f);
            Grid2D emptyGrid = new Grid2D(0, 0, 1.0f, 1.0f);

            // Different nonempty
            AddOneDefaultColection(3);
            AddOneDefaultGrid(bigGrid);

            // The same nonempty
            AddPairDefaultGridAndCollection(smallGrid);

            // Empty
            AddOneDefaultColection(0);
            AddOneDefaultGrid(emptyGrid);
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

        public string ToLongString(string format)
        {
            StringBuilder strBulder = new StringBuilder();

            foreach (V5Data dataElem in LstData)
            {
                strBulder.Append(dataElem.ToLongString(format) + "\n\n");
            }

            return strBulder.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)LstData).GetEnumerator();
        }

        public IEnumerator<V5Data> GetEnumerator()
        {
            return ((IEnumerable<V5Data>)LstData).GetEnumerator();
        }

        public float Min
        {
            get
            {
                return (from lstElem in LstData
                        where lstElem.GetType() == typeof(V5DataCollection)
                        from dataItem in lstElem
                        select dataItem.FieldValue.Length()).Min();
            }
        }

        public IEnumerable<DataItem> IterDataItemsFromCollectionWithMin
        {
            get
            {
                float minLengh = Min;
                return from lstElem in LstData
                       from dataItem in lstElem
                       where dataItem.FieldValue.Length() == minLengh
                       select dataItem;
            }
        }

        public IEnumerable<Vector2> IterVector2Target
        {
            get
            {
                var iterV5DataOnGrid = from lstElem in LstData
                                       where lstElem.GetType() == typeof(V5DataOnGrid)
                                       from dataItem in lstElem
                                       select dataItem.PointCoord;

                var iterV5DataCollection = from lstElem in LstData 
                                           where lstElem.GetType() == typeof(V5DataCollection)
                                           from dataItem in lstElem
                                           select dataItem.PointCoord;

                return iterV5DataOnGrid.Except(iterV5DataCollection).Distinct();
            }
        }
    }
}
