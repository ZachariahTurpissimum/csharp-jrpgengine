using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace csharp_jrpengine.Sys
{
    public class FrameCounter
    {
        int Frames = 0;
        public int LastFps { get; private set; }

        Stopwatch timer = Stopwatch.StartNew();
        TimeSpan maximumElapsedTime = new TimeSpan(0, 0, 1);
        TimeSpan currentElapsedTime = new TimeSpan(0);

        public void Update()
        {
            Frames++;

            currentElapsedTime = timer.Elapsed;

            if (currentElapsedTime > maximumElapsedTime)
            {
                LastFps = Frames;
                Frames = 0;
                currentElapsedTime = new TimeSpan(0);
                timer.Restart();
            }
        }
    }
}
