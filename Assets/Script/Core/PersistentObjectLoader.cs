using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Core
{

    public class PersistentObject : MonoBehaviour
    {
        [SerializeField] GameObject persistentObjectPrefab;
        private static GameObject instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = Instantiate(persistentObjectPrefab);
                DontDestroyOnLoad(instance);
            }

        }



    } 
}
