using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain.ViewModel
{
    /// <summary>
    /// 返回基类
    /// </summary>
    public class ResponseBase<T>
    {
        /// <summary>
        /// 成功或失败
        /// </summary>
        public bool IsSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }
    }
}
