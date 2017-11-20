using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    GameObject muzzle;
    GameObject bulletPiont;
    GameObject rayPiont1;
    GameObject rayPiont2;
    bool OnMove=false;
    Vector3 MoveVector ;
    public float speed =1;
    int state;
    int dance;
    Vector3 endPosition;
    Animator animator;
    public PublicCharacterData data;
    Image m;
    void Start()
    {
        muzzle = gameObject.transform.Find("MuzzlePiont").gameObject;
        rayPiont1 = gameObject.transform.Find("RayPiont1").gameObject;
        rayPiont2 = gameObject.transform.Find("RayPiont2").gameObject;
        bulletPiont = GameObject.Find("BulletPiont");
        animator = gameObject.GetComponent<Animator>();
        m = gameObject.transform.Find("Image").GetComponent<Image>();
        animator.Play("Bron", 0);
        StartCoroutine(OnDelay(3, () =>
        {
            m.gameObject.SetActive(false);
        }));
    }
    void Init(PublicCharacterData data)
    {
        animator.Play("Bron", 0);
        StartCoroutine(OnDelay(3, () =>
         {
             m.gameObject.SetActive(false);
         }));
        var image = gameObject.GetComponent<Image>();
        var image_Show = Resources.Load<Image>(data.picture).sprite;
        image.sprite = image_Show;
    }

    void Update()
    {
        if (OnMove==false)
        {
            state = 0;
            if (Input.GetKey(KeyCode.D))
            {
                MoveVector = new Vector3(1, 0, 0);
                state = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                MoveVector = new Vector3(0, -1, 0);
                state = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                MoveVector = new Vector3(-1, 0, 0);
                state = 1; 
            }
            if (Input.GetKey(KeyCode.W))
            {
                MoveVector = new Vector3(0, 1, 0);
                state = 1;
            }
            endPosition=transform.position+ MoveVector * 25;
        }
        if (state!=0)
        {
            OnMove = true;
            Move();
        }
        Fire();
    }

    void Move()
    {
        Debug.Log("dance= "+ transform.position);
        if ((endPosition - transform.position).magnitude<1f)
        {
            OnMove = false;
            return;
        }
        Trun(MoveVector);
        RaycastHit2D hit1 = Physics2D.Raycast(rayPiont1.transform.position, MoveVector, 0.1f);
        RaycastHit2D hit2 = Physics2D.Raycast(rayPiont2.transform.position, MoveVector, 0.1f);
        if (hit1.collider != null || hit2.collider != null)
        {
            if (hit1.collider == null)
            {
                if (hit2.collider.tag == "Wall1")
                {
                    transform.position += MoveVector*speed ;
                }
                else
                {
                    OnMove = false ;
                }
            }
            else if (hit2.collider == null)
            {
                if (hit1.collider.tag == "Wall1")
                {
                    transform.position = MoveVector*speed ;
                }
                else
                {
                    OnMove =false;
                }
            }
            else
            {
                if (hit1.collider.tag == "Wall1" && hit2.collider.tag == "Wall1")
                {
                    transform.position = MoveVector*speed;
                }
                else
                {
                    OnMove = false ;
                }
            }
        }
        else
        {
            transform.position += MoveVector*speed ;
        }
    }

    void Trun(Vector3 moveVector)
    {
        var angel = Vector3.Angle(transform.right, moveVector);
        var normal = Vector3.Cross(transform.right, moveVector);
        angel *= Mathf.Sign(Vector3.Dot(transform.forward, normal));
        var vector = transform.right.normalized - moveVector.normalized;
        if (vector.magnitude > 0.1f)
        {
            transform.Rotate(transform.forward, angel);
        }
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bulletDemo = Resources.Load<GameObject>("Bullet");
            var bullet = Instantiate(bulletDemo, muzzle.transform);
            bullet.transform.SetParent(bulletPiont.transform);
            bullet.transform.localScale = Vector3.one;
            bullet.AddComponent<Bullet>().motherObject=gameObject;
        }
    }

    public void Die()
    {
        state = 0;
        animator.Play("Die",0);
        StartCoroutine(OnDelay(0.3f, () =>
        {
            Destroy(gameObject);
        }));
    }

    IEnumerator OnDelay(float time, UnityEngine.Events.UnityAction rFunc)
    {
        yield return new WaitForSeconds(time);
        rFunc();
        yield return null;
    }


}
