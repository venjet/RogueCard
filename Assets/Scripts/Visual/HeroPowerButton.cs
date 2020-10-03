using UnityEngine;
using System.Collections;


//教程中这个脚本是绑定在Cylinder上的，不过现在的Unity已经支持Capsule Collider 2D了，所以我直接绑在了父对象上。
public class HeroPowerButton : MonoBehaviour {

    public AreaPosition owner;

    public GameObject Front;
    public GameObject Back;

    public GameObject Glow;

    private bool wasUsed = false;
    public bool WasUsedThisTurn
    { 
        get
        {
            return wasUsed;
        } 
        set
        {
            wasUsed = value;
            if (!wasUsed)
            {
                Front.SetActive(true);
                Back.SetActive(false);
            }
            else
            {
                Front.SetActive(false);
                Back.SetActive(true);
                Highlighted = false;
            }
        }
    }

    private bool highlighted = false;
    public bool Highlighted
    {
        get{ return highlighted; }

        set
        {
            highlighted = value;
            Glow.SetActive(highlighted);
        }
    }

    void OnMouseDown()
    {
        if (!WasUsedThisTurn && Highlighted)
        {
            GlobalSettings.Instance.Players[owner].UseHeroPower();
            WasUsedThisTurn= !WasUsedThisTurn;
        }
    }
}
