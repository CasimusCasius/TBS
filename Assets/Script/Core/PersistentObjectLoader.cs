using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Core
{

    public class PersistentObject : MonoBehaviour
    {
        [SerializeField] Transform persistentObjectPrefab;
        private static GameObject instance;

        private void Awake()
        {
            if (instance == null)
            {
                Instantiate(persistentObjectPrefab);
                DontDestroyOnLoad(instance);
            }

        }



    } 
}
