using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    public class GameID
    {
        public string NameOfGame { get;}

        public GameID(string nameOfGame)
        {
            NameOfGame = nameOfGame;
        }

        public override string ToString()
        {
            return $"{NameOfGame}";
        }

        public override bool Equals(object? obj)
        {
            return obj is GameID gameID &&
                NameOfGame == gameID.NameOfGame;
        }

        public override int GetHashCode() 
        {
            return HashCode.Combine(NameOfGame);
        }

        public static bool operator ==(GameID left, GameID right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            return !(left is null) && left.Equals(right);
        }

        public static bool operator !=(GameID left, GameID right)
        {
            return !(left == right);
        }
    }
}
