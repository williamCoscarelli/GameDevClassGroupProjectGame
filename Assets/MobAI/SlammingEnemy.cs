using UnityEngine;

public class EnemySlamming : MonoBehaviour
{
    public float moveDistance = 3f;
    public float upSpeed = 2f;
    public float downSpeed = 10f;
    public float waitAtTopTime = 1f;

    private Vector3 startPos;
    private Vector3 endPos;
    private enum SlamState { MovingUp, WaitingAtTop, MovingDown }
    private SlamState state = SlamState.MovingUp;

    private float waitTimer = 0f;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.up * moveDistance;
    }

    void Update()
    {
        switch (state)
        {
            case SlamState.MovingUp:
                MoveUp();
                break;

            case SlamState.WaitingAtTop:
                WaitAtTop();
                break;

            case SlamState.MovingDown:
                MoveDown();
                break;
        }
    }

    private void MoveUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, upSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, endPos) < 0.01f)
        {
            state = SlamState.WaitingAtTop;
            waitTimer = waitAtTopTime;
        }
    }

    private void WaitAtTop()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer <= 0f)
        {
            state = SlamState.MovingDown;
        }
    }

    private void MoveDown()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos, downSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) < 0.01f)
        {
            state = SlamState.MovingUp;
        }
    }
}
