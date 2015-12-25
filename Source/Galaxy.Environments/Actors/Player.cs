#region using

using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Galaxy.Core.Actors;
using Galaxy.Core.Environment;

#endregion

namespace Galaxy.Environments.Actors
{
  public class PlayerShip : DethAnimationActor
  {
    #region Constant

    private const int Speed = 3;
      private int LiveCount = 3;

    #endregion

    #region Constructors

    public PlayerShip(ILevelInfo info)
      : base(info)
    {
      Width = 22;
      Height = 26;
      ActorType = ActorType.Player;
    }

    #endregion

    #region Overrides

    public override void Load()
    {
        Load(@"Assets\player.png");
    }

    #region Overrides of DethAnimationActor

    public override void Update()
    {
      base.Update();

      if (IsPressed(VirtualKeyStates.Left))
        Position = new Point(Position.X - Speed, Position.Y);
      if (IsPressed(VirtualKeyStates.Right))
        Position = new Point(Position.X + Speed, Position.Y);
    }

    #endregion

    public override bool IsAlive
    {
        get { return base.IsAlive; }
        set
        {
            Trace.WriteLine(LiveCount);
            LiveCount--;
            MessageBox.Show(string.Format("Осталось жизней: {0}", LiveCount + 1));
            if (LiveCount < 0)
            {
                CanDrop = true;
                base.IsAlive = false;
            }
            else
            {
                base.IsAlive = true;
            }
        }
    }

    #endregion
  }
}
