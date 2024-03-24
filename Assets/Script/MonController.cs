using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonController : MonoBehaviour
{
    public Transform[] targetPoint;
    public int currentPoint;

    public NavMeshAgent agent;
    public Animator animator;

    public float waitAtPoint = 2f;
    private float waitCounter;


    private FOV fv;

    public enum AIState
    {
        isDead, isSeekTargetPoint, isSeekPlayer, isAttack
    }
    public AIState state;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
       // Debug.Log(distanceToPlayer);

        fv = GetComponent<FOV>();
        if (!PlayerController.instance.isDead)
        {
            if (fv.seePlayer)
            {
                state = AIState.isSeekPlayer;
                state = AIState.isAttack;
            }
            else if (!fv.seePlayer)
            {
                state = AIState.isSeekTargetPoint;
            }
            
        }
        else
        {
            state = AIState.isSeekTargetPoint;
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
       
        switch (state)
        {
            case AIState.isDead:
                break;
            case AIState.isSeekPlayer:
                agent.SetDestination(PlayerController.instance.transform.position);
                animator.SetBool("Run", true);
                animator.SetBool("Attack", false);
                break;
            case AIState.isSeekTargetPoint:
                agent.SetDestination(targetPoint[currentPoint].position);
                agent.stoppingDistance = 0;
                animator.SetBool("Run", true);
                animator.SetBool("Attack", false);
                if (agent.remainingDistance <= .2f)
                {
                    if (waitCounter > 0)
                    {
                        waitCounter -= Time.deltaTime;
                        animator.SetBool("Run", false);

                    }
                    else
                    {
                        currentPoint++;
                        waitCounter = waitAtPoint;
                        animator.SetBool("Run", true);
                    }

                    if (currentPoint >= targetPoint.Length)
                    {
                        currentPoint = 0;
                    }
                    agent.SetDestination(targetPoint[currentPoint].position);
                }
                break;
            case AIState.isAttack:
                RotateTowardPlayer();
                agent.stoppingDistance = 1f;
                agent.SetDestination(PlayerController.instance.transform.position);
                animator.SetBool("Attack", false);
                animator.SetBool("Run", true);
                if (distanceToPlayer < 1f)
                {
                    animator.SetBool("Attack", true);
                    animator.SetBool("Run", false);
                }
                
                break;
        }
       
       
        
    }
    void RotateTowardPlayer()
    {
        Vector3 direction = (PlayerController.instance.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
