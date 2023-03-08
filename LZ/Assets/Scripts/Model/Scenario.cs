using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scenario
{
    public int GroupId { get; set; } = 10000;

    // key : groupid, value : answer id
    public Dictionary<int, List<int>> History { get; set; }


    public Scenario()
    {
        History = new Dictionary<int, List<int>>();
    }
}