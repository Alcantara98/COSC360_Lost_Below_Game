using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Vector2 movement;
    public float boostSpeed = 400;
    public float boostCooldown = 2;
    float bTimer;
    public float speed = 1500;
    public float boostCost = 5;
    PlayerOxygen oxygen;
    Rigidbody2D player;
    public float turnSpeed;

    public Animator anim;
    private bool swimming;
    //public OxygenMaster oxygen;


    float previousHorizontal;

    private void Start()
    {
        swimming = false;
        anim = GetComponentInChildren<Animator>();
        previousHorizontal = 1;
        bTimer = 1.0f;
        player = transform.GetComponent<Rigidbody2D>();
        oxygen = transform.GetComponent<PlayerOxygen>();
    }
    // Update is called once per frame
    void Update()
    {

        //Transition between animations
        if(swimming ==  false && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            swimming = true;
            anim.SetTrigger("Diver Swim");
            Debug.Log("Swim");
        }
        if(swimming == true)
        {
            if(Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                anim.SetTrigger("Diver Idle");
                swimming = false;
                Debug.Log("Idle");
            }
            else if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                anim.SetTrigger("Diver Idle");
                swimming = false;
                Debug.Log("Idle");
            }
            else if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                anim.SetTrigger("Diver Idle");
                swimming = false;
                Debug.Log("Idle");
            }
            else if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
            {
                anim.SetTrigger("Diver Idle");
                swimming = false;
                Debug.Log("Idle");
            }
           // swimming = false;
        }

        if (bTimer > 0)
        {
            bTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && bTimer <= 0)
        {
            Boost();
        }

        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal < 0)
        {

            if (previousHorizontal > 0)
            {
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z *= -1;
                transform.rotation = Quaternion.Euler(rotationVector);
                this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
            }
            //this.transform.localScale = new Vector2(-0.2f, 0.2f);
        }
        else if (horizontal > 0)
        {
            if (previousHorizontal < 0)
            {
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.z *= -1;
                transform.rotation = Quaternion.Euler(rotationVector);
                this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
            }
            //this.transform.localScale = new Vector2(0.2f, 0.2f);
        }

        if (vertical > 0 && horizontal > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, 45),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical < 0 && horizontal > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, -45),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical > 0 && horizontal < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, -45),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical < 0 && horizontal < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, +45),
                                 turnSpeed * Time.deltaTime);
        }
        if ((horizontal < 0 || horizontal > 0) && vertical > -0.01 && vertical < 0.01)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, 0),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical > 0 && horizontal > -0.01 && horizontal < 0.01 && previousHorizontal > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, 90),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical < 0 && horizontal > -0.01 && horizontal < 0.01 && previousHorizontal > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, -90),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical > 0 && horizontal > -0.01 && horizontal < 0.01 && previousHorizontal < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, -90),
                                 turnSpeed * Time.deltaTime);
        }
        if (vertical < 0 && horizontal > -0.01 && horizontal < 0.01 && previousHorizontal < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                 Quaternion.Euler(0, 0, 90),
                                 turnSpeed * Time.deltaTime);
        }
        if (horizontal > 0 || horizontal < 0)
        {
            previousHorizontal = horizontal;
        }

        /**
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position) * Quaternion.Euler(0, 0, 90);
        **/

        movement = new Vector2(horizontal, vertical);
        player.AddForce(movement * speed * Time.deltaTime);
    
    }

    void Boost()
    {
        if (oxygen.DecreaseOxygen(boostCost))
        {
            Vector2 facing = player.velocity.normalized;
            player.AddForce(facing * boostSpeed);
            bTimer = boostCooldown;
        }
    }

}
