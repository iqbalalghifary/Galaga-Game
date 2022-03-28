using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class Enemy : MonoBehaviour
    {
        void Update()
        {
            
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
