using Mega.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Domain.Entity.HomePage
{
    public class HomePageImsges : BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLoc imageLoc { get; set; }
    }
    public enum ImageLoc
    {
        L1=0,
        L2=1,
        R1=2,
        CenterFullScreen=3,
        G1=4,
        G2=5,


    }
}
