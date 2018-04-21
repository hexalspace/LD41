using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;



public class Connection
{
    public Room room;
    public Vector2 offset;
}

public class Room
{
    public void addConnectedRoom(Connection c)
    {
        connectedRooms.Add(c);
    }

    public List<List<char>> getRoomCharMap()
    {
        var charMap = new List<List<char>>();
        foreach( var row in associatedGameObjects)
        {
            var currentRow = new List<char>();
            charMap.Add(currentRow);
            foreach (var gameObject in row)
            {
                var cs = gameObject.GetComponent<CharSerialization>();
                currentRow.Add(cs.value);
            }
        }
        return charMap;
    }

    public readonly List<Connection> connectedRooms = new List<Connection>();
    public readonly List<List<GameObject>> associatedGameObjects = new List<List<GameObject>>();
}

public class Director : MonoBehaviour
{
    private static readonly string commentStart = "//";
    private static readonly string prefabPath = "Prefab";
    private Dictionary<char, Object> charToUnityObject_ = new Dictionary<char, Object>();

    private Room activeRoom_;

    public static List<List<char>> exCharMap = new List<List<char>>
    {
        new List<char> { '*','P','P','P','*' },
        new List<char> { '*','#','#','#','*' },
        new List<char> { '*','#','#','#','*' },
        new List<char> { '*','#','#','#','*' },
        new List<char> { '*','#','#','#','*' },
        new List<char> { '*','*','*','*','*' },
    };


    // Use this for initialization
    void Start ()
    {
        loadCharSerializableObjects();


        Room r = spawnRoom(exCharMap, new Vector2());
        setActiveRoom(r);
	}

    void setActiveRoom(Room r)
    {
        activeRoom_ = r;
    }

    Room spawnRoom(List<List<char>> charRoomMap, Vector2 origin)
    {
        var newRoom = new Room();
        float offSet = 1;
        Vector2 spawnPosition = new Vector2(origin.x, origin.y);

        // newRoom gameObject array needs to be same size as the char map definition it is created from
        foreach (var cl in charRoomMap)
        {
            var row = new List<GameObject>();
            newRoom.associatedGameObjects.Add(row);
            foreach (var c in cl )
            {
                row.Add(null);
            }
        }

        // weird ordering is to allow us to match Unity coordinates though we create top down
        for (var i = charRoomMap.Count - 1; i >= 0; i--)
        {
            for (var j = 0; j < charRoomMap[i].Count; j++)
            {
                char c = charRoomMap[i][j];
                if (!charToUnityObject_.ContainsKey(c))
                {
                    throw new System.Exception("Missing character serialization key: " + c);
                }

                GameObject instantiatedObq = (GameObject)Instantiate(charToUnityObject_[c], spawnPosition, Quaternion.identity);
                newRoom.associatedGameObjects[i][j] = instantiatedObq;

                spawnPosition.x += offSet;
            }
            spawnPosition.x = origin.x;
            spawnPosition.y += offSet;
        }

        return newRoom;
    }

    void loadCharSerializableObjects()
    {
        var prefabs = Resources.LoadAll(prefabPath).Cast<GameObject>();

        foreach( var p in prefabs)
        {
            var cs = p.GetComponent<CharSerialization>();
            charToUnityObject_[cs.value] = p;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            print("tnoeuh");
        }

    }
}
