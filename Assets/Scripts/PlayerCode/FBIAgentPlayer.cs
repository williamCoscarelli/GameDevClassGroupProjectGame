using UnityEngine;

public class FBIAgentPlayer : MonoBehaviour
{
   
    public SpriteRenderer FBISpriteRenderer;
    public Rigidbody2D FBIAgentPlayerRigidbody2D;
    public GameObject Bullet;
    private int NumberOfJumpsLeft = 2;
    
    public void Move(Vector2 direction)
    {
        
        FaceCorrectDirection(direction);
        
        float xAmount = direction.x * 5f * Time.deltaTime;
        float yAmount = direction.y * 5f * Time.deltaTime;
        FBISpriteRenderer.transform.Translate(xAmount, yAmount, 0f);
        FBISpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(FBISpriteRenderer);
    }

    public void Jump(Vector2 JumpHight)
    {
        if (NumberOfJumpsLeft > 0)
        {
            FBIAgentPlayerRigidbody2D.linearVelocity = (new Vector2(0,0));
            FBIAgentPlayerRigidbody2D.AddForce(JumpHight, ForceMode2D.Impulse);
            NumberOfJumpsLeft--;
        }
        else
        {
            return;
        }
    }

    public float returnVerticalVelocity()
    {
        float yvelocity = 0; 
        yvelocity = FBIAgentPlayerRigidbody2D.linearVelocity.y;
        return yvelocity;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            NumberOfJumpsLeft = 2;
        }

        if (other.gameObject.tag == "Platform")
        {
            NumberOfJumpsLeft = 2;
        }
    }
    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            FBISpriteRenderer.flipX = false;
        }
        
        else if (direction.x < 0) 
        { 
            FBISpriteRenderer.flipX = true;
        }
    }

    public void ShootBulletUp()
    {
        Instantiate(Bullet, this.transform.position, Bullet.transform.rotation);
        // check bullet code for movement 
    }
}
