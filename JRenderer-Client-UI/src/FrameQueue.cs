using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRenderer_Client.src
{
    class FrameQueue
    {
        public static Queue<PpmImage> queue;
        static public void Create()
        {
            queue = new Queue<PpmImage>();
        }
    }
}
