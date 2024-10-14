﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    public class MPInt32Cast : MPOperator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MPInt32Cast()
            : base("(int)", PrecedenceUnary, false)
        {
        }

        /// <summary>
        /// Find byte cast
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="previousToken"></param>
        /// <returns></returns>
        public override int Match(string expression, object previousToken)
        {
            if (!IsUnary(previousToken))
                return -1;
            Match m = Regex.Match(expression, @"^\((int|Int32)\)");
            if (m.Success)
                return m.Length;
            return -1;
        }

        /// <summary>
        /// Execute byte cast
        /// </summary>
        /// <param name="output"></param>
        public override void Execute(Stack<object> output)
        {
            // Pop object from the stack
            object top = PopOrGet(output);
            TypeCode tc = Type.GetTypeCode(top.GetType());

            switch (tc)
            {
                case TypeCode.Byte: output.Push((int)(Byte)top); return;
                case TypeCode.Char: output.Push((int)(Char)top); return;
                case TypeCode.Decimal: output.Push((int)(Decimal)top); return;
                case TypeCode.Double: output.Push((int)(Double)top); return;
                case TypeCode.Int16: output.Push((int)(Int16)top); return;
                case TypeCode.Int32: output.Push((int)(Int32)top); return;
                case TypeCode.Int64: output.Push((int)(Int64)top); return;
                case TypeCode.SByte: output.Push((int)(SByte)top); return;
                case TypeCode.Single: output.Push((int)(Single)top); return;
                case TypeCode.UInt16: output.Push((int)(UInt16)top); return;
                case TypeCode.UInt32: output.Push((int)(UInt32)top); return;
                case TypeCode.UInt64: output.Push((int)(UInt64)top); return;
            }

            // Invalid operation
            throw new InvalidOperatorTypesException("(Int32)", top);
        }
    }
}
