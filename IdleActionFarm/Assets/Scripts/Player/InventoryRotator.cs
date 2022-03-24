using UnityEngine;
using System.Collections;

public class InventoryRotator : MonoBehaviour
{

    [SerializeField] private Transform _inventory;
    private Coroutine _rotateCoroutine;

    private void Start()
    {

    }
    public void ChangeSpeed(float speed)
    {
        //if (speed > 0f && _rotateCoroutine == null)
        //{
        //    _rotateCoroutine = StartCoroutine(Rotate());
        //}
        //else if (speed < 0.1f)
        //{
        //    StopAllCoroutines();
        //    _rotateCoroutine = null;
        //}
    }

    private IEnumerator Rotate()
    {
        var waitForFixedUpdate = new WaitForSeconds(0.5f);
        print("StartCoroutine");
        while(true)
        {
            yield return RotateÑlockwise();
            yield return RotateOverclockwise();
        }

    }

    private IEnumerator RotateÑlockwise()
    {
        var waitForFixedUpdate = new WaitForSeconds(1f);

        _inventory.Rotate(new Vector3(0, 0, 20f));
        yield return waitForFixedUpdate;
    }

    private IEnumerator RotateOverclockwise()
    {
        var waitForFixedUpdate = new WaitForSeconds(1f);

        _inventory.Rotate(new Vector3(0, 0, -20f));
        yield return waitForFixedUpdate;
    }
}
