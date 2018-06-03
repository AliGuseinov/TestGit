using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
namespace HomeWork
{
    class Station
    {
        //наименование
        public string Name { get; private set; }

        public Station(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return string.Format("[Station: Name={0}]", Name);
        }
    }

    class Route
    {
        //станции
        public List<Station> Stations { get; set; }

        //время начала движения
        public DateTime TimeStart { get; private set; }
        //время конца движения
        public DateTime TimeEnd { get; private set; }
        //интервал движения
        public TimeSpan Interval { get; private set; }

        public override string ToString()
        {
            return string.Format("[Route: Stations={0}, TimeStart={1}, TimeEnd={2}, Interval={3}]", Stations, TimeStart, TimeEnd, Interval);
        }
        //StationsGraph stationGraph;

        public Route(DateTime timeStart, DateTime timeEnd, TimeSpan interval)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Interval = interval;

            Stations = new List<Station>();
        }

        public Route(DateTime timeStart, DateTime timeEnd, TimeSpan interval, List<Station> stations)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Interval = interval;

            Stations = stations;

            //stationGraph = new StationsGraph();
        }
    }

    class Schedule
    {
        //Маршрут
        public Route ScheduleRoute { get; private set; }
        //Время
        public DateTime ScheduleTime { get; private set; }

        public Schedule(Route scheduleRoute, DateTime scheduleTime)
        {
            ScheduleRoute = scheduleRoute;
            ScheduleTime = scheduleTime;
        }

        public override string ToString()
        {
            return string.Format("[Schedule: ScheduleRoute={0}, ScheduleTime={1}]", ScheduleRoute, ScheduleTime);
        }

        static public List<Schedule> Сompute(List<Route> listOfRoutes,
                                       Station currentStation,
                                       DateTime currentTime)
        {
            List<Route> routesWithCurrentStation = listOfRoutes.FindAll(
                new Predicate<Route>((route) => route.Stations.Contains(currentStation))
            );

            //для выбранных маршрутов найти ближайшее время отправления
            List<Schedule> schedules = new List<Schedule>();
            int i = 0;
            while (i < routesWithCurrentStation.Count)
            {
                Route currentRoute = routesWithCurrentStation[i];
                List<Station> routeStaions = currentRoute.Stations;

                int stationNum = routeStaions.IndexOf(currentStation);
                DateTime firstArriveTime = currentRoute.TimeStart + stationNum * currentRoute.Interval;
                schedules.Add(new Schedule(currentRoute, FindNearestTime(currentTime, currentRoute.Interval, firstArriveTime)));
                i++;
            }

            return schedules;

        }

        static private DateTime FindNearestTime(DateTime currentTime, TimeSpan interval, DateTime TimeStart)
        {
            DateTime departureTime = TimeStart;
            while (departureTime < currentTime)
            {
                departureTime = departureTime + interval;
                departureTime.ToString();
            }
            return departureTime;

        }

    }

    //class StationsGraph
    //{
    //    byte[,] matrix;

    //    public StationsGraph(List<Station> allStations, List<Station> selectedStations){
    //        matrix = new byte[allStations.Count, allStations.Count];
    //        int i = 0;
    //        int j = 0;

    //        while(i<matrix.GetLength(0)){
    //            j = 0;
    //            while(j<matrix.GetLength(1))
    //            {
    //                matrix[i, j] = (byte)(
    //                    (
    //                        i <  (allStations.Count - 1) &&
    //                        selectedStations.IndexOf(allStations[i]) != -1 &&
    //                        selectedStations.IndexOf(allStations[i + 1]) != -1
    //                    ) ? 1 : 0
    //                );
    //            }
    //        }
    //    }
    //}

    //class ScheduleSearcher
    //{

    //}

    class Program
    {
        class IOException : Exception
        {
            public IOException(string Message) : base(Message) { }
        }
        class FileFormatException : Exception
        {
            public FileFormatException(string Message) : base(Message) { }
        }


        public static void FileReader(out List<Station> ListOfStations, out List<Route> ListOfRoutes)
        {
            StreamReader dataReader;
            int i;
            try
            {
                dataReader = new StreamReader("/Users/aliguseinov/data.txt");
            }
            catch (System.IO.IOException e)
            {
                throw new IOException(e.Message);
            }

            string StationTitle = dataReader.ReadLine();
            if (StationTitle != "Stations")
            {
                throw new FileFormatException("В файле нет станций");
            }

            string StationText = dataReader.ReadLine();
            if ((StationText == null) | (StationText == ""))
            {
                throw new FileFormatException("В файле нет станций");
            }

            string RoutesTitle = dataReader.ReadLine();
            if (RoutesTitle != "Routes")
            {
                throw new FileFormatException("В файле нет маршрутов");
            }

            string RouteLine = "";
            if (RouteLine == null)
            {
                throw new FileFormatException("В файле нет маршрутов");
            }
            List<string> RoutesText = new List<string>();
            while (RouteLine != null)
            {
                RouteLine = dataReader.ReadLine();
                if (RouteLine != null)
                    RoutesText.Add(RouteLine);
            }
            dataReader.Close();

            string[] StationNames = StationText.Split(",");
            int m = 0;
            while (m < StationNames.Length)
            {
                if (StationNames[m] == "")
                {
                    throw new FileFormatException("В файле нет названий станций");
                }
                m++;
            }
            ListOfStations = new List<Station>();
            i = 0;
            while (i < StationNames.Length)
            {
                ListOfStations.Add(new Station(StationNames[i]));
                i++;
            }

            ListOfRoutes = new List<Route>();
            i = 0;
            while (i < RoutesText.Count)
            {
                string[] RouteParts = RoutesText[i].Split(";");

                Route route = new Route(
                    DateTime.Parse(RouteParts[0]),
                    DateTime.Parse(RouteParts[1]),
                    TimeSpan.Parse(RouteParts[2])
                );


                string[] RouteStationsText = RouteParts[3].Split(",");
                List<Station> RouteStations = new List<Station>();
                int j = 0;
                while (j < RouteStationsText.Length)
                {
                    RouteStations.Add(
                        ListOfStations.Find(
                            new Predicate<Station>((station) => station.Name == RouteStationsText[j])
                        )
                    );

                    j++;
                }
                //RouteStations.ToString();
                route.Stations = RouteStations;

                ListOfRoutes.Add(route);
                i++;
            }
           
        }
        //public static void FileWriter(out List<Station> ListOfStations, out List<Route> ListOfRoutes){
        //StreamWriter dataWriter;

        //dataWriter = new StreamWriter("/Users/aliguseinov/fileExample/data.txt");
        //string StationTitle = dataWriter.WriteLine();

        //string StationText = dataWriter.WriteLine();

        //string RoutesTitle = dataWriter.WriteLine();





        static void Main(string[] args)
        {
            List<Station> ListofStations = new List<Station>();
            List<Route> ListofRoutes = new List<Route>();
            try
            {
                FileReader(out ListofStations, out ListofRoutes);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Произошла ошибка ввода и вывода:" + ex.Message);
            }
            catch (FileFormatException ex)
            {
                Console.WriteLine("Неверный формат файла:" + ex.Message);
            }

            Station currentStation = ListofStations[0];
            DateTime currentTime = new DateTime(2018, 01, 01, 12, 09, 00);

            List<Schedule> schedules = Schedule.Сompute(ListofRoutes, currentStation, currentTime);
            int i = 0;
            while(i<schedules.Count){
                Console.WriteLine(schedules[i].ToString());
                i++;
            }
            ;
            Console.WriteLine(schedules);
            string[] lines = new string[schedules.Count];

            i = 0;
            while (i < schedules.Count)
            {
                lines[i] = schedules[i].ToString();
                i++;
            };

            System.IO.File.WriteAllLines("/Users/aliguseinov/fileExample/file1.txt", lines);

        }

            //вывести результаты
        //string value = { "00:10" };
        //    foreach (string value in values)
        //    {
        //        try
        //        {
        //            TimeSpan interval = TimeSpan.Parse(value);
        //Console.WriteLine("{0} --> {1}", value, interval);
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("{0}: Bad Format", value);
            //    }
            //    catch (OverflowException)
            //    {
            //        Console.WriteLine("{0}: Overflow", value);
            //    }

            //}

        }

}

