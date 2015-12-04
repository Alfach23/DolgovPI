using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace Galaxy.Environments.Actors
{
    class CLightning : BaseActor
    {
        private const int MaxSpeed = 3;
        public CLightning(ILevelInfo info) : base(info)
        {
            Width = 25;
            Height = 25;
            ActorType = ActorType.Lightning;
        }

        public override void Load()
        {
            Load("Assets/ball_lightning.png");
        }

        public override void Update()
        {
            //Position = new Point(Position.X, Position.Y);
            h_changePosition();
        }
        public virtual void h_changePosition()
        {
            Position = new Point(Position.X - 8, Position.Y);
            //Random rnd1 = new Random();
            //Random rnd2 = new Random();
            //int MMaxr = 20;
            //int MMinr = 1;

            //int rr1 = rnd1.Next(MMinr, MMaxr);
            //int rr2 = rnd2.Next(MMinr, MMaxr);

            //var EndMap = Info.GetLevelSize();
            //Position = new Point(Position.X + rr1, Position.Y + rr2);

            //if (Position.Y > EndMap.Height || Position.X > EndMap.Width)
            //{
            //    Position = new Point(Position.X - rr1, Position.Y - rr2);
            //}

            //Position = new Point(Position.X + rr1, Position.Y-rr2);


            //Point LightningPosition = Info.GetPlayerPosition();

            //Vector distance = new Vector(LightningPosition.X - Position.X, LightningPosition.Y - Position.Y);
            //double coef = distance.X / MaxSpeed;

            //Vector movement = Vector.Divide(distance, coef);

            //Size levelSize = Info.GetLevelSize();

            //if (movement.X > levelSize.Width)
            //    movement = new Vector(levelSize.Width, movement.Y);

            //if (movement.X < 0 || double.IsNaN(movement.X))
            //    movement = new Vector(0, movement.Y);

            //if (movement.Y > levelSize.Height)
            //    movement = new Vector(movement.X, levelSize.Height);

            //if (movement.Y < 0 || double.IsNaN(movement.Y))
            //    movement = new Vector(movement.X, 0);

            //Position = new Point((int)(Position.X + movement.X), (int)(Position.Y + movement.Y));
        }
    }
}
