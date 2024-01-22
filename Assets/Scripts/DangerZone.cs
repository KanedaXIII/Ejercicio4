using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DangerZone : MonoBehaviour
{
    [SerializeField]
    private Light2D _Light2d;
    // Start is called before the first frame update
    void Start()
    {
        _Light2d = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchLight()
    {
        if (_Light2d != null)
        {
            _Light2d.color = Color.white;
        }
        else
        {

        }
    }
    public IEnumerator ChangeZone()
    {
        Debug.Log("");
        yield return new WaitForSeconds(2f);
    }
}
