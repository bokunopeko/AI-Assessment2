using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MosterState : MonoBehaviour
{
  public enum States
    {
        idle,
        whenPlayerGetClose,
        attackedByPlayer,
        getCaught,


    }

    public States states;
    private Vector2 position;
    private void Start()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();

        collider.enabled = true;
        collider.radius = 10f;
        collider.isTrigger = true;
        NextState();
        position = gameObject.transform.position;
    }

    void NextState()
    {
        switch (states)
        {
            case States.idle:
                break;
            case States.whenPlayerGetClose:
                break;
            case States.attackedByPlayer:
                break;
            case States.getCaught:
                break;
        }
    }

    IEnumerator IdleState()
    {
        
        while ( states == States.idle )
        {
            float randomX = Random.Range(-10f, 10f);
            float randomY = Random.Range(-10f, 10f);
            Vector2 randomDirection = new Vector2( randomX, randomY );
            
            


            
            transform.position = transform.right * randomDirection * Time.deltaTime;
            yield return null;

        }
        
        NextState();
    }
    IEnumerator WhenPlayerGetCloseState()
    {
        
        while ( states == States.whenPlayerGetClose )
        {
            Debug.Log("working");
            yield return null;
        }
        

       
        NextState();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("player enter");
            states = States.whenPlayerGetClose;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            while (states == States.whenPlayerGetClose)
            {
                StartCoroutine(DelayedRunning());

            }
          
        }

    }

    IEnumerator DelayedRunning()
    {
        Debug.Log("player Exit");
      
        yield return new WaitForSeconds(5f );
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);


    }

    IEnumerator AttackByPlayerState()
    {
        yield return null;
        NextState();
    }

    IEnumerator GetCaughtStat()
    {
        yield return null;
        NextState();
    }

}
