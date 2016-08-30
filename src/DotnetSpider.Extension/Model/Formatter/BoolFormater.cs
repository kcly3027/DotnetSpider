﻿using System;
using System.Text.RegularExpressions;
using DotnetSpider.Core;

namespace DotnetSpider.Extension.Model.Formatter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class BoolFormatter : Formatter
	{
		public string Pattern { get; set; }
		public string True { get; set; } = "T";
		public string False { get; set; } = "F";

		protected override dynamic FormateValue(dynamic value)
		{
			return Regex.Matches(value, Pattern).Count > 0 ? True : False;
		}

		protected override void CheckArguments()
		{
			if (string.IsNullOrEmpty(Pattern) || string.IsNullOrWhiteSpace(Pattern))
			{
				throw new SpiderException("Pattern should not be null.");
			}
		}
	}
}
