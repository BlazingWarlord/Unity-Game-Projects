using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AddTask : MonoBehaviour
{
    public GameObject input;
    public TMP_InputField input_text;
    public Toggle toggle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInput()
    {
        input_text = input.GetComponent<TMP_InputField>();
        Debug.Log(input_text.text);
        PlayerPrefs.SetString("NewTask", input_text.text);
        SceneManager.LoadScene(0);



    }
}
