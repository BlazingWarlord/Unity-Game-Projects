using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DeleteTask : MonoBehaviour
{
    public Transform taskname;
    public Transform parent;
    public Transform parent2;
    //public StoreData sd;
    // Start is called before the first frame update
    void Start()
    {
        //sd = Canvas.GetComponent<StoreData>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete()
    {
        parent = transform.parent;
        taskname = parent.Find("TaskName");
        TextMeshProUGUI TaskName = taskname.GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetString("Delete", TaskName.text);
        SceneManager.LoadScene(0);


    }
}
