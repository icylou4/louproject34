using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("floats")]
    public float moveSpeed;
    public float patrolTime;
    [Header("bools")]
    public bool xPatrol;
    public bool yPatrol;
    public bool zPatrol;
    public bool movePlayer;
    [Header("refs")]
    public Vector3 direction;
    public CharacterController playerController; 
    void Start()
    {
        StartCoroutine(xRoutine());
        StartCoroutine(yRoutine());
        StartCoroutine(zRoutine());
        playerController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*Time.deltaTime*moveSpeed);
        if(movePlayer)
        {
            playerController.Move(direction*Time.deltaTime*moveSpeed);
        }
    }

    IEnumerator xRoutine()
    {
        while(xPatrol)
        {
            direction = Vector3.left;
            yield return new WaitForSeconds(patrolTime);
            direction = Vector3.right;
            yield return new WaitForSeconds(patrolTime);
        }
    }
    IEnumerator yRoutine()
    {
        while(yPatrol)
        {
            direction = Vector3.up;
            yield return new WaitForSeconds(patrolTime);
            direction = Vector3.down;
            yield return new WaitForSeconds(patrolTime);
        }
    }
    IEnumerator zRoutine()
    {
        while(zPatrol)
        {
            direction = Vector3.forward;
            yield return new WaitForSeconds(patrolTime);
            direction = Vector3.back;
            yield return new WaitForSeconds(patrolTime);
        }
    }
}
