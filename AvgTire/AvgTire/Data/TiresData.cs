using System.Runtime.Intrinsics.X86;
using AvgTire.Pages;
using Microsoft.AspNetCore.Components;
using MySqlConnector;
using System.IO;
using Syncfusion.Blazor.RichTextEditor;
using Syncfusion.Blazor.Kanban.Internal;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using MathNet.Numerics;

namespace AvgTire.Data
{
    public class TiresData : ComponentBase
    {
        static List<AvgCalc> AvgFinalFirst = new();
        static List<AvgCalc> AvgFinalSecond = new();
        static string server = "localhost";
        static string database = "test";
        static string username = "root";
        static string password = "";

        enum Recording_Point
        {
            f101t102,
            f102t103,
            f103t104,
            f104t105,
            f105t106,
            f106t107,
            f107t108,
            f108t109,
            f110t111,
            f112t113,
            f113t114,
            f114t115,

        }
        enum Maro
        {
            f201t202,
            f201t203,
            f204t205,
            f205t206,
            f205t207,
            f208t209,
            f209t210,
            f210t211,
            f211t212,
            f212t213,
            f213t214,
            f213t217,
            f214t215,
            f215t216,
            f217t218,
            f218t219,
        }
        enum Maro_Tarto
        {
            f301t302,
            f302t303,
            f303t304,
            f304t305,
            f305t306,
            f306t307,
            f307t308,
            f308t309,
            f309t310,
        }
        enum Zomi_Tarto
        {
            f401t402,
            f402t403,
            f403t404,
            f404t405,
            f405t406,
            f406t407,
            f407t408,
        }
        enum Deburring
        {
            f501t502,
            f501t503,
            f504t505,
            f506t507,
            f508t509,
            f510t511,
            f512t513,
            f513t514,
            f514t515,
            f515t516,
            f516t517,
            f517t518,
        }
        enum EndPoint
        {
            f601t602,
        }
        private List<Data> AvgAll()
        {
            string conection = "SERVER= " + server + ";" + "DATABASE=" + database + ";" + "UID= " + username + ";" + "PASSWORD=" + password;
            MySqlConnection con = new MySqlConnection(conection);
            con.Open();


            //string help1 = "SELECT *, FORMAT(avg(TIMESTAMPDIFF(SECOND, StartDate,EndDate)), 2)  AS AvgDates FROM tires GROUP BY id;";
            string help1 = "SELECT * FROM tires";


            MySqlCommand cmd = new MySqlCommand(help1, con);


            MySqlDataReader reader = cmd.ExecuteReader();


            List<Data> records = new();
            while (reader.Read())
            {

                records.Add(new Data() { Id = reader.GetInt32(0), Number = reader.GetInt32(1), EventID = reader.GetInt32(2), Startdate = reader.GetDateTime(3), /*Enddate = reader.GetDateTime(4)*/ Type = reader.GetInt32(4),/* Avgdate = reader.GetChar(6)*/});
            }

            return records;
        }
        public Task<List<Data>> AvgwithoutavgAsync()
        {
            return Task.Run(() =>
            {
                return AvgAll();
            });
        }
        private List<Data> AvgAllSecond()
        {
            string conection = "SERVER= " + server + ";" + "DATABASE=" + database + ";" + "UID= " + username + ";" + "PASSWORD=" + password;
            MySqlConnection con = new MySqlConnection(conection);
            con.Open();


            //string help1 = "SELECT *, FORMAT(avg(TIMESTAMPDIFF(SECOND, StartDate,EndDate)), 2)  AS AvgDates FROM tires GROUP BY id;";
            string help1 = "SELECT * FROM tires_2";


            MySqlCommand cmd = new MySqlCommand(help1, con);


            MySqlDataReader reader = cmd.ExecuteReader();


            List<Data> records = new();
            while (reader.Read())
            {

                records.Add(new Data() { Id = reader.GetInt32(0), Number = reader.GetInt32(1), EventID = reader.GetInt32(2), Startdate = reader.GetDateTime(3), /*Enddate = reader.GetDateTime(4)*/ Type = reader.GetInt32(4),/* Avgdate = reader.GetChar(6)*/});
            }

            return records;
        }
        public Task<List<Data>> AvgwithoutavgSecondAsync()
        {
            return Task.Run(() =>
            {
                return AvgAllSecond();
            });
        }

        private List<Data> AvgAllThird()
        {
            string conection = "SERVER= " + server + ";" + "DATABASE=" + database + ";" + "UID= " + username + ";" + "PASSWORD=" + password;
            MySqlConnection con = new MySqlConnection(conection);
            con.Open();


            //string help1 = "SELECT *, FORMAT(avg(TIMESTAMPDIFF(SECOND, StartDate,EndDate)), 2)  AS AvgDates FROM tires GROUP BY id;";
            string help1 = "SELECT * FROM tires_3";


            MySqlCommand cmd = new MySqlCommand(help1, con);


            MySqlDataReader reader = cmd.ExecuteReader();


            List<Data> records = new();
            while (reader.Read())
            {

                records.Add(new Data() { Id = reader.GetInt32(0), Number = reader.GetInt32(1), EventID = reader.GetInt32(2), Startdate = reader.GetDateTime(3), /*Enddate = reader.GetDateTime(4)*/ Type = reader.GetInt32(4),/* Avgdate = reader.GetChar(6)*/});
            }

            return records;
        }
        public Task<List<Data>> AvgwithoutavgThirdAsync()
        {
            return Task.Run(() =>
            {
                return AvgAllThird();
            });
        }

