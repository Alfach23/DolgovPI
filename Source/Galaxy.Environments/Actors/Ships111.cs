using System.Diagnostics;
using System.Drawing;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;

namespace Galaxy.Environments.Actors
{
    public class Ships111 : Ship
    {
        public EnemyBullet CreateBullet()
        {
            EnemyBullet enemyBullet = new EnemyBullet(Info);
            {
                Position = Position;
            }

            enemyBullet.Load();
            return enemyBullet;
        }

        protected override void H_changePosition()
        {
            Position = new Point(Position.X - 8, Position.Y);
        }

        public Ships111(ILevelInfo info) : base(info)
        {
            Width = Width;
            Height = Height;
            ActorType = ActorType.Enemy;
        }

        public override void Load()
        {
            Load(@"Assets/ship.png");
            InitTimer();
        }
    }
}