﻿namespace Net.Component
{
    /// <summary>
    /// 网络操作指令 (系统命令使用0-100, 基础网络组件使用100-150) 请从150开始自定义命令
    /// </summary>
    public class Command : Share.NetCmd
    {
        /// <summary>
        /// 客户端输入操作指令
        /// </summary>
        public const byte Input = 100;
        /// <summary>
        /// 玩家运动命令
        /// </summary>
        public const byte Movement = 101;
        /// <summary>
        /// 创建玩家命令
        /// </summary>
        public const byte CreatePlayer = 102;
        /// <summary>
        /// 玩家攻击命令
        /// </summary>
        public const byte Attack = 103;
        /// <summary>
        /// 同步生命值
        /// </summary>
        public const byte SyncHealth = 104;
        /// <summary>
        /// 玩家攻击到敌人
        /// </summary>
        public const byte Damage = 105;
        /// <summary>
        /// 敌人怪物AI同步指令
        /// </summary>
        public const byte EnemySync = 106;
        /// <summary>
        /// 玩家切换状态
        /// </summary>
        public const byte SwitchState = 107;
        /// <summary>
        /// 怪物切换状态
        /// </summary>
        public const byte EnemySwitchState = 108;
        /// <summary>
        /// Transform同步指令
        /// <code><see cref="Net.Share.Operation.identity"/> 作为网络物体标识</code>
        /// <code><see cref="Net.Share.Operation.index"/> 作为要实例化registerObjects的物体索引</code>
        /// <code><see cref="Net.Share.Operation.index1"/> 用作NetComponentID区分</code> 
        /// <code><see cref="Net.Share.Operation.index2"/> 作为父子转换组件索引</code>
        /// <code><see cref="Net.Share.Operation.cmd1"/> 作为SyncMode(同步模式)</code>
        /// <code><see cref="Net.Share.Operation.position"/> 作为位置同步</code>
        /// <code><see cref="Net.Share.Operation.rotation"/> 作为旋转同步</code>
        /// <code><see cref="Net.Share.Operation.direction"/> 作为缩放同步</code>
        /// </summary>
        public const byte Transform = 109;
        /// <summary>
        /// NetworkIdentity组件被销毁指令
        /// </summary>
        public const byte Destroy = 110;
        /// <summary>
        /// 当玩家进入场景后通知
        /// </summary>
        public const byte OnPlayerEnter = 113;
        /// <summary>
        /// 当客户端退出游戏, 通知其他客户端删除此客户端所生成的NetworkIdentity物体
        /// </summary>
        public const byte OnPlayerExit = 114;
        /// <summary>
        /// 网络行为组件命令，当你继承NetworkBehaviour组件实现你的网络组件时需要使用这个命令进行同步
        /// </summary>
        public const byte NetworkComponent = 115;
    }
}