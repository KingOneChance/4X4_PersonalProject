using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Just Object Move On x or y Line
/// </summary>
public class LineMoveBase : MonoBehaviour
{
    [SerializeField] protected ObjectType type;
    [SerializeField] protected MoveDir axis;
    [SerializeField] protected float moveSpeed=0.01f;
    protected enum MoveDir
    {
        xRight,
        xLeft,
        yUP,
        yDown,
    }
    void Start()
    {
        type = ObjectType.PointBlock;
      //EnemyLineMove(); ==>이동 코루틴을 시작과 OnEnable 모두 실행시켜서 발생한 문제이다. 속도차이가 발생했었다.
    }
    private void OnEnable()
    {
        SelectMoveDIr();
        EnemyLineMove();
    }
    protected void SelectMoveDIr()
    {
        int ranNum = Random.Range(0, 4);
        if (ranNum == 0) axis = MoveDir.xRight;
        else if (ranNum == 1) axis = MoveDir.xLeft;
        else if (ranNum == 2) axis = MoveDir.yUP;
        else if (ranNum == 3) axis = MoveDir.yDown;
        EnemyInitialPos();
    }
    protected void EnemyInitialPos()
    {
        int ranNum2 = Random.Range(0, 4);
        Vector2 intialPos = new Vector2();
        if (axis == MoveDir.xRight) intialPos = EnemyInitialPos_Value(ranNum2, "x", -10, 0);
        else if (axis == MoveDir.xLeft) intialPos = EnemyInitialPos_Value(ranNum2, "x", 10, 0);
        else if (axis == MoveDir.yUP) intialPos = EnemyInitialPos_Value(ranNum2, "y", 0, -7);
        else if (axis == MoveDir.yDown) intialPos = EnemyInitialPos_Value(ranNum2, "y", 0, 7);
        gameObject.transform.position = intialPos;
    }
    protected virtual Vector2 EnemyInitialPos_Value(int ranNum2, string who, int x, int y)
    {
        Vector2 intialPos = new Vector2();
        if (who == "x")
        {
            if (ranNum2 == 0) intialPos = new Vector2(x, 1.5f);
            else if (ranNum2 == 1) intialPos = new Vector2(x, 0.5f);
            else if (ranNum2 == 2) intialPos = new Vector2(x, -0.5f);
            else if (ranNum2 == 3) intialPos = new Vector2(x, -1.5f);
        }
        else
        {
            if (ranNum2 == 0) intialPos = new Vector2(1.5f,y);
            else if (ranNum2 == 1) intialPos = new Vector2(0.5f,y);
            else if (ranNum2 == 2) intialPos = new Vector2(-0.5f,y);
            else if (ranNum2 == 3) intialPos = new Vector2(-1.5f,y);
        }
        return intialPos;
    }
    protected void EnemyLineMove()
    {
        StartCoroutine(CO_EnemyLineMove());
    }
    WaitForFixedUpdate time = new WaitForFixedUpdate();
    protected virtual IEnumerator CO_EnemyLineMove()
    {
        while (true)
        {
            if (axis == MoveDir.xRight) gameObject.transform.Translate(Vector2.right * moveSpeed);
            else if (axis == MoveDir.xLeft) gameObject.transform.Translate(Vector2.left  * moveSpeed);
            else if (axis == MoveDir.yUP) gameObject.transform.Translate(Vector2.up * moveSpeed);
            else if (axis == MoveDir.yDown) gameObject.transform.Translate(Vector2.down * moveSpeed);
            yield return new WaitForSeconds(0.01f);

            if (gameObject.transform.position.x > 11 || gameObject.transform.position.x < -11 || gameObject.transform.position.y > 11 || gameObject.transform.position.y < -11)
                break;
        }
        gameObject.SetActive(false);
    }
}
