using UnityEngine;

public class InputForPlayer : MonoBehaviour
{
    public FBIAgentPlayer FBIAgentPlayer;

    public CurrentGun CurrentGun;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            FBIAgentPlayer.Reset();
        }
        if (Input.GetKey(KeyCode.A))
        {
            FBIAgentPlayer.Move(new Vector2(-1, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            FBIAgentPlayer.Move(new Vector2(1, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FBIAgentPlayer.Jump(new Vector2(0, 5));
        }

        if (Input.GetKey(KeyCode.I))
        {
            CurrentGun.Shootbullet(new Vector2(0, 20));
        }
        if (Input.GetKey(KeyCode.K))
        {
            CurrentGun.Shootbullet(new Vector2(0, -20));
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            CurrentGun.Shootbullet(new Vector2(-20, 0));
        }
        
        if (Input.GetKey(KeyCode.L))
        {
            CurrentGun.Shootbullet(new Vector2(20, 0));
        }
    }
}
