using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public bool isInverted;
    public Transform playerTrans;
    public float rotationSpeed = 100f;
    float mousex;
    float mousey;
    Quaternion camAngle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
        {
            isInverted = true;
        }
        else
        {
            isInverted = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mousex += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        mousey += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime * (isInverted ? -1 : 1);

        Vector3 direct = new Vector3(0, 1f, -4f);

        mousey = Mathf.Clamp(mousey, -20f, 20f);
        camAngle = Quaternion.Euler(mousey, mousex, 0);
        transform.position = playerTrans.position + camAngle *direct;
        transform.LookAt(playerTrans);
    }
}
