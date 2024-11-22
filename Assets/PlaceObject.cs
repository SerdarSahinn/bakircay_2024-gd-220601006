using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public ParticleSystem placeEffect; // Yerle�tirme efekti

    void Start()
    {
        // Particle System ba�lang��ta durdurulmal�
        placeEffect.Stop();
    }

    public void PlaceObjectEffect()
    {
        // Efekti objenin pozisyonuna hizala ve oynat
        placeEffect.transform.position = transform.position;
        placeEffect.Play();
    }
   

}