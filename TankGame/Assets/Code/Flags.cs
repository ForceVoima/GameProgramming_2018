using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    public static class Flags
    {
        public static int Set(int mask, int flag)
        {
            // OR operation
            return mask | flag;
        }

        public static int Unset(int mask, int flag)
        {
            // AND NOT operation
            return mask & (~flag);
        }

        public static int Toggle(int mask, int flag)
        {
            // XOR operation
            return mask ^ flag;
        }

        public static bool Contains(int mask, int flag)
        {
            return (mask & flag) != 0;
        }

        public static int CreateMask(params int[] flags)
        {
            int mask = 0;

            for (int i = 0; i < flags.Length; i++)
            {
                mask |= 1 << flags[i];
            }

            return mask;
        }
    }
}
