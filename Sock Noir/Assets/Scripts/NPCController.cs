using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{    
    private SpriteRenderer baseSock;
    private SpriteRenderer hat;
    private SpriteRenderer blush;
    private SpriteRenderer accessory;
    private SpriteRenderer dress;
    private SpriteRenderer eyebrow;
    private SpriteRenderer eye;

    private Sprite[] hats;
    private Sprite[] basesocks;
    private Sprite[] blushes;
    private Sprite[] accessories;
    private Sprite[] dresses;
    private Sprite[] eyebrows;
    private Sprite[] eyes;


    void Start()
    {        
        baseSock = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();        
        hat = this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();        
        blush = this.gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();        
        accessory = this.gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();        
        dress = this.gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>();
        eyebrow = this.gameObject.transform.GetChild(5).GetComponent<SpriteRenderer>();
        eye = this.gameObject.transform.GetChild(6).GetComponent<SpriteRenderer>();
        

        if(baseSock.sprite == null){            
            Debug.Log("Assign Random BaseSock");
            basesocks = Resources.LoadAll<Sprite>("basesock");
            baseSock.sprite = basesocks[Random.Range(0, basesocks.Length)];
        }

        if(baseSock.color.Equals(Color.white)){
            Debug.Log("Assign Random Color");
            baseSock.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        }

        if(hat.sprite == null){            
            Debug.Log("Assign Random hat");
            hats = Resources.LoadAll<Sprite>("hats");
            hat.sprite = hats[Random.Range(0, hats.Length)];
        }

        if(blush.sprite == null){            
            Debug.Log("Assign Random blush");
            blushes = Resources.LoadAll<Sprite>("blushes");
            blush.sprite = blushes[Random.Range(0, blushes.Length)];
        }

        if(accessory.sprite == null){            
            Debug.Log("Assign Random accessory");
            accessories = Resources.LoadAll<Sprite>("accessories");
            if(accessories.Length > 0){
                Debug.Log("Some accessory found :(");
                accessory.sprite = accessories[Random.Range(0, accessories.Length)];
            }
            else{
                Debug.Log("No accessory found :(");
            }
        }

        if(dress.sprite == null){            
            Debug.Log("Assign Random dress");
            dresses = Resources.LoadAll<Sprite>("dresses");
            dress.sprite = dresses[Random.Range(0, dresses.Length)];
        }

        if(eyebrow.sprite == null){            
            Debug.Log("Assign Random eyebrow");
            eyebrows = Resources.LoadAll<Sprite>("eyebrows");
            eyebrow.sprite = eyebrows[Random.Range(0, eyebrows.Length)];
        }

        if(eye.sprite == null){            
            Debug.Log("Assign Random eye");
            eyes = Resources.LoadAll<Sprite>("eyes");
            eye.sprite = eyes[Random.Range(0, eyes.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

