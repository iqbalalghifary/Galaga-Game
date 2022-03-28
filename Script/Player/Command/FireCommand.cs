using Assets.Script.Bullet;
using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Player.Command
{
    public class FireCommand : Command
    {
        private BulletType _bulletType;
        private BulletFactory _bulletFactory;
        public FireCommand(GameObject gameObject, BulletFactory bulletFactory, BulletType bulletType) : base(gameObject)
        {
            _bulletType = bulletType;
            _bulletFactory = bulletFactory;
        }
        public override void Execute()
        {
            GameConfiguration gameConfiguration = GameConfiguration.Instance;
            if (gameConfiguration.GetBulletCount() == 0)
            {
                gameConfiguration.SetBulletCount(1);
                _bulletFactory.BuildBullet(_bulletType, _gameObject.transform.position);
            }
        }
    }
}
