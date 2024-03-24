using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Keycount : MonoBehaviour
{
    public int key;
    public Text keyText;
    public bool keysfinish = false;
    // Start is called before the first frame update
    public static Keycount instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (key==7)
        {
            keysfinish = true;
        }
        else
        {
            keysfinish = false;
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {

                key++;
                keyText.text = "Key = " + key;
                Destroy(other.gameObject);

            
        }
        else if (other.tag == "Keyfake")
        {
            Destroy(other.gameObject);
        }
    }
}
