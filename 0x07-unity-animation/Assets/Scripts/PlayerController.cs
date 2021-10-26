using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float gravity = -20f;
    public float jumpForce = 5f;
    public float speed = 12f;
    public Animator anim;
    int fallingDown = Animator.StringToHash("Fall");
    int jump = Animator.StringToHash("Jump");
    bool run = false;
    Transform cameraMain;
    Transform positionPlayer;
    Vector3 velocity;


    void Start()
    {
        positionPlayer = GetComponent<Transform>();
        cameraMain = Camera.main.transform;
    }
    public void Update()
    {        
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            run = false;
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            anim.SetTrigger(jump);
            if (positionPlayer.position.y < -5f)
            {
                anim.SetTrigger(fallingDown);
            }

        }

        if (run == true)
            anim.SetBool("Running", true);
        else
            anim.SetBool("Running", false);
            
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 direct = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        if (direct.magnitude >= 0.1f)
        {
            run = true;
            float angTarget = Mathf.Atan2(direct.x, direct.z) * Mathf.Rad2Deg + cameraMain.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, angTarget, 0f);
            Vector3 moveDirect = Quaternion.Euler(0f, angTarget, 0f) * Vector3.forward;
            controller.Move(moveDirect.normalized * speed * Time.deltaTime);
        }
        else
            run = false;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (positionPlayer.position.y < -5f)
        {
            anim.SetTrigger(fallingDown);
            if (positionPlayer.position.y < -50f)
            {
                run = false;
                positionPlayer.position = new Vector3(0, 70, 0);
            }
        }
    }
}