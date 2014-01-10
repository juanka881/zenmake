using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenMake.Helpers
{
	public class LispyNamer
	{
		private readonly StringBuilder sb;

		public LispyNamer()
		{
			this.sb = new StringBuilder();
		}

		private bool IsSeparatorNeeded(char current, char? last, int pos, string str)
		{
			if (!last.HasValue)
				return false;

			if (char.IsUpper(current) && char.IsLower(last.Value))
			{
				return true;
			}
			else
			{
				var nextpos = pos + 1;

				if (nextpos >= str.Length)
					return false;

				var next = str[nextpos];

				if (char.IsUpper(current) && char.IsLower(next))
					return true;
			}

			return false;
		}

		public string GetName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				return name ?? string.Empty;

			this.sb.Clear();

			var last = null as char?;

			var len = name.Length;

			for (int i = 0; i < len; i++)
			{
				var c = name[i];

				if (this.IsSeparatorNeeded(c, last, i, name))
					sb.Append('-');

				sb.Append(char.ToLower(c));

				last = c;
			}

			return sb.ToString();
		}
	}
}