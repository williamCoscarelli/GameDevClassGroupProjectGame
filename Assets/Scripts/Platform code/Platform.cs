using UnityEngine;

public class Platform : MonoBehaviour
{
    
    public FBIAgentPlayer FBIAgentPlayer;

    public GameObject DoubleJumpActivator;
    public GameObject Platformthing;
    // Update is called once per frame

    void Start()
    {
        FBIAgentPlayer = FindAnyObjectByType<FBIAgentPlayer>();
    }
    void Update()
    {
        PlayerPlatformInteraction();
    }

    private void LetPlayerPass()
    {
        // let player fall or pass through platforms
        Platformthing.SetActive(false);
        DoubleJumpActivator.SetActive(false);
        
    }

    private void DontLetPlayerPass()
    {
        Platformthing.SetActive(true);
        DoubleJumpActivator.SetActive(true);
    }

    private void PlayerPlatformInteraction()
    {
        if (FBIAgentPlayer.returnVerticalVelocity() > 0)
        {
            LetPlayerPass();
        }
        if (FBIAgentPlayer.returnVerticalVelocity() <= 0)
        {
            DontLetPlayerPass();
        }
    }
}
