
using System;

namespace Items.Models
{
    [Serializable]
    public class StartSettings
    {
        public float BallSpeed;
        public float BallGravity;

        public float CamStartSpeed;
        public float CamMaxSpeed;
        public float CamSpeedMultiplier;
    }
}