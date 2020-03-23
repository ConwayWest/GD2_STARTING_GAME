using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NETWORK_ENGINE;
using UnityEngine.UI;

public class GameCharacter : NetworkComponent
{
    public string Uname;
    public Text MyTextBox;
    public override void HandleMessage(string flag, string value)
    {
        if (flag == "UNAME")
        {

            Uname = value;
            MyTextBox.text = value;
        }
    }

    public override IEnumerator SlowUpdate()
    {
        //if (IsServer)
        //{
        //    NetworkPlayer[] AllPlayers = GameObject.FindObjectsOfType<NetworkPlayer>();
        //    for (int i = 0; i < AllPlayers.Length; i++)
        //    {
        //        if (AllPlayers[i].Owner == Owner)
        //        {
        //            Uname = AllPlayers[i].UserName;
        //            SendUpdate("UNAME", Uname);
        //        }
        //    }
        //}

        while (true)
        {
            if (IsServer)
            {
                if (IsDirty)
                {
                    SendUpdate("UNAME", Uname);
                    MyTextBox.text = Uname;
                    IsDirty = false;
                }
            }
            yield return new WaitForSeconds(MyCore.MasterTimer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
