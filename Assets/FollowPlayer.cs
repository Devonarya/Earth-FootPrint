using UnityEngine;

public class FollowPlayerParallax : MonoBehaviour
{
    public Transform player;         // Transform player
    public float parallaxFactor = 0.2f; // Jangan diganti
    private Vector3 lastPlayerPos;   // Posisi player sebelumnya

    void Start()
    {
        // Simpan posisi awal player saat mulai
        lastPlayerPos = player.position;
    }

    void Update()
    {
        // Hitung perbedaan gerak player dari frame sebelumnya
        Vector3 deltaMovement = player.position - lastPlayerPos;

        // Geser background sesuai faktor parallax (hanya di X)
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, 0f, 0f);

        // Simpan posisi player sekarang untuk perhitungan frame berikutnya
        lastPlayerPos = player.position;
    }
}
