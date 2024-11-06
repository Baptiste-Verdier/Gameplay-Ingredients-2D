using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class ObjectInterractions : MonoBehaviour
{
    private GameObject bridge;
    private GameObject lever;
    public Sprite fixedHandle;
    public Sprite turnedHandle;

    private bool handleFixed = false;
    private bool nearLever = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && nearLever == true && handleFixed == false && PlayerInventory.Instance.IsInInventory("LEVERHANDLE") == true)
        { 
            FixingHandle();
            PlayerInventory.Instance.RemoveItemFromInventory("LEVERHANDLE");
        }
      else if (Input.GetKeyDown(KeyCode.W) && nearLever == true && handleFixed == true)
        {
            LoweringBridge();
            lever.GetComponent<SpriteRenderer>().sprite = turnedHandle;
        }
    }

    private bool FixingHandle() 
    {
        lever = GameObject.Find("Switch Broken");
        lever.GetComponent<SpriteRenderer>().sprite = fixedHandle;
        return handleFixed = true;
    }

    private void LoweringBridge()
    {
             bridge = GameObject.Find("Bridge");
            bridge.GetComponent<Animator>().SetTrigger("Down");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if ( collision.CompareTag("Lever"))
        {
            nearLever = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Lever"))
        {
            nearLever = false;
        }
    }
    
}