        private async Task<Dictionary<Enum, AvgCalc>> AvgDictionaryAsync()
        {
            List<Data> AvgData = await AvgwithoutavgAsync();
            List<AvgCalc> AvgFinal = new();
            AvgCalc avg = new();
            AvgCalc avg217helper = new();

            var Recording_PointDict = new Dictionary<Enum, AvgCalc>();
            var Recording_PointDicttest2 = new Dictionary<Enum, bool>();


            foreach (var item in AvgData)
            {

                switch (item.EventID)
                {
                    #region Recording_Point
                    case 101:
                        {
                            Recording_PointDicttest2[Recording_Point.f101t102] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 102:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f101t102])
                            {
                                //ref var valOrNew =
                                //    ref CollectionsMarshal.GetValueRefOrAddDefault(Recording_PointDict, Recording_Point.f101t102, out var existed);
                                //if (!existed)
                                //{ 

                                //}
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f101t102))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype = avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f101t102, avg);
                                    Recording_PointDict[Recording_Point.f101t102].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f101t102].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f101t102].totalCount++;

                                    ;
                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f101t102].alltimetype;
                                    ;
                                    avg.dataList = Recording_PointDict[Recording_Point.f101t102].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f101t102].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);


                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    avg.totalCount = Recording_PointDict[Recording_Point.f101t102].totalCount + 1;
                                    
                                    Recording_PointDict[Recording_Point.f101t102] = avg;

                                    ;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f102t103] = true;
                            break;


                        }
                    case 103:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f102t103])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f102t103))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f102t103, avg);
                                    Recording_PointDict[Recording_Point.f102t103].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f102t103].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f102t103].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f102t103].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f102t103].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f102t103].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f102t103].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f102t103] = avg;
                                    ;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f103t104] = true;

                            break;

                        }
                    case 104:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f103t104])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f103t104))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f103t104, avg);
                                    Recording_PointDict[Recording_Point.f103t104].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f103t104].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f103t104].totalCount++;
                                    AvgFinal.Add(avg);
                                    ;

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f103t104].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f103t104].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f103t104].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f103t104] = avg;
                                    
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f104t105] = true;

                            break;

                        }
                    case 105:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f104t105])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f104t105))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f104t105, avg);
                                    Recording_PointDict[Recording_Point.f104t105].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f104t105].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f104t105].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f104t105].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f104t105].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f104t105].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f104t105].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f104t105] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f105t106] = true;

                            break;

                        }
                    case 106:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f105t106])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f105t106))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f105t106, avg);
                                    Recording_PointDict[Recording_Point.f105t106].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f105t106].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f105t106].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f105t106].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f105t106].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f105t106].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f105t106].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f105t106] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f106t107] = true;

                            break;

                        }
                    case 107:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f106t107])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f106t107))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f106t107, avg);
                                    Recording_PointDict[Recording_Point.f106t107].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f106t107].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f106t107].totalCount++;
                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f106t107].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f106t107].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f106t107].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f106t107].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f106t107] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f107t108] = true;

                            break;

                        }
                    case 108:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f107t108])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f107t108))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f107t108, avg);
                                    Recording_PointDict[Recording_Point.f107t108].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f107t108].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f107t108].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f107t108].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f107t108].alltimetype;


                                    avg.dataList = Recording_PointDict[Recording_Point.f107t108].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f107t108].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f107t108] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f108t109] = true;

                            break;

                        }
                    case 109:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f108t109])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f108t109))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f108t109, avg);
                                    Recording_PointDict[Recording_Point.f108t109].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f108t109].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f108t109].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f108t109].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f108t109].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f108t109].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f108t109].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f108t109] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f108t109] = true;

                            break;

                        }
                    case 110:
                        {
                            Recording_PointDicttest2[Recording_Point.f110t111] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 111:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f110t111])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f110t111))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f110t111, avg);
                                    Recording_PointDict[Recording_Point.f110t111].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f110t111].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f110t111].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f110t111].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f110t111].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f110t111].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f110t111].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f110t111] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f] = true;

                            break;

                        }
                    case 112:
                        {
                            Recording_PointDicttest2[Recording_Point.f112t113] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 113:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f112t113])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f112t113))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f112t113, avg);
                                    Recording_PointDict[Recording_Point.f112t113].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f112t113].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f112t113].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f112t113].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f112t113].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f112t113].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f112t113].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f112t113] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f113t114] = true;

                            break;

                        }
                    case 114:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f113t114])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f113t114))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f113t114, avg);
                                    Recording_PointDict[Recording_Point.f113t114].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f113t114].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f113t114].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f113t114].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f113t114].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f113t114].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f113t114].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f113t114] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f114t115] = true;

                            break;

                        }
                    case 115:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f114t115])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f114t115))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f114t115, avg);
                                    Recording_PointDict[Recording_Point.f114t115].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f114t115].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f114t115].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f114t115].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f114t115].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f114t115].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f114t115].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f114t115] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f114t115] = true;

                            break;

                        }
                    #endregion
                    #region Maro
                    case 201:
                        {
                            Recording_PointDicttest2[Maro.f201t202] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 202:
                        {
                            Recording_PointDicttest2[Maro.f201t203] = true;
                            break;
                        }
                    case 203:
                        {
                            if (Recording_PointDicttest2[Maro.f201t202] && Recording_PointDicttest2[Maro.f201t203])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f201t202))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f201t202, avg);
                                    Recording_PointDict[Maro.f201t202].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f201t202].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f201t202].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f201t202].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f201t202].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f201t202].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f201t202].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f201t202] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 204:
                        {
                            Recording_PointDicttest2[Maro.f204t205] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 205:
                        {
                            if (Recording_PointDicttest2[Maro.f204t205])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f204t205))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f204t205, avg);
                                    Recording_PointDict[Maro.f204t205].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f204t205].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f204t205].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f204t205].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f204t205].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f204t205].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f204t205].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f204t205] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f205t206] = true;
                            break;


                        }
                    case 206:
                        {
                            if (Recording_PointDicttest2[Maro.f205t206])
                            {
                                Recording_PointDicttest2[Maro.f205t207] = true;

                            }

                            break;


                        }
                    case 207:
                        {
                            if (Recording_PointDicttest2[Maro.f205t206] && Recording_PointDicttest2[Maro.f205t207])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f205t206))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f205t206, avg);
                                    Recording_PointDict[Maro.f205t206].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f205t206].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f205t206].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f205t206].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f205t206].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f205t206].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f205t206].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f205t206] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 208:
                        {
                            Recording_PointDicttest2[Maro.f208t209] = true;
                            avg = AddItem(item);
                            break;


                        }
                    case 209:
                        {
                            if (Recording_PointDicttest2[Maro.f208t209])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f208t209))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f208t209, avg);
                                    Recording_PointDict[Maro.f208t209].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f208t209].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f208t209].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f208t209].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f208t209].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f208t209].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f208t209].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f208t209] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f209t210] = true;
                            break;


                        }
                    case 210:
                        {
                            if (Recording_PointDicttest2[Maro.f209t210])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f209t210))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f209t210, avg);
                                    Recording_PointDict[Maro.f209t210].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f209t210].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f209t210].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f209t210].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f209t210].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f209t210].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f209t210].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f209t210] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f210t211] = true;
                            break;

                        }
                    case 211:
                        {
                            if (Recording_PointDicttest2[Maro.f210t211])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f210t211))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f210t211, avg);
                                    Recording_PointDict[Maro.f210t211].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f210t211].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f210t211].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f210t211].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f210t211].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f210t211].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f210t211].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f210t211] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f211t212] = true;
                            break;

                        }
                    case 212:
                        {
                            if (Recording_PointDicttest2[Maro.f211t212])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f211t212))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f211t212, avg);
                                    Recording_PointDict[Maro.f211t212].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f211t212].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f211t212].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f211t212].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f211t212].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f211t212].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f211t212].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f211t212] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f212t213] = true;
                            break;

                        }
                    case 213:
                        {
                            if (Recording_PointDicttest2[Maro.f212t213])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f212t213))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f212t213, avg);
                                    Recording_PointDict[Maro.f212t213].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f212t213].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f212t213].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f212t213].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f212t213].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f212t213].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f212t213].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f212t213] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            avg217helper = AddItem(item);
                            Recording_PointDicttest2[Maro.f213t214] = true;
                            break;

                        }
                    case 214:
                        {
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f214t215] = true;
                            break;

                        }
                    case 215:
                        {

                            if (Recording_PointDicttest2[Maro.f214t215])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f214t215))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f214t215, avg);
                                    Recording_PointDict[Maro.f214t215].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f214t215].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f214t215].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f214t215].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f214t215].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f214t215].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f214t215].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f214t215] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f215t216] = true;
                            break;

                        }
                    case 216:
                        {

                            if (Recording_PointDicttest2[Maro.f215t216])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f215t216))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f215t216, avg);
                                    Recording_PointDict[Maro.f215t216].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f215t216].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f215t216].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f215t216].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f215t216].alltimetype;

                                    avg.dataList = Recording_PointDict[Maro.f215t216].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f215t216].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f215t216] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;

                        }
                    case 217:
                        {
                            Recording_PointDicttest2[Maro.f217t218] = true;
                            Recording_PointDicttest2[Maro.f213t217] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 218:
                        {
                            //!
                            if (Recording_PointDicttest2[Maro.f213t214] && Recording_PointDicttest2[Maro.f213t217])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f213t214))
                                {
                                    avg217helper.Avgtime = item.Startdate;
                                    avg217helper.alltimetype += avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f213t214, avg217helper);
                                    Recording_PointDict[Maro.f204t205].dataList.Add(avg217helper.alltimetype);
                                    Recording_PointDict[Maro.f204t205].IdList.Add(avg217helper.alltimetype);
                                    Recording_PointDict[Maro.f213t214].totalCount++;

                                    AvgFinal.Add(avg217helper);


                                }
                                else
                                {
                                    avg217helper.Avgtime = item.Startdate;

                                    avg217helper.totalCount = Recording_PointDict[Maro.f213t214].totalCount + 1;
                                    avg217helper.alltimetype = Recording_PointDict[Maro.f213t214].alltimetype;

                                    avg217helper.dataList = Recording_PointDict[Maro.f213t214].dataList;
                                    avg217helper.IdList = Recording_PointDict[Maro.f213t214].IdList;
                                    avg217helper.dataList.Add(avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks);
                                    avg217helper.IdList.Add(avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks);

                                    avg217helper.alltimetype += avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks;
                                    Recording_PointDict[Maro.f213t214] = avg217helper;

                                    AvgFinal.Add(avg217helper);

                                }

                            }

                            if (Recording_PointDicttest2[Maro.f217t218])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f217t218))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f217t218, avg);
                                    Recording_PointDict[Maro.f217t218].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f217t218].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f217t218].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f217t218].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f217t218].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f217t218].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f217t218].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f217t218] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f218t219] = true;
                            break;

                        }
                    case 219:
                        {

                            if (Recording_PointDicttest2[Maro.f218t219])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f218t219))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f218t219, avg);
                                    Recording_PointDict[Maro.f218t219].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f218t219].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f218t219].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f218t219].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f218t219].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f218t219].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f218t219].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f218t219] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Maro.f218t219] = true;
                            break;

                        }
                    #endregion
                    #region MaroTatro
                    case 301:
                        {
                            Recording_PointDicttest2[Maro_Tarto.f301t302] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 302:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f301t302])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f301t302))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f301t302, avg);
                                    Recording_PointDict[Maro_Tarto.f301t302].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f301t302].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f301t302].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f301t302].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f301t302].alltimetype;

                                    avg.dataList = Recording_PointDict[Maro_Tarto.f301t302].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f301t302].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f301t302] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f302t303] = true;
                            break;


                        }
                    case 303:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f302t303])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f302t303))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f302t303, avg);
                                    Recording_PointDict[Maro_Tarto.f302t303].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f302t303].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f302t303].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f302t303].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f302t303].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f302t303].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f302t303].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f302t303] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f303t304] = true;
                            break;
                        }
                    case 304:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f303t304])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f303t304))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f303t304, avg);
                                    Recording_PointDict[Maro_Tarto.f303t304].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f303t304].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f303t304].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f303t304].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f303t304].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f303t304].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f303t304].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f303t304] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f304t305] = true;
                            break;
                        }
                    case 305:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f304t305])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f304t305))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f304t305, avg);
                                    Recording_PointDict[Maro_Tarto.f304t305].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f304t305].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f304t305].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f304t305].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f304t305].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f304t305].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f304t305].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f304t305] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f305t306] = true;
                            break;
                        }
                    case 306:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f305t306])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f305t306))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f305t306, avg);
                                    Recording_PointDict[Maro_Tarto.f305t306].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f305t306].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f305t306].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f305t306].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f305t306].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f305t306].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f305t306].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f305t306] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f306t307] = true;
                            break;
                        }
                    case 307:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f306t307])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f306t307))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f306t307, avg);
                                    Recording_PointDict[Maro_Tarto.f306t307].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f306t307].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f306t307].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f306t307].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f306t307].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f306t307].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f306t307].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f306t307] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f307t308] = true;
                            break;
                        }
                    case 308:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f307t308])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f307t308))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f307t308, avg);
                                    Recording_PointDict[Maro_Tarto.f307t308].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f307t308].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f307t308].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f307t308].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f307t308].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f307t308].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f307t308].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f307t308] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f308t309] = true;
                            break;
                        }
                    case 309:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f308t309])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f308t309))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f308t309, avg);
                                    Recording_PointDict[Maro_Tarto.f308t309].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f308t309].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f308t309].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f308t309].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f308t309].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f308t309].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f308t309].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f308t309] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f309t310] = true;
                            break;
                        }
                    case 310:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f309t310])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f309t310))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f309t310, avg);
                                    Recording_PointDict[Maro_Tarto.f309t310].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f309t310].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f309t310].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f309t310].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f309t310].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f309t310].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f309t310].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f309t310] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }

                    #endregion
                    #region Zomi_tarto
                    case 401:
                        {
                            Recording_PointDicttest2[Zomi_Tarto.f401t402] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 402:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f401t402])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f401t402))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f401t402, avg);
                                    Recording_PointDict[Zomi_Tarto.f401t402].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f401t402].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f401t402].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f401t402].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f401t402].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f401t402].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f401t402].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f401t402] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f402t403] = true;
                            break;
                        }
                    case 403:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f402t403])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f402t403))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f402t403, avg);
                                    Recording_PointDict[Zomi_Tarto.f402t403].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f402t403].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f402t403].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f402t403].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f402t403].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f402t403].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f402t403].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f402t403] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f403t404] = true;
                            break;
                        }
                    case 404:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f403t404])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f403t404))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f403t404, avg);
                                    Recording_PointDict[Zomi_Tarto.f403t404].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f403t404].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f403t404].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f403t404].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f403t404].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f403t404].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f403t404].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f403t404] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f404t405] = true;
                            break;
                        }
                    case 405:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f404t405])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f404t405))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f404t405, avg);
                                    Recording_PointDict[Zomi_Tarto.f404t405].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f404t405].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f404t405].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f404t405].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f404t405].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f404t405].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f404t405].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f404t405] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f405t406] = true;
                            break;
                        }
                    case 406:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f405t406])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f405t406))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f405t406, avg);
                                    Recording_PointDict[Zomi_Tarto.f405t406].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f405t406].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f405t406].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f405t406].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f405t406].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f405t406].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f405t406].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f405t406] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f406t407] = true;
                            break;
                        }
                    case 407:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f406t407])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f406t407))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f406t407, avg);
                                    Recording_PointDict[Zomi_Tarto.f406t407].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f406t407].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f406t407].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f406t407].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f406t407].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f406t407].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f406t407].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f406t407] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f407t408] = true;
                            break;
                        }
                    case 408:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f407t408])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f407t408))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f407t408, avg);
                                    Recording_PointDict[Zomi_Tarto.f407t408].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f407t408].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f407t408].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f407t408].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f407t408].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f407t408].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f407t408].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f407t408] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    #endregion
                    #region Deburring
                    case 501:
                        {
                            Recording_PointDicttest2[Deburring.f501t502] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 502:
                        {
                            Recording_PointDicttest2[Deburring.f501t503] = true;
                            break;
                        }
                    case 503:
                        {
                            if (Recording_PointDicttest2[Deburring.f501t502] && Recording_PointDicttest2[Deburring.f501t503])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f501t502))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f501t502, avg);
                                    Recording_PointDict[Deburring.f501t502].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f501t502].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f501t502].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f501t502].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f501t502].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f501t502].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f501t502].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f501t502] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 504:
                        {
                            Recording_PointDicttest2[Deburring.f504t505] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 505:
                        {
                            if (Recording_PointDicttest2[Deburring.f504t505])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f504t505))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f504t505, avg);
                                    Recording_PointDict[Deburring.f504t505].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f504t505].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f504t505].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f504t505].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f504t505].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f504t505].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f504t505].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f504t505] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 506:
                        {
                            Recording_PointDicttest2[Deburring.f506t507] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 507:
                        {
                            if (Recording_PointDicttest2[Deburring.f506t507])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f506t507))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f506t507, avg);
                                    Recording_PointDict[Deburring.f506t507].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f506t507].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f506t507].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f506t507].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f506t507].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f506t507].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f506t507].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f506t507] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 508:
                        {
                            Recording_PointDicttest2[Deburring.f508t509] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 509:
                        {
                            if (Recording_PointDicttest2[Deburring.f508t509])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f508t509))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f508t509, avg);
                                    Recording_PointDict[Deburring.f508t509].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f508t509].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f508t509].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f508t509].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f508t509].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f508t509].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f508t509].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f508t509] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 510:
                        {
                            Recording_PointDicttest2[Deburring.f510t511] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 511:
                        {
                            if (Recording_PointDicttest2[Deburring.f510t511])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f510t511))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f510t511, avg);
                                    Recording_PointDict[Deburring.f510t511].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f510t511].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f510t511].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f510t511].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f510t511].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f510t511].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f510t511].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f510t511] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 512:
                        {
                            Recording_PointDicttest2[Deburring.f512t513] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 513:
                        {
                            if (Recording_PointDicttest2[Deburring.f512t513])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f512t513))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f512t513, avg);
                                    Recording_PointDict[Deburring.f512t513].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f512t513].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f512t513].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f512t513].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f512t513].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f512t513].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f512t513].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f512t513] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f513t514] = true;
                            break;

                        }
                    case 514:
                        {
                            if (Recording_PointDicttest2[Deburring.f513t514])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f513t514))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f513t514, avg);
                                    Recording_PointDict[Deburring.f513t514].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f513t514].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f513t514].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f513t514].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f513t514].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f513t514].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f513t514].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f513t514] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f514t515] = true;
                            break;

                        }
                    case 515:
                        {
                            if (Recording_PointDicttest2[Deburring.f514t515])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f514t515))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f514t515, avg);
                                    Recording_PointDict[Deburring.f514t515].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f514t515].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f514t515].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f514t515].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f514t515].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f514t515].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f514t515].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f514t515] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f515t516] = true;
                            break;

                        }
                    case 516:
                        {
                            if (Recording_PointDicttest2[Deburring.f515t516])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f515t516))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f515t516, avg);
                                    Recording_PointDict[Deburring.f515t516].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f515t516].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f515t516].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f515t516].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f515t516].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f515t516].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f515t516].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f515t516] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f516t517] = true;
                            break;

                        }
                    case 517:
                        {
                            if (Recording_PointDicttest2[Deburring.f516t517])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f516t517))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f516t517, avg);
                                    Recording_PointDict[Deburring.f516t517].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f516t517].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f516t517].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f516t517].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f516t517].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f516t517].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f516t517].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f516t517] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f517t518] = true;
                            break;

                        }
                    case 518:
                        {
                            if (Recording_PointDicttest2[Deburring.f517t518])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f517t518))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f517t518, avg);
                                    Recording_PointDict[Deburring.f517t518].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f517t518].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f517t518].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f517t518].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f517t518].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f517t518].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f517t518].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f517t518] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    #endregion
                    #region EndPoint
                    case 601:
                        {
                            Recording_PointDicttest2[EndPoint.f601t602] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 602:
                        {
                            if (Recording_PointDicttest2[EndPoint.f601t602])
                            {

                                if (!Recording_PointDict.ContainsKey(EndPoint.f601t602))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(EndPoint.f601t602, avg);
                                    Recording_PointDict[EndPoint.f601t602].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[EndPoint.f601t602].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[EndPoint.f601t602].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[EndPoint.f601t602].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[EndPoint.f601t602].alltimetype;
                                    avg.dataList = Recording_PointDict[EndPoint.f601t602].dataList;
                                    avg.IdList = Recording_PointDict[EndPoint.f601t602].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[EndPoint.f601t602] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                        #endregion
                }

            }
            AvgFinalFirst = AvgFinal;
            return Recording_PointDict;
            ;
        }

        public Task<Dictionary<Enum, AvgCalc>> AvgFinalDictionaryAsync()
        {
            Task.WaitAll();
            return Task.Run(() =>
            {
                return AvgDictionaryAsync()/*.Result*/;
            });
        }
        private async Task<Dictionary<Enum, AvgCalc>> AvgDictionarySecondAsync()
        {
            List<Data> AvgData = await AvgwithoutavgSecondAsync();
            List<AvgCalc> AvgFinal = new();
            AvgCalc avg = new();
            AvgCalc avg217helper = new();

            var Recording_PointDict = new Dictionary<Enum, AvgCalc>();
            var Recording_PointDicttest2 = new Dictionary<Enum, bool>();

            foreach (var item in AvgData)
            {

                switch (item.EventID)
                {
                    #region Recording_Point
                    case 101:
                        {
                            Recording_PointDicttest2[Recording_Point.f101t102] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 102:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f101t102])
                            {
                                //ref var valOrNew =
                                //    ref CollectionsMarshal.GetValueRefOrAddDefault(Recording_PointDict, Recording_Point.f101t102, out var existed);
                                //if (!existed)
                                //{ 

                                //}
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f101t102))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype = avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f101t102, avg);
                                    Recording_PointDict[Recording_Point.f101t102].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f101t102].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f101t102].totalCount++;

                                    ;
                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f101t102].alltimetype;
                                    ;
                                    avg.dataList = Recording_PointDict[Recording_Point.f101t102].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f101t102].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);


                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    avg.totalCount = Recording_PointDict[Recording_Point.f101t102].totalCount + 1;

                                    Recording_PointDict[Recording_Point.f101t102] = avg;

                                    ;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f102t103] = true;
                            break;


                        }
                    case 103:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f102t103])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f102t103))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f102t103, avg);
                                    Recording_PointDict[Recording_Point.f102t103].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f102t103].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f102t103].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f102t103].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f102t103].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f102t103].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f102t103].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f102t103] = avg;
                                    ;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f103t104] = true;

                            break;

                        }
                    case 104:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f103t104])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f103t104))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f103t104, avg);
                                    Recording_PointDict[Recording_Point.f103t104].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f103t104].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f103t104].totalCount++;
                                    AvgFinal.Add(avg);
                                    ;

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f103t104].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f103t104].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f103t104].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f103t104] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f104t105] = true;

                            break;

                        }
                    case 105:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f104t105])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f104t105))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f104t105, avg);
                                    Recording_PointDict[Recording_Point.f104t105].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f104t105].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f104t105].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f104t105].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f104t105].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f104t105].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f104t105].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f104t105] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f105t106] = true;

                            break;

                        }
                    case 106:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f105t106])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f105t106))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f105t106, avg);
                                    Recording_PointDict[Recording_Point.f105t106].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f105t106].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f105t106].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f105t106].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f105t106].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f105t106].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f105t106].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f105t106] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f106t107] = true;

                            break;

                        }
                    case 107:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f106t107])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f106t107))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f106t107, avg);
                                    Recording_PointDict[Recording_Point.f106t107].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f106t107].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f106t107].totalCount++;
                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f106t107].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f106t107].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f106t107].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f106t107].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f106t107] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f107t108] = true;

                            break;

                        }
                    case 108:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f107t108])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f107t108))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f107t108, avg);
                                    Recording_PointDict[Recording_Point.f107t108].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f107t108].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f107t108].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f107t108].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f107t108].alltimetype;


                                    avg.dataList = Recording_PointDict[Recording_Point.f107t108].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f107t108].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f107t108] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f108t109] = true;

                            break;

                        }
                    case 109:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f108t109])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f108t109))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f108t109, avg);
                                    Recording_PointDict[Recording_Point.f108t109].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f108t109].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f108t109].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f108t109].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f108t109].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f108t109].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f108t109].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f108t109] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f108t109] = true;

                            break;

                        }
                    case 110:
                        {
                            Recording_PointDicttest2[Recording_Point.f110t111] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 111:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f110t111])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f110t111))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f110t111, avg);
                                    Recording_PointDict[Recording_Point.f110t111].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f110t111].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f110t111].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f110t111].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f110t111].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f110t111].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f110t111].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f110t111] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f] = true;

                            break;

                        }
                    case 112:
                        {
                            Recording_PointDicttest2[Recording_Point.f112t113] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 113:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f112t113])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f112t113))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f112t113, avg);
                                    Recording_PointDict[Recording_Point.f112t113].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f112t113].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f112t113].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f112t113].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f112t113].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f112t113].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f112t113].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f112t113] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f113t114] = true;

                            break;

                        }
                    case 114:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f113t114])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f113t114))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f113t114, avg);
                                    Recording_PointDict[Recording_Point.f113t114].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f113t114].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f113t114].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f113t114].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f113t114].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f113t114].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f113t114].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f113t114] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f114t115] = true;

                            break;

                        }
                    case 115:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f114t115])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f114t115))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f114t115, avg);
                                    Recording_PointDict[Recording_Point.f114t115].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f114t115].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f114t115].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f114t115].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f114t115].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f114t115].dataList;
                                    avg.IdList = Recording_PointDict[Recording_Point.f114t115].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f114t115] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f114t115] = true;

                            break;

                        }
                    #endregion
                    #region Maro
                    case 201:
                        {
                            Recording_PointDicttest2[Maro.f201t202] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 202:
                        {
                            Recording_PointDicttest2[Maro.f201t203] = true;
                            break;
                        }
                    case 203:
                        {
                            if (Recording_PointDicttest2[Maro.f201t202] && Recording_PointDicttest2[Maro.f201t203])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f201t202))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f201t202, avg);
                                    Recording_PointDict[Maro.f201t202].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f201t202].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f201t202].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f201t202].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f201t202].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f201t202].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f201t202].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f201t202] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 204:
                        {
                            Recording_PointDicttest2[Maro.f204t205] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 205:
                        {
                            if (Recording_PointDicttest2[Maro.f204t205])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f204t205))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f204t205, avg);
                                    Recording_PointDict[Maro.f204t205].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f204t205].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f204t205].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f204t205].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f204t205].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f204t205].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f204t205].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f204t205] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f205t206] = true;
                            break;


                        }
                    case 206:
                        {
                            if (Recording_PointDicttest2[Maro.f205t206])
                            {
                                Recording_PointDicttest2[Maro.f205t207] = true;

                            }

                            break;


                        }
                    case 207:
                        {
                            if (Recording_PointDicttest2[Maro.f205t206] && Recording_PointDicttest2[Maro.f205t207])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f205t206))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f205t206, avg);
                                    Recording_PointDict[Maro.f205t206].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f205t206].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f205t206].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f205t206].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f205t206].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f205t206].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f205t206].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f205t206] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 208:
                        {
                            Recording_PointDicttest2[Maro.f208t209] = true;
                            avg = AddItem(item);
                            break;


                        }
                    case 209:
                        {
                            if (Recording_PointDicttest2[Maro.f208t209])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f208t209))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f208t209, avg);
                                    Recording_PointDict[Maro.f208t209].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f208t209].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f208t209].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f208t209].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f208t209].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f208t209].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f208t209].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f208t209] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f209t210] = true;
                            break;


                        }
                    case 210:
                        {
                            if (Recording_PointDicttest2[Maro.f209t210])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f209t210))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f209t210, avg);
                                    Recording_PointDict[Maro.f209t210].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f209t210].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f209t210].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f209t210].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f209t210].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f209t210].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f209t210].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f209t210] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f210t211] = true;
                            break;

                        }
                    case 211:
                        {
                            if (Recording_PointDicttest2[Maro.f210t211])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f210t211))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f210t211, avg);
                                    Recording_PointDict[Maro.f210t211].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f210t211].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f210t211].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f210t211].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f210t211].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f210t211].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f210t211].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f210t211] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f211t212] = true;
                            break;

                        }
                    case 212:
                        {
                            if (Recording_PointDicttest2[Maro.f211t212])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f211t212))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f211t212, avg);
                                    Recording_PointDict[Maro.f211t212].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f211t212].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f211t212].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f211t212].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f211t212].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f211t212].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f211t212].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f211t212] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f212t213] = true;
                            break;

                        }
                    case 213:
                        {
                            if (Recording_PointDicttest2[Maro.f212t213])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f212t213))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f212t213, avg);
                                    Recording_PointDict[Maro.f212t213].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f212t213].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f212t213].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f212t213].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f212t213].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f212t213].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f212t213].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f212t213] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            avg217helper = AddItem(item);
                            Recording_PointDicttest2[Maro.f213t214] = true;
                            break;

                        }
                    case 214:
                        {
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f214t215] = true;
                            break;

                        }
                    case 215:
                        {

                            if (Recording_PointDicttest2[Maro.f214t215])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f214t215))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f214t215, avg);
                                    Recording_PointDict[Maro.f214t215].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f214t215].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f214t215].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f214t215].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f214t215].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f214t215].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f214t215].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f214t215] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f215t216] = true;
                            break;

                        }
                    case 216:
                        {

                            if (Recording_PointDicttest2[Maro.f215t216])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f215t216))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f215t216, avg);
                                    Recording_PointDict[Maro.f215t216].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f215t216].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f215t216].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f215t216].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f215t216].alltimetype;

                                    avg.dataList = Recording_PointDict[Maro.f215t216].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f215t216].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f215t216] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;

                        }
                    case 217:
                        {
                            Recording_PointDicttest2[Maro.f217t218] = true;
                            Recording_PointDicttest2[Maro.f213t217] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 218:
                        {
                            //!
                            if (Recording_PointDicttest2[Maro.f213t214] && Recording_PointDicttest2[Maro.f213t217])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f213t214))
                                {
                                    avg217helper.Avgtime = item.Startdate;
                                    avg217helper.alltimetype += avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f213t214, avg217helper);
                                    Recording_PointDict[Maro.f204t205].dataList.Add(avg217helper.alltimetype);
                                    Recording_PointDict[Maro.f204t205].IdList.Add(avg217helper.alltimetype);
                                    Recording_PointDict[Maro.f213t214].totalCount++;

                                    AvgFinal.Add(avg217helper);


                                }
                                else
                                {
                                    avg217helper.Avgtime = item.Startdate;

                                    avg217helper.totalCount = Recording_PointDict[Maro.f213t214].totalCount + 1;
                                    avg217helper.alltimetype = Recording_PointDict[Maro.f213t214].alltimetype;

                                    avg217helper.dataList = Recording_PointDict[Maro.f213t214].dataList;
                                    avg217helper.IdList = Recording_PointDict[Maro.f213t214].IdList;
                                    avg217helper.dataList.Add(avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks);
                                    avg217helper.IdList.Add(avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks);

                                    avg217helper.alltimetype += avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks;
                                    Recording_PointDict[Maro.f213t214] = avg217helper;

                                    AvgFinal.Add(avg217helper);

                                }

                            }

                            if (Recording_PointDicttest2[Maro.f217t218])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f217t218))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f217t218, avg);
                                    Recording_PointDict[Maro.f217t218].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f217t218].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f217t218].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f217t218].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f217t218].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f217t218].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f217t218].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f217t218] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f218t219] = true;
                            break;

                        }
                    case 219:
                        {

                            if (Recording_PointDicttest2[Maro.f218t219])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f218t219))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f218t219, avg);
                                    Recording_PointDict[Maro.f218t219].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f218t219].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f218t219].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f218t219].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f218t219].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f218t219].dataList;
                                    avg.IdList = Recording_PointDict[Maro.f218t219].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f218t219] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Maro.f218t219] = true;
                            break;

                        }
                    #endregion
                    #region MaroTatro
                    case 301:
                        {
                            Recording_PointDicttest2[Maro_Tarto.f301t302] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 302:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f301t302])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f301t302))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f301t302, avg);
                                    Recording_PointDict[Maro_Tarto.f301t302].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f301t302].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f301t302].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f301t302].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f301t302].alltimetype;

                                    avg.dataList = Recording_PointDict[Maro_Tarto.f301t302].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f301t302].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f301t302] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f302t303] = true;
                            break;


                        }
                    case 303:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f302t303])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f302t303))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f302t303, avg);
                                    Recording_PointDict[Maro_Tarto.f302t303].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f302t303].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f302t303].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f302t303].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f302t303].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f302t303].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f302t303].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f302t303] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f303t304] = true;
                            break;
                        }
                    case 304:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f303t304])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f303t304))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f303t304, avg);
                                    Recording_PointDict[Maro_Tarto.f303t304].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f303t304].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f303t304].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f303t304].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f303t304].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f303t304].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f303t304].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f303t304] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f304t305] = true;
                            break;
                        }
                    case 305:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f304t305])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f304t305))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f304t305, avg);
                                    Recording_PointDict[Maro_Tarto.f304t305].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f304t305].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f304t305].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f304t305].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f304t305].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f304t305].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f304t305].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f304t305] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f305t306] = true;
                            break;
                        }
                    case 306:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f305t306])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f305t306))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f305t306, avg);
                                    Recording_PointDict[Maro_Tarto.f305t306].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f305t306].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f305t306].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f305t306].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f305t306].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f305t306].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f305t306].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f305t306] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f306t307] = true;
                            break;
                        }
                    case 307:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f306t307])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f306t307))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f306t307, avg);
                                    Recording_PointDict[Maro_Tarto.f306t307].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f306t307].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f306t307].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f306t307].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f306t307].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f306t307].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f306t307].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f306t307] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f307t308] = true;
                            break;
                        }
                    case 308:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f307t308])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f307t308))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f307t308, avg);
                                    Recording_PointDict[Maro_Tarto.f307t308].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f307t308].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f307t308].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f307t308].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f307t308].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f307t308].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f307t308].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f307t308] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f308t309] = true;
                            break;
                        }
                    case 309:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f308t309])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f308t309))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f308t309, avg);
                                    Recording_PointDict[Maro_Tarto.f308t309].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f308t309].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f308t309].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f308t309].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f308t309].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f308t309].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f308t309].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f308t309] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f309t310] = true;
                            break;
                        }
                    case 310:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f309t310])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f309t310))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f309t310, avg);
                                    Recording_PointDict[Maro_Tarto.f309t310].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f309t310].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f309t310].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f309t310].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f309t310].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f309t310].dataList;
                                    avg.IdList = Recording_PointDict[Maro_Tarto.f309t310].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f309t310] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }

                    #endregion
                    #region Zomi_tarto
                    case 401:
                        {
                            Recording_PointDicttest2[Zomi_Tarto.f401t402] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 402:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f401t402])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f401t402))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f401t402, avg);
                                    Recording_PointDict[Zomi_Tarto.f401t402].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f401t402].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f401t402].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f401t402].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f401t402].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f401t402].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f401t402].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f401t402] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f402t403] = true;
                            break;
                        }
                    case 403:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f402t403])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f402t403))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f402t403, avg);
                                    Recording_PointDict[Zomi_Tarto.f402t403].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f402t403].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f402t403].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f402t403].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f402t403].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f402t403].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f402t403].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f402t403] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f403t404] = true;
                            break;
                        }
                    case 404:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f403t404])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f403t404))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f403t404, avg);
                                    Recording_PointDict[Zomi_Tarto.f403t404].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f403t404].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f403t404].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f403t404].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f403t404].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f403t404].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f403t404].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f403t404] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f404t405] = true;
                            break;
                        }
                    case 405:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f404t405])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f404t405))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f404t405, avg);
                                    Recording_PointDict[Zomi_Tarto.f404t405].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f404t405].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f404t405].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f404t405].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f404t405].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f404t405].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f404t405].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f404t405] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f405t406] = true;
                            break;
                        }
                    case 406:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f405t406])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f405t406))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f405t406, avg);
                                    Recording_PointDict[Zomi_Tarto.f405t406].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f405t406].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f405t406].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f405t406].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f405t406].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f405t406].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f405t406].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f405t406] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f406t407] = true;
                            break;
                        }
                    case 407:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f406t407])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f406t407))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f406t407, avg);
                                    Recording_PointDict[Zomi_Tarto.f406t407].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f406t407].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f406t407].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f406t407].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f406t407].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f406t407].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f406t407].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f406t407] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f407t408] = true;
                            break;
                        }
                    case 408:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f407t408])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f407t408))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f407t408, avg);
                                    Recording_PointDict[Zomi_Tarto.f407t408].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f407t408].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f407t408].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f407t408].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f407t408].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f407t408].dataList;
                                    avg.IdList = Recording_PointDict[Zomi_Tarto.f407t408].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f407t408] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    #endregion
                    #region Deburring
                    case 501:
                        {
                            Recording_PointDicttest2[Deburring.f501t502] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 502:
                        {
                            Recording_PointDicttest2[Deburring.f501t503] = true;
                            break;
                        }
                    case 503:
                        {
                            if (Recording_PointDicttest2[Deburring.f501t502] && Recording_PointDicttest2[Deburring.f501t503])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f501t502))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f501t502, avg);
                                    Recording_PointDict[Deburring.f501t502].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f501t502].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f501t502].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f501t502].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f501t502].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f501t502].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f501t502].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f501t502] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 504:
                        {
                            Recording_PointDicttest2[Deburring.f504t505] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 505:
                        {
                            if (Recording_PointDicttest2[Deburring.f504t505])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f504t505))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f504t505, avg);
                                    Recording_PointDict[Deburring.f504t505].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f504t505].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f504t505].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f504t505].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f504t505].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f504t505].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f504t505].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f504t505] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 506:
                        {
                            Recording_PointDicttest2[Deburring.f506t507] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 507:
                        {
                            if (Recording_PointDicttest2[Deburring.f506t507])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f506t507))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f506t507, avg);
                                    Recording_PointDict[Deburring.f506t507].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f506t507].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f506t507].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f506t507].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f506t507].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f506t507].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f506t507].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f506t507] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 508:
                        {
                            Recording_PointDicttest2[Deburring.f508t509] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 509:
                        {
                            if (Recording_PointDicttest2[Deburring.f508t509])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f508t509))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f508t509, avg);
                                    Recording_PointDict[Deburring.f508t509].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f508t509].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f508t509].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f508t509].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f508t509].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f508t509].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f508t509].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f508t509] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 510:
                        {
                            Recording_PointDicttest2[Deburring.f510t511] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 511:
                        {
                            if (Recording_PointDicttest2[Deburring.f510t511])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f510t511))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f510t511, avg);
                                    Recording_PointDict[Deburring.f510t511].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f510t511].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f510t511].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f510t511].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f510t511].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f510t511].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f510t511].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f510t511] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 512:
                        {
                            Recording_PointDicttest2[Deburring.f512t513] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 513:
                        {
                            if (Recording_PointDicttest2[Deburring.f512t513])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f512t513))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f512t513, avg);
                                    Recording_PointDict[Deburring.f512t513].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f512t513].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f512t513].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f512t513].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f512t513].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f512t513].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f512t513].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f512t513] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f513t514] = true;
                            break;

                        }
                    case 514:
                        {
                            if (Recording_PointDicttest2[Deburring.f513t514])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f513t514))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f513t514, avg);
                                    Recording_PointDict[Deburring.f513t514].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f513t514].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f513t514].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f513t514].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f513t514].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f513t514].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f513t514].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f513t514] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f514t515] = true;
                            break;

                        }
                    case 515:
                        {
                            if (Recording_PointDicttest2[Deburring.f514t515])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f514t515))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f514t515, avg);
                                    Recording_PointDict[Deburring.f514t515].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f514t515].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f514t515].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f514t515].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f514t515].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f514t515].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f514t515].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f514t515] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f515t516] = true;
                            break;

                        }
                    case 516:
                        {
                            if (Recording_PointDicttest2[Deburring.f515t516])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f515t516))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f515t516, avg);
                                    Recording_PointDict[Deburring.f515t516].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f515t516].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f515t516].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f515t516].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f515t516].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f515t516].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f515t516].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f515t516] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f516t517] = true;
                            break;

                        }
                    case 517:
                        {
                            if (Recording_PointDicttest2[Deburring.f516t517])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f516t517))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f516t517, avg);
                                    Recording_PointDict[Deburring.f516t517].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f516t517].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f516t517].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f516t517].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f516t517].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f516t517].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f516t517].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f516t517] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f517t518] = true;
                            break;

                        }
                    case 518:
                        {
                            if (Recording_PointDicttest2[Deburring.f517t518])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f517t518))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f517t518, avg);
                                    Recording_PointDict[Deburring.f517t518].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f517t518].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f517t518].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f517t518].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f517t518].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f517t518].dataList;
                                    avg.IdList = Recording_PointDict[Deburring.f517t518].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f517t518] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    #endregion
                    #region EndPoint
                    case 601:
                        {
                            Recording_PointDicttest2[EndPoint.f601t602] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 602:
                        {
                            if (Recording_PointDicttest2[EndPoint.f601t602])
                            {

                                if (!Recording_PointDict.ContainsKey(EndPoint.f601t602))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(EndPoint.f601t602, avg);
                                    Recording_PointDict[EndPoint.f601t602].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[EndPoint.f601t602].IdList.Add(avg.alltimetype);
                                    Recording_PointDict[EndPoint.f601t602].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[EndPoint.f601t602].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[EndPoint.f601t602].alltimetype;
                                    avg.dataList = Recording_PointDict[EndPoint.f601t602].dataList;
                                    avg.IdList = Recording_PointDict[EndPoint.f601t602].IdList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.IdList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[EndPoint.f601t602] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                        #endregion
                }

            }
            AvgFinalSecond = AvgFinal;
            return Recording_PointDict;
        }

        public Task<Dictionary<Enum, AvgCalc>> AvgFinalDictionarySecondAsync()
        {
            Task.WaitAll();
            return Task.Run(() =>
            {
                return AvgDictionarySecondAsync();
            });
        }

        private async Task<Dictionary<Enum, AvgCalc>> AvgDictionaryThirdAsync()
        {
            List<Data> AvgData = await AvgwithoutavgThirdAsync();
            List<AvgCalc> AvgFinal = new();
            AvgCalc avg = new();
            AvgCalc avg217helper = new();

            var Recording_PointDict = new Dictionary<Enum, AvgCalc>();
            var Recording_PointDicttest2 = new Dictionary<Enum, bool>();

            //foreach (Data data in AvgData) 
            //{
            //    AvgFinal.Add(AddItem(data));
            //}

            foreach (var item in AvgData)
            {

                switch (item.EventID)
                {
                    #region Recording_Point
                    case 101:
                        {
                            Recording_PointDicttest2[Recording_Point.f101t102] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 102:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f101t102])
                            {
                                //ref var valOrNew =
                                //    ref CollectionsMarshal.GetValueRefOrAddDefault(Recording_PointDict, Recording_Point.f101t102, out var existed);
                                //if (!existed)
                                //{ 

                                //}
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f101t102))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype = avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f101t102, avg);
                                    Recording_PointDict[Recording_Point.f101t102].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f101t102].totalCount++;

                                    ;
                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f101t102].alltimetype;
                                    ;
                                    avg.dataList = Recording_PointDict[Recording_Point.f101t102].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    avg.totalCount = Recording_PointDict[Recording_Point.f101t102].totalCount + 1;

                                    Recording_PointDict[Recording_Point.f101t102] = avg;

                                    ;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f102t103] = true;
                            break;


                        }
                    case 103:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f102t103])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f102t103))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f102t103, avg);
                                    Recording_PointDict[Recording_Point.f102t103].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f102t103].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f102t103].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f102t103].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f102t103].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f102t103] = avg;
                                    ;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f103t104] = true;

                            break;

                        }
                    case 104:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f103t104])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f103t104))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f103t104, avg);
                                    Recording_PointDict[Recording_Point.f103t104].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f103t104].totalCount++;
                                    AvgFinal.Add(avg);
                                    ;

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f103t104].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f103t104].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f103t104].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f103t104] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f104t105] = true;

                            break;

                        }
                    case 105:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f104t105])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f104t105))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f104t105, avg);
                                    Recording_PointDict[Recording_Point.f104t105].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f104t105].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f104t105].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f104t105].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f104t105].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f104t105] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f105t106] = true;

                            break;

                        }
                    case 106:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f105t106])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f105t106))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f105t106, avg);
                                    Recording_PointDict[Recording_Point.f105t106].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f105t106].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f105t106].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f105t106].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f105t106].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f105t106] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f106t107] = true;

                            break;

                        }
                    case 107:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f106t107])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f106t107))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f106t107, avg);
                                    Recording_PointDict[Recording_Point.f106t107].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f106t107].totalCount++;
                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f106t107].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f106t107].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f106t107].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f106t107] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f107t108] = true;

                            break;

                        }
                    case 108:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f107t108])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f107t108))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f107t108, avg);
                                    Recording_PointDict[Recording_Point.f107t108].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f107t108].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f107t108].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f107t108].alltimetype;


                                    avg.dataList = Recording_PointDict[Recording_Point.f107t108].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f107t108] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f108t109] = true;

                            break;

                        }
                    case 109:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f108t109])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f108t109))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f108t109, avg);
                                    Recording_PointDict[Recording_Point.f108t109].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f108t109].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f108t109].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f108t109].alltimetype;

                                    avg.dataList = Recording_PointDict[Recording_Point.f108t109].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f108t109] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f108t109] = true;

                            break;

                        }
                    case 110:
                        {
                            Recording_PointDicttest2[Recording_Point.f110t111] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 111:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f110t111])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f110t111))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f110t111, avg);
                                    Recording_PointDict[Recording_Point.f110t111].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f110t111].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f110t111].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f110t111].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f110t111].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f110t111] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f] = true;

                            break;

                        }
                    case 112:
                        {
                            Recording_PointDicttest2[Recording_Point.f112t113] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 113:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f112t113])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f112t113))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f112t113, avg);
                                    Recording_PointDict[Recording_Point.f112t113].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f112t113].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f112t113].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f112t113].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f112t113].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f112t113] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f113t114] = true;

                            break;

                        }
                    case 114:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f113t114])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f113t114))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f113t114, avg);
                                    Recording_PointDict[Recording_Point.f113t114].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f113t114].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f113t114].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f113t114].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f113t114].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f113t114] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Recording_Point.f114t115] = true;

                            break;

                        }
                    case 115:
                        {
                            if (Recording_PointDicttest2[Recording_Point.f114t115])
                            {
                                if (!Recording_PointDict.ContainsKey(Recording_Point.f114t115))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Recording_Point.f114t115, avg);
                                    Recording_PointDict[Recording_Point.f114t115].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Recording_Point.f114t115].totalCount++;
                                    AvgFinal.Add(avg);

                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Recording_Point.f114t115].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Recording_Point.f114t115].alltimetype;
                                    avg.dataList = Recording_PointDict[Recording_Point.f114t115].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Recording_Point.f114t115] = avg;
                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Recording_Point.f114t115] = true;

                            break;

                        }
                    #endregion
                    #region Maro
                    case 201:
                        {
                            Recording_PointDicttest2[Maro.f201t202] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 202:
                        {
                            Recording_PointDicttest2[Maro.f201t203] = true;
                            break;
                        }
                    case 203:
                        {
                            if (Recording_PointDicttest2[Maro.f201t202] && Recording_PointDicttest2[Maro.f201t203])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f201t202))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f201t202, avg);
                                    Recording_PointDict[Maro.f201t202].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f201t202].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f201t202].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f201t202].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f201t202].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f201t202] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 204:
                        {
                            Recording_PointDicttest2[Maro.f204t205] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 205:
                        {
                            if (Recording_PointDicttest2[Maro.f204t205])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f204t205))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f204t205, avg);
                                    Recording_PointDict[Maro.f204t205].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f204t205].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f204t205].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f204t205].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f204t205].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f204t205] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f205t206] = true;
                            break;


                        }
                    case 206:
                        {
                            if (Recording_PointDicttest2[Maro.f205t206])
                            {
                                Recording_PointDicttest2[Maro.f205t207] = true;

                            }

                            break;


                        }
                    case 207:
                        {
                            if (Recording_PointDicttest2[Maro.f205t206] && Recording_PointDicttest2[Maro.f205t207])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f205t206))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f205t206, avg);
                                    Recording_PointDict[Maro.f205t206].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f205t206].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f205t206].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f205t206].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f205t206].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f205t206] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 208:
                        {
                            Recording_PointDicttest2[Maro.f208t209] = true;
                            avg = AddItem(item);
                            break;


                        }
                    case 209:
                        {
                            if (Recording_PointDicttest2[Maro.f208t209])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f208t209))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f208t209, avg);
                                    Recording_PointDict[Maro.f208t209].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f208t209].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f208t209].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f208t209].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f208t209].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f208t209] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f209t210] = true;
                            break;


                        }
                    case 210:
                        {
                            if (Recording_PointDicttest2[Maro.f209t210])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f209t210))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f209t210, avg);
                                    Recording_PointDict[Maro.f209t210].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f209t210].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f209t210].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f209t210].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f209t210].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f209t210] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f210t211] = true;
                            break;

                        }
                    case 211:
                        {
                            if (Recording_PointDicttest2[Maro.f210t211])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f210t211))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f210t211, avg);
                                    Recording_PointDict[Maro.f210t211].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f210t211].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f210t211].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f210t211].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f210t211].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f210t211] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f211t212] = true;
                            break;

                        }
                    case 212:
                        {
                            if (Recording_PointDicttest2[Maro.f211t212])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f211t212))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f211t212, avg);
                                    Recording_PointDict[Maro.f211t212].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f211t212].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f211t212].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f211t212].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f211t212].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f211t212] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f212t213] = true;
                            break;

                        }
                    case 213:
                        {
                            if (Recording_PointDicttest2[Maro.f212t213])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f212t213))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f212t213, avg);
                                    Recording_PointDict[Maro.f212t213].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f212t213].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f212t213].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f212t213].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f212t213].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f212t213] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            avg217helper = AddItem(item);
                            Recording_PointDicttest2[Maro.f213t214] = true;
                            break;

                        }
                    case 214:
                        {
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f214t215] = true;
                            break;

                        }
                    case 215:
                        {

                            if (Recording_PointDicttest2[Maro.f214t215])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f214t215))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f214t215, avg);
                                    Recording_PointDict[Maro.f214t215].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f214t215].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f214t215].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f214t215].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f214t215].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f214t215] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f215t216] = true;
                            break;

                        }
                    case 216:
                        {

                            if (Recording_PointDicttest2[Maro.f215t216])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f215t216))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f215t216, avg);
                                    Recording_PointDict[Maro.f215t216].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f215t216].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f215t216].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f215t216].alltimetype;

                                    avg.dataList = Recording_PointDict[Maro.f215t216].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f215t216] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;

                        }
                    case 217:
                        {
                            Recording_PointDicttest2[Maro.f217t218] = true;
                            Recording_PointDicttest2[Maro.f213t217] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 218:
                        {
                            //!
                            if (Recording_PointDicttest2[Maro.f213t214] && Recording_PointDicttest2[Maro.f213t217])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f213t214))
                                {
                                    avg217helper.Avgtime = item.Startdate;
                                    avg217helper.alltimetype += avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f213t214, avg217helper);
                                    Recording_PointDict[Maro.f204t205].dataList.Add(avg217helper.alltimetype);
                                    Recording_PointDict[Maro.f213t214].totalCount++;

                                    AvgFinal.Add(avg217helper);


                                }
                                else
                                {
                                    avg217helper.Avgtime = item.Startdate;

                                    avg217helper.totalCount = Recording_PointDict[Maro.f213t214].totalCount + 1;
                                    avg217helper.alltimetype = Recording_PointDict[Maro.f213t214].alltimetype;

                                    avg217helper.dataList = Recording_PointDict[Maro.f213t214].dataList;
                                    avg217helper.dataList.Add(avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks);

                                    avg217helper.alltimetype += avg217helper.Avgtime.Ticks - avg217helper.Startdate.Ticks;
                                    Recording_PointDict[Maro.f213t214] = avg217helper;

                                    AvgFinal.Add(avg217helper);

                                }

                            }

                            if (Recording_PointDicttest2[Maro.f217t218])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f217t218))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f217t218, avg);
                                    Recording_PointDict[Maro.f217t218].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f217t218].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f217t218].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f217t218].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f217t218].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f217t218] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro.f218t219] = true;
                            break;

                        }
                    case 219:
                        {

                            if (Recording_PointDicttest2[Maro.f218t219])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro.f218t219))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro.f218t219, avg);
                                    Recording_PointDict[Maro.f218t219].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro.f218t219].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro.f218t219].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro.f218t219].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro.f218t219].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro.f218t219] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            //avg = AddItem(item);
                            //Recording_PointDicttest2[Maro.f218t219] = true;
                            break;

                        }
                    #endregion
                    #region MaroTatro
                    case 301:
                        {
                            Recording_PointDicttest2[Maro_Tarto.f301t302] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 302:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f301t302])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f301t302))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f301t302, avg);
                                    Recording_PointDict[Maro_Tarto.f301t302].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f301t302].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f301t302].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f301t302].alltimetype;

                                    avg.dataList = Recording_PointDict[Maro_Tarto.f301t302].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);

                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f301t302] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f302t303] = true;
                            break;


                        }
                    case 303:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f302t303])
                            {
                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f302t303))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f302t303, avg);
                                    Recording_PointDict[Maro_Tarto.f302t303].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f302t303].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f302t303].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f302t303].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f302t303].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f302t303] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f303t304] = true;
                            break;
                        }
                    case 304:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f303t304])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f303t304))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f303t304, avg);
                                    Recording_PointDict[Maro_Tarto.f303t304].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f303t304].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f303t304].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f303t304].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f303t304].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f303t304] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f304t305] = true;
                            break;
                        }
                    case 305:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f304t305])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f304t305))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f304t305, avg);
                                    Recording_PointDict[Maro_Tarto.f304t305].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f304t305].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f304t305].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f304t305].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f304t305].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f304t305] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f305t306] = true;
                            break;
                        }
                    case 306:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f305t306])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f305t306))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f305t306, avg);
                                    Recording_PointDict[Maro_Tarto.f305t306].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f305t306].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f305t306].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f305t306].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f305t306].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f305t306] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f306t307] = true;
                            break;
                        }
                    case 307:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f306t307])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f306t307))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f306t307, avg);
                                    Recording_PointDict[Maro_Tarto.f306t307].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f306t307].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f306t307].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f306t307].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f306t307].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f306t307] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f307t308] = true;
                            break;
                        }
                    case 308:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f307t308])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f307t308))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f307t308, avg);
                                    Recording_PointDict[Maro_Tarto.f307t308].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f307t308].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f307t308].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f307t308].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f307t308].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f307t308] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f308t309] = true;
                            break;
                        }
                    case 309:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f308t309])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f308t309))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f308t309, avg);
                                    Recording_PointDict[Maro_Tarto.f308t309].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f308t309].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f308t309].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f308t309].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f308t309].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f308t309] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Maro_Tarto.f309t310] = true;
                            break;
                        }
                    case 310:
                        {
                            if (Recording_PointDicttest2[Maro_Tarto.f309t310])
                            {

                                if (!Recording_PointDict.ContainsKey(Maro_Tarto.f309t310))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Maro_Tarto.f309t310, avg);
                                    Recording_PointDict[Maro_Tarto.f309t310].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Maro_Tarto.f309t310].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Maro_Tarto.f309t310].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Maro_Tarto.f309t310].alltimetype;
                                    avg.dataList = Recording_PointDict[Maro_Tarto.f309t310].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Maro_Tarto.f309t310] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }

                    #endregion
                    #region Zomi_tarto
                    case 401:
                        {
                            Recording_PointDicttest2[Zomi_Tarto.f401t402] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 402:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f401t402])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f401t402))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f401t402, avg);
                                    Recording_PointDict[Zomi_Tarto.f401t402].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f401t402].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f401t402].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f401t402].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f401t402].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f401t402] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f402t403] = true;
                            break;
                        }
                    case 403:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f402t403])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f402t403))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f402t403, avg);
                                    Recording_PointDict[Zomi_Tarto.f402t403].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f402t403].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f402t403].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f402t403].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f402t403].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f402t403] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f403t404] = true;
                            break;
                        }
                    case 404:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f403t404])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f403t404))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f403t404, avg);
                                    Recording_PointDict[Zomi_Tarto.f403t404].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f403t404].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f403t404].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f403t404].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f403t404].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f403t404] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f404t405] = true;
                            break;
                        }
                    case 405:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f404t405])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f404t405))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f404t405, avg);
                                    Recording_PointDict[Zomi_Tarto.f404t405].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f404t405].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f404t405].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f404t405].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f404t405].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f404t405] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f405t406] = true;
                            break;
                        }
                    case 406:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f405t406])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f405t406))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f405t406, avg);
                                    Recording_PointDict[Zomi_Tarto.f405t406].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f405t406].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f405t406].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f405t406].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f405t406].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f405t406] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f406t407] = true;
                            break;
                        }
                    case 407:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f406t407])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f406t407))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f406t407, avg);
                                    Recording_PointDict[Zomi_Tarto.f406t407].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f406t407].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f406t407].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f406t407].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f406t407].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f406t407] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Zomi_Tarto.f407t408] = true;
                            break;
                        }
                    case 408:
                        {
                            if (Recording_PointDicttest2[Zomi_Tarto.f407t408])
                            {

                                if (!Recording_PointDict.ContainsKey(Zomi_Tarto.f407t408))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Zomi_Tarto.f407t408, avg);
                                    Recording_PointDict[Zomi_Tarto.f407t408].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Zomi_Tarto.f407t408].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Zomi_Tarto.f407t408].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Zomi_Tarto.f407t408].alltimetype;
                                    avg.dataList = Recording_PointDict[Zomi_Tarto.f407t408].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Zomi_Tarto.f407t408] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    #endregion
                    #region Deburring
                    case 501:
                        {
                            Recording_PointDicttest2[Deburring.f501t502] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 502:
                        {
                            Recording_PointDicttest2[Deburring.f501t503] = true;
                            break;
                        }
                    case 503:
                        {
                            if (Recording_PointDicttest2[Deburring.f501t502] && Recording_PointDicttest2[Deburring.f501t503])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f501t502))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f501t502, avg);
                                    Recording_PointDict[Deburring.f501t502].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f501t502].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f501t502].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f501t502].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f501t502].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f501t502] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;


                        }
                    case 504:
                        {
                            Recording_PointDicttest2[Deburring.f504t505] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 505:
                        {
                            if (Recording_PointDicttest2[Deburring.f504t505])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f504t505))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f504t505, avg);
                                    Recording_PointDict[Deburring.f504t505].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f504t505].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f504t505].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f504t505].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f504t505].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f504t505] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 506:
                        {
                            Recording_PointDicttest2[Deburring.f506t507] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 507:
                        {
                            if (Recording_PointDicttest2[Deburring.f506t507])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f506t507))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f506t507, avg);
                                    Recording_PointDict[Deburring.f506t507].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f506t507].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f506t507].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f506t507].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f506t507].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f506t507] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 508:
                        {
                            Recording_PointDicttest2[Deburring.f508t509] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 509:
                        {
                            if (Recording_PointDicttest2[Deburring.f508t509])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f508t509))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f508t509, avg);
                                    Recording_PointDict[Deburring.f508t509].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f508t509].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f508t509].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f508t509].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f508t509].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f508t509] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 510:
                        {
                            Recording_PointDicttest2[Deburring.f510t511] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 511:
                        {
                            if (Recording_PointDicttest2[Deburring.f510t511])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f510t511))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f510t511, avg);
                                    Recording_PointDict[Deburring.f510t511].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f510t511].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f510t511].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f510t511].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f510t511].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f510t511] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    case 512:
                        {
                            Recording_PointDicttest2[Deburring.f512t513] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 513:
                        {
                            if (Recording_PointDicttest2[Deburring.f512t513])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f512t513))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f512t513, avg);
                                    Recording_PointDict[Deburring.f512t513].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f512t513].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f512t513].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f512t513].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f512t513].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f512t513] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f513t514] = true;
                            break;

                        }
                    case 514:
                        {
                            if (Recording_PointDicttest2[Deburring.f513t514])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f513t514))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f513t514, avg);
                                    Recording_PointDict[Deburring.f513t514].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f513t514].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f513t514].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f513t514].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f513t514].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f513t514] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f514t515] = true;
                            break;

                        }
                    case 515:
                        {
                            if (Recording_PointDicttest2[Deburring.f514t515])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f514t515))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f514t515, avg);
                                    Recording_PointDict[Deburring.f514t515].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f514t515].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f514t515].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f514t515].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f514t515].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f514t515] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f515t516] = true;
                            break;

                        }
                    case 516:
                        {
                            if (Recording_PointDicttest2[Deburring.f515t516])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f515t516))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f515t516, avg);
                                    Recording_PointDict[Deburring.f515t516].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f515t516].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f515t516].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f515t516].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f515t516].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f515t516] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f516t517] = true;
                            break;

                        }
                    case 517:
                        {
                            if (Recording_PointDicttest2[Deburring.f516t517])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f516t517))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f516t517, avg);
                                    Recording_PointDict[Deburring.f516t517].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f516t517].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f516t517].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f516t517].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f516t517].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f516t517] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            avg = AddItem(item);
                            Recording_PointDicttest2[Deburring.f517t518] = true;
                            break;

                        }
                    case 518:
                        {
                            if (Recording_PointDicttest2[Deburring.f517t518])
                            {
                                if (!Recording_PointDict.ContainsKey(Deburring.f517t518))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(Deburring.f517t518, avg);
                                    Recording_PointDict[Deburring.f517t518].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[Deburring.f517t518].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[Deburring.f517t518].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[Deburring.f517t518].alltimetype;
                                    avg.dataList = Recording_PointDict[Deburring.f517t518].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[Deburring.f517t518] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                    #endregion
                    #region EndPoint
                    case 601:
                        {
                            Recording_PointDicttest2[EndPoint.f601t602] = true;
                            avg = AddItem(item);
                            break;
                        }
                    case 602:
                        {
                            if (Recording_PointDicttest2[EndPoint.f601t602])
                            {

                                if (!Recording_PointDict.ContainsKey(EndPoint.f601t602))
                                {
                                    avg.Avgtime = item.Startdate;
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict.Add(EndPoint.f601t602, avg);
                                    Recording_PointDict[EndPoint.f601t602].dataList.Add(avg.alltimetype);
                                    Recording_PointDict[EndPoint.f601t602].totalCount++;

                                    AvgFinal.Add(avg);


                                }
                                else
                                {
                                    avg.Avgtime = item.Startdate;

                                    avg.totalCount = Recording_PointDict[EndPoint.f601t602].totalCount + 1;
                                    avg.alltimetype = Recording_PointDict[EndPoint.f601t602].alltimetype;
                                    avg.dataList = Recording_PointDict[EndPoint.f601t602].dataList;
                                    avg.dataList.Add(avg.Avgtime.Ticks - avg.Startdate.Ticks);
                                    avg.alltimetype += avg.Avgtime.Ticks - avg.Startdate.Ticks;
                                    Recording_PointDict[EndPoint.f601t602] = avg;

                                    AvgFinal.Add(avg);

                                }

                            }
                            break;
                        }
                        #endregion
                }

            }
            return Recording_PointDict;
        }

        public Task<Dictionary<Enum, AvgCalc>> AvgFinalDictionaryThirdAsync()
        {
            Task.WaitAll();
            return Task.Run(() =>
            {
                return AvgDictionaryThirdAsync().Result;
            });
        }

        /*private*/
        private async Task<List<AvgCalc>> JumpOutData()
        {
            var FirstData = await AvgFinalDictionaryAsync();
            var SecondtData = await AvgFinalDictionarySecondAsync();
            //List<AvgCalc> dataList = FirstData.Values.ToList();
            List<Data> Datasetone = await AvgwithoutavgAsync();
            List<AvgCalc> JumpedOutList = new();
            List<AvgCalc> JumpedOutList2 = new();
            List<AvgCalc> OutList = new();
            List<double> IDStrore = new();

            foreach (var dic_key in FirstData)
            {
                if (!CloseEnoughForMe(dic_key.Value.TrimAvg, dic_key.Value.TimeBtwValues, 1)) //----
                {
                    JumpedOutList.Add(dic_key.Value);
                    ;
                }
            }

            ;
            foreach (var item in AvgFinalFirst)
            {
                foreach (var dickey in JumpedOutList)
                {
                    if (item.EventID == dickey.EventID)
                    {
                        if (dickey.IdList[item.Number] != dickey.TrimAvg)
                        {
                            OutList.Add(item);
                            //OutList.Add(new AvgCalc() { Id = item.Id, EventID = item.EventID, Number = item.Number, totaltime = dickey.dataList[index], Type = item.Type });
                            ;
                        }
                    }
                }
            }


            foreach (var dic_key in SecondtData)
            {
                if (!CloseEnoughForMe(dic_key.Value.TrimAvg, dic_key.Value.TimeBtwValues, 1)) //----
                {
                    JumpedOutList2.Add(dic_key.Value);
                    ;
                }
            }

            ;
            foreach (var item in AvgFinalSecond)
            {
                foreach (var dickey in JumpedOutList2)
                {
                    if (item.EventID == dickey.EventID)
                    {
                        if (dickey.IdList[item.Number] != dickey.TrimAvg)
                        {
                            OutList.Add(item);

                        }
                    }
                }
            }
            //foreach (var item in AvgFina2)
            //{
            //    foreach (var dic_key in FirstData)
            //    {
            //        if (item.EventID == dic_key.Value.EventID)
            //        {
            //            //for (int i = 0; i < item.totalCount; i++)
            //            //{
            //                if (dic_key.Value.TrimAvg != item.dataList[item.Number])
            //                {
            //                    JumpedOutList.Add(item);
            //                    ;
            //                }
            //            //}

            //        }
            //    }

            //}
            //HashSet<int> eventIds = new HashSet<int>(FirstData.Values.Select(x => x.EventID));

            //foreach (var item in AvgFina2)
            //{
            //    // Check if the EventID exists in the HashSet
            //    if (eventIds.Contains(item.EventID))
            //    {
            //        // Get the corresponding dictionary entry
            //        var dic_key = FirstData.Values.Select(x => x);
            //        ;
            //        //Check the condition
            //        //if (dic_key != item.dataList[item.Number])
            //        //{
            //        //    JumpedOutList.Add(item);
            //        //}
            //    }
            //}
            //    foreach (var item in Datasetone)
            //{
            //    foreach (var dic_key in FirstData)
            //    {
            //        if (item.EventID == dic_key.Value.EventID)
            //        {
            //            if (item.Startdate != DateTime.MinValue && item.Startdate != DateTime.MaxValue && item.Startdate != DateTime.FromOADate(0) && item.Startdate.TimeOfDay.TotalSeconds != dic_key.Value.TrimAvg)
            //            {
            //                JumpedOutList.Add(AddItem(item));
            //            }
            //        }

            //    }
            //}
            //------------------------------------------------------------
            return OutList;


            //foreach (var item in FirstData)
            //{
            //    JumpedOutList = item.Value.SkipData.ToList;

            //}
            //for (int i = 0; i < AvgFina2.Count; i++)
            //{
            //    foreach (var dic_key in FirstData)
            //    {
            //        if (AvgFina2[i].EventID == dic_key.Value.EventID)
            //        {
            //            if (dic_key.Value.TrimAvg != AvgFina2[i].dataList[i])
            //            {
            //                JumpedOutList.Add(AvgFina2[i]);
            //                ;
            //            }
            //        }
            //    }
            //}
            //for (int i = 0; i < AvgFina2.Count; i++)
            //{
            //    if (AvgFina2[i].TrimAvg != AvgFina2[i].TimeBtwValues)
            //    {
            //        JumpedOutList.Add(AvgFina2[i]);
            //        ;
            //    }
            //}

            //    foreach (var item in AvgFina2)
            //    {
            //        foreach (var dic_key in FirstData)
            //        {
            //            if (item.EventID == dic_key.Value.EventID)
            //            {
            //            for (int i = 0; i < item.totalCount; i++)
            //            {
            //                if (dic_key.Value.TrimAvg != item.dataList[i])
            //                {
            //                    JumpedOutList.Add(item);
            //                    ;
            //                }
            //            }

            //        }
            //    }

            //}

            ////foreach (var item in AvgFina2)
            ////{
            ////    if (item.TrimAvg != item.TimeBtwValues)
            ////    {
            ////        JumpedOutList.Add(item);
            ////        ;
            ////    }
            ////    //    foreach (var dic_key in FirstData)
            ////    //{
            ////    //    if (item.EventID == dic_key.Value.EventID)
            ////    //    {
            ////    //        if (dic_key.Value.TrimAvg != item.dataList[item.totalCount])
            ////    //        {
            ////    //            JumpedOutList.Add(item);
            ////    //            ;
            ////    //        }
            ////    //    }
            ////    //}

            ////}

            //return JumpedOutList;
        }

        public async Task<Task<List<AvgCalc>>> JumpOutDataAsync()
        {
            return Task.Run(() =>
            {
                return JumpOutData();
            });
        }


        private async Task<List<AvgCalc>> AvglistAsync()
        {

            List<Data> AvgData = await AvgwithoutavgAsync();
            List<AvgCalc> AvgFinal = new();
            AvgCalc avg = new();
            AvgCalc avg217helper = new();

            var Recording_PointDict = new Dictionary<Enum, AvgCalc>();
            var Recording_PointDicttest2 = new Dictionary<Enum, bool>();


            //avg = Recording_PointDict[Recording_Point.f101t102];
            //var localDate2 = DateTime.FromBinary((long)Recording_PointDict[Recording_Point.f101t102].TimeBtwValues);
            ;
            return AvgFinal;
            
            #region lista
            //for (int i = 0; i < AvgData.Count-1; i++)
            //{
            //    bool a = AvgData[i].EventID.IsBetween(101, 115);
            //    bool b = AvgData[i].EventID.IsBetween(201, 219);
            //    bool c = AvgData[i].EventID.IsBetween(301, 310);
            //    bool d = AvgData[i].EventID.IsBetween(401, 408);
            //    bool e = AvgData[i].EventID.IsBetween(501, 518);


            //    if (AvgData[i].EventID == 602)
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        if (a)
            //        {
            //            long elapsedTicks = AvgData[i+1].Startdate.Ticks - AvgData[i].Startdate.Ticks;
            //            var localDate2 = DateTime.FromBinary(elapsedTicks);
            //            helper.Add(elapsedTicks);
            //            AvgFinal.Add(new AvgCalc { Id = AvgData[i].Id, Number = AvgData[i].Number, EventID = AvgData[i].EventID + "-" + AvgData[i+1].EventID, Startdate = AvgData[i].Startdate, Type = AvgData[i].Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //            if (AvgData[i].EventID == 115)
            //            {
            //                helper.Clear();
            //            }
            //        }
            //        if (b)
            //        {
            //            long elapsedTicks = AvgData[i + 1].Startdate.Ticks - AvgData[i].Startdate.Ticks;
            //            var localDate2 = DateTime.FromBinary(elapsedTicks);
            //            helper.Add(elapsedTicks);
            //            AvgFinal.Add(new AvgCalc { Id = AvgData[i].Id, Number = AvgData[i].Number, EventID = AvgData[i].EventID + "-" + AvgData[i + 1].EventID, Startdate = AvgData[i].Startdate, Type = AvgData[i].Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //            if (AvgData[i].EventID == 219)
            //            {
            //                helper.Clear();
            //            }
            //        }
            //        if (c)
            //        {
            //            long elapsedTicks = AvgData[i + 1].Startdate.Ticks - AvgData[i].Startdate.Ticks;
            //            var localDate2 = DateTime.FromBinary(elapsedTicks);
            //            helper.Add(elapsedTicks);
            //            AvgFinal.Add(new AvgCalc { Id = AvgData[i].Id, Number = AvgData[i].Number, EventID = AvgData[i].EventID + "-" + AvgData[i + 1].EventID, Startdate = AvgData[i].Startdate, Type = AvgData[i].Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //            if (AvgData[i].EventID == 310)
            //            {
            //                helper.Clear();
            //            }
            //        }

            //        if (d)
            //        {
            //            long elapsedTicks = AvgData[i + 1].Startdate.Ticks - AvgData[i].Startdate.Ticks;
            //            var localDate2 = DateTime.FromBinary(elapsedTicks);
            //            helper.Add(elapsedTicks);
            //            AvgFinal.Add(new AvgCalc { Id = AvgData[i].Id, Number = AvgData[i].Number, EventID = AvgData[i].EventID + "-" + AvgData[i + 1].EventID, Startdate = AvgData[i].Startdate, Type = AvgData[i].Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //            if (AvgData[i].EventID == 408)
            //            {
            //                helper.Clear();
            //            }
            //        }

            //        if (e)
            //        {
            //            long elapsedTicks = AvgData[i + 1].Startdate.Ticks - AvgData[i].Startdate.Ticks;
            //            var localDate2 = DateTime.FromBinary(elapsedTicks);
            //            helper.Add(elapsedTicks);
            //            AvgFinal.Add(new AvgCalc { Id = AvgData[i].Id, Number = AvgData[i].Number, EventID = AvgData[i].EventID + "-" + AvgData[i + 1].EventID, Startdate = AvgData[i].Startdate, Type = AvgData[i].Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //            if (AvgData[i].EventID == 518)
            //            {
            //                helper.Clear();
            //            }
            //        }
            //    }


            //}
            #endregion

            #region foreeach lista
            //         foreach (var item in AvgData) 
            //{
            //             bool a = item.EventID.IsBetween(101, 115);
            //             bool b = item.EventID.IsBetween(201, 219);
            //             bool c = item.EventID.IsBetween(301, 310);
            //             bool d = item.EventID.IsBetween(401, 408);
            //             bool e = item.EventID.IsBetween(501, 518);

            //             if (item.EventID == 602)
            //             {
            //                 continue;
            //             }
            //             else
            //             {
            //                 if (a)
            //                 {
            //                     var nextItem = AvgData[AvgData.IndexOf(item) + 1];
            //                     long elapsedTicks = nextItem.Startdate.Ticks - item.Startdate.Ticks;
            //                     var localDate2 = DateTime.FromBinary(elapsedTicks);
            //                     helper.Add(elapsedTicks);
            //                     AvgFinal.Add(new AvgCalc { Id = item.Id, Number = item.Number, EventID = item.EventID + "-" + nextItem.EventID, Startdate = item.Startdate, Type = item.Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //                     if (item.EventID == 115)
            //                     {
            //                         helper.Clear();
            //                     }
            //                 }
            //                 if (b)
            //                 {
            //                     var nextItem = AvgData[AvgData.IndexOf(item) + 1];
            //                     long elapsedTicks = nextItem.Startdate.Ticks - item.Startdate.Ticks;
            //                     var localDate2 = DateTime.FromBinary(elapsedTicks);
            //                     helper.Add(elapsedTicks);
            //                     AvgFinal.Add(new AvgCalc { Id = item.Id, Number = item.Number, EventID = item.EventID + "-" + nextItem.EventID, Startdate = item.Startdate, Type = item.Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //                     if (item.EventID == 219)
            //                     {
            //                         helper.Clear();
            //                     }
            //                 }
            //                 if (c)
            //                 {
            //                     var nextItem = AvgData[AvgData.IndexOf(item) + 1];
            //                     long elapsedTicks = nextItem.Startdate.Ticks - item.Startdate.Ticks;
            //                     var localDate2 = DateTime.FromBinary(elapsedTicks);
            //                     helper.Add(elapsedTicks);
            //                     AvgFinal.Add(new AvgCalc { Id = item.Id, Number = item.Number, EventID = item.EventID + "-" + nextItem.EventID, Startdate = item.Startdate, Type = item.Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //                     if (item.EventID == 310)
            //                     {
            //                         helper.Clear();
            //                     }
            //                 }

            //                 if (d)
            //                 {
            //                     var nextItem = AvgData[AvgData.IndexOf(item) + 1];
            //                     long elapsedTicks = nextItem.Startdate.Ticks - item.Startdate.Ticks;
            //                     var localDate2 = DateTime.FromBinary(elapsedTicks);
            //                     helper.Add(elapsedTicks);
            //                     AvgFinal.Add(new AvgCalc { Id = item.Id, Number = item.Number, EventID = item.EventID + "-" + nextItem.EventID, Startdate = item.Startdate, Type = item.Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //                     if (item.EventID == 408)
            //                     {
            //                         helper.Clear();
            //                     }
            //                 }

            //                 if (e)
            //                 {
            //                     var nextItem = AvgData[AvgData.IndexOf(item) + 1];
            //                     long elapsedTicks = nextItem.Startdate.Ticks - item.Startdate.Ticks;
            //                     var localDate2 = DateTime.FromBinary(elapsedTicks);
            //                     helper.Add(elapsedTicks);
            //                     AvgFinal.Add(new AvgCalc { Id = item.Id, Number = item.Number, EventID = item.EventID + "-" + nextItem.EventID, Startdate = item.Startdate, Type = item.Type, Avgtime = localDate2, Areaavg = DateTime.FromBinary(AveragePart(helper)) });
            //                     if (item.EventID == 518)
            //                     {
            //                         helper.Clear();
            //                     }
            //                 }
            //             }       
            //         }
            #endregion


        }

            public Task<List<AvgCalc>> AvgFinalAsync()
            {
                return Task.Run(() =>
                {
                    return AvglistAsync();
                });
            }

        static bool CloseEnoughForMe(double value1, double value2, double acceptableDifference)
        {
           //double ok =  Math.Round(value1 / 10000000);
           // double okok = Math.Round(value2 / 10000000);
            return Math.Abs(Math.Round(value1 % 10000000) - Math.Round(value2 % 10000000)) <= acceptableDifference;
        }
        public AvgCalc AddItem(Data item)          
        {
            return new AvgCalc() { Id = item.Id, EventID = item.EventID, Number = item.Number, Startdate = item.Startdate, Type = item.Type };
        }
        //public void AddValue(Dictionary<Recording_Point, AvgCalc> Recording_PointDict, Recording_Point dicKey, AvgCalc Value)
        //{
        //    if (Recording_PointDict.ContainsKey(dicKey))
        //    {
        //        Recording_PointDict[dicKey] = Value;
        //    }
        //    else
        //    {
        //        Recording_PointDict.Add(dicKey, Value);
        //    }
        //}
        //static long AveragePart(List<long> list)
        //    {
        //        long sum = 0;
        //        if (list.Any())
        //            foreach (long number in list)
        //                sum += number;
        //        //!
        //    return sum / list.Count;
        //    }
        //}
        //static bool NextIsExist()
        //{ 

        //}

    }
}
