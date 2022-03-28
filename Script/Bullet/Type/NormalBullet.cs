using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Bullet.Type
{
    public class NormalBullet : IBullet
    {        
        public NormalBullet() : base(0.05f);
    }
}
