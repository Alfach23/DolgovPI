using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;

namespace Galaxy.Environments.Actors
{
    public class ShipNew :Ship
    {
        public EnemyBullet CreateBullet()
        {
            EnemyBullet enemyBullet = new EnemyBullet(Info);
            {
                Position = Position;
            };

            enemyBullet.Load();
            return enemyBullet;
        }

        public override void h_changePosition()
        {
            Position = new Point(Position.X - 8, Position.Y);
        }

        public ShipNew(ILevelInfo info) : base(info)
        {
            Width = Width;
            Height = Height;
            ActorType = ActorType.Enemy;
        }
        public override void Update()
        {
            CreateBullet();
            base.Update();
        }
        public override void Load()
        {
            Load(@"Assets/ship.png");
            InitTimer();
        }
    }
}
