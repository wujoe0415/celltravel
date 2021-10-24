using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Moving(Time.deltaTime);
    }    
    private void Moving(float dt)//get Input and moving
    {
        float verticalTranslation = Input.GetAxisRaw("Vertical") * movementSpeed * dt;
        float HorizontalTranslation = Input.GetAxisRaw("Horizontal") * movementSpeed * dt;
        transform.Translate(HorizontalTranslation, verticalTranslation, 0);
    }
}
