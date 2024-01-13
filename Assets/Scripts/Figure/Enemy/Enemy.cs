using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _type, id, move;
    [SerializeField] private float blood, speed, speedBullet;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator anm;
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private Blood bl;
    [SerializeField] private GameObject _bullet1, _bullet3, _light1, _light3, headGun, enemy, _bl, pa;
    
    Vector2 up, down, left, right;
    [SerializeField] private Vector2 velocity;
    bool isReset, isDie;

    // Start is called before the first frame update
    void Start()
    {
        objectManager = FindObjectOfType<ObjectManager>();
        _bl.SetActive(false);
        up = new Vector2(0, 1f);
        down = new Vector2(0, -1f);
        left = new Vector2(-1f, 0);
        right = new Vector2(1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (objectManager.isTime)
        {
            _rb.velocity = new Vector2(0, 0);
        }
        else
        {
            if (!isReset)
            {
                int randomNumber = Random.Range(1, 5);
                if (randomNumber == 1)
                {
                    velocity = up;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
                    move = 8;
                }
                else if (randomNumber == 2)
                {
                    velocity = down;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180f);
                    move = 2;
                }
                else if (randomNumber == 3)
                {
                    velocity = right;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90f);
                    move = 6;
                }
                else
                {
                    velocity = left;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90f);
                    move = 4;
                }
                isReset = true;
                Invoke("_reset", 3f);
                Invoke("getGun", 1f);

            }
            _rb.velocity = velocity * speed;
            if (!isDie)
                pa.transform.position = transform.position + new Vector3(0, 3.48f, 0);
            if (!isDie && blood < 0)
            {
                anm.Play("die");
                headGun.SetActive(false);
                Invoke("_des", 1f);
                isDie = true;
            }
        }
    }
    void _reset()
    {
        isReset = false;
    }    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("cham");
        velocity = new Vector2(0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_bl.activeSelf && collision.CompareTag("Bullet"))
        {
            _bl.SetActive(true);
            Invoke("closeBlood", 1f);
        }    
        //if (!isDie && collision.CompareTag("Bullet"))
        //{
        //    anm.Play("die");
        //    headGun.SetActive(false);
        //    Invoke("_des", 1f);
        //    isDie = true;
        //}
    }
    void _des()
    {
        enemy.SetActive(false);
        Destroy(enemy);
    }
    void closeBlood()
    {
        _bl.SetActive(false);
    }    
    void getGun()
    {
        GameObject newBullet;
        if (_type == 1)
        {
            newBullet = Instantiate(_bullet1, transform.position, _bullet1.transform.rotation);
            _light1.SetActive(true);
            Invoke("resetLight1", 0.3f);
        }
        else
        {
            newBullet = Instantiate(_bullet3, transform.position, _bullet3.transform.rotation);
            _light3.SetActive(true);
            Invoke("resetLight3", 0.3f);
        }

        if (move == 2)
        {
            newBullet.GetComponent<Bullet>().velocity = new Vector3(0, -speedBullet, 0);
            newBullet.transform.position = new Vector3(transform.position.x, transform.position.y - 0.7f, newBullet.transform.position.z);
            newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, -180f);
        }
        else if (move == 8)
        {
            newBullet.GetComponent<Bullet>().velocity = new Vector3(0, speedBullet, 0);
            newBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.7f, newBullet.transform.position.z);
            newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, 0f);
        }
        else if (move == 4)
        {
            newBullet.GetComponent<Bullet>().velocity = new Vector3(-speedBullet, 0, 0);
            newBullet.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, newBullet.transform.position.z);
            newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, 90f);
        }
        else
        {
            newBullet.GetComponent<Bullet>().velocity = new Vector3(speedBullet, 0, 0);
            newBullet.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, newBullet.transform.position.z);
            newBullet.transform.eulerAngles = new Vector3(newBullet.transform.eulerAngles.x, newBullet.transform.eulerAngles.y, -90f);
        }
        newBullet.GetComponent<Bullet>().setVelocity();
    }
    void resetLight1()
    {
        _light1.SetActive(false);
    }
    void resetLight3()
    {
        _light3.SetActive(false);
    }
    public void getBullet()
    {
        blood -= 40f;
        bl.blood = blood;

    }
}
