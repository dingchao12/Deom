using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prop : MonoBehaviour {
    public PropData data;

    void Start ()
    {
        Init();
    }
    void Init()
    {
        var image = gameObject.GetComponent<Image>();
        var imageShow = Resources.Load<Sprite>("Image/" + data.Pictrue);
        image.sprite = imageShow;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (data.ID == "3")
    //        {
    //                Destroy(gameObject);
    //                if (collision.gameObject.GetComponent<Character>().data.ID == "1")
    //                {
    //                    //collision.gameObject.GetComponent<Character>().ChangeLevel(CreatCollisionData("2"));
    //                   // collision.gameObject.GetComponent<Character>().data = CreatCollisionData("2");
    //                }
    //                if (collision.gameObject.GetComponent<Character>().data.ID == "2")
    //                {
    //                   // collision.gameObject.GetComponent<Character>().ChangeLevel(CreatCollisionData("2"));
    //                   // collision.gameObject.GetComponent<Character>().data = CreatCollisionData("3");
    //                }
    //                if (collision.gameObject.GetComponent<Character>().data.ID == "3")
    //                {
    //                   // collision.gameObject.GetComponent<Character>().ChangeLevel(CreatCollisionData("2"));
    //                   // collision.gameObject.GetComponent<Character>().data = CreatCollisionData("4");
    //                }
                
    //        }
    //    }
    //}

    
}
