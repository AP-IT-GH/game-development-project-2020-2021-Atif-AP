using System;
using System.Collections.Generic;
using System.Text;

namespace FallParkour.Animation
{
    public class Animatie
    {
        private List<AnimationFrame> frames;

        public AnimationFrame CurrentFrame { get; set; }

        private int counter;

        public Animatie()
        {
            frames = new List<AnimationFrame>();

        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }

        public void Update()
        {
            CurrentFrame = frames[counter];
            counter++;

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
