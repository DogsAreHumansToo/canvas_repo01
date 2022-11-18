using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAlphaChange : MonoBehaviour
{

    //All of the background sprites
    public SpriteRenderer[] bgSprRenderer;
    //How much alpha to subtract per enemy killed
    public byte AlphaChange = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoreTransparency()
    {
        //Debug.Log("bgSprRend = " + bgSprRenderer.Length);
        for (int s = 0; s < bgSprRenderer.Length; s++)
        {


            Color32 c = bgSprRenderer[s].color;
            byte a = (byte)(c.a - (byte)AlphaChange);
            if (a < 0) a = 0;
            c.a = a;
            Debug.Log("Color = " + a);
            bgSprRenderer[s].color = c;
        }
    }

}
