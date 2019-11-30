using System;

namespace MoeCalculator
{
    public enum Element
    {
        Unknown = 0,

        [OutputColor(Color = ConsoleColor.Red)]
        Flame,
        
        [OutputColor(Color = ConsoleColor.Cyan)]
        Ice,
        
        [OutputColor(Color = ConsoleColor.Yellow)]
        Thunder
    }
}