using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   public GameObject cubePiecePrefab;
   AudioSource destroySound;
   public float explodeForce = 500f;
   
   [SerializeField] TextMeshProUGUI textScore;

    void Start()
    {
        destroySound = GetComponent<AudioSource>();
         textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ExplodeCube();
            AddScore();
        }
    }

    private void AddScore()
    {
        Progress.Instance.PlayerInfo.Score += 10;
        textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
        if (Progress.Instance.PlayerInfo.Score == 100)
        {
            SceneManager.LoadScene("WorkShop7");
        }
    }

    private void ExplodeCube()
    {
        Vector3 size = transform.localScale;
        int piecesPerUnit = 4;

        int xCount = Mathf.RoundToInt(size.x * piecesPerUnit);
        int yCount = Mathf.RoundToInt(size.y * piecesPerUnit);
        int zCount = Mathf.RoundToInt(size.z * piecesPerUnit);

        Vector3 pieceSize = new Vector3(size.x / xCount, size.y / yCount, size.z / zCount);

        AudioSource.PlayClipAtPoint(destroySound.clip, transform.position);

        for (int x = 0; x < xCount; x++)
        {
            for (int y = 0; y < yCount; y++)
            {
                for (int z = 0; z < zCount; z++)
                {
                    Vector3 offset = new Vector3(
                        (x + 0.5f) * pieceSize.x,
                        (y + 0.5f) * pieceSize.y,
                        (z + 0.5f) * pieceSize.z
                    );

                    Vector3 piecePosition = transform.position - size / 2f + offset;

                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    piece.transform.localScale = pieceSize;

                    Rigidbody rb = piece.GetComponent<Rigidbody>();
                    rb.AddExplosionForce(explodeForce, transform.position, 5f);
                }
            }
        }
        Destroy(gameObject);
    }
}
