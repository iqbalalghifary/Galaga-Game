using Assets.Script;
using Assets.Script.Enum;
using Assets.Script.Player.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameConfiguration gameConfiguration = GameConfiguration.Instance;
        if (gameConfiguration.GamePlay == true)
        {
            ExecuteInput();
        }
    }

    void ExecuteInput()
    {
        Command command = InputHandler();
        if (command != null)
            command.Execute();

    }
    Command InputHandler()
    {
        GameConfiguration gameConfiguration = GameConfiguration.Instance;

        //Used If-Else to avoid double button execute in same time
        if (Input.GetKey(gameConfiguration.KeyCodeRight) & gameObject.transform.position.x < 2.65f)        
            return new RightCommand(this.gameObject, gameConfiguration.SpeedShip);
        else if(Input.GetKey(gameConfiguration.KeyCodeLeft) & gameObject.transform.position.x > -3.0f)
            return new LeftCommand(this.gameObject, gameConfiguration.SpeedShip);
        else if (Input.GetKey(gameConfiguration.KeyCodeFire))
        {            
            return new FireCommand(this.gameObject, gameConfiguration.BulletFactory, BulletType.Normal);            
        }

        return null;
    }
}
