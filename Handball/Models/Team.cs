using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned;
        private double overallRating;
        private List<IPlayer> players;
        

        public Team(string name)
        {
            name = Name;
            pointsEarned = PointsEarned;
            overallRating = OverallRating;
            players = new List<IPlayer>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }
        public int PointsEarned 
        { 
            get => pointsEarned = 0;
            private set => pointsEarned = value;
        }

        public double OverallRating 
        {
            get => players.Count == 0 ? 0 : overallRating;
            private set
            {
                overallRating = value;
            }
        }

        IReadOnlyCollection<IPlayer> ITeam.Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;

            IPlayer goalkeeper = players.Find(p => p is Goalkeeper);
            if (goalkeeper != null)
            {
                Math.Min(goalkeeper.Rating + 0.5, 10.0);
            }
        }

        public void Lose()
        {
            foreach (var player in players)
            {
               Math.Max(player.Rating - 0.5, 1); // Decrease player rating while not going below 0
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3; // Increase points earned

            foreach (var player in players)
            {
                
                Math.Min(player.Rating + 0.5, 10.0); // Increase player rating while not exceeding 10
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            
            if (players.Count == 0)
            {
                sb.AppendLine($"--Players: none");
            }
            else
            {
                sb.AppendLine($"--Players: {String.Join(", ", players.Select(c => c.Name))}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
