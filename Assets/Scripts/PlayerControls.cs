using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;


    float xThrow, yThrow;

    void Start()
     {

     }

    // Update is called once per frame
    void Update()
    {
        processTranslation();
        processRotation();
    }

    void processTranslation()
    {
       xThrow = Input.GetAxis("Horizontal");
       yThrow = Input.GetAxis("Vertical");

      float xOffset = xThrow * Time.deltaTime * controlSpeed;
      float rawXpos = transform.localPosition.x + xOffset;
      float clampedXpos = Mathf.Clamp(rawXpos, -xRange,xRange);

      float yOffset = yThrow * Time.deltaTime * controlSpeed;
      float rawYpos = transform.localPosition.y + yOffset;
      float clampedYpos = Mathf.Clamp(rawYpos, (-yRange +5f),yRange);

      transform.localPosition = new Vector3 (clampedXpos,clampedYpos,transform.localPosition.z);
    }

    void processRotation()
    {

      float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
      float pitchDueToControlThrow = yThrow * controlPitchFactor;

      float pitch =  pitchDueToPosition + pitchDueToControlThrow;
      float yaw = 0f;
      float roll = 0f;

      transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
}
