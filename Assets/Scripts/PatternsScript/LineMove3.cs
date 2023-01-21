using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove3 : LineMoveBase
{
    protected override Vector2 EnemyInitialPos_Value(int ranNum2, string who, int x, int y)
    {
        Vector2 intialPos = new Vector2();
        if (who == "x")
        {
            if (ranNum2 == 0) intialPos = new Vector2(x, 0);
            else if (ranNum2 == 1) intialPos = new Vector2(x, 0);
            else if (ranNum2 == 2) intialPos = new Vector2(x, 0);
            else if (ranNum2 == 3) intialPos = new Vector2(x, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
            if (ranNum2 == 0) intialPos = new Vector2(0, y);
            else if (ranNum2 == 1) intialPos = new Vector2(0, y);
            else if (ranNum2 == 2) intialPos = new Vector2(0, y);
            else if (ranNum2 == 3) intialPos = new Vector2(0, y);
        }
        return intialPos;
    }
    WaitForFixedUpdate times = new WaitForFixedUpdate();
    protected override IEnumerator CO_EnemyLineMove()
    {
        while (true)
        {
            if (axis == MoveDir.xRight) gameObject.transform.Translate(Vector2.right  * moveSpeed);
            else if (axis == MoveDir.xLeft) gameObject.transform.Translate(Vector2.left * moveSpeed);
            else if (axis == MoveDir.yUP) gameObject.transform.Translate(Vector2.right  * moveSpeed);
            else if (axis == MoveDir.yDown) gameObject.transform.Translate(Vector2.left  * moveSpeed);
            yield return new WaitForSeconds(0.01f);

            if (gameObject.transform.position.x > 11 || gameObject.transform.position.x < -11 || gameObject.transform.position.y > 11 || gameObject.transform.position.y < -11)
                break;
        }
        gameObject.SetActive(false);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
