using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public  class MonsterData
{
    public readonly string ID;
    public readonly string Level;
    public readonly string Picture;
    public readonly string moveSpeed;
    public readonly string Bullet;
    public float Value(string m)
    {
        float  intA;
        float .TryParse(m, out intA);
        return intA;
    }
}

public class CharacterData
{
    public readonly string ID;
    public readonly string Level;
    public readonly string Picture;
    public readonly string moveSpeed;
    public readonly string Bullet;
    public float Value(string m)
    {
        float intA;
        float .TryParse(m, out intA);
        return intA;
    }
}

public class StaticData : MonoBehaviour {
    public static StaticData Instance;
    public Dictionary<string, MonsterData> monsterDictionary;
    public Dictionary<string, CharacterData> characterDictionary;

    void Awake()
    {
        Instance = this;
    }
	void Start ()
    {
       
    }
    void Init()
    {
        monsterDictionary = Load<Dictionary<string, MonsterData>>("dd");
        characterDictionary = Load<Dictionary<string, CharacterData>>("dd");
    }
	
	void Update ()
    {
		
	}

    public static T Load<T>(string name)
    {
        string rName = name;
        string readFilePath = Application.persistentDataPath + "/" + rName + ".txt";
        string str;
        T data = default(T);
        if (File.Exists(readFilePath))
        {
            StreamReader textData = File.OpenText(readFilePath);
            str = textData.ReadLine();
            textData.Close();
            textData.Dispose();
            data = JsonMapper.ToObject<T>(str);
        }
        return data;
    }

}
