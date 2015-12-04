using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;

namespace Galaxy.Environments.Actors
{
    class CLightning : BaseActor
    {
        #region Constant

        private const int MaxSpeed = 6;

        #endregion

        #region Private fields

        private bool m_flying;
        private Stopwatch m_flyTimer;

        #endregion

        #region Constructors

        public CLightning(ILevelInfo info)
            : base(info)
        {
            Width = 25;
            Height = 25;
            ActorType = ActorType.Lightning;
        }

        #endregion

        #region Overrides

        public override void Load()
        {
            Load("Assets/ball_lightning.png");
        }
        #endregion

        #region Overrides

        public override void Update()
        {
            base.Update();
            H_changePosition();
        }

        #endregion
        public void H_changePosition()
        {
            Position = new Point(Position.X + MaxSpeed, Position.Y - MaxSpeed);
        }
    }
}
