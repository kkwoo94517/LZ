using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class HelperService
{
    private static int seed = 0;

    public static float RandomSeed()
    {
        seed++;
        return (float)((seed * 9301 + 94297) % 233280 / 233280.0f);
    }

}