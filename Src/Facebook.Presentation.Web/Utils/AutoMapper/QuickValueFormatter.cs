using System;
using System.Collections.Generic;
using AutoMapper;

namespace Facebook.Presentation.Web.Utils.AutoMapper
{
    public class QuickValueFormatter<T> : ValueFormatter<T>
    {
        private readonly Func<T, string> _formatter;

        public QuickValueFormatter(Func<T, string> formatter)
        {
            _formatter = formatter;
        }

        protected override string FormatValueCore(T value)
        {
            return _formatter(value);
        }
    }
}