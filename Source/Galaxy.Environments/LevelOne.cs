#region using

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Galaxy.Core.Actors;
using Galaxy.Core.Collision;
using Galaxy.Core.Environment;
using Galaxy.Environments.Actors;

#endregion

namespace Galaxy.Environments
{
  /// <summary>
  ///   The level class for Open Mario.  This will be the first level that the player interacts with.
  /// </summary>
  public class LevelOne : BaseLevel
  {
    private int m_frameCount;

    #region Constructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="LevelOne" /> class.
    /// </summary>
    public LevelOne()
    {
      // Backgrounds
      FileName = @"Assets\LevelOne.png";

      // Enemies
      for (int i = 0; i < 5; i++)
      {
        Ship = new Ships111(this);
          Ship.Load();
        int positionY = Ship.Height + 10;
        int positionX = 150 + i * (Ship.Width + 50);

        Ship.Position = new Point(positionX, positionY);

        Actors.Add(Ship);
      }

      // Player
      Player = new PlayerShip(this);
      int playerPositionX = Size.Width / 2 - Player.Width / 2;
      int playerPositionY = Size.Height - Player.Height - 50;
      Player.Position = new Point(playerPositionX, playerPositionY);
      Actors.Add(Player);
    }

    #endregion

    #region Overrides

    private void h_dispatchKey()
    {
      if (!IsPressed(VirtualKeyStates.Space)) return;

      if(m_frameCount % 10 != 0) return;

      Bullet bullet = new Bullet(this)
      {
        Position = Player.Position
      };
        
      //bullet.Load();
      Actors.Add(bullet);
    }

    public override BaseLevel NextLevel()
    {
      return new StartScreen();
    }

    public override void Update()
    {
      m_frameCount++;
      h_dispatchKey();
        TimeEnemyBul();

        //int i = new  Random().Next(Actors.Count);
        //Bullet bullet = new Bullet(this);
        //bullet.Load();
        //bullet.Position = Actors[i].Position;
        //Actors.Add(bullet);

      base.Update();

      IEnumerable<BaseActor> killedActors = CollisionChecher.GetAllCollisions(Actors);

      foreach (BaseActor killedActor in killedActors)
      {
        if (killedActor.IsAlive)
          killedActor.IsAlive = false;
      }

      List<BaseActor> toRemove = Actors.Where(actor => actor.CanDrop).ToList();
      BaseActor[] actors = new BaseActor[toRemove.Count()];
      toRemove.CopyTo(actors);

      foreach (BaseActor actor in actors.Where(actor => actor.CanDrop))
      {
        Actors.Remove(actor);
      }

      if (Player.CanDrop)
        Failed = true;

      //has no enemy
      if (Actors.All(actor => actor.ActorType != ActorType.Enemy))
        Success = true;
    }
      //таймер
    //создать таймер, который будет выполнять проверку по времени.
    private Stopwatch BullShotTime = new Stopwatch();
      private void TimeEnemyBul()
      {
          
          if (BullShotTime.ElapsedMilliseconds < 5000)
              return;

          var enemyBullet = new EnemyBullet(this);
          var enemyList = Actors.Where((actor) => actor is Ship || actor is Ships111).ToList();
          if (enemyList.Count > 0)
          {
              Random rnd = new Random();
              int qq = rnd.Next(enemyList.Count);

              var target = enemyList[qq].Position;
              enemyBullet.Position = new Point(target.X, target.Y + 10);

              enemyBullet.Load();

              Actors.Add(enemyBullet);

              BullShotTime.Restart();
          }
      }

    #endregion
  }
}
