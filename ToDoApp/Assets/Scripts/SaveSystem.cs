using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem  
{
    // Start is called before the first frame update
    public static void Save(StoreData sd)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sfl";
        FileStream stream = new FileStream(path,FileMode.Create);
        
    }
  
}
