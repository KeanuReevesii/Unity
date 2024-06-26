﻿namespace Net.Share
{
    /// <summary>
    /// 帧同步列表
    /// </summary>
    public readonly struct OperationList //结构是在栈创建,是很快, 配合我们的极速序列化适配器后快的飞起
    {
        /// <summary>
        /// 帧索引
        /// </summary>
        public readonly uint frame;
        /// <summary>
        /// 帧操作列表
        /// </summary>
        public readonly Operation[] operations;

        /// <summary>
        /// 构造
        /// </summary>
        public OperationList(uint frame) : this()
        {
            this.frame = frame;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="opts"></param>
        public OperationList(Operation[] opts) : this()
        {
            operations = opts;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="opts"></param>
        public OperationList(uint frame, Operation[] opts)
        {
            this.frame = frame;
            operations = opts;
        }

        public override string ToString()
        {
            return $"frame:{frame} - opers:{operations}";
        }
    }
}
