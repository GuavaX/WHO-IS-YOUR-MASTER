using UnityEngine;

public class ShowNumber : MonoBehaviour
{
    public GameObject[] number;
    private GameObject objNumber;

    private void Start()
    {
        objNumber = GameObject.Find("數字3D");
    }



}
