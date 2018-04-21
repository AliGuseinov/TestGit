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

        StationsGraph stationGraph;

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

            //stationGraph = new StationsGraph();
        }
    }

    class StationsGraph
    {
        byte[,] matrix;

        public StationsGraph(List<Station> allStations, List<Station> selectedStations){
            matrix = new byte[allStations.Count, allStations.Count];
            int i = 0;
            int j = 0;

            while(i<matrix.GetLength(0)){
                j = 0;
                while(j<matrix.GetLength(1))
                {
                    matrix[i, j] = (byte)(
                        (
                            i <  (allStations.Count - 1) &&
                            selectedStations.IndexOf(allStations[i]) != -1 &&
                            selectedStations.IndexOf(allStations[i + 1]) != -1
                        ) ? 1 : 0
                    );
                }
            }
        }
    }

    //class ScheduleSearcher
    //{
        
    //}

    class Program
    {
        class IOException: Exception{
            public IOException(string Message) : base(Message) { }
        }
        class FileFormatException: Exception{
            public FileFormatException(string Message) : base(Message){}
        }
        public static void FileReader(out List<Station> ListOfStations, out List<Route> ListOfRoutes )
        {
            StreamReader dataReader;
            int i;
            try
            {
                dataReader = new StreamReader("/Users/aliguseinov/data.txt");
            }
            catch(System.IO.IOException e) {
                throw new IOException(e.Message);
            }

            string StationTitle = dataReader.ReadLine();
            if(StationTitle != "Stations"){
                throw new FileFormatException("В файле нет станций");
            }

            string StationText = dataReader.ReadLine();
            if((StationText == null)| (StationText=="")){
                throw new FileFormatException("В файле нет станций");
            }

            string RoutesTitle = dataReader.ReadLine();
            if(RoutesTitle != "Routes"){
                throw new FileFormatException("В файле нет маршрутов");
            }

            string RouteLine = "";
            if (RouteLine==null){
                throw new FileFormatException("В файле нет маршрутов");
            }
            ArrayList RoutesText = new ArrayList();
            while (RouteLine != null)
            {
                RouteLine = dataReader.ReadLine();
                if (RouteLine != null)
                    RoutesText.Add(RouteLine);
            }
            dataReader.Close();

            string[] StationNames = StationText.Split(",");
            int m = 0;
            while(m<StationNames.Length){
                if(StationNames[m]!= "Names"){
                    throw new FileFormatException("В файле нет названий станций");
                }
            }
            ListOfStations = new List<Station>();
            i = 0;
            while(i<StationNames.Length) {
                ListOfStations.Add(new Station(StationNames[i]));
                i++;
            }

            ListOfRoutes = new List<Route>();
        }

        static void Main(string[] args)
        {
            List<Station> ListofStations = new List<Station>();
            List<Route> ListofRoutes = new List<Route>();
            try
            {
                FileReader(out ListofStations, out ListofRoutes);
            }
            catch(IOException ex){
                Console.WriteLine("Произошла ошибка ввода и вывода:" + ex.Message );
            }
            catch(FileFormatException ex){
                Console.WriteLine("Неверный формат файла:" + ex.Message);
            }
            Console.WriteLine(ListofStations);
            Console.WriteLine(ListofRoutes);
        }

    }
}
