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

        private const int MaxSpeed = 3;
        private const long StartFlyMs = 2000;

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
            InitTimer();
        }

        protected void InitTimer()
        {
            if (m_flyTimer == null)
            {
                m_flyTimer = new Stopwatch();
                m_flyTimer.Start();
            }
        }

        #endregion

        #region Overrides

        public override void Update()
        {
            base.Update();

            if (!IsAlive)
                return;

            if (!m_flying)
            {
                if (m_flyTimer.ElapsedMilliseconds <= StartFlyMs) return;

                m_flyTimer.Stop();
                m_flyTimer = null;
                h_changePosition();
                m_flying = true;
            }
            else
            {
                h_changePosition();
            }
        }

        #endregion
        public virtual void h_changePosition()
        {
            Position = new Point(Position.X+13, Position.Y + 4);
        }
    }
}
