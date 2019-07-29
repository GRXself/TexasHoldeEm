using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public abstract class TexasHoldEmHandCardLevel : IComparable<TexasHoldEmHandCardLevel>
    {
        public string Name { get; protected set; }
        protected int Value { private get; set; }

        protected TexasHoldEmHandCardLevel()
        {
            Initializer();
        }

        protected abstract void Initializer();
        
        public abstract bool IsThisLevel(List<PokerCard> cards);

        public int CompareTo(TexasHoldEmHandCardLevel other)
        {
            return Value.CompareTo(other.Value);
        }

        public abstract TexasGameResult GetSameLevelCompareResult(TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer);

        public static IEnumerable<TexasHoldEmHandCardLevel> GetAllLevelInstances()
        {
            return Assembly.GetAssembly(typeof(TexasHoldEmHandCardLevel))
                .GetTypes()
                .Where(levelClass => levelClass.IsClass && !levelClass.IsAbstract &&
                                     levelClass.IsSubclassOf(typeof(TexasHoldEmHandCardLevel)))
                .Select(level => (TexasHoldEmHandCardLevel) Activator.CreateInstance(level));
        }
    }
}