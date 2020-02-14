using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject death;

    //For Animation Purposes
    public Animator anim;
    private bool swimming;
    private bool flipping;
    private bool justFlipped;
    private int currentAnimation;//  1:Idle 2:Swim 3:Flip;
    private int AngleSection; //1 2 3 4 quarters;
    private float gameOverTimer = -500;
    private bool gameOver = false;
    private float horizontal;

    public GameObject explosion;
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
        Application.targetFrameRate = 60;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOverTimer > -500)
        {
            if (gameOverTimer > 0)
            {
                gameOverTimer -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        // Player movement from input (it's a variable between -1 and 1) for
        // degree of left or right movement
        float horizontalPhysics = Input.GetAxis("Horizontal");
        float verticalPhysics = Input.GetAxis("Vertical");
        if (gameOver)
        {
            horizontalPhysics = 0;
            verticalPhysics = 0;
        }

        //Animation Part
        if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            horizontal = 1;
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            horizontal = -1;
        }
        else
        {
            horizontal = 0;
        }
        //Flipping When looking right
        if (!pullingBoulder)
        {
            if (horizontal < (previousHorizontal - 0.1) && horizontal < -0.1)
            {
                //justFlipped = true;
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
                    else if (this.transform.rotation.eulerAngles.z > 270 && this.transform.rotation.eulerAngles.z < 360)
                    {
                        transform.Rotate(new Vector3(0, 0, -1) * 180 * Time.deltaTime, Space.Self);
                        AngleSection = 4;
                    }
                }
                if (AngleSection == 1 && this.transform.rotation.eulerAngles.z > 90)
                {
                    flipping = false;
                    swimming = true;
                    anim.SetTrigger("Diver Flip to Swim");
                    currentAnimation = 2;
                }
                else if (AngleSection == 4 && this.transform.rotation.eulerAngles.z < 270)
                {
                    flipping = false;
                    swimming = true;
                    anim.SetTrigger("Diver Flip to Swim");
                    currentAnimation = 2;
                }
            }
            //Do this when in middle of flipping animation but player chooses to revert back to the same direction
            else if (flipping && horizontal > -0.1 && previousHorizontal > 0.1)
            {
                //justFlipped = false;
                flipping = false;
                if (horizontal > 0.1)
                {
                    swimming = true;
                    anim.SetTrigger("Diver Flip to Swim");
                    currentAnimation = 2;
                }
                else if (horizontal > -0.1 & horizontal < 0.1)
                {
                    swimming = false;
                    anim.SetTrigger("Diver Flip to Idle");
                    currentAnimation = 1;
                }
            }

            //Flipping when looking left
            if (horizontal > (previousHorizontal + 0.1) && horizontal > 0.1)
            {
                //justFlipped = true;
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
                    else if (this.transform.rotation.eulerAngles.z > 270 && this.transform.rotation.eulerAngles.z < 360)
                    {
                        transform.Rotate(new Vector3(0, 0, -1) * 180 * Time.deltaTime, Space.Self);
                        AngleSection = 4;
                    }
                }
                if (AngleSection == 1 && this.transform.rotation.eulerAngles.z > 90)
                {
                    flipping = false;
                    swimming = true;
                    anim.SetTrigger("Diver Flip to Swim");
                    currentAnimation = 2;
                }
                else if (AngleSection == 4 && this.transform.rotation.eulerAngles.z < 270)
                {
                    flipping = false;
                    swimming = true;
                    anim.SetTrigger("Diver Flip to Swim");
                    currentAnimation = 2;
                }
            }
            //Do this when in middle of flipping animation but player chooses to revert back to the same direction
            else if (flipping && horizontal < 0.1 && previousHorizontal < -0.1)
            {
                //justFlipped = false;
                flipping = false;
                if (horizontal < -0.1)
                {
                    swimming = true;
                    anim.SetTrigger("Diver Flip to Swim");
                    currentAnimation = 2;
                }
                else if (horizontal > -0.1 & horizontal < 0.1)
                {
                    swimming = false;
                    anim.SetTrigger("Diver Flip to Idle");
                    currentAnimation = 1;
                }
            }

            //Stop if Player if flipping in the y axis, wait for it to reach to 90 degrees then flip to make it look more natural
            if (!flipping)
            {
                //Transition between animations
                if (swimming == false && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
                {
                    swimming = true;
                    // if (!justFlipped)
                    // {
                    Debug.Log(previousHorizontal + "    " +  horizontal);
                        anim.SetTrigger("Diver Swim");
                        currentAnimation = 2;
                   // }
                }
                if (swimming == true)
                {
                    if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
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

                if (verticalPhysics > 0.1 && horizontalPhysics > 0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, 45),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics < -0.1 && horizontalPhysics > 0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, -45),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics > 0.1 && horizontalPhysics < -0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, -45),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics < -0.1 && horizontalPhysics < -0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, +45),
                                         turnSpeed * Time.deltaTime);
                }
                if ((horizontalPhysics < -0.1 || horizontalPhysics > 0.1) && verticalPhysics > -0.01 && verticalPhysics < 0.01)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, 0),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics > 0.1 && horizontalPhysics > -0.01 && horizontalPhysics < 0.01 && previousHorizontal > 0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, 90),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics < -0.1 && horizontalPhysics > -0.01 && horizontalPhysics < 0.01 && previousHorizontal > 0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, -90),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics > 0.1 && horizontalPhysics > -0.01 && horizontalPhysics < 0.01 && previousHorizontal < -0.1)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                         Quaternion.Euler(0, 0, -90),
                                         turnSpeed * Time.deltaTime);
                }
                if (verticalPhysics < -0.1 && horizontalPhysics > -0.01 && horizontalPhysics < 0.01 && previousHorizontal < -0.1)
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
        movement = new Vector2(horizontalPhysics, verticalPhysics);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            //Destroy(gameObject);
            Destroy(collision.gameObject);
            //yield return new WaitForSeconds(2);
            gameOver = true;
            gameOverTimer = 1.5f;
            //gameObject.GetComponent<PlayerOxygen>().Deth();
            //death.GetComponent<PlayerPhysicsWithFlip>().goToGameOver();
            //goToGameOver();

        }
    }

    IEnumerator goToGameOver()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }

}
