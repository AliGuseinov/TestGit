using System;
using System.Collections.Generic;

namespace HomeWork
{
    class Station
    {
        //наименование
        public string Name { get; private set; }

        public Station(string name){
            Name = name;
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

        public Route(DateTime timeStart, DateTime timeEnd, TimeSpan interval){
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Interval = interval;

            Stations = new List<Station>();
        }

        public Route(DateTime timeStart, DateTime timeEnd, TimeSpan interval, List<Station> stations){
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Interval = interval;

            Stations = stations;
        }
    }

    //class StationsGraph
    //{
        
    //}

    //class ScheduleSearcher
    //{
        
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station("белорусская");
            List<Station> stations = new List<Station>();
            stations.Add(station);

            Route route1 = new Route(
                new DateTime(2018, 3, 12, 8, 0, 0),
                new DateTime(2018, 3, 12, 23, 0, 0),
                new TimeSpan(0, 10, 0)
            );
            route1.Stations.Add(station);

            Route route2 = new Route(
                new DateTime(2018, 3, 12, 8, 0, 0),
                new DateTime(2018, 3, 12, 23, 0, 0),
                new TimeSpan(0, 10, 0),
                stations
            );

            Console.WriteLine(station);
            Console.WriteLine(route1);
        }
    }
}
