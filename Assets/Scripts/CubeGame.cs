using UnityEngine;
using TMPro;

public class CubeGame : MonoBehaviour
{
    public Rigidbody cube1;
    public Rigidbody cube2;
    public Rigidbody cube3;
    public TextMeshProUGUI resultText;

    public void PickCube1() => DropAllExcept(cube1);
    public void PickCube2() => DropAllExcept(cube2);
    public void PickCube3() => DropAllExcept(cube3);

    private void DropAllExcept(Rigidbody safeCube)
    {
        Rigidbody[] cubes = { cube1, cube2, cube3 };
        foreach (Rigidbody rb in cubes)
        {
            if (rb != safeCube)
                rb.useGravity = true;
            else
                rb.useGravity = false;
        }

        resultText.text = "YOU LOSE";
    }
}
