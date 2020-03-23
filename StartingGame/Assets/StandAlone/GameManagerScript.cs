using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NETWORK_ENGINE;

public class GameManagerScript : NetworkComponent
{
    public bool GameStarted = false;
    NetworkCore MyCore;
    public NetworkPlayer[] temp;
    public bool playerSpawned = false;
    public GameObject[] PlayerManagers;

    public override void HandleMessage(string flag, string value)
    {
        if (flag == "START")
        {
            if (IsClient)
            {
                Debug.Log("here");
                PlayerManagers = GameObject.FindGameObjectsWithTag("NetPlayManager");
                for (int i = 0; i < PlayerManagers.Length; i++)
                {
                    PlayerManagers[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }

    public override IEnumerator SlowUpdate()
    {
        while (true)
        {
            yield return new WaitWhile(() => MyCore.IsConnected == false);
            while (MyCore.IsServer)
            {
                while (!GameStarted || MyCore.Connections.Count == 0)
                {
                    Debug.Log("The number of players is : " + MyCore.Connections.Count);

                    if (MyCore.Connections.Count != 0)
                    {
                        GameStarted = true;
                    }
                    temp = GameObject.FindObjectsOfType<NetworkPlayer>();
                    
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if(!temp[i].Ready)
                        {
                            GameStarted = false;
                        }
                    }
                    yield return new WaitForSeconds(MyCore.MasterTimer);
                }

                SendUpdate("START", "True");

                if (playerSpawned == false)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        GameObject tempGo;
                        if (temp[i].UserColor == 0)
                        {
                            if (temp[i].UserShape == 0)
                            {
                                tempGo = MyCore.NetCreateObject(0, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                            else if (temp[i].UserShape == 1)
                            {
                                tempGo = MyCore.NetCreateObject(1, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                            else if (temp[i].UserShape == 2)
                            {
                                tempGo = MyCore.NetCreateObject(2, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                        }
                        else if (temp[i].UserColor == 1)
                        {
                            if (temp[i].UserShape == 0)
                            {
                                tempGo = MyCore.NetCreateObject(3, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                            else if (temp[i].UserShape == 1)
                            {
                                tempGo = MyCore.NetCreateObject(4, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                            else if (temp[i].UserShape == 2)
                            {
                                tempGo = MyCore.NetCreateObject(5, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                        }
                        else if (temp[i].UserColor == 2)
                        {
                            if (temp[i].UserShape == 0)
                            {
                                tempGo = MyCore.NetCreateObject(6, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                            else if (temp[i].UserShape == 1)
                            {
                                tempGo = MyCore.NetCreateObject(7, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                            else if (temp[i].UserShape == 2)
                            {
                                tempGo = MyCore.NetCreateObject(8, temp[i].Owner, new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(-5, 5)));
                                tempGo.GetComponent<GameCharacter>().Uname = temp[i].UserName;
                            }
                        }
                    }
                    playerSpawned = true;
                }

                yield return new WaitForSeconds(MyCore.MasterTimer);
            }
            yield return new WaitWhile(() => MyCore.IsConnected);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MyCore = GameObject.FindObjectOfType<NetworkCore>();
        StartCoroutine("SlowUpdate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
