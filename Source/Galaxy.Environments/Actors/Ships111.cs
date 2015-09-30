﻿using System.Diagnostics;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;

namespace Galaxy.Environments.Actors
{
    public class Ships111 : Ship
    {
        public Ships111(ILevelInfo info) : base(info)
        {
            Width = Width+25;
            Height = Height + 25;
            ActorType = ActorType.Enemy;
        }

        public override void Load()
        {
            InitTimer();
            Load("Assets\\Nevskiy.png");
        }
    }
}