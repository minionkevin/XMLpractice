using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

//singleton
public class XMLDataMgr 
{
    private static XMLDataMgr instance = new XMLDataMgr();
    public static XMLDataMgr Instance => instance;



    private XMLDataMgr() { }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data">saving obj</param>
    /// <param name="fileName">file name</param>
    public void saveData(object data, string fileName)
    {
        //1.path
        string path = Application.persistentDataPath + "/" + fileName + ".xml";

        //2.save
        using (StreamWriter w = new StreamWriter(path))
        {
            //3.serialize
            XmlSerializer s = new XmlSerializer(data.GetType());
            s.Serialize(w, data);
        }
    }

    public object loadData(Type type, string fileName)
    {
        //1.check if exits
        string path = Application.persistentDataPath + "/" + fileName + ".xml";
        if(!File.Exists(path))
        {
            path = Application.streamingAssetsPath + "/" + fileName + ".xml";
            if (!File.Exists(path))
            {
                //not exist return empty new obj
                return Activator.CreateInstance(type);
            }
        }

        //2.read
        using (StreamReader r = new StreamReader(path))
        {
            XmlSerializer s = new XmlSerializer(type);
            return s.Deserialize(r);
        }
    }
}
