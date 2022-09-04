using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StoreData : MonoBehaviour
{
    public static List<string> tasks = new List<string>();
    public GameObject listelement;
    public Transform TaskName;
    public TextMeshProUGUI TaskText;
    public int tasknumber = 0;
    public GameObject listhead;

    // Start is called before the first frame update
    //Vector3(295.799988,233,0)
    private void Awake()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sfl";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            tasks = bf.Deserialize(stream) as List<string>;
            stream.Close();
        }
        else
        {
            Debug.Log("No File Found");
        }
    }
    void Start()
    {
        
        if(PlayerPrefs.GetString("NewTask") != "")
        {
            AddToList();
            PlayerPrefs.SetString("NewTask", "");
        }

        if (PlayerPrefs.GetString("Delete") != "")
        {
            RemovefromList();
            PlayerPrefs.SetString("Delete", "");
        }
        //TaskName = listelement.transform.Find("TaskName");
        //TaskText = TaskName.GetComponent<TextMeshProUGUI>();
        //TaskText.text = "Task is renamed !";

        //Vector3(4,56.9358521,0) and Vector3(0,84,0)
        foreach (string name in tasks)
        {
            float y = listhead.transform.position.y;
            GameObject clone1 = Instantiate(listelement);
            clone1.transform.parent = transform;
            clone1.transform.position = new Vector3(listhead.transform.position.x, y - (91 * tasknumber), 0);
            TaskName = clone1.transform.Find("TaskName");
            TaskText = TaskName.GetComponent<TextMeshProUGUI>();
            TaskText.text = name;
            tasknumber += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddToList()
    {
        Debug.Log((PlayerPrefs.GetString("NewTask")));
        if (PlayerPrefs.GetString("NewTask") != "")
        {
            tasks.Add(PlayerPrefs.GetString("NewTask"));
        }
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sfl";
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, tasks);
        stream.Close();
    }

    void RemovefromList()
    {
        Debug.Log((PlayerPrefs.GetString("Delete")));
        if (PlayerPrefs.GetString("Delete") != "")
        {
            tasks.Remove(PlayerPrefs.GetString("Delete"));
        }
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sfl";
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, tasks);
        stream.Close();
    }

    
}
