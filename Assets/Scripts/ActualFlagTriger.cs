using UnityEngine;

public class ActualFlagTriger : MonoBehaviour
{
    public Goalflag GoalFlag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoalFlag = FindAnyObjectByType<Goalflag>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FBIPlayer")
        {
            print("im triggered");
            GoalFlag.DoTheThing();
        }
    }
}