using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public  class MonsterData
{
    public readonly string id;
    public readonly string level;
    public readonly string pictrue;
    public readonly string MoveSpeed;
    public readonly string buttle;
    public float Value(string m)
    {
        float  intA;
        float .TryParse(m, out intA);
        return intA;
    }
}
public class PropData
{
    public readonly string ID;
    public readonly string Pictrue;
}
public class CharacterData
{
    public readonly string id;
    public readonly string level;
    public readonly string pictrue;
    public readonly string MoveSpeed;
    public readonly string buttle;
    public float Value(string m)
    {
        float intA;
        float.TryParse(m, out intA);
        return intA;
    }
}

public class StaticData : MonoBehaviour {
    public static StaticData Instance;
    public Dictionary<string, MonsterData> monsterDictionary;
    public Dictionary<string, CharacterData> characterDictionary;
    public Dictionary<string, PropData> propdictionary;

    void Awake()
    {
        Instance = this;
        Init();
        LoadSence();
    }
    void Init()
    {
        monsterDictionary = Load<MonsterData>("Monster");
        characterDictionary = Load<CharacterData>("Character");
        propdictionary = Load< PropData>("Prop");
    }

    void LoadSence()
    {
        var temp = Resources.Load<GameObject>("Sence").gameObject;
        var sence = Instantiate(temp);
        sence.name = temp.name;
        sence.AddComponent<GameMode>();
    }

    public Dictionary<string, T> Load<T>(string rName) 
    {
        string str;
        {
            TextAsset textAsset = Resources.Load<TextAsset>(rName);
            if (textAsset == null)
            {
                return null;
            }
            str = textAsset.text;
        }
        Dictionary<string, T> data = JsonMapper.ToObject<Dictionary<string, T>>(str);
        return data;
    }

}
