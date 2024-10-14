﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MultiParse.Default
{
    /// <summary>
    /// A class able to parse (positive) integers
    /// </summary>
    public class MPUInt64 : MPDataType
    {
        /// <summary>
        /// Matches an integer at the start of an expression and removes it afterwards
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="previousToken"></param>
        /// <param name="converted"></param>
        /// <returns></returns>
        public override int Match(string expression, object previousToken, out object converted)
        {
            string sign = @"^";
            if (IsUnary(previousToken))
                sign = @"^\+?";

            // Match an integer
            Match m = Regex.Match(expression, @"^(?<value>" + sign + @"\d+)([uU][lL]|[lL][uU])?(?![\w\.])");
            if (m.Success)
            {
                try
                {
                    converted = UInt64.Parse(m.Groups["value"].Value);
                }
                catch (Exception)
                {
                    converted = null;
                    return -1;
                }
                return m.Length;
            }

            // Default
            converted = null;
            return -1;
        }
    }
}
