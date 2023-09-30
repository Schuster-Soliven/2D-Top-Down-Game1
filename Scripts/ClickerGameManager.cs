using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ClickerGameManager : MonoBehaviour
{
    SaveData saveData;
    int clicks = 0;
    int increment_amt = 1;
    [SerializeField]
    TextMeshProUGUI clicksText;
    [SerializeField]
    SpriteSO spriteObject;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    bool randomColor = true;
    float height, width;
    Camera main;
    void Start()
    {
        DateTime d = new DateTime();
        DateTime.TryParse(PlayerPrefs.GetString("LastOnline", DateTime.Now.ToString()),out d);
        Debug.Log(DateTime.Now - d);

        saveData = ScriptableObject.CreateInstance<SaveData>();
        if(File.Exists(Application.persistentDataPath+"/CurScore.dat"))
        {
            Debug.Log(Application.persistentDataPath+"/CurScore.dat");
            JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.persistentDataPath+"/CurScore.dat"),saveData);
            clicks = saveData.clicks;
        }
    
        clicksText.text = clicks.ToString();
        main = Camera.main;
        height = main.orthographicSize;
        width = height * main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        clicks += increment_amt;
        clicksText.text = clicks.ToString();
        var p = Instantiate(prefab, new Vector3(UnityEngine.Random.Range(-width, width),
            UnityEngine.Random.Range(-height,height), 0),Quaternion.identity);
        var sr = p.GetComponent<SpriteRenderer>();
        sr.sprite = spriteObject.sprite;
        if(randomColor)
            sr.color = UnityEngine.Random.ColorHSV();
        else
            sr.color = spriteObject.color;
        p.GetComponent<ClickParticle>().maxScale = UnityEngine.Random.Range(spriteObject.scale*0.5f, spriteObject.scale*2f);
    }

    void OnDestroy()
    {
        ShuttingDown();
    }
    public void ShuttingDown()
    {
        PlayerPrefs.SetString("LastOnline",DateTime.Now.ToString());
        saveData.clicks = clicks;
        File.WriteAllText(Application.persistentDataPath+"/CurScore.dat", JsonUtility.ToJson(saveData));

    }
}
