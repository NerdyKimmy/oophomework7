using System;


namespace Facade
{ 
    class Amplifier
    {
        public void On() => Console.WriteLine("Amplifier is on.");
        public void SetVolume(int volumeLevel) => Console.WriteLine($"Amplifier volume set to {volumeLevel}.");
        public void Off() => Console.WriteLine("Amplifier is off.");
    }

    class DvdPlayer
    {
        public void On() => Console.WriteLine("DVD Player is on.");
        public void Play(string movieName) => Console.WriteLine($"Playing {movieName}.");
        public void Stop() => Console.WriteLine("DVD Player stopped.");
        public void Off() => Console.WriteLine("DVD Player is off.");
    }

    class Projector
    {
        public void On() => Console.WriteLine("Projector is on.");
        public void SetWideScreenMode() => Console.WriteLine("Projector in widescreen mode.");
        public void Off() => Console.WriteLine("Projector is off.");
    }

    class HomeTheaterFacade
    {
        private Amplifier amplifier;
        private DvdPlayer dvdPlayer;
        private Projector projector;

        public HomeTheaterFacade(Amplifier amplifier, DvdPlayer dvdPlayer, Projector projector)
        {
            this.amplifier = amplifier;
            this.dvdPlayer = dvdPlayer;
            this.projector = projector;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            amplifier.On();
            amplifier.SetVolume(5);
            dvdPlayer.On();
            dvdPlayer.Play(movie);
            projector.On();
            projector.SetWideScreenMode();
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down the movie theater...");
            dvdPlayer.Stop();
            dvdPlayer.Off();
            amplifier.Off();
            projector.Off();
        }
    }

    class Program
    {
        static void Main()
        {
            Amplifier amplifier = new Amplifier();
            DvdPlayer dvdPlayer = new DvdPlayer();
            Projector projector = new Projector();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amplifier, dvdPlayer, projector);

            homeTheater.WatchMovie("Inception");
            Console.WriteLine();
            homeTheater.EndMovie();
        }
    }
}