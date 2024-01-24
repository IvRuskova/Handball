﻿using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }
        public double Rating { get; protected set; }

        public string Team { get; private set; }

        public abstract void DecreaseRating();

        public abstract void IncreaseRating();
        

        public void JoinTeam(string name)
        {
            Team = name;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.team}: {Name}");
            sb.AppendLine($"--Rating: {this.rating}");
                return sb.ToString().TrimEnd();
        }
    }
}
