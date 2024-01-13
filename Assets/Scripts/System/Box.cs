using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Animator anm;
    bool isDie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("cham");
        //if (!collision.CompareTag("Player"))
        {
            if (!isDie)
            {
                isDie = true;
                anm.Play("die");
                Invoke("_des", 0.2f);
            }
        }
    }
    void _des()
    {

        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
