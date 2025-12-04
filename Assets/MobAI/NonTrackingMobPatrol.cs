using UnityEngine;

public class NonTrackingMobPatrol : MonoBehaviour
{
    public float moveDistance;
    public float speed;
    private Animator animator;

    private Vector3 startPos;
    private Vector3 endPos;
    private bool goingRight = true;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        setStartAndEndPosition();
    }

    private void setStartAndEndPosition()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        animator.SetBool("isWalking", true);
        Vector3 target;
        if (goingRight)
            target = endPos;
        else
            target = startPos;
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            goingRight = !goingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
