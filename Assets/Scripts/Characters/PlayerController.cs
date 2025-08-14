using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator anim;
    private GameObject attackTarget;
    private float lastAttackTime;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        MouseManager.Instance.OnMouseClicked += MoveToTarget;
        MouseManager.Instance.OnEnemyClicked += EventAttack;
    }

    void Update()
    {
        SwitchAnimation();

        lastAttackTime -= Time.deltaTime;
    }

    private void SwitchAnimation()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    public void MoveToTarget(Vector3 target)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        agent.destination = target;
    }

    private void EventAttack(GameObject targert)
    {
        if (targert != null)
        {
            attackTarget = targert;
            StartCoroutine(MoveToAttackTarget());
        }
    }

    IEnumerator MoveToAttackTarget()
    {
        agent.isStopped = false;

        transform.LookAt(attackTarget.transform);

        while (Vector3.Distance(attackTarget.transform.position, transform.position) > 1)
        {
            agent.destination = attackTarget.transform.position;
            yield return null;
        }

        agent.isStopped = true;
        //Attack

        if (lastAttackTime < 0)
        {
            anim.SetTrigger("Attack");
            //ÖØÖÃÀäÈ´Ê±¼ä
            lastAttackTime = 0.5f;
        }
    }
}
