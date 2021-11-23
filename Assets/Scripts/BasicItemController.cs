using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//可以被破坏的东西
public class BasicItemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
