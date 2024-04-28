using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_and_abstract_classes
{
    internal interface IFlyable
    {
        void FlyTo(int x, int y, int z) { }

        void GetFlyTime(int x, int y, int z) { }
    }
}
