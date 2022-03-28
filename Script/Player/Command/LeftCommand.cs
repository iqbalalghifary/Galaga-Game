using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Player.Command
{
    public class LeftCommand : Command
    {
        private float _speed = 0.01f;
        public LeftCommand(GameObject gameObject, float speed) : base(gameObject)
        {
            _speed = speed;
        }

        public override void Execute()
        {
            _gameObject.transform.Translate(new Vector3(-_speed, 0f));
        }
    }
}
