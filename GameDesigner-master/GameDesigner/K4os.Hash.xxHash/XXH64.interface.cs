﻿// ReSharper disable InconsistentNaming

using System;
using System.Runtime.CompilerServices;
using HashT = System.UInt64;

namespace K4os.Hash.xxHash 
{
    /// <summary>
    /// xxHash 64-bit.
    /// </summary>
    public partial class XXH64
    {
        /// <summary>Hash of empty buffer.</summary>
        public const ulong EmptyHash = 17241709254077376921;

        /// <summary>Hash of provided buffer.</summary>
        /// <param name="bytes">Buffer.</param>
        /// <param name="length">Length of buffer.</param>
        /// <returns>Digest.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe HashT DigestOf(void* bytes, int length) =>
            DigestOf(bytes, length, 0);

        /// <summary>Hash of provided buffer.</summary>
        /// <param name="bytes">Buffer.</param>
        /// <param name="length">Length of buffer.</param>
        /// <param name="seed">Seed.</param>
        /// <returns>Digest.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe HashT DigestOf(void* bytes, int length, HashT seed) =>
            XXH64_hash(bytes, length, seed);

        private State _state;

        /// <summary>Creates xxHash instance.</summary>
        public XXH64() => Reset();

        /// <summary>Creates xxHash instance.</summary>
        public XXH64(HashT seed) => Reset(seed);

        /// <summary>Resets hash calculation.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset() => Reset(ref _state);

        /// <summary>Resets hash calculation.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(HashT seed) => Reset(ref _state, seed);

        /// <summary>Updates the hash using given buffer.</summary>
        /// <param name="bytes">Buffer.</param>
        /// <param name="length">Length of buffer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Update(void* bytes, int length) =>
            Update(ref _state, (byte*)bytes, length);

        /// <summary>Updates the hash using given buffer.</summary>
        /// <param name="bytes">Buffer.</param>
        /// <param name="length">Length of buffer.</param>
        [Obsolete("Use void* overload, this one will be removed in next version.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void Update(byte* bytes, int length) =>
            Update(ref _state, bytes, length);

        /// <summary>Hash so far.</summary>
        /// <returns>Hash so far.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HashT Digest() => Digest(_state);

        /// <summary>Hash so far, as byte array.</summary>
        /// <returns>Hash so far.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] DigestBytes() => BitConverter.GetBytes(Digest());

        /// <summary>Resets hash calculation.</summary>
        /// <param name="state">Hash state.</param>
        /// <param name="seed">Hash seed.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Reset(ref State state, HashT seed = 0)
        {
            fixed (State* stateP = &state)
                XXH64_reset(stateP, seed);
        }

        /// <summary>Updates the has using given buffer.</summary>
        /// <param name="state">Hash state.</param>
        /// <param name="bytes">Buffer.</param>
        /// <param name="length">Length of buffer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Update(ref State state, void* bytes, int length)
        {
            fixed (State* stateP = &state)
                XXH64_update(stateP, bytes, length);
        }

        /// <summary>Hash so far.</summary>
        /// <returns>Hash so far.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe HashT Digest(in State state)
        {
            fixed (State* stateP = &state)
                return XXH64_digest(stateP);
        }
    }
}