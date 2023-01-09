using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadInAbyss : MonoBehaviour
{
    
    public GameObject bloodSprayPrefab;
    private SpriteRenderer spriteRenderer;
    private GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.transform.tag == "PlayerCenter")
        {
            Debug.Log("Down" + coll.transform.tag);
            GameManager.instance.RestartGame(3f);
            StartCoroutine(SprayBlood(3f, coll.transform.position, player));
        }
    }

    private IEnumerator SprayBlood(float delay, Vector2 position, GameObject player)
    {
        var bloodSpray = (GameObject)Instantiate(bloodSprayPrefab, position, Quaternion.identity);
        Destroy(bloodSpray, 3f);
        Destroy(player);
        yield return new WaitForSeconds(delay);
    }
}
