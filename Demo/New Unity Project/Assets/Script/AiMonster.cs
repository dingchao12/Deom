using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AiMonster : MonoBehaviour
{
    GameObject muzzle;
    GameObject bulletPiont;
    GameObject rayPiont1;
    GameObject rayPiont2;
    Vector3 MoveVector;
    Vector3 endPosition;
    float time1;
    bool onMove = false;
    int m,state;
    public PublicMonsterData data;
    Animator animator;
    Image image;
    void Start()
    {
        muzzle = gameObject.transform.Find("MuzzlePiont").gameObject;
        bulletPiont = GameObject.Find("BulletPiont");
        rayPiont1 = gameObject.transform.Find("RayPiont1").gameObject;
        rayPiont2 = gameObject.transform.Find("RayPiont2").gameObject;
        animator = gameObject.GetComponent<Animator>();
        Init(data);
    }
    void Init(PublicMonsterData data)
    {
        if (data != null)
        {
            image = gameObject.transform.Find("Draw").GetComponent<Image>();
            Debug.Log(image.sprite.name + "   ++++++");
            var image_Show = Resources.Load<Sprite>("Image/" + data.picture);
            image.sprite = image_Show;
            Debug.Log(image.sprite.name);
        }
    }

    void Update()
    {
        if (onMove==false)
        {
            onMove = true;
            m = Random.Range(0, 4);
            if (m == 0)
            {
                MoveVector = new Vector3(1, 0, 0);
                state = 1;
            }
            if (m == 1)
            {
                MoveVector = new Vector3(-1, 0, 0);
                state = 1;
            }
            if (m == 2)
            {
                MoveVector = new Vector3(0, 1, 0);
                state = 1;
            }
            if (m == 3)
            {
                MoveVector = new Vector3(0, -1, 0);
                state = 1;
            }
            endPosition = transform.position + MoveVector * 25;
        }
        time1 += Time.deltaTime;
        if (state==1)
        {
            Move();
        }
        if (time1 > 1.5)
        {
            Fire();
            time1 = 0;
        }
    }

    void Move()
    {
        if (endPosition == transform.position)
        {
            int time = Random.Range(0, 5);
            if (time == 0)
            {
                onMove = false;
                return;
            }
            else
            {
                endPosition = transform.position + MoveVector * 25;
            }
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
                    transform.position += MoveVector;
                }
                else
                {
                    onMove = false;
                    Debug.Log("m:" + m);
                }
            }
            else if (hit2.collider == null)
            {
                if (hit1.collider.tag == "Wall1")
                {
                    transform.position += MoveVector;
                }
                else
                {
                    onMove = false;
                }
            }
            else
            {
                if (hit1.collider.tag == "Wall1" && hit2.collider.tag == "Wall1")
                {
                    transform.position += MoveVector;
                }
                else
                {
                    onMove = false;
                }
            }
        }
        else
        {
            transform.position += MoveVector;
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
        var bulletDemo = Resources.Load<GameObject>("Bullet");
        var bullet = Instantiate(bulletDemo, muzzle.transform);
        bullet.transform.SetParent(bulletPiont.transform);
        bullet.transform.localScale = Vector3.one;
        if (data.Level == 4)
        {
            bullet.AddComponent<Bullet1>().motherObject = gameObject;
        }
        else
        {
            bullet.AddComponent<Bullet>().motherObject = gameObject;
        }
    }
    public void Die()
    {
        state=0;
        image.gameObject.SetActive(false);
        animator.Play("Die", 0);
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
