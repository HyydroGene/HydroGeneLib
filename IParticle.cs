using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HydroGene
{
    interface IParticle
    {
        float Life { get; set; }
        bool ToRemove { get; set; }
    }
}
