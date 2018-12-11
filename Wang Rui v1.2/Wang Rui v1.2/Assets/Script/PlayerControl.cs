using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMoveModifier;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private bool playerMoving;
    private Vector2 lastMove;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;


    private void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        playerMoving = false;


                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5)
                {
                    //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                    myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                }
                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {

                    //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                    playerMoving = true;
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                }
                if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
                {
                    myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
                }
                if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
                }
                if (Input.GetKeyDown(KeyCode.J))
                {
                    attackTimeCounter = attackTime;
                    attacking = true;
                    myRigidbody.velocity = Vector2.zero;
                    anim.SetBool("Attack", true);
                }

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
                {
                    currentMoveSpeed = moveSpeed * diagonalMoveModifier;
                }
                else
                {
                    currentMoveSpeed = moveSpeed;
                }




        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }
}
