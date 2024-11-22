using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 offset;        // Fare ile objenin týklama pozisyonu arasýndaki fark
    private float zCoord;         // Objeyi ekranda doðru þekilde hareket ettirmek için Z koordinatý
    private bool isPlaced = false; // Objenin yerleþtirilip yerleþtirilmediðini kontrol eder

    void OnMouseDown()
    {
        // Eðer obje yerleþtirilmiþse, sürüklenmesine izin verme
        if (isPlaced) return;

        // Objenin fareye göre pozisyonunu ayarlamak için Z koordinatýný kaydet
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // Fare pozisyonunu 3D dünyaya çevir
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord; // Objeyi doðru derinlikte tutmak için Z koordinatýný kullan
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        // Eðer obje yerleþtirilmiþse, hareket ettirme
        if (isPlaced) return;

        // Objeyi fare hareketine göre yeniden pozisyonlandýr
        transform.position = GetMouseWorldPos() + offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eðer obje PlacementArea'ya girmiþse ve henüz yerleþtirilmemiþse
        if (other.CompareTag("PlacementArea") && !isPlaced)
        {
            isPlaced = true; // Obje artýk yerleþtirildi
            transform.position = other.transform.position; // Objeyi PlacementArea'nýn pozisyonuna hizala
            Debug.Log("Objeyi yerleþtirdiniz!");
        }
    }
}

