using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Player.Command
{
    public class Command
    {
        protected GameObject _gameObject;
        public Command(GameObject gameObject)
        {
            _gameObject = gameObject;
        }
        public virtual void Execute()
        {
            //Do Nothing
        }
    }
}
