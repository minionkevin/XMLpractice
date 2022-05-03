using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestItem
{
    public int id = 12;
    public int num = 100;
}

public class Test
{
    public int testNum;
    public string testString;

    public TestItem item = new TestItem();
    public int[] arr;
    public List<TestItem> list;
    public SerializeDic<int, TestItem> dic;
}
public class TestObj : MonoBehaviour
{
    void Start()
    {
        /*
         * save data
        Test t = new Test();
        t.testNum = 1;
        t.testString = "kevin";
        t.item = new TestItem();
        t.arr = new int[12];
        t.dic = new SerializeDic<int, TestItem>() { { 1, new TestItem() } };
        t.dic.Add(0, new TestItem());

        XMLDataMgr.Instance.saveData(t, "TestSaving");*/


        //load data
        Test t = XMLDataMgr.Instance.loadData(typeof(Test), "TestSaving") as Test;
        Debug.Log(t.testString);
    }

}
