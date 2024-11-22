using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public ParticleSystem placeEffect; // Yerleþtirme efekti

    void Start()
    {
        // Particle System baþlangýçta durdurulmalý
        placeEffect.Stop();
    }

    public void PlaceObjectEffect()
    {
        // Efekti objenin pozisyonuna hizala ve oynat
        placeEffect.transform.position = transform.position;
        placeEffect.Play();
    }
   

}