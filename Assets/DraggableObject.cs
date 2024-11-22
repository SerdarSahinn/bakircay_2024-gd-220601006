using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;        // Fare ile objenin t�klama pozisyonu aras�ndaki fark
    private float zCoord;         // Objeyi ekranda do�ru �ekilde hareket ettirmek i�in Z koordinat�
    private bool isPlaced = false; // Objenin yerle�tirilip yerle�tirilmedi�ini kontrol eder

    void OnMouseDown()
    {
        // E�er obje yerle�tirilmi�se, s�r�klenmesine izin verme
        if (isPlaced) return;

        // Objenin fareye g�re pozisyonunu ayarlamak i�in Z koordinat�n� kaydet
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // Fare pozisyonunu 3D d�nyaya �evir
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord; // Objeyi do�ru derinlikte tutmak i�in Z koordinat�n� kullan
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        // E�er obje yerle�tirilmi�se, hareket ettirme
        if (isPlaced) return;

        // Objeyi fare hareketine g�re yeniden pozisyonland�r
        transform.position = GetMouseWorldPos() + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        // E�er obje PlacementArea'ya girmi�se ve hen�z yerle�tirilmemi�se
        if (other.CompareTag("PlacementArea") && !isPlaced)
        {
            isPlaced = true; // Obje art�k yerle�tirildi
            transform.position = other.transform.position; // Objeyi PlacementArea'n�n pozisyonuna hizala
            Debug.Log("Objeyi yerle�tirdiniz!");
        }
    }
}

