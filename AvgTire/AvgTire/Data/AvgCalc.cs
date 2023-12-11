using AvgTire.Data;
using System.Runtime.Intrinsics.X86;
using Syncfusion.Blazor.PivotView;
using Syncfusion.Blazor.RichTextEditor;
using Syncfusion.Blazor.Schedule;
using Syncfusion.Blazor.Grids;
using MathNet.Numerics.Statistics;
using Newtonsoft.Json.Linq;

namespace AvgTire.Data
{
    public class AvgCalc
    {
        private int id;

        private int number;

        private int eventID;

        private DateTime startdate;

        //private DateTime enddate;

        private int type;

        private DateTime avgtime;

        public /*static*/ int totalCount;
        public /*static*/  long  alltimetype;

        public double totaltime;

        public List<double> dataList = new();

        public List<double> IdList = new();
        //public List<int> SkipedValues = new();

        public int Id { get => id; set => id = value; }
        public int Number { get => number; set => number = value; }
        public int EventID { get => eventID; set => eventID = value; }
        public DateTime Startdate { get => startdate; set => startdate = value; }
        //public DateTime Enddate { get => enddate; set => enddate = value; }
        public int Type { get => type; set => type = value; }
        public DateTime Avgtime { get => avgtime; set => avgtime = value; }

        public double TimeBtwValues
        {
            get
            {

                /////*this.*/alltimetype = alltimetype + ok;
                ///*this.*/
                //long ok = avgtime.Ticks - startdate.Ticks;
                ////alltimetype =+ ok;
                //ok += alltimetype;

                ////totalCount = totalCount + 1;
                /////*this.*/
                ////totalCount++;
                if (alltimetype != 0 && totalCount != 0)
                {
                    double timetype = alltimetype / totalCount;
                    return timetype;
                }
                return default;

                //double timetype = alltimetype / totalCount;
                ////var localDate2 = DateTime.FromBinary(timetype);

                ////alltimetype = (long)timetype;
                //return timetype;

            }
            set { }
        }
        //public  double GetMedian
        //{
        //    get
        //    {
        //        AvgCalc calc = new AvgCalc();

        //        //if (medianhelperlist.Count == 0)
        //        //    return default(double);

        //            medianhelperlist.Add(alltimetype);
        //            medianhelperlist.Sort();
        //            return medianhelperlist[(medianhelperlist.Count / 2)];
                

        //        //int size = totalCount;
        //        //int mid = size / 2;

        //        //double helper = (double)alltimetype;
        //        //if (size % 2 != 0)
        //        //    return arrSorted[mid];

        //        //dynamic value1 = arrSorted[mid];
        //        //dynamic value2 = arrSorted[mid - 1];
        //        //return (value1 + value2) / 2;
        //        //return helper.Median();

        //    }
        //    set { }
        //}
        public double TrimAvg
        {
            get
            {

                int trimPercentage = 10;

                int trimCount = (int)Math.Ceiling(dataList.Count * trimPercentage / 100.0);


                //if (dataList.Count > 0)
                //{

                //var indexMapping = dataList.Select((value, index) => new { Value = value, Index = index })
                //    .OrderBy(item => item.Value)
                //    .Select((item, newIndex) => new { OriginalIndex = item.Index, NewIndex = newIndex })
                //    .ToDictionary(item => item.OriginalIndex, item => item.NewIndex);

                dataList.Sort(); //----

                List<double> trimmedDataList = dataList.Skip(trimCount).Take(dataList.Count - 2 * trimCount).ToList();

                //dataList = dataList.OrderBy(item => indexMapping[dataList.IndexOf(item)]).ToList();

                double trimmedMean = trimmedDataList.Average();



                ;

                    return trimmedMean;
                //}


                //return default;

            }
            set { }
        }

        //public void CheckAndAddToSkippedIds()
        //{
        //    int trimPercentage = 10;

        //    int trimCount = (int)Math.Ceiling(dataList.Count * trimPercentage / 100.0);

        //    if (dataList.Count > 0)
        //    {
        //        dataList.Sort();

        //        List<double> trimmedDataList = dataList.Skip(trimCount).Take(dataList.Count - 2 * trimCount).ToList();

        //        if (!trimmedDataList.Contains(dataList.First()) || !trimmedDataList.Contains(dataList.Last()))
        //        {
        //            skippedIdsList.Add(this.id);
        //        }
        //    }
        //}

        //public List<int> SkipData
        //{
        //    get
        //    {
        //        return skippedIdsList;
        //    }
        //    set { }

        //}
        //public List<int> SkipData
        //{
        //    get
        //    {
        //        int trimPercentage = 5;

        //        int trimCount = (int)Math.Ceiling(dataList.Count * trimPercentage / 100.0);


        //        if (TrimAvg != TimeBtwValues)
        //        {
        //            ;
        //            skippedIdsList.Add(this.id);

        //        }
        //        return skippedIdsList;
        //        //           if (dataList.Count > 0)
        //        //           {
        //        //               dataList.Sort();

        //        //               //List<double> skippedDataList = dataList.Take(trimCount).Concat(dataList.Skip(dataList.Count - trimCount)).ToList();
        //        //               //List<int> skippedDataList = dataList
        //        //               //.Select(value => (int)value) 
        //        //               //.Take(trimCount)
        //        //               //.Concat(dataList.Select(value => (int)value).Skip(dataList.Count - trimCount))
        //        //               //.ToList();

        //        //               List<AvgCalc> avgCalcList = dataList
        //        //              .Select(value => new AvgCalc { Id = this.id })
        //        //              .ToList();

        //        //               //List<int> skippedIdsList = avgCalcList
        //        //               //    .Take(trimCount)
        //        //               //    .Concat(avgCalcList.Skip(avgCalcList.Count - trimCount))
        //        //               //    .Select(avgCalc => avgCalc.Id)
        //        //               //    .ToList();

        //        //               string skippedIdsString = string.Join(", ", avgCalcList
        //        //.Take(trimCount)
        //        //.Concat(avgCalcList.Skip(avgCalcList.Count - trimCount))
        //        //.Select(avgCalc => avgCalc.Id));

        //        //               return skippedIdsString;

        //        //           }
        //        //           return default;

        //    }
        //    set { }
        //    //get
        //    //{
        //    //    int trimPercentage = 10;

        //    //    int trimCount = (int)Math.Ceiling(dataList.Count * trimPercentage / 100.0);

        //    //    dataList.Sort();

        //    //    if (dataList.Count > 0)
        //    //    {
        //    //        dataList.Sort();


        //    //        List<AvgCalc> skippedDataList = dataList
        //    //       .Take(trimCount)
        //    //       .Concat(dataList.Skip(dataList.Count - trimCount))
        //    //       .Select(value => new  AvgCalc { Id = this.Id, Number = this.Number, EventID = this.EventID, Startdate = this.Startdate, Type = this.Type,})
        //    //       .ToList();

        //    //        return skippedDataList;
        //    //    }
        //    //    return default;


        //    //}
        //    //set { }
        //}

    }
}
