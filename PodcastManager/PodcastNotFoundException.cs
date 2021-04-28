using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastBusinessLayer
{
    public class PodcastNotFoundException : Exception
    {
        public PodcastNotFoundException() : base("Not found")
        {

        }
    }
}
