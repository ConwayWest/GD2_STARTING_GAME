using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NETWORK_ENGINE;
using UnityEngine.UI;

public class NetworkPlayer : NetworkComponent
{
    public int UserColor;
    public int UserShape;
    public string UserName;
    public bool Ready = false;
    public override void HandleMessage(string flag, string value)
    {
        if (flag == "COLOR")
        {
            UserColor = int.Parse(value);
            if (IsServer)
            {
                SendUpdate("COLOR", value);
            }
        }

        if (flag == "SHAPE")
        {
            UserShape = int.Parse(value);
            if(IsServer)
            {
                SendUpdate("SHAPE", value);
            }
        }

        if (flag == "UNAME")
        {
            UserName = value;
            if(IsServer)
            {
                SendUpdate("UNAME", value);
            }
        }

        if (flag == "CLIENTREADY")
        {
            Ready = bool.Parse(value);
            if(IsServer)
            {
                SendUpdate("CLIENTREADY", value);
            }
        }

        if (flag == "CREATEPLAYER")
        {
            if (IsServer)
            {
                if (UserColor == 0)
                {
                    if (UserShape == 0)
                    {
                        MyCore.NetCreateObject(0, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                    else if (UserShape == 1)
                    {
                        MyCore.NetCreateObject(1, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                    else if (UserShape == 2)
                    {
                        MyCore.NetCreateObject(2, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                }
                else if (UserColor == 1)
                {
                    if (UserShape == 0)
                    {
                        MyCore.NetCreateObject(3, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                    else if (UserShape == 1)
                    {
                        MyCore.NetCreateObject(4, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                    else if (UserShape == 2)
                    {
                        MyCore.NetCreateObject(5, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                }
                else if (UserColor == 2)
                {
                    if (UserShape == 0)
                    {
                        MyCore.NetCreateObject(6, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                    else if (UserShape == 1)
                    {
                        MyCore.NetCreateObject(7, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                    else if (UserShape == 2)
                    {
                        MyCore.NetCreateObject(8, Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                    }
                }

            }
        }
    }

    public override IEnumerator SlowUpdate()
    {
        if (!IsLocalPlayer)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }

        //if (IsLocalPlayer)
        //{
        //    this.transform.GetChild(0).gameObject.SetActive(true);
        //}
        yield return new WaitForSeconds(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int c)
    {
        // Color = c;
        SendCommand("COLOR", c.ToString());
    }

    public void ChangeShape(int s)
    {
        // Shape = s;
        SendCommand("SHAPE", s.ToString());
    }

    public void ChangeName(string n)
    {
        // Name = n;
        SendCommand("UNAME", n);
    }

    public void ReadyStatus()
    {
        SendCommand("CLIENTREADY", "True");
        //SendCommand("CREATEPLAYER", 0.ToString());
        //this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
