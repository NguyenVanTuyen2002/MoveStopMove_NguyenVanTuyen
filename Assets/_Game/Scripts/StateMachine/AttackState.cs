using System.Collections;
using UnityEngine;

public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        // Gọi hàm tấn công khi vào trạng thái tấn công
        //t.AttackCharacterInRange();
    }

    public void OnExecute(Bot t)
    {
        // Kiểm tra xem target có phải là null không sau khi tấn công
        if (t.target != null)
        {
            // Nếu target không phải là null, tiếp tục tấn công
            t.AttackCharacterInRange();
        }
        else
        {
            // Nếu target là null, chuyển sang trạng thái tuần tra
            t.ChangeState(new IdleState());
        }
    }

    public void OnExit(Bot t)
    {
        // Dừng coroutine tấn công khi thoát khỏi trạng thái tấn công
        //t.StopAttackCoroutine();
    }
}
