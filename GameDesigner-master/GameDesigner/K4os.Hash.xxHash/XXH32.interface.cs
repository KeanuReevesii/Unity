﻿// ReSharper disable InconsistentNaming

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using HashT = System.UInt32;

namespace K4os.Hash.xxHash 
{

    /// <summary>
    /// xxHash 32-bit.
    /// </summary>
    public partial class XXH32
    {
        /// <summary>Hash of empty buffer.</summary>
        public const HashT EmptyHash = 46947589;

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
            XXH32_hash((byte*)bytes, length, seed);

        private State _state;

        /// <summary>Creates xxHash instance.</summary>
        public XXH32() => Reset();

        /// <summary>Creates xxHash instance.</summary>
        public XXH32(HashT seed) => Reset(seed);

        /// <summary>Resets hash calculation.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset() => Reset(ref _state);

        /// <summary>Resets hash calculation.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(HashT seed) => Reset(ref _state, seed);

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
                XXH32_reset(stateP, seed);
        }

        /// <summary>Updates the has using given buffer.</summary>
        /// <param name="state">Hash state.</param>
        /// <param name="bytes">Buffer.</param>
        /// <param name="length">Length of buffer.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Update(ref State state, void* bytes, int length)
        {
            fixed (State* stateP = &state)
                XXH32_update(stateP, bytes, length);
        }

        /// <summary>Hash so far.</summary>
        /// <returns>Hash so far.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe HashT Digest(in State state)
        {
            fixed (State* stateP = &state)
                return XXH32_digest(stateP);
        }
    }
}