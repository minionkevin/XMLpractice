using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;


public class SerializeDic<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

        //跳过root
        reader.Read();

        while(reader.NodeType!=XmlNodeType.EndElement)
        {
            TKey key = (TKey)keySer.Deserialize(reader);
            TValue value = (TValue)valueSer.Deserialize(reader);
            this.Add(key, value);
        }
        //root end
        reader.Read();
    }

    //序列化规则
    public void WriteXml(XmlWriter writer)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer valueSer = new XmlSerializer(typeof(TValue));

        foreach(KeyValuePair<TKey,TValue> kv in this)
        {
            //键值对 序列化
            keySer.Serialize(writer, kv.Key);
            valueSer.Serialize(writer, kv.Value);
        }
    }
}
