using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public enum status
    {
        //枚举量（状态）
        SUCCESS, 主键存在错误, 外键不匹配错误
    }
    /// <summary>
    /// 这是显示返回错误信息枚举类
    /// </summary>
    public class State
    {
        // 实例变量
        public status value;
        public State(status value)
        {
            this.value = value;
        }
        public status GetState()
        {
            return value;
        }
        public void SetState(status value)
        {
            this.value = value;
        }
    }
}
