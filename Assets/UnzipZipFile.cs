using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.IO.Compression;

public class UnzipZipFile : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetZipFile());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetZipFile()
    {
        DownloadHandlerFile DHF = new DownloadHandlerFile(Path.Combine(Application.persistentDataPath, "EpicMAR.zip"));
        UnityWebRequest req = UnityWebRequest.Get("http://epic-demo.com/epicmar/EpicMAR.zip");
        req.downloadHandler = DHF;
        yield return req.SendWebRequest();
        if(File.Exists(Path.Combine(Application.persistentDataPath, "EpicMAR.dat")))
            File.Delete(Path.Combine(Application.persistentDataPath, "EpicMAR.dat"));
        if (File.Exists(Path.Combine(Application.persistentDataPath, "EpicMAR.xml")))
            File.Delete(Path.Combine(Application.persistentDataPath, "EpicMAR.xml"));
        if (File.Exists(Path.Combine(Application.persistentDataPath, "EpicMAR.zip")))
        {
            System.IO.Compression. ZipFile.ExtractToDirectory(Path.Combine(Application.persistentDataPath, "EpicMAR.zip"), Application.persistentDataPath);
        }
        print(Application.persistentDataPath);

    }
}
