using UnityEngine;

public class PlayerPhysicsWithFlip : MonoBehaviour
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
    public bool pullingBoulder = false;

    //For Animation Purposes
    public Animator anim;
    private bool swimming;
    private bool flipping;
    private bool justFlipped;
    private int currentAnimation;//  1:Idle 2:Swim 3:Flip;
    private int AngleSection; //1 2 3 4 quarters;

    float previousHorizontal;

    private void Start()
    {
        AngleSection = 1;
        currentAnimation = 1;
        justFlipped = false;
        flipping = false;
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
        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Flipping When looking right
        if (horizontal < (previousHorizontal-0.1) && horizontal < 0) 
        {
            justFlipped = true;
            flipping = true;
            if (flipping)
            {
                if (currentAnimation == 2)
                {
                    anim.SetTrigger("Diver Swim to Flip");
                }
                else if(currentAnimation == 1)
                {
                    anim.SetTrigger("Diver Idle to Flip");
                }
                currentAnimation = 3;

                if (this.transform.rotation.eulerAngles.z >= 0 && this.transform.rotation.eulerAngles.z < 90)
                {
                    transform.Rotate(new Vector3(0, 0, 1) * 180 * Time.deltaTime, Space.Self);
                    AngleSection = 1;
                }
                else if(this.transform.rotation.eulerAngles.z > 270 && this.transform.rotation.eulerAngles.z <= 360)
                {
                    transform.Rotate(new Vector3(0, 0, -1) * 180 * Time.deltaTime, Space.Self);
                    AngleSection = 4;
                }
            }
            if(AngleSection == 1 && this.transform.rotation.eulerAngles.z > 90)
            {
                Debug.Log("Done Flipping");
                flipping = false;
                swimming = true;
                anim.SetTrigger("Diver Flip to Swim");
                currentAnimation = 2;
            }
            else if (AngleSection == 4 && this.transform.rotation.eulerAngles.z < 270)
            {
                Debug.Log("Done Flipping");
                flipping = false;
                swimming = true;
                anim.SetTrigger("Diver Flip to Swim");
                currentAnimation = 2;
            }
        }
        //Flipping when looking left
        if (horizontal > (previousHorizontal + 0.1) && horizontal > 0)
        {
            justFlipped = true;
            flipping = true;
            if (flipping)
            {
                if (currentAnimation == 2)
                {
                    anim.SetTrigger("Diver Swim to Flip");
                }
                else if (currentAnimation == 1)
                {
                    anim.SetTrigger("Diver Idle to Flip");
                }
                currentAnimation = 3;

                if (this.transform.rotation.eulerAngles.z >= 0 && this.transform.rotation.eulerAngles.z < 90)
                {
                    transform.Rotate(new Vector3(0, 0, 1) * 180 * Time.deltaTime, Space.Self);
                    AngleSection = 1;
                }
                else if (this.transform.rotation.eulerAngles.z > 270 && this.transform.rotation.eulerAngles.z <= 360)
                {
                    transform.Rotate(new Vector3(0, 0, -1) * 180 * Time.deltaTime, Space.Self);
                    AngleSection = 4;
                }
            }
            if (AngleSection == 1 && this.transform.rotation.eulerAngles.z > 90)
            {
                Debug.Log("Done Flipping");
                flipping = false;
                swimming = true;
                anim.SetTrigger("Diver Flip to Swim");
                currentAnimation = 2;
            }
            else if (AngleSection == 4 && this.transform.rotation.eulerAngles.z < 270)
            {
                Debug.Log("Done Flipping");
                flipping = false;
                swimming = true;
                anim.SetTrigger("Diver Flip to Swim");
                currentAnimation = 2;
            }
        }

        //Stop if Player if flipping in the y axis, wait for it to reach to 90 degrees then flip to make it look more natural
        if (!flipping)
        {
            //Transition between animations
            if (swimming == false && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
            {
                swimming = true;
                if (!justFlipped)
                {
                    anim.SetTrigger("Diver Swim");
                    currentAnimation = 2;
                }
            }
            if (swimming == true)
            {
                if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
                {
                    if (currentAnimation == 2)
                    {
                        anim.SetTrigger("Diver Idle");
                    }else if(currentAnimation == 3)
                    {
                        anim.SetTrigger("Diver Flip to Idle");
                    }
                    currentAnimation = 1;
                    swimming = false;
                    justFlipped = false;
                }
                else if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
                {
                    if (currentAnimation == 2)
                    {
                        anim.SetTrigger("Diver Idle");
                    }
                    else if (currentAnimation == 3)
                    {
                        anim.SetTrigger("Diver Flip to Idle");
                    }
                    currentAnimation = 1;
                    swimming = false;
                    justFlipped = false;
                }
                else if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    if (currentAnimation == 2)
                    {
                        anim.SetTrigger("Diver Idle");
                    }
                    else if (currentAnimation == 3)
                    {
                        anim.SetTrigger("Diver Flip to Idle");
                    }
                    currentAnimation = 1;
                    swimming = false;
                    justFlipped = false;
                }
                else if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
                {
                    if (currentAnimation == 2)
                    {
                        anim.SetTrigger("Diver Idle");
                    }
                    else if (currentAnimation == 3)
                    {
                        anim.SetTrigger("Diver Flip to Idle");
                    }
                    currentAnimation = 1;
                    swimming = false;
                    justFlipped = false;
                }
            }

            if (!pullingBoulder)
            {
                // Player movement from input (it's a variable between -1 and 1) for
                // degree of left or right movement


                if (horizontal < -0.1)
                {
                    if (previousHorizontal > 0.1)
                    {
                        var rotationVector = transform.rotation.eulerAngles;
                        rotationVector.z *= -1;
                        transform.rotation = Quaternion.Euler(rotationVector);
                        this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
                    }
                }
                else if (horizontal > 0.1)
                {
                    if (previousHorizontal < -0.1)
                    {
                        var rotationVector = transform.rotation.eulerAngles;
                        rotationVector.z *= -1;
                        transform.rotation = Quaternion.Euler(rotationVector);
                        this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
                    }
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
                if (horizontal > 0.1 || horizontal < -0.1)
                {
                    previousHorizontal = horizontal;
                }
            }
        }

        //Boost Mechanics
        if (bTimer > 0)
        {
            bTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && bTimer <= 0)
        {
            Boost();
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
