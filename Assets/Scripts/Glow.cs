using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Glow : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume postProcessVolume;
    private float actualValue = 10f;
    private float actualSize = 0.1f;

    

    void Update()
    {
        ChangeBloomIntensitySettings();
    }

    public void ChangeBloomIntensitySettings()
    {
        GameObject gameObject = GameObject.Find("empty");
        GameObject bullet = GameObject.Find("Capsule");
        postProcessVolume = gameObject.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out Bloom bloom);
        actualValue -= 0.1f;
        actualSize -= 0.0009f;
        if(bullet != null)
        {
            bullet.transform.localScale = new Vector3(actualSize, actualSize, actualSize);
        }
        bloom.intensity.value = actualValue;
        if (actualValue <= 0.5f)
        {
            Destroy(bullet);
        }
    }

    public void increaseLight()
    {
        GameObject bullet = GameObject.Find("Capsule");
        GameObject light = GameObject.Find("Point Light");
        Light lightComp = light.GetComponent<Light>();
        lightComp.range += 1;
        lightComp.intensity += 1;
        if(bullet  == null)
        {
            lightComp.range = 0;
            lightComp.intensity = 0;
        }
    }
}
