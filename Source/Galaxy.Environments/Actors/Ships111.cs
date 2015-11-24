using System.Diagnostics;
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

        public override void Update()
        {
            base.Update();
            EnemyBullet enemyBullet = new EnemyBullet(Info);
        }
        public override void Load()
        {
            Load(@"Assets/ship.png");
            InitTimer();
        }
    }
}