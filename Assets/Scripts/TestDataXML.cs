using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TestDataXML : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		DataSet db = new DataSet();
		db.ReadXml("./ex.xml");
		DataTable table = db.Tables[0];
		foreach(DataRow row in table.Rows)
		{
			foreach(DataColumn column in table.Columns)
			{
				Debug.Log(row[column].ToString());
			}
		}
    }
}
