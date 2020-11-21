using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PickupInfo
{
    public int      CellIndex { get; private set; }
    public float    LiveTimeS { get; private set; }
    public PickupInfo(int cellIndex, float liveTimeS)
    {
        CellIndex = cellIndex;
        LiveTimeS = liveTimeS;
    }
}
